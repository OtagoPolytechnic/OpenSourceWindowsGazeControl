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
            onOff = new bool[5];
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
            if (Program.onStartUp)
            {
                AutoStart.SetOff();
                Program.onStartUp = !Program.onStartUp;
                ChangeButtonColor(btnAutoStart, false);
            }
            else
            {
                if (AutoStart.SetOn())
                {
                    Program.onStartUp = !Program.onStartUp;
                    ChangeButtonColor(btnAutoStart, true);
                }
            }
            form1.OnStartTextChange();
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
            button.BackColor = onOff ? ValueNeverChange.SelectedColor: ValueNeverChange.SettingButtonColor;
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
                    ChangeButtonColor(btnGaze, !onOff[0]);
                    ChangeButtonColor(btnSwitch, onOff[0]);
                    break;
                case GazeOrSwitch.SWITCH:
                    ChangeButtonColor(btnGaze, onOff[0]);
                    ChangeButtonColor(btnSwitch, !onOff[0]);
                    break;
            }
        }

        private void changeSizes(Sizes s)
        {
            switch (s)
            {
                case Sizes.SMALL:
                    ChangeButtonColor(btnSizeLarge, onOff[4]);
                    ChangeButtonColor(btnSizeSmall, !onOff[4]);
                    break;
                case Sizes.LARGE:
                    ChangeButtonColor(btnSizeLarge, !onOff[4]);
                    ChangeButtonColor(btnSizeSmall, onOff[4]);
                    break;
                default:
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

        private void btnWordPredictionOnOff_Click(object sender, EventArgs e)
        {
            onOff[2] = !onOff[2];
            ChangeButtonColor(btnWordPredictionOnOff, onOff[2]);
            lblOnOff(lblWordPredictionOnOffIndiction, onOff[2]);
        }

        private void btnSoundFeedback_Click(object sender, EventArgs e)
        {
            onOff[3] = !onOff[3];
            ChangeButtonColor(btnSoundFeedback, onOff[3]);
            lblOnOff(lblSoundFeedbackOnOff, onOff[3]);
        }

        private void btnSizeLarge_Click(object sender, EventArgs e)
        {
            sizes = Sizes.LARGE;
            changeSizes(sizes);
        }

        private void btnSizeSmall_Click(object sender, EventArgs e)
        {
            sizes = Sizes.SMALL;
            changeSizes(sizes);
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
                setting.soundFeedback = onOff[3];
                setting.speed = trackBarSpeed.Value;
                setting.typingSpeed = trackBarGazeTypingSpeed.Value;
                setting.wordPrediction = onOff[2];
                string settings = JsonConvert.SerializeObject(setting);
                File.WriteAllText(Program.path, settings);
                MessageBox.Show("Save Success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Program.ReadWriteJson();
            trackBarPrecision.Value = Program.readSettings.precision;
            trackBarSpeed.Value = Program.readSettings.speed;
            trackBarGazeTypingSpeed.Value = Program.readSettings.typingSpeed;
            lblCurrentLanguage.Text = Program.readSettings.language;
            lblIndicationLeftOrRight.Text = lblIndicationLeftOrRight.Text.Remove(3) + Program.readSettings.position;
            
            if (Program.onStartUp)
            {
                ChangeButtonColor(btnAutoStart, true);
            }
            else
            {
                ChangeButtonColor(btnAutoStart, false);
            }

            if (Program.readSettings.wordPrediction)
            {
                onOff[2] = true;
                ChangeButtonColor(btnWordPredictionOnOff, onOff[2]);
                lblOnOff(lblWordPredictionOnOffIndiction, onOff[2]);
            }
            else
            {
                onOff[2] = false;
                ChangeButtonColor(btnWordPredictionOnOff, onOff[2]);
                lblOnOff(lblWordPredictionOnOffIndiction, onOff[2]);
            }

            if (Program.readSettings.soundFeedback)
            {
                onOff[3] = true;
                ChangeButtonColor(btnSoundFeedback, onOff[3]);
                lblOnOff(lblSoundFeedbackOnOff, onOff[3]);
            }
            else
            {
                onOff[3] = false;
                ChangeButtonColor(btnSoundFeedback, onOff[3]);
                lblOnOff(lblSoundFeedbackOnOff, onOff[3]);
            }

            if (Program.readSettings.size == Sizes.SMALL.ToString())
            {
                sizes = Sizes.SMALL;
                changeSizes(sizes);
            }
            else
            {
                sizes = Sizes.LARGE;
                changeSizes(sizes);
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
                ChangeButtonColor(btnChangeSide, true);
            }
            else
            {
                OnTheRight = true;
            }
        }
    }
}
