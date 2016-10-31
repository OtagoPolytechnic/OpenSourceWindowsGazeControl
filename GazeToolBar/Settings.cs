using System;
using System.Windows.Forms;
using ShellLib;
using System.Drawing;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using EyeXFramework.Forms;

namespace GazeToolBar
{
    public partial class Settings : Form
    {
        private Form1 form1;
        private bool[] onOff;
        private bool pnlKeyboardIsShow;
        private bool pnlGeneralIsShow;
        private bool WaitForUserKeyPress;
        private static FormsEyeXHost eyeXHost;


        private List<Panel> fKeyPannels;

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

        public Settings(Form1 form1, FormsEyeXHost EyeXHost)
        {
            eyeXHost = EyeXHost;
            InitializeComponent();
            pnlPageKeyboard.Hide();
            ChangeButtonColor(btnGeneralSetting, true, true);
            this.form1 = form1;
            //This code make setting form full screen
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //End
            panelSaveAndCancel.Location = ReletiveSize.panelSaveAndCancel(panelSaveAndCancel.Width, panelSaveAndCancel.Height);
            controlRelocateAndResize();
            //tabControlMain.Size = ReletiveSize.TabControlSize;
            onOff = new bool[5];
            for (int i = 0; i < onOff.Length; i++)
            {
                onOff[i] = false;
            }
            pnlGeneralIsShow = true;
            pnlKeyboardIsShow = false;

            //Set Short cut key assignment panel to the viable width of the form
            pnlPageKeyboard.Width = ValueNeverChange.SCREEN_SIZE.Width - 20;

            //Set feed back label to the center of the screen.
            lbFKeyFeedback.Location = new Point((pnlPageKeyboard.Width / 2) - (lbFKeyFeedback.Width / 2), lbFKeyFeedback.Location.Y);
            //Store reference to short cut assignment panels in a list so they can be iterated over and set their on screen positions relative form size.
            fKeyPannels = new List<Panel>() { pnlLeftClick, pnlRightClick, pnlDoubleClick, pnlScroll, pnlDragAndDrop };
            //Set panel positions.
            setFkeyPanelWidth(fKeyPannels);

            //set initial values of mapped keys to on screen label.
            lbDouble.Text = form1.FKeyMapDictionary[ActionToBePerformed.DoubleClick];
            lbRight.Text = form1.FKeyMapDictionary[ActionToBePerformed.RightClick];
            lbLeft.Text = form1.FKeyMapDictionary[ActionToBePerformed.LeftClick];
            lbScroll.Text = form1.FKeyMapDictionary[ActionToBePerformed.Scroll];

            WaitForUserKeyPress = false;

            form1.LowLevelKeyBoardHook.OnKeyPressed += GetKeyPress;


           

        }

        private void controlRelocateAndResize()
        {
            panelSaveAndCancel.Location = ReletiveSize.panelSaveAndCancel(panelSaveAndCancel.Width, panelSaveAndCancel.Height);
            pnlGeneral.Size = ReletiveSize.panelGeneralSize();
            panelPrecision.Location = ReletiveSize.distribute(pnlGeneral, panelPrecision.Location.X, 1, 3, "h", 0);
            pnlFixationTimeOut.Location = ReletiveSize.distribute(pnlGeneral, pnlFixationTimeOut.Location.X, 2, 3, "h", 0);
            panelOther.Location = ReletiveSize.distribute(pnlGeneral, panelOther.Location.X, 3, 3, "h", 0);

            panelPrecision.Size = new Size(pnlGeneral.Size.Width, panelPrecision.Size.Height);
            pnlFixationTimeOut.Size = new Size(pnlGeneral.Size.Width, pnlFixationTimeOut.Size.Height);
            panelOther.Size = new Size(pnlGeneral.Size.Width, panelOther.Size.Height);

            lblFixationDetectionTimeLength.Location = ReletiveSize.labelPosition(panelPrecision, lblFixationDetectionTimeLength);
            lblSpeed.Location = ReletiveSize.labelPosition(pnlFixationTimeOut, lblSpeed);
            lblOther.Location = ReletiveSize.labelPosition(panelOther, lblOther);

            pnlOtherAuto.Location = new Point(panelOther.Size.Width / 2, pnlOtherAuto.Location.Y);

            //double p = ((double)pnlSelectionGaze.Location.X + (double)btnGaze.Location.X) / (double)pnlSelectionGaze.Parent.Size.Width;
            pnlFixTimeLengthContent.Location = ReletiveSize.distribute(panelPrecision, pnlFixTimeLengthContent.Location.Y, 1, 1, "w", 0.8);
            pnlFixTimeOutContent.Location = new Point(pnlFixTimeLengthContent.Location.X, pnlFixTimeOutContent.Location.Y);

            pnlFixTimeLengthContent.Size = ReletiveSize.controlLength(panelPrecision, pnlFixTimeLengthContent.Size.Height, 0.8);
            pnlFixTimeOutContent.Size = pnlFixTimeLengthContent.Size;

            double percentage = (double)(pnlFixTimeLengthContent.Size.Width - 138) / (double)pnlFixTimeLengthContent.Size.Width;
            trackBarFixTimeLength.Size = ReletiveSize.controlLength(pnlFixTimeLengthContent, trackBarFixTimeLength.Size.Height, percentage);
            trackBarFixTimeOut.Size = trackBarFixTimeLength.Size;

            btnFixTimeLengthPlus.Location = ReletiveSize.reletiveLocation(trackBarFixTimeLength, btnFixTimeLengthPlus.Location.Y, 7, 'v');
            btnFixTimeOutPlus.Location = new Point(btnFixTimeLengthPlus.Location.X, btnFixTimeOutPlus.Location.Y);
        }

        //private void btnChangeSide_Click(object sender, EventArgs e)
        //{
        //    if (OnTheRight)
        //    {
        //        changeSide("On left", ApplicationDesktopToolbar.AppBarEdges.Left, false);
        //        ChangeButtonColor(btnChangeSide, true, false);
        //    }
        //    else
        //    {
        //        changeSide("On Right", ApplicationDesktopToolbar.AppBarEdges.Right, true);
        //        ChangeButtonColor(btnChangeSide, false, false);
        //    }
        //}

        //private void changeSide(string text, ApplicationDesktopToolbar.AppBarEdges edge, bool flag)
        //{
        //    lblIndicationLeftOrRight.Text = text;
        //    form1.Edge = edge;
        //    OnTheRight = flag;
        //}

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

        //private void btnGaze_Click(object sender, EventArgs e)
        //{

        //    gazeOrSwitch = GazeOrSwitch.GAZE;
        //    changeSitchGaze(gazeOrSwitch);

        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //private void btnSwitch_Click(object sender, EventArgs e)
        //{

        //    gazeOrSwitch = GazeOrSwitch.SWITCH;
        //    changeSitchGaze(gazeOrSwitch);
        //}

        //private void changeSitchGaze(GazeOrSwitch gs)
        //{
        //    switch (gs)
        //    {
        //        case GazeOrSwitch.GAZE:
        //            ChangeButtonColor(btnGaze, !onOff[0], false);
        //            ChangeButtonColor(btnSwitch, onOff[0], false);
        //            break;
        //        case GazeOrSwitch.SWITCH:
        //            ChangeButtonColor(btnGaze, onOff[0], false);
        //            ChangeButtonColor(btnSwitch, !onOff[0], false);
        //            break;
        //    }
        //}

        

        //private void lblOnOff(Label l, bool b)
        //{
        //    if(b)
        //    {
        //        l.Text = "On";
        //    }
        //    else
        //    {
        //        l.Text = "Off";
        //    }

        //}


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SettingJSON setting = new SettingJSON();

                //TODO: Need to be replaced

                //setting.position = lblIndicationLeftOrRight.Text.Substring(3);
                //setting.precision = trackBarFixTimeLength.Value;
                //setting.selection = gazeOrSwitch.ToString();
                //setting.size = sizes.ToString();
                //setting.soundFeedback = onOff[3];
                //setting.speed = trackBarFixTimeOut.Value;
                //setting.wordPrediction = onOff[2];
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
            //TODO: Need to be replaced
            //trackBarFixTimeLength.Value = Program.readSettings.precision;
            //trackBarFixTimeOut.Value = Program.readSettings.speed;
            //lblIndicationLeftOrRight.Text = lblIndicationLeftOrRight.Text.Remove(3) + Program.readSettings.position;
            
            if (Program.onStartUp)
            {
                ChangeButtonColor(btnAutoStart, true, false);
            }
            else
            {
                ChangeButtonColor(btnAutoStart, false, false);
            }


            //TODO: Need to be replaced

            //if (Program.readSettings.selection == GazeOrSwitch.GAZE.ToString())
            //{
            //    gazeOrSwitch = GazeOrSwitch.GAZE;
            //    //changeSitchGaze(gazeOrSwitch);
            //}
            //else
            //{
            //    gazeOrSwitch = GazeOrSwitch.SWITCH;
            //    //changeSitchGaze(gazeOrSwitch);
            //}

            //if (Program.readSettings.position == "left")
            //{
            //    OnTheRight = false;
            //    //ChangeButtonColor(btnChangeSide, true, false);
            //}
            //else
            //{
            //    OnTheRight = true;
            //}
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

                WaitForUserKeyPress = false;
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

                lbFKeyFeedback.Text = "";
            }
        }

        private void changeTrackBarValue(TrackBar trackbar, String IncrementOrDecrement)
        {
            switch (IncrementOrDecrement)
            {
                case "I":
                    if (trackbar.Value != trackbar.Maximum) { trackbar.Value = ++trackbar.Value; }
                    break;
                case "D":
                    if (trackbar.Value != trackbar.Minimum) { trackbar.Value = --trackbar.Value; }
                    break;
            }
            trackbar.Update();
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            connectBehaveMap();
            form1.shortCutKeyWorker.StopKeyboardWorker();
        }

        //Method to assign key when for function short cut. Waits until WaitForUserKeyPress is set to true, the next key that is pressed
        //is assign to the function stored in actionToAssignKey.
        public void GetKeyPress(object o, HookedKeyboardEventArgs pressedKey)

        {

            String keyPressed = pressedKey.KeyPressed.ToString();

             if(WaitForUserKeyPress)
            {

                if (checkIfKeyIsAssignedAlready(keyPressed, form1.shortCutKeyWorker.keyAssignments))
                {
                    lbFKeyFeedback.Text = keyPressed + " already assigned.";
                }
                else
                {
                    form1.shortCutKeyWorker.keyAssignments[actionToAssignKey] = keyPressed;
                    updateLabel(pressedKey.KeyPressed.ToString(), actionToAssignKey);
                    WaitForUserKeyPress = false;
                    lbFKeyFeedback.Text = "";
                }
            }
        }


        private bool checkIfKeyIsAssignedAlready(String ValueToCheck, Dictionary<ActionToBePerformed, String> KeyAssignedDict)
        {
            
            foreach (KeyValuePair<ActionToBePerformed, String> currentKVP in KeyAssignedDict)
            { 
                if(currentKVP.Value == ValueToCheck)
                {
                    return true;
                }
            }

            return false;
        }

        void updateLabel(String newKey, ActionToBePerformed functiontoAssign)
        {
            switch (functiontoAssign)
            {
                case ActionToBePerformed.LeftClick:
                    lbLeft.Text = newKey;
                    break;
                case ActionToBePerformed.RightClick:
                    lbRight.Text = newKey;
                    break;
                case ActionToBePerformed.Scroll:
                    lbScroll.Text = newKey;
                    break;
                case ActionToBePerformed.DoubleClick:
                    lbDouble.Text = newKey;
                    break;
            }
        }




        private void setFkeyPanelWidth(List<Panel> panelList)
        {
            int screenWidth = pnlPageKeyboard.Width;

            int amountOfPanels = panelList.Count;

            int panelWidth = panelList[0].Width;

            int screenSectionSize = screenWidth / amountOfPanels;

            int spacer = screenSectionSize - panelWidth;

            int spacerBuffer = spacer / 2;

            foreach (Panel currentPanel in panelList)
            {
                Point panelLocation = new Point(spacerBuffer, currentPanel.Location.Y);

                Console.WriteLine(screenWidth);
                Console.WriteLine(panelLocation.X);

                currentPanel.Location = panelLocation;

                spacerBuffer += screenSectionSize;
            }
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.shortCutKeyWorker.StartKeyBoardWorker();
            WaitForUserKeyPress = false;
        }
        private void btnFixTimeLengthMins_Click(object sender, EventArgs e)
        {
            changeTrackBarValue(trackBarFixTimeLength, "D");
        }

        private void btnFixTimeLengthPlus_Click(object sender, EventArgs e)
        {
            changeTrackBarValue(trackBarFixTimeLength, "I");
        }

        private void btnFixTimeOutMins_Click(object sender, EventArgs e)
        {
            changeTrackBarValue(trackBarFixTimeOut, "D");
        }

        private void btnFixTimeOutPlus_Click(object sender, EventArgs e)
        {
            changeTrackBarValue(trackBarFixTimeOut, "I");
        }
    }
}
