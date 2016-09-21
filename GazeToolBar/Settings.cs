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
        private GazeOrSwitch gazeOrSwitch;
        private Sizes sizes;
        private bool pnlKeyboardIsShow;
        private bool pnlGeneralIsShow;

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
            pnlPageKeyboard.Hide();
            ChangeButtonColor(btnGeneralSetting, true, true);
            this.form1 = form1;
            //This code make setting form full screen
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //End
            OnTheRight = true;
            panelSaveAndCancel.Location = ReletiveSize.panelSaveAndCancel(panelSaveAndCancel.Width, panelSaveAndCancel.Height);
            //tabControlMain.Size = ReletiveSize.TabControlSize;
            onOff = new bool[5];
            for (int i = 0; i < onOff.Length; i++)
            {
                onOff[i] = false;
            }
            pnlGeneralIsShow = true;
            pnlKeyboardIsShow = false;
        }

        private void btnChangeSide_Click(object sender, EventArgs e)
        {
            if (OnTheRight)
            {
                changeSide("On left", ApplicationDesktopToolbar.AppBarEdges.Left, false);
                ChangeButtonColor(btnChangeSide, true, false);
            }
            else
            {
                changeSide("On Right", ApplicationDesktopToolbar.AppBarEdges.Right, true);
                ChangeButtonColor(btnChangeSide, false, false);
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

            if (Program.onStartUp)
            {
                AutoStart.SetOff();
                Program.onStartUp = !Program.onStartUp;
                ChangeButtonColor(btnAutoStart, false, false);
            }
            else
            {
                if (AutoStart.SetOn())
                {
                    Program.onStartUp = !Program.onStartUp;
                    ChangeButtonColor(btnAutoStart, true, false);
                }
            }

            form1.OnStartTextChange();

        }

        public void ChangeButtonColor(Button button, bool onOff, bool hasText)
        {

            button.BackColor = onOff ? ValueNeverChange.SelectedColor: ValueNeverChange.SettingButtonColor;
            if (hasText)
            {
                if (onOff)
                {
                    button.ForeColor = Color.Black;
                }
                else
                {
                    button.ForeColor = Color.White;
                }
            }
        }

        private void btnGaze_Click(object sender, EventArgs e)
        {

            gazeOrSwitch = GazeOrSwitch.GAZE;
            changeSitchGaze(gazeOrSwitch);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {

            gazeOrSwitch = GazeOrSwitch.SWITCH;
            changeSitchGaze(gazeOrSwitch);
        }

        private void changeSitchGaze(GazeOrSwitch gs)
        {
            switch (gs)
            {
                case GazeOrSwitch.GAZE:
                    ChangeButtonColor(btnGaze, !onOff[0], false);
                    ChangeButtonColor(btnSwitch, onOff[0], false);
                    break;
                case GazeOrSwitch.SWITCH:
                    ChangeButtonColor(btnGaze, onOff[0], false);
                    ChangeButtonColor(btnSwitch, !onOff[0], false);
                    break;
            }
        }

        

        private void lblOnOff(Label l, bool b)
        {
            if(b)
            {
                l.Text = "On";
            }
            else
            {
                l.Text = "Off";
            }

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
                
                setting.position = lblIndicationLeftOrRight.Text.Substring(3);
                setting.precision = trackBarPrecision.Value;
                setting.selection = gazeOrSwitch.ToString();
                setting.size = sizes.ToString();
                setting.soundFeedback = onOff[3];
                setting.speed = trackBarSpeed.Value;
                
                setting.wordPrediction = onOff[2];
                string settings = JsonConvert.SerializeObject(setting);
                File.WriteAllText(Program.path, settings);
                //MessageBox.Show("Save Success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form1.NotifyIcon.BalloonTipTitle = "Saving success";
                form1.NotifyIcon.BalloonTipText = "Your settins are successfuly saved";
                this.Close();
                form1.NotifyIcon.ShowBalloonTip(2000);
            }
            catch (Exception exception)
            {
                form1.NotifyIcon.BalloonTipTitle = "Saving error";
                form1.NotifyIcon.BalloonTipText = "For some reason, your settings are not successfuly saved, click me to show error message";
                form1.NotifyIcon.Tag = exception.Message;
                this.Close();
                form1.NotifyIcon.BalloonTipClicked += NotifyIcon_BalloonTipClicked;
                form1.NotifyIcon.ShowBalloonTip(5000);
                //MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            MessageBox.Show((String)((NotifyIcon)sender).Tag, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Program.ReadWriteJson();
            trackBarPrecision.Value = Program.readSettings.precision;
            trackBarSpeed.Value = Program.readSettings.speed;
            
            lblIndicationLeftOrRight.Text = lblIndicationLeftOrRight.Text.Remove(3) + Program.readSettings.position;
            
            if (Program.onStartUp)
            {
                ChangeButtonColor(btnAutoStart, true, false);
            }
            else
            {
                ChangeButtonColor(btnAutoStart, false, false);
            }



            if (Program.readSettings.selection == GazeOrSwitch.GAZE.ToString())
            {
                gazeOrSwitch = GazeOrSwitch.GAZE;
                changeSitchGaze(gazeOrSwitch);
            }
            else
            {
                gazeOrSwitch = GazeOrSwitch.SWITCH;
                changeSitchGaze(gazeOrSwitch);
            }

            if (Program.readSettings.position == "left")
            {
                OnTheRight = false;
                ChangeButtonColor(btnChangeSide, true, false);
            }
            else
            {
                OnTheRight = true;
            }
        }

        private void btnGeneralSetting_Click(object sender, EventArgs e)
        {
            if (!pnlGeneralIsShow)
            {
                pnlPageKeyboard.Hide();
                ChangeButtonColor(btnShortCutKeySetting, false, true);
                pnlGeneral.Show();
                ChangeButtonColor(btnGeneralSetting, true, true);
                pnlKeyboardIsShow = false;
                pnlGeneralIsShow = true;
            }
        }

        private void btnKeyBoardSetting_Click(object sender, EventArgs e)
        {
            if (!pnlKeyboardIsShow)
            {
                pnlGeneral.Hide();
                ChangeButtonColor(btnGeneralSetting, false, true);
                pnlPageKeyboard.Show();
                ChangeButtonColor(btnShortCutKeySetting, true, true);
                pnlKeyboardIsShow = true;
                pnlGeneralIsShow = false;
            }
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            connectBehaveMap();
        }
    }
}
