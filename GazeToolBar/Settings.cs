﻿using System;
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
        private GazeOrSwitch gazeOrSwitch;
        private Sizes sizes;

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
                changeSide("On Left", ApplicationDesktopToolbar.AppBarEdges.Left, false);
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

        public string ChangeButtonColor(Button button, bool onOff)
        {
            button.BackColor = onOff ? ValueNeverChange.SettingButtonColor : ValueNeverChange.SelectedColor;
            return onOff ? "On" : "Off";
        }

        private void btnGaze_Click(object sender, EventArgs e)
        {
            gazeOrSwitch = GazeOrSwitch.GAZE;
            EnumTranslate.GazeOrSwitchTranslate(btnGaze, btnSwitch, gazeOrSwitch);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            gazeOrSwitch = GazeOrSwitch.SWITCH;
            EnumTranslate.GazeOrSwitchTranslate(btnGaze, btnSwitch, gazeOrSwitch);
        }

        private void btnWordPredictionOnOff_Click(object sender, EventArgs e)
        {
            onOff[0] = !onOff[0];
            lblWordPredictionOnOffIndiction.Text = ChangeButtonColor(btnWordPredictionOnOff, onOff[0]);
        }

        private void btnSoundFeedback_Click(object sender, EventArgs e)
        {
            onOff[1] = !onOff[1];
            lblSoundFeedbackOnOff.Text = ChangeButtonColor(btnSoundFeedback, onOff[1]);
        }

        private void btnSizeLarge_Click(object sender, EventArgs e)
        {
            sizes = Sizes.LARGE;
            EnumTranslate.SisesTranslate(btnSizeSmall, btnSizeLarge, sizes);
        }

        private void btnSizeSmall_Click(object sender, EventArgs e)
        {
            sizes = Sizes.SMALL;
            EnumTranslate.SisesTranslate(btnSizeSmall, btnSizeLarge, sizes);
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
            try
            {
                SettingJSON setting = new SettingJSON();
                setting.language = lblCurrentLanguage.Text;
                setting.position = lblIndicationLeftOrRight.Text.Substring(3);
                setting.precision = trackBarPrecision.Value;
                setting.selection = gazeOrSwitch.ToString();
                setting.size = sizes.ToString();
                setting.soundFeedback = onOff[1];
                setting.speed = trackBarSpeed.Value;
                setting.typingSpeed = trackBarGazeTypingSpeed.Value;
                setting.wordPercision = onOff[0];
                string settings = JsonConvert.SerializeObject(setting);
                File.WriteAllText(Program.path, settings);
                MessageBox.Show("Save Success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
