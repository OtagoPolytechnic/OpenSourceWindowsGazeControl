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

        private void connectBehaveMap()
        {
            Program.EyeXHost.Connect(bhavSettingMap);

            //Temp for 100 
            //Will change later
            bhavSettingMap.Add(btnAutoStart, new GazeAwareBehavior(OnbtnAutoStart_Click) { DelayMilliseconds = 100 });
            bhavSettingMap.Add(btnGaze, new GazeAwareBehavior(OnbtnGaze_Click) { DelayMilliseconds = 100 });
            bhavSettingMap.Add(btnSave, new GazeAwareBehavior(OnbtnSave_Click) { DelayMilliseconds = 100 });
            bhavSettingMap.Add(btnCancel, new GazeAwareBehavior(OnbtnCancel_Click) { DelayMilliseconds = 100 });
            bhavSettingMap.Add(btnChangeSide, new GazeAwareBehavior(OnbtnChangeSide_Click) { DelayMilliseconds = 100 });
            bhavSettingMap.Add(btnSwitch, new GazeAwareBehavior(OnbtnSwitch_Click) { DelayMilliseconds = 100 });
            bhavSettingMap.Add(trackBarPrecision, new GazeAwareBehavior(OntrackBarPrecision_Scroll) { DelayMilliseconds = 100 });
            bhavSettingMap.Add(trackBarSpeed, new GazeAwareBehavior(OntrackBarSpeed_Scroll) { DelayMilliseconds = 100 });
            bhavSettingMap.Add(btnGeneralSetting, new GazeAwareBehavior(OnBtnGeneralSettingClick) { DelayMilliseconds = 100 });
            bhavSettingMap.Add(btnShortCutKeySetting, new GazeAwareBehavior(OnBtnKeyboardSettingClick) { DelayMilliseconds = 100 });

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

        private void OntrackBarGazeTypingSpeed_Scroll(object sender, GazeAwareEventArgs e)
        {
            //throw new NotImplementedException();
        }







        private void OntrackBarSpeed_Scroll(object sender, GazeAwareEventArgs e)
        {
            //trackBarSpeed.
            //throw new NotImplementedException();
        }

        private void OntrackBarPrecision_Scroll(object sender, GazeAwareEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OnbtnSwitch_Click(object sender, GazeAwareEventArgs e)
        {
            btnSwitch.PerformClick();
        }



        private void OnbtnChangeSide_Click(object sender, GazeAwareEventArgs e)
        {
            btnChangeSide.PerformClick();
        }



        private void OnbtnCancel_Click(object sender, GazeAwareEventArgs e)
        {
            btnCancel.PerformClick();
        }

        private void OnbtnSave_Click(object sender, GazeAwareEventArgs e)
        {
            btnSave.PerformClick();
        }

        private void OnbtnGaze_Click(object sender, GazeAwareEventArgs e)
        {
            btnGaze.PerformClick();
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

        private void btFKeyLeftClick_Click(object sender, EventArgs e)
        {
            Console.Write(sender.ToString());
        }

        private void btFKeyRightClick_Click(object sender, EventArgs e)
        {

        }

        private void btFKeyDoubleClick_Click(object sender, EventArgs e)
        {

        }

        private void btFKeyScroll_Click(object sender, EventArgs e)
        {

        }

        private void btFKeyDrapAndDrop_Click(object sender, EventArgs e)
        {

        }

        private void btClearFKeyLeftClick_Click(object sender, EventArgs e)
        {

        }

        private void btClearFKeyRightClick_Click(object sender, EventArgs e)
        {

        }

        private void btClearFKeyDoubleClick_Click(object sender, EventArgs e)
        {

        }

        private void btClearFKeyScroll_Click(object sender, EventArgs e)
        {

        }

        private void btClearFKeyDrapAndDrop_Click(object sender, EventArgs e)
        {

        }
    }
}
