using EyeXFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    partial class Settings 
    {
        private void connectBehaveMap()
        {
            Program.EyeXHost.Connect(bhavSettingMap);

            //Temp for 100 
            //Will change later
            bhavSettingMap.Add(btnAutoStart, new GazeAwareBehavior(OnbtnAutoStart_Click) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
            bhavSettingMap.Add(btnGaze, new GazeAwareBehavior(OnbtnGaze_Click) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
            bhavSettingMap.Add(btnSave, new GazeAwareBehavior(OnbtnSave_Click) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
            bhavSettingMap.Add(btnCancel, new GazeAwareBehavior(OnbtnCancel_Click) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
            bhavSettingMap.Add(btnChangeLanguage, new GazeAwareBehavior(OnbtnChangeLanguage_Click) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
            bhavSettingMap.Add(btnChangeSide, new GazeAwareBehavior(OnbtnChangeSide_Click) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
            bhavSettingMap.Add(btnSizeLarge, new GazeAwareBehavior(OnbtnSizeLarge_Click) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
            bhavSettingMap.Add(btnSwitch, new GazeAwareBehavior(OnbtnSwitch_Click) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
            bhavSettingMap.Add(trackBarPrecision, new GazeAwareBehavior(OntrackBarPrecision_Scroll) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
            bhavSettingMap.Add(trackBarSpeed, new GazeAwareBehavior(OntrackBarSpeed_Scroll) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
            bhavSettingMap.Add(btnWordPredictionOnOff, new GazeAwareBehavior(OnbtnWordPredictionOnOff_Click) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
            bhavSettingMap.Add(btnSizeSmall, new GazeAwareBehavior(OnbtnSizeSmall_Click) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
            bhavSettingMap.Add(btnSoundFeedback, new GazeAwareBehavior(OnbtnSoundFeedback_Click) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
            bhavSettingMap.Add(trackBarGazeTypingSpeed, new GazeAwareBehavior(OntrackBarGazeTypingSpeed_Scroll) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
        }

        private void OntrackBarGazeTypingSpeed_Scroll(object sender, GazeAwareEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnbtnSoundFeedback_Click(object sender, GazeAwareEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnbtnSizeSmall_Click(object sender, GazeAwareEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnbtnWordPredictionOnOff_Click(object sender, GazeAwareEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OntrackBarSpeed_Scroll(object sender, GazeAwareEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OntrackBarPrecision_Scroll(object sender, GazeAwareEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnbtnSwitch_Click(object sender, GazeAwareEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnbtnSizeLarge_Click(object sender, GazeAwareEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnbtnChangeSide_Click(object sender, GazeAwareEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnbtnChangeLanguage_Click(object sender, GazeAwareEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnbtnCancel_Click(object sender, GazeAwareEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnbtnSave_Click(object sender, GazeAwareEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnbtnGaze_Click(object sender, GazeAwareEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnbtnAutoStart_Click(object sender, GazeAwareEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
