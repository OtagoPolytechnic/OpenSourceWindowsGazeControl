using System;
using System.Drawing;
using System.Windows.Forms;
using EyeXFramework;
using Tobii;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using EyeXFramework.Forms;
using OptiKey;
using OptiKey.UI.Windows;


namespace GazeToolBar
{
    /*
        Date: 17/05/2016
        Name: Derek Dai
        Description: Main toolbar form
    */
    public partial class Form1 : ShellLib.ApplicationDesktopToolbar
    {
        private Settings settings;
        private ContextMenu contextMenu;
        private MenuItem menuItemExit;
        private MenuItem menuItemStartOnOff;
        private MenuItem settingsItem;
        public StateManager stateManager; 
        private static FormsEyeXHost eyeXHost; 

        //Allocate memory location for KeyboardHook and worker.
        public KeyboardHook LowLevelKeyBoardHook;
        public ShortcutKeyWorker shortCutKeyWorker;

        OptiKey.GazeKeyboard keyboardInitializer;
        MainWindow keyboard;

        public Dictionary<ActionToBePerformed, String> FKeyMapDictionary;

        List<Panel> highlightPannerList;

        public Form1()
        {
            
            InitializeComponent();
            contextMenu = new ContextMenu();
            menuItemExit = new MenuItem();
            menuItemStartOnOff = new MenuItem();
            settingsItem = new MenuItem();
            initMenuItem();
            
            highlightPannerList = new List<Panel>();
            highlightPannerList.Add(pnlHiLteRightClick);
            highlightPannerList.Add(pnlHighLightSingleLeft);
            highlightPannerList.Add(pnlHighLightDoubleClick);
            //highlightPannerList.Add(pnlHighLightDragAndDrop);
            highlightPannerList.Add(pnlHighLightScrol);
            highlightPannerList.Add(pnlHighLightKeyboard);
            highlightPannerList.Add(pnlHighLightSettings);
            setButtonPanelHight(highlightPannerList);


            eyeXHost = new FormsEyeXHost();
            eyeXHost.Start();

            keyboardInitializer = new OptiKey.GazeKeyboard();
            keyboard = keyboardInitializer.CreateKeyboard();

            connectBehaveMap();
        }

        /// <summary>
        /// Setup the context menu for
        /// notify icon
        /// </summary>
        private void initMenuItem()
        {
            menuItemExit.Text = "Exit";
            menuItemStartOnOff.Text = ValueNeverChange.AUTO_START_OFF;
            menuItemExit.Click += new EventHandler(menuItemExit_Click);
            settingsItem.Text = "Setting";
           // settingsItem.Click += new EventHandler(settingItem_Click);
            contextMenu.MenuItems.Add(settingsItem);
            contextMenu.MenuItems.Add(menuItemStartOnOff);
            contextMenu.MenuItems.Add(menuItemExit);
            notifyIcon.ContextMenu = contextMenu;
            OnStartTextChange();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public MenuItem MenuItemStartOnOff { get { return menuItemStartOnOff; } }

        private void Form1_Load(object sender, EventArgs e)
        {


            FKeyMapDictionary = new Dictionary<ActionToBePerformed, string>();
            FKeyMapDictionary.Add(ActionToBePerformed.DoubleClick, "Key not assigned");
            FKeyMapDictionary.Add(ActionToBePerformed.LeftClick, "Key not assigned");
            FKeyMapDictionary.Add(ActionToBePerformed.Scroll, "Key not assigned");
            FKeyMapDictionary.Add(ActionToBePerformed.RightClick, "Key not assigned");


            //Instantiate keyboard hook and pass into worker class.
            LowLevelKeyBoardHook = new KeyboardHook();

            shortCutKeyWorker = new ShortcutKeyWorker(LowLevelKeyBoardHook, FKeyMapDictionary, eyeXHost);

            //Start monitoring key presses.
            LowLevelKeyBoardHook.HookKeyboard();

            if(Program.readSettings.position == "left")
            {
                Edge = AppBarEdges.Left;
            }
            else
            {
                Edge = AppBarEdges.Right;
            }
            stateManager = new StateManager(this, shortCutKeyWorker, eyeXHost);
            timer2.Enabled = true;

            
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settings = new Settings(this, eyeXHost);
            settings.Show();
        }

        private void btnRightClick_Click(object sender, EventArgs e)
        {
            SystemFlags.actionButtonSelected = true;//raise action button flag
            SystemFlags.actionToBePerformed = ActionToBePerformed.RightClick;
            
        }

        private void btnSingleLeftClick_Click(object sender, EventArgs e)
        {
            SystemFlags.actionButtonSelected = true;//raise action button flag
            SystemFlags.actionToBePerformed = ActionToBePerformed.LeftClick;
        }

        private void btnDoubleClick_Click(object sender, EventArgs e)
        {

            SystemFlags.actionButtonSelected = true;//raise action button flag
            SystemFlags.actionToBePerformed = ActionToBePerformed.DoubleClick;
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {

            //Console.WriteLine("optikey button");

            if (keyboard.IsVisible)
            {
                keyboard.Hide();
            }
            else
            {
                keyboard.Show();
            }                 
        }

        private void btnScoll_Click(object sender, EventArgs e)
        {

            SystemFlags.actionButtonSelected = true;
            SystemFlags.actionToBePerformed = ActionToBePerformed.Scroll;

        }

        //private void btnDragAndDrop_Click(object sender, EventArgs e)
        //{
        //    //Create logic to run left mouse down, update xy then left mouse up to simulate drag and drop
        //}

        public void OnStartTextChange()
        {
            if (Program.onStartUp)
            {
                menuItemStartOnOff.Text = ValueNeverChange.AUTO_START_ON;
            }
            else
            {
                menuItemStartOnOff.Text = ValueNeverChange.AUTO_START_OFF;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            stateManager.Run();
        }


        private void setButtonPanelHight(List<Panel> panelList)
        {
            int screenHeight = ValueNeverChange.SCREEN_SIZE.Height;
           
            int amountOfPanels = panelList.Count;
           
            int panelHight = panelList[0].Height;
            
            int screenSectionSize = screenHeight / amountOfPanels;
           
            int spacer = screenSectionSize - panelHight;
            
            int spacerBuffer = spacer / 2;

            foreach(Panel currentPanel in panelList)
            {
                Point panelLocation = new Point(currentPanel.Location.X, spacerBuffer);

                Console.WriteLine(screenHeight);
                Console.WriteLine(panelLocation.Y);

                currentPanel.Location = panelLocation;

                spacerBuffer += screenSectionSize;
            }
        }
        public System.Windows.Forms.NotifyIcon NotifyIcon
        {
            get { return notifyIcon; }
            set { notifyIcon = value; }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Remove KeyboardHook on closing form.
            LowLevelKeyBoardHook.UnHookKeyboard();
            eyeXHost.Dispose();
        }

    }
}
