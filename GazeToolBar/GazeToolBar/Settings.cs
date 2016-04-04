using System;
using System.Windows.Forms;
using ShellLib;

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
            OnTheRight = true;
        }

        private void btnChangeSide_Click(object sender, EventArgs e)
        {
            if (OnTheRight)
            {
                changeSide("To Right", ApplicationDesktopToolbar.AppBarEdges.Left, false);
            }
            else
            {
                changeSide("To Left", ApplicationDesktopToolbar.AppBarEdges.Right, true);
            }
        }

        private void changeSide(string text, ApplicationDesktopToolbar.AppBarEdges edge, bool flag)
        {
            btnChangeSide.Text = text;
            form1.Edge = edge;
            OnTheRight = flag;
        }

        private void btnAutoStart_Click(object sender, EventArgs e)
        {
            form1.setAutoStartOnOff();
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
    }
}
