using System;
using System.Windows.Forms;
using ShellLib;
using System.Drawing;
using Newtonsoft.Json;
using System.IO;

namespace GazeToolBar
{
    public partial class Settings : Form
    {
        private Form1 form1;
        private bool OnTheRight;
        private bool[] onOff;

        public enum GazeOrSwitch
        {
            GAZE,
            SWITCH
        }

        public enum Sizes
        {
            SMALL,
            LARGE
        }

        public Settings(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            //This code make setting form full screen
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //End
            OnTheRight = true;
            panelSaveAndCancel.Location = ReletiveSize.panelSaveAndCancel(panelSaveAndCancel.Width, panelSaveAndCancel.Height);
            tabControlMain.Size = ReletiveSize.TabControlSize;
            onOff = new bool[2];
            for (int i = 0; i < onOff.Length; i++)
            {
                onOff[i] = false;
            }
        }

        private void btnChangeSide_Click(object sender, EventArgs e)
        {
            if (OnTheRight)
            {
                changeSide("On left", ApplicationDesktopToolbar.AppBarEdges.Left, false);
                ChangeButtonColor(btnChangeSide, true);
            }
            else
            {
                changeSide("On Right", ApplicationDesktopToolbar.AppBarEdges.Right, true);
                ChangeButtonColor(btnChangeSide, false);
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
            string settings = File.ReadAllText(Program.path);
            SettingJSON setting = JsonConvert.DeserializeObject<SettingJSON>(settings);
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

        public void ChangeButtonColor(Button button, bool onOff)
        {
            button.BackColor = onOff ? ValueNeverChange.SettingButtonColor : ValueNeverChange.SelectedColor;
        }

        private void btnGaze_Click(object sender, EventArgs e)
        {
            GazeOrSwitch gaze = GazeOrSwitch.GAZE;
            EnumTranslate.GazeOrSwitchTranslate(btnGaze, btnSwitch, gaze);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            GazeOrSwitch Switch = GazeOrSwitch.SWITCH;
            EnumTranslate.GazeOrSwitchTranslate(btnGaze, btnSwitch, Switch);
        }

        private void btnWordPredictionOnOff_Click(object sender, EventArgs e)
        {
            onOff[0] = !onOff[0];
            ChangeButtonColor(btnWordPredictionOnOff, onOff[0]);
        }

        private void btnSoundFeedback_Click(object sender, EventArgs e)
        {
            onOff[1] = !onOff[1];
            ChangeButtonColor(btnSoundFeedback, onOff[1]);
        }

        private void btnSizeLarge_Click(object sender, EventArgs e)
        {
            Sizes large = Sizes.LARGE;
            EnumTranslate.SisesTranslate(btnSizeSmall, btnSizeLarge, large);
        }

        private void btnSizeSmall_Click(object sender, EventArgs e)
        {
            Sizes small = Sizes.SMALL;
            EnumTranslate.SisesTranslate(btnSizeSmall, btnSizeLarge, small);
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBarPrecision_Scroll(object sender, EventArgs e)
        {

        }

        private void btnChangeLanguage_Click(object sender, EventArgs e)
        {

        }

        private void trackBarGazeTypingSpeed_Scroll(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
