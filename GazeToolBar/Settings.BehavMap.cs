using EyeXFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazeToolBar
{
    partial class Settings 
    {

        int buttonClickDelay = 500;
        String notAssigned = "Key not assigned";

        private void connectBehaveMap()
        {
            eyeXHost.Connect(bhavSettingMap);

            //Temp for 100 
            //Will change later
            bhavSettingMap.Add(btnAutoStart, new GazeAwareBehavior(OnbtnAutoStart_Click) { DelayMilliseconds = buttonClickDelay });
            bhavSettingMap.Add(btnSave, new GazeAwareBehavior(OnbtnSave_Click) { DelayMilliseconds = buttonClickDelay });
            bhavSettingMap.Add(btnCancel, new GazeAwareBehavior(OnbtnCancel_Click) { DelayMilliseconds = buttonClickDelay });
            bhavSettingMap.Add(btnFixTimeLengthMins, new GazeAwareBehavior(OnbtnFixTimeLengthMins_Click) { DelayMilliseconds = buttonClickDelay });
            bhavSettingMap.Add(btnFixTimeLengthPlus, new GazeAwareBehavior(OnbtnFixTimeLengthPlus_Click) { DelayMilliseconds = buttonClickDelay });
            bhavSettingMap.Add(btnFixTimeOutMins, new GazeAwareBehavior(OnbtnFixTimeOutMins_Click) { DelayMilliseconds = buttonClickDelay });
            bhavSettingMap.Add(btnFixTimeOutPlus, new GazeAwareBehavior(OnbtnFixTimeOutPlus_Click) { DelayMilliseconds = buttonClickDelay });
            bhavSettingMap.Add(btnGeneralSetting, new GazeAwareBehavior(OnBtnGeneralSettingClick) { DelayMilliseconds = buttonClickDelay });
            bhavSettingMap.Add(btnShortCutKeySetting, new GazeAwareBehavior(OnBtnKeyboardSettingClick) { DelayMilliseconds = buttonClickDelay });

            //Set buttons
            bhavSettingMap.Add(btFKeyLeftClick, new GazeAwareBehavior(btFKeyLeftClick_Click) { DelayMilliseconds = buttonClickDelay });
            bhavSettingMap.Add(btFKeyRightClick, new GazeAwareBehavior(btFKeyRightClick_Click) { DelayMilliseconds = buttonClickDelay });
            bhavSettingMap.Add(btFKeyDoubleClick, new GazeAwareBehavior(btFKeyDoubleClick_Click) { DelayMilliseconds = buttonClickDelay });
            bhavSettingMap.Add(btFKeyScroll, new GazeAwareBehavior(btFKeyScroll_Click) { DelayMilliseconds = buttonClickDelay });
            bhavSettingMap.Add(btFKeyDrapAndDrop, new GazeAwareBehavior(btFKeyDrapAndDrop_Click) { DelayMilliseconds = buttonClickDelay });
            //clear buttons
            bhavSettingMap.Add(btClearFKeyLeftClick, new GazeAwareBehavior(btClearFKeyLeftClick_Click) { DelayMilliseconds = buttonClickDelay });
            bhavSettingMap.Add(btClearFKeyRightClick, new GazeAwareBehavior(btClearFKeyRightClick_Click) { DelayMilliseconds = buttonClickDelay });
            bhavSettingMap.Add(btClearFKeyDoubleClick, new GazeAwareBehavior(btClearFKeyDoubleClick_Click) { DelayMilliseconds = buttonClickDelay });
            bhavSettingMap.Add(btClearFKeyScroll, new GazeAwareBehavior(btClearFKeyScroll_Click) { DelayMilliseconds = buttonClickDelay });
            bhavSettingMap.Add(btClearFKeyDrapAndDrop, new GazeAwareBehavior(btClearFKeyDrapAndDrop_Click) { DelayMilliseconds = buttonClickDelay });
            //highlight panels
            bhavSettingMap.Add(pnlFKeyHighlight1, new GazeAwareBehavior(OnGazeChangeBTColour));
            bhavSettingMap.Add(pnlFKeyHighlight2, new GazeAwareBehavior(OnGazeChangeBTColour));
            bhavSettingMap.Add(pnlFKeyHighlight3, new GazeAwareBehavior(OnGazeChangeBTColour));
            bhavSettingMap.Add(pnlFKeyHighlight4, new GazeAwareBehavior(OnGazeChangeBTColour));
            bhavSettingMap.Add(pnlFKeyHighlight5, new GazeAwareBehavior(OnGazeChangeBTColour));
            bhavSettingMap.Add(pnlFKeyHighlight6, new GazeAwareBehavior(OnGazeChangeBTColour));
            bhavSettingMap.Add(pnlFKeyHighlight7, new GazeAwareBehavior(OnGazeChangeBTColour));
            bhavSettingMap.Add(pnlFKeyHighlight8, new GazeAwareBehavior(OnGazeChangeBTColour));
            bhavSettingMap.Add(pnlFKeyHighlight9, new GazeAwareBehavior(OnGazeChangeBTColour));
            bhavSettingMap.Add(pnlFKeyHighlight10, new GazeAwareBehavior(OnGazeChangeBTColour));
            
        }

        //toggle border on and off on gaze to gaze to give feed back.
        private void OnGazeChangeBTColour(object s, GazeAwareEventArgs e)
        {
            var sentButton = s as Panel;
            if (sentButton != null)
            {
                sentButton.BackColor = (e.HasGaze) ? Color.Red : Color.Black;
            }
        }
        private void OnbtnFixTimeOutPlus_Click(object sender, GazeAwareEventArgs e)
        {
            btnFixTimeOutPlus.PerformClick();
        }

        private void OnbtnFixTimeOutMins_Click(object sender, GazeAwareEventArgs e)
        {
            btnFixTimeOutMins.PerformClick();
        }

        private void OnbtnFixTimeLengthPlus_Click(object sender, GazeAwareEventArgs e)
        {
            btnFixTimeLengthPlus.PerformClick();
        }

        private void OnbtnFixTimeLengthMins_Click(object sender, GazeAwareEventArgs e)
        {
            btnFixTimeLengthMins.PerformClick();
        }

        private void OnbtnCancel_Click(object sender, GazeAwareEventArgs e)
        {
            btnCancel.PerformClick();
        }

        private void OnbtnSave_Click(object sender, GazeAwareEventArgs e)
        {
            btnSave.PerformClick();
        }

        private void OnbtnAutoStart_Click(object sender, GazeAwareEventArgs e)
        {
            btnAutoStart.PerformClick();
        }

        private void OnBtnGeneralSettingClick(object sender, GazeAwareEventArgs e)
        {
            btnGeneralSetting.PerformClick();
        }

        private void OnBtnKeyboardSettingClick(object sender, GazeAwareEventArgs e)
        {
            btnShortCutKeySetting.PerformClick();
        }



        //====================================================================================


              //Shortcut keys panel buy button event methods. 


        //====================================================================================

        ActionToBePerformed actionToAssignKey;

        private void btFKeyLeftClick_Click(object sender, EventArgs e)
        {
            WaitForUserKeyPress = true;
            actionToAssignKey = ActionToBePerformed.LeftClick;
            lbFKeyFeedback.Text = "please press a key";
            
        }

        private void btFKeyRightClick_Click(object sender, EventArgs e)
        {
            WaitForUserKeyPress = true;
            actionToAssignKey = ActionToBePerformed.RightClick;
            lbFKeyFeedback.Text = "please press a key";
        }

        private void btFKeyDoubleClick_Click(object sender, EventArgs e)
        {
            WaitForUserKeyPress = true;
            actionToAssignKey = ActionToBePerformed.DoubleClick;
            lbFKeyFeedback.Text = "please press a key";
        }

        private void btFKeyScroll_Click(object sender, EventArgs e)
        {
            WaitForUserKeyPress = true;
            actionToAssignKey = ActionToBePerformed.Scroll;
            lbFKeyFeedback.Text = "please press a key";
        }

        private void btFKeyDrapAndDrop_Click(object sender, EventArgs e)
        {

        }

       
        //Clear key map

        private void btClearFKeyLeftClick_Click(object sender, EventArgs e)
        {
            form1.shortCutKeyWorker.keyAssignments[ActionToBePerformed.LeftClick] = notAssigned;
            lbLeft.Text = notAssigned;
        }

        private void btClearFKeyRightClick_Click(object sender, EventArgs e)
        {
            form1.shortCutKeyWorker.keyAssignments[ActionToBePerformed.RightClick] = notAssigned;
            lbRight.Text = notAssigned;
        }

        private void btClearFKeyDoubleClick_Click(object sender, EventArgs e)
        {
            form1.shortCutKeyWorker.keyAssignments[ActionToBePerformed.LeftClick] = notAssigned;
            lbDouble.Text = notAssigned;
        }

        private void btClearFKeyScroll_Click(object sender, EventArgs e)
        {
            form1.shortCutKeyWorker.keyAssignments[ActionToBePerformed.Scroll] = notAssigned;
            lbScroll.Text = notAssigned;
        }

        private void btClearFKeyDrapAndDrop_Click(object sender, EventArgs e)
        {

        }


    }
}
