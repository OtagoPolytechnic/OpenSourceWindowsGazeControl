using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using OptiKey.Enums;
using OptiKey.Extensions;
using OptiKey.Models;
using OptiKey.Observables.PointSources;
using OptiKey.Observables.TriggerSources;
using OptiKey.Properties;
using OptiKey.Services;
using OptiKey.Static;
using OptiKey.UI.ViewModels;
using OptiKey.UI.Windows;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Repository.Hierarchy;
using NBug.Core.UI;
using Octokit;
using Octokit.Reactive;
using Application = System.Windows.Application;
using FileMode = System.IO.FileMode;
using System.Drawing;
using System.Windows.Forms;
namespace OptiKey
{
    public class GazeKeyboard
    {
        private const string GazeTrackerUdpRegex = @"^STREAM_DATA\s(?<instanceTime>\d+)\s(?<x>-?\d+(\.[0-9]+)?)\s(?<y>-?\d+(\.[0-9]+)?)";
        int toolBarOffset;
        int taskBarOffset;

        //ctor
        public GazeKeyboard()
        {
            toolBarOffset = 135;
            taskBarOffset = 40;

            //Upgrade settings (if required) - this ensures that user settings migrate between version changes
            if (Settings.Default.SettingsUpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.SettingsUpgradeRequired = false;
                Settings.Default.Save();
                Settings.Default.Reload();
            }           

            //Apply resource language (and listen for changes)
            Action<Languages> applyResourceLanguage = language => Properties.Resources.Culture = language.ToCultureInfo();
            Settings.Default.OnPropertyChanges(s => s.UiLanguage).Subscribe(applyResourceLanguage);
            applyResourceLanguage(Settings.Default.UiLanguage);
        }

        public MainWindow CreateKeyboard()
        {
            ////Apply resource language (and listen for changes)
            Action<OptiKey.Enums.Languages> applyResourceLanguage = language => OptiKey.Properties.Resources.Culture = language.ToCultureInfo();
            Settings.Default.OnPropertyChanges(s => s.UiLanguage).Subscribe(applyResourceLanguage);
            applyResourceLanguage(Settings.Default.UiLanguage);

            MainWindow mainWindow; 

            //Define MainViewModel before services so I can setup a delegate to call into the MainViewModel
            //This is to work around the fact that the MainViewModel is created after the services.
            OptiKey.UI.ViewModels.MainViewModel mainViewModel = null;
            Action<KeyValue> fireKeySelectionEvent = kv =>
            {
                if (mainViewModel != null) //Access to modified closure is a good thing here, for once!
                {
                    mainViewModel.FireKeySelectionEvent(kv);
                }
            };

            //Create services
            var errorNotifyingServices = new List<INotifyErrors>();
            IAudioService audioService = new AudioService();
            IDictionaryService dictionaryService = new DictionaryService(OptiKey.Enums.AutoCompleteMethods.NGram);
            IPublishService publishService = new PublishService();
            ISuggestionStateService suggestionService = new SuggestionStateService();
            ICalibrationService calibrationService = OptiKey.App.CreateCalibrationService();
            ICapturingStateManager capturingStateManager = new CapturingStateManager(audioService);
            ILastMouseActionStateManager lastMouseActionStateManager = new LastMouseActionStateManager();
            IKeyStateService keyStateService = new KeyStateService(suggestionService, capturingStateManager, lastMouseActionStateManager, calibrationService, fireKeySelectionEvent);
            IInputService inputService = CreateInputService(keyStateService, dictionaryService, audioService, calibrationService, capturingStateManager, errorNotifyingServices);
            IKeyboardOutputService keyboardOutputService = new KeyboardOutputService(keyStateService, suggestionService, publishService, dictionaryService, fireKeySelectionEvent);
            IMouseOutputService mouseOutputService = new MouseOutputService(publishService);
            errorNotifyingServices.Add(audioService);
            errorNotifyingServices.Add(dictionaryService);
            errorNotifyingServices.Add(publishService);
            errorNotifyingServices.Add(inputService);

            //Release keys on application exit
            //ReleaseKeysOnApplicationExit(keyStateService, publishService);

            //Compose UI
            mainWindow = new MainWindow(audioService, dictionaryService, inputService, keyStateService);

            //for testing just hard code the size and position of the mainWindow    

            ////get the size of the screen
            Rectangle screenSize = Screen.PrimaryScreen.Bounds;
            double windowWidth = screenSize.Width - toolBarOffset;
            double windowHeight = screenSize.Height * 0.40;

            Rect windowDimensions = new Rect(0,  (screenSize.Height - windowHeight) - taskBarOffset, windowWidth, windowHeight);

            //Settings.Default.MainWindowFloatingSizeAndPosition = windowDimensions;

            IWindowManipulationService mainWindowManipulationService = new WindowManipulationService(
                    mainWindow,
                    () => Settings.Default.MainWindowOpacity,
                    () => Settings.Default.MainWindowState,
                    () => Settings.Default.MainWindowPreviousState,
                    //() => Settings.Default.MainWindowFloatingSizeAndPosition,    
                    () => windowDimensions,
                    () => Settings.Default.MainWindowDockPosition,
                    () => Settings.Default.MainWindowDockSize,
                    () => Settings.Default.MainWindowFullDockThicknessAsPercentageOfScreen,
                    () => Settings.Default.MainWindowCollapsedDockThicknessAsPercentageOfFullDockThickness,
                    () => Settings.Default.MainWindowMinimisedPosition,
                    o => Settings.Default.MainWindowOpacity = o,
                    state => Settings.Default.MainWindowState = state,
                    state => Settings.Default.MainWindowPreviousState = state,
                    rect => Settings.Default.MainWindowFloatingSizeAndPosition = rect,
                    pos => Settings.Default.MainWindowDockPosition = pos,
                    size => Settings.Default.MainWindowDockSize = size,
                    t => Settings.Default.MainWindowFullDockThicknessAsPercentageOfScreen = t,
                    t => Settings.Default.MainWindowCollapsedDockThicknessAsPercentageOfFullDockThickness = t);
            errorNotifyingServices.Add(mainWindowManipulationService);
            mainWindow.WindowManipulationService = mainWindowManipulationService;            

            mainViewModel = new MainViewModel(
                audioService, calibrationService, dictionaryService, keyStateService,
                suggestionService, capturingStateManager, lastMouseActionStateManager,
                inputService, keyboardOutputService, mouseOutputService, mainWindowManipulationService, errorNotifyingServices);

            mainWindow.MainView.DataContext = mainViewModel;

            //Setup actions to take once main view is loaded (i.e. the view is ready, so hook up the services which kicks everything off)
            Action postMainViewLoaded = mainViewModel.AttachServiceEventHandlers;
            if (mainWindow.MainView.IsLoaded)
            {
                postMainViewLoaded();
            }
            else
            {
                RoutedEventHandler loadedHandler = null;
                loadedHandler = (s, a) =>
                {
                    postMainViewLoaded();
                    mainWindow.MainView.Loaded -= loadedHandler; //Ensure this handler only triggers once
                };
                mainWindow.MainView.Loaded += loadedHandler;
            }

            //Show the main window
            ResourceDictionary resourses = new ResourceDictionary();
            mainWindow.Resources = resourses;
            ThemeResourceDictionary themeDictionary = new ThemeResourceDictionary();            
            resourses.MergedDictionaries.Add(themeDictionary);

            //setSize            

            //Display splash screen and check for updates (and display message) after the window has been sized and positioned for the 1st time
            EventHandler sizeAndPositionInitialised = null;
            sizeAndPositionInitialised = async (_, __) =>
            {
                mainWindowManipulationService.SizeAndPositionInitialised -= sizeAndPositionInitialised; //Ensure this handler only triggers once                    
                inputService.RequestResume(); //Start the input service                    
            };
            if (mainWindowManipulationService.SizeAndPositionIsInitialised)
            {
                sizeAndPositionInitialised(null, null);
            }
            else
            {
                mainWindowManipulationService.SizeAndPositionInitialised += sizeAndPositionInitialised;
            }

            
            mainWindow.Closed += (_, __) => ReleaseKeysOnApplicationExit(keyStateService, publishService);

            
            return mainWindow;
        }

        public static void ReleaseKeysOnApplicationExit(IKeyStateService keyStateService, IPublishService publishService)
        {
            
            if (keyStateService.SimulateKeyStrokes)
            {
                publishService.ReleaseAllDownKeys();
            }
            
        }

        private static void AttachUnhandledExceptionHandlers()
        {
            //Current.DispatcherUnhandledException += (sender, args) => Log.Error("A DispatcherUnhandledException has been encountered...", args.Exception);
            //AppDomain.CurrentDomain.UnhandledException += (sender, args) => Log.Error("An UnhandledException has been encountered...", args.ExceptionObject as Exception);
            //TaskScheduler.UnobservedTaskException += (sender, args) => Log.Error("An UnobservedTaskException has been encountered...", args.Exception);

#if !DEBUG
            Application.Current.DispatcherUnhandledException += NBug.Handler.DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += NBug.Handler.UnhandledException;
            TaskScheduler.UnobservedTaskException += NBug.Handler.UnobservedTaskException;

            NBug.Settings.ProcessingException += (exception, report) =>
            {
                //Add latest log file contents as custom info in the error report
                var rootAppender = ((Hierarchy)LogManager.GetRepository())
                    .Root.Appenders.OfType<FileAppender>()
                    .FirstOrDefault();

                if (rootAppender != null)
                {
                    using (var fs = new FileStream(rootAppender.File, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (var sr = new StreamReader(fs, Encoding.Default))
                        {
                            var logFileText = sr.ReadToEnd();
                            report.CustomInfo = logFileText;
                        }
                    }
                }
            };

            NBug.Settings.CustomUIEvent += (sender, args) =>
            {
                var crashWindow = new CrashWindow
                {
                    Topmost = true,
                    ShowActivated = true
                };
                crashWindow.ShowDialog();

                //The crash report has not been created yet - the UIDialogResult SendReport param determines what happens next
                args.Result = new UIDialogResult(ExecutionFlow.BreakExecution, SendReport.Send);
            };

            NBug.Settings.InternalLogWritten += (logMessage, category) => Log.DebugFormat("NBUG:{0} - {1}", category, logMessage);
#endif
        }        

        private static void HandleCorruptSettings()
        {
            try
            {
                //Attempting to read a setting from a corrupt user config file throws an exception
                var upgradeRequired = Settings.Default.SettingsUpgradeRequired;
            }
            catch (ConfigurationErrorsException cee)
            {
                //Log.Warn("User settings file is corrupt and needs to be corrected. Alerting user and shutting down.");
                string filename = ((ConfigurationErrorsException)cee.InnerException).Filename;

                if (System.Windows.MessageBox.Show(
                        OptiKey.Properties.Resources.CORRUPTED_SETTINGS_MESSAGE,
                        OptiKey.Properties.Resources.CORRUPTED_SETTINGS_TITLE,
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Error) == MessageBoxResult.Yes)
                {
                    File.Delete(filename);
                    try
                    {
                        System.Windows.Forms.Application.Restart();
                    }
                    catch {} //Swallow any exceptions (e.g. DispatcherExceptions) - we're shutting down so it doesn't matter.
                }
                //Current.Shutdown(); //Avoid the inevitable crash by shutting down gracefully
            }
        }        

        public static ICalibrationService CreateCalibrationService()
        {
            switch (Settings.Default.PointsSource)
            {
                case PointsSources.TheEyeTribe:
                    return new TheEyeTribeCalibrationService();

                case PointsSources.TobiiEyeX:
                case PointsSources.TobiiRex:
                case PointsSources.TobiiPcEyeGo:
                    return new TobiiEyeXCalibrationService();
            }

            return null;
        }

        public static IInputService CreateInputService(
            IKeyStateService keyStateService,
            IDictionaryService dictionaryService,
            IAudioService audioService,
            ICalibrationService calibrationService,
            ICapturingStateManager capturingStateManager,
            List<INotifyErrors> errorNotifyingServices)
        {
            //Log.Info("Creating InputService.");

            //Instantiate point source
            IPointSource pointSource;
            switch (Settings.Default.PointsSource)
            {
                case PointsSources.GazeTracker:
                    pointSource = new GazeTrackerSource(
                        Settings.Default.PointTtl,
                        Settings.Default.GazeTrackerUdpPort,
                        new Regex(GazeTrackerUdpRegex));
                    break;

                case PointsSources.TheEyeTribe:
                    var theEyeTribePointService = new TheEyeTribePointService();
                    errorNotifyingServices.Add(theEyeTribePointService);
                    pointSource = new PointServiceSource(
                        Settings.Default.PointTtl,
                        theEyeTribePointService);
                    break;

                case PointsSources.TobiiEyeX:
                case PointsSources.TobiiRex:
                case PointsSources.TobiiPcEyeGo:
                    var tobiiEyeXPointService = new TobiiEyeXPointService();
                    var tobiiEyeXCalibrationService = calibrationService as TobiiEyeXCalibrationService;
                    if (tobiiEyeXCalibrationService != null)
                    {
                        tobiiEyeXCalibrationService.EyeXHost = tobiiEyeXPointService.EyeXHost;
                    }
                    errorNotifyingServices.Add(tobiiEyeXPointService);
                    pointSource = new PointServiceSource(
                        Settings.Default.PointTtl,
                        tobiiEyeXPointService);
                    break;

                case PointsSources.MousePosition:
                    pointSource = new MousePositionSource(
                        Settings.Default.PointTtl);
                    break;

                default:
                    throw new ArgumentException("'PointsSource' settings is missing or not recognised! Please correct and restart OptiKey.");
            }

            //Instantiate key trigger source
            ITriggerSource keySelectionTriggerSource;
            switch (Settings.Default.KeySelectionTriggerSource)
            {
                case TriggerSources.Fixations:
                    keySelectionTriggerSource = new KeyFixationSource(
                       Settings.Default.KeySelectionTriggerFixationLockOnTime,
                       Settings.Default.KeySelectionTriggerFixationResumeRequiresLockOn,
                       Settings.Default.KeySelectionTriggerFixationDefaultCompleteTime,
                       Settings.Default.KeySelectionTriggerFixationCompleteTimesByIndividualKey
                        ? Settings.Default.KeySelectionTriggerFixationCompleteTimesByKeyValues
                        : null, 
                       Settings.Default.KeySelectionTriggerIncompleteFixationTtl,
                       pointSource.Sequence);
                    break;

                case TriggerSources.KeyboardKeyDownsUps:
                    keySelectionTriggerSource = new KeyboardKeyDownUpSource(
                        Settings.Default.KeySelectionTriggerKeyboardKeyDownUpKey,
                        pointSource.Sequence);
                    break;

                case TriggerSources.MouseButtonDownUps:
                    keySelectionTriggerSource = new MouseButtonDownUpSource(
                        Settings.Default.KeySelectionTriggerMouseDownUpButton,
                        pointSource.Sequence);
                    break;

                default:
                    throw new ArgumentException(
                        "'KeySelectionTriggerSource' setting is missing or not recognised! Please correct and restart OptiKey.");
            }

            //Instantiate point trigger source
            ITriggerSource pointSelectionTriggerSource;
            switch (Settings.Default.PointSelectionTriggerSource)
            {
                case TriggerSources.Fixations:
                    pointSelectionTriggerSource = new PointFixationSource(
                        Settings.Default.PointSelectionTriggerFixationLockOnTime,
                        Settings.Default.PointSelectionTriggerFixationCompleteTime,
                        Settings.Default.PointSelectionTriggerLockOnRadiusInPixels,
                        Settings.Default.PointSelectionTriggerFixationRadiusInPixels,
                        pointSource.Sequence);
                    break;

                case TriggerSources.KeyboardKeyDownsUps:
                    pointSelectionTriggerSource = new KeyboardKeyDownUpSource(
                        Settings.Default.PointSelectionTriggerKeyboardKeyDownUpKey,
                        pointSource.Sequence);
                    break;

                case TriggerSources.MouseButtonDownUps:
                    pointSelectionTriggerSource = new MouseButtonDownUpSource(
                        Settings.Default.PointSelectionTriggerMouseDownUpButton,
                        pointSource.Sequence);
                    break;

                default:
                    throw new ArgumentException(
                        "'PointSelectionTriggerSource' setting is missing or not recognised! "
                        + "Please correct and restart OptiKey.");
            }

            var inputService = new InputService(keyStateService, dictionaryService, audioService, capturingStateManager,
                pointSource, keySelectionTriggerSource, pointSelectionTriggerSource);
            inputService.RequestSuspend(); //Pause it initially
            return inputService;
        }
    }    
}
