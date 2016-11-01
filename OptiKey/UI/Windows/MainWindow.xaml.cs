using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using OptiKey.Enums;
using OptiKey.Extensions;
using OptiKey.Models;
using OptiKey.Services;
using OptiKey.Static;
using log4net;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace OptiKey.UI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IAudioService audioService;
        private readonly IDictionaryService dictionaryService;
        private readonly IInputService inputService;
        private readonly IKeyStateService keyStateService;
        private readonly InteractionRequest<NotificationWithServicesAndState> managementWindowRequest;
        private readonly ICommand managementWindowRequestCommand;
        private readonly ICommand quitCommand;

        public MainWindow(
            IAudioService audioService,
            IDictionaryService dictionaryService,
            IInputService inputService,
            IKeyStateService keyStateService)
        {
            InitializeComponent();

            this.audioService = audioService;
            this.dictionaryService = dictionaryService;
            this.inputService = inputService;
            this.keyStateService = keyStateService;

            managementWindowRequest = new InteractionRequest<NotificationWithServicesAndState>();
            managementWindowRequestCommand = new DelegateCommand(RequestManagementWindow);
            quitCommand = new DelegateCommand(Quit);

            //Setup key binding (Alt-M and Shift-Alt-M) to open settings
            InputBindings.Add(new KeyBinding
            {
                Command = managementWindowRequestCommand,
                Modifiers = ModifierKeys.Alt,
                Key = Key.M
            });
            InputBindings.Add(new KeyBinding
            {
                Command = managementWindowRequestCommand,
                Modifiers = ModifierKeys.Shift | ModifierKeys.Alt,
                Key = Key.M
            });

            Title = string.Format(Properties.Resources.WINDOW_TITLE, DiagnosticInfo.AssemblyVersion);
        }

        public IWindowManipulationService WindowManipulationService { get; set; }

        public InteractionRequest<NotificationWithServicesAndState> ManagementWindowRequest { get { return managementWindowRequest; } }
        public ICommand ManagementWindowRequestCommand { get { return managementWindowRequestCommand; } }
        public ICommand QuitCommand { get { return quitCommand; } }

        public void InputPause()
        {
            inputService.RequestSuspend();
        }

        public void InputResume()
        {
            inputService.RequestResume();
        }

        private void RequestManagementWindow()
        {
            var modalManagementWindow = WindowManipulationService != null &&
                                        WindowManipulationService.WindowState == WindowStates.Maximised;

            if (modalManagementWindow)
            {
                inputService.RequestSuspend();
            }
            var restoreModifierStates = keyStateService.ReleaseModifiers(Log);
            ManagementWindowRequest.Raise(
                new NotificationWithServicesAndState
                {
                    ModalWindow = modalManagementWindow,
                    AudioService = audioService,
                    DictionaryService = dictionaryService
                },
                _ =>
                {
                    if (modalManagementWindow)
                    {
                        inputService.RequestResume();
                    }
                    restoreModifierStates();
                });
        }

        private void Quit()
        {           
            //Application.Current.Shutdown();
        }

        private void OnContextMenuOpened(object sender, RoutedEventArgs e)
        {
            inputService.RequestSuspend();
        }

        private void OnContextMenuClosed(object sender, RoutedEventArgs e)
        {
            inputService.RequestResume();
        }
    }
}
