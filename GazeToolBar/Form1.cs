using System;
using System.Drawing;
using System.Windows.Forms;
using EyeXFramework;
using Tobii;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;


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
        public StateManager stateManager;

        List<Panel> highlightPannerList;

        public Form1()
        {
            
            InitializeComponent();
            contextMenu = new ContextMenu();
            menuItemExit = new MenuItem();
            menuItemStartOnOff = new MenuItem();
            initMenuItem();
            
            highlightPannerList = new List<Panel>();
            highlightPannerList.Add(pnlHiLteRightClick);
            highlightPannerList.Add(pnlHighLightSingleLeft);
            highlightPannerList.Add(pnlHighLightDoubleClick);
            highlightPannerList.Add(pnlHighLightDragAndDrop);
            highlightPannerList.Add(pnlHighLightScrol);
            highlightPannerList.Add(pnlHighLightKeyboard);
            highlightPannerList.Add(pnlHighLightSettings);
            setButtonPanelHight(highlightPannerList);

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
            contextMenu.MenuItems.Add(menuItemStartOnOff);
            contextMenu.MenuItems.Add(menuItemExit);
        }


        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        public MenuItem MenuItemStartOnOff { get { return menuItemStartOnOff; } }

        public Settings Settings { get { return settings; }
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Edge = AppBarEdges.Right;
            stateManager = new StateManager(this);
            timer2.Enabled = true;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settings = new Settings(this);
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
            // this will open the exe for optikey. is tried to both the location of optikeys exe and the binary file for GazeToolBar. so will likely break if file/folders are moved
            //will need some logic to decide if it needs to open or close optikey
            Process process = System.Diagnostics.Process.Start(Path.GetFullPath("../../../OptiKey/src/JuliusSweetland.OptiKey/bin/Debug/OptiKey.exe"));
            //MessageBox.Show(Environment.CurrentDirectory);

            //if optikey is already open
            //process.Kill();
        }

        private void btnScoll_Click(object sender, EventArgs e)
        {

            SystemFlags.actionButtonSelected = true;
            SystemFlags.actionToBePerformed = ActionToBePerformed.Scroll;

            /*This will have to be added to the action enum and the logic will have to someplace else, not sure where yet*/

            //detect fixation, drop middle click where user fixates.

            //move in to scroll mode.

            //drop out of scroll mode if user looks outside screen bounds.
            
            //fixationWorker.SetupSelectedFixationAction(VirtualMouse.MiddleMouseButton);
            //Add logic to scroll/pan with eyes after middle click
        }

        private void btnDragAndDrop_Click(object sender, EventArgs e)
        {
            //Create logic to run left mouse down, update xy then left mouse up to simulate drag and drop
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
    }
}
