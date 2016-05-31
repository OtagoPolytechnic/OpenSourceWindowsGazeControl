using System;
using System.Windows.Forms;
using ShellLib;
using System.Drawing;

namespace GazeToolBar
{
    public partial class Settings : Form
    {
        private Form1 form1;
        private bool OnTheRight;

        public Settings(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            //This code make setting form full screen
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //End
            OnTheRight = true;
        }

        private void btnChangeSide_Click(object sender, EventArgs e)
        {
            if (OnTheRight)
            {
                changeSide("On left", ApplicationDesktopToolbar.AppBarEdges.Left, false);
            }
            else
            {
                changeSide("On Right", ApplicationDesktopToolbar.AppBarEdges.Right, true);
            }
        }

        private void changeSide(string text, ApplicationDesktopToolbar.AppBarEdges edge, bool flag)
        {
            lblIndicationLeftOrRight.Text = text;
            form1.Edge = edge;
            OnTheRight = flag;
        }

        private void btnAutoStart_Click(object sender, EventArgs e)
        {
            AutoStart.setAutoStartOnOff(form1.Settings, form1.MenuItemStartOnOff);
        }

        public Button BtnAutoStart
        {
            get
            {
                return btnAutoStart;
            }
        }

        public Button BtnChangeSide
        {
            get
            {
                return btnChangeSide;
            }
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            AutoStart.IsAutoStart(form1.Settings, form1.MenuItemStartOnOff);
        }

        private void tabControlMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControlMain.TabPages[e.Index];
            e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
        }
    }
}
