using System;
using System.Drawing;
using System.Windows.Forms;

namespace GazeToolBar
{
    public partial class Form1 : ShellLib.ApplicationDesktopToolbar
    {
        private Settings settings;
        private ContextMenu contextMenu;
        private MenuItem menuItemExit;
        private MenuItem menuItemStartOnOff;
        private Bitmap leftSingleClick;
        private Bitmap rightClick;
        private Bitmap settingIcon;
        private Bitmap doubleClick;

        public Form1()
        {
            leftSingleClick = new Bitmap(new Bitmap("Left-Click-icon.png"), ReletiveSize.btnSize);
            rightClick = new Bitmap(new Bitmap("Right-Click-icon.png"), ReletiveSize.btnSize);
            settingIcon = new Bitmap(new Bitmap("settings-icon.png"), ReletiveSize.btnSize);
            doubleClick = new Bitmap(new Bitmap("Double-Click-icon.png"), ReletiveSize.btnSize);
            //Change resolution to 800 * 600
            ChangeResolution.ChangeScreenResolution();            
            InitializeComponent();
            Size = ReletiveSize.formSize;
            AutoStart.OpenKey();
            contextMenu = new ContextMenu();
            menuItemExit = new MenuItem();
            menuItemStartOnOff = new MenuItem();
            initMenuItem();
            setBtnSize();
            connectBehaveMap();
            Edge = AppBarEdges.Right;
            AutoStart.IsAutoStart(settings, menuItemStartOnOff);
            btnSingleClick.Image = leftSingleClick;
            btnRightClick.Image = rightClick;
            btnSettings.Image = settingIcon;
            btnDoubleClick.Image = doubleClick;
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
            menuItemStartOnOff.Click += new EventHandler(menuItemStartOnOff_Click);
            contextMenu.MenuItems.Add(menuItemStartOnOff);
            contextMenu.MenuItems.Add(menuItemExit);
            ntficGaze.ContextMenu = contextMenu;
        }

        /// <summary>
        /// Set all the size of buttons, panel
        /// and location of the buttons, panel.
        /// This will make toolbar adjust itelf corespond to screen resolution
        /// </summary>
        private void setBtnSize()
        {
            btnSingleClick.Size = ReletiveSize.btnSize;
            btnDoubleClick.Size = ReletiveSize.btnSize;
            btnRightClick.Size = ReletiveSize.btnSize;
            btnSettings.Size = ReletiveSize.btnSize;
            btnSingleClick.Location = new Point(ReletiveSize.btnPositionX, ReletiveSize.btnPostionY(2));
            btnDoubleClick.Location = new Point(ReletiveSize.btnPositionX, ReletiveSize.btnPostionY(3));
            btnRightClick.Location = new Point(ReletiveSize.btnPositionX, ReletiveSize.btnPostionY(1));
            btnSettings.Location = new Point(ReletiveSize.btnPositionX, ReletiveSize.btnPostionY(4));
            panel.Location = new Point(panel.Location.X, ReletiveSize.panelPositionY);
            panel.Size = ReletiveSize.panelSize;
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItemStartOnOff_Click(object sender, EventArgs e)
        {
            AutoStart.setAutoStartOnOff(settings, menuItemStartOnOff);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settings = new Settings(this);
            settings.Show();
        }

        /// <summary>
        /// Change resolution back to its orignal resolution.
        /// This will solve the problem that desktop won't show the taskbar properly.
        /// </summary>
        private void Form1_Shown(object sender, System.EventArgs e)
        {
            ChangeResolution.ChangeResolutionBack();
        }

        public MenuItem MenuItemStartOnOff { get { return menuItemStartOnOff; } }

        public Settings Settings { get { return settings; }
            
        }
    }
}
