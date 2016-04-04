using EyeXFramework;
using System;

namespace GazeToolBar
{
    partial class Form1
    {
        /// <summary>
        /// Connect behave map with buttons
        /// and add event to the behave map
        /// </summary>
        private void connectBehaveMap()
        {
            Program.EyeXHost.Connect(bhavMapDoubleClick);
            Program.EyeXHost.Connect(bhavMapRightClick);
            Program.EyeXHost.Connect(bhavMapSingleClick);
            Program.EyeXHost.Connect(bhavMapSettings);

            bhavMapDoubleClick.Add(btnDoubleClick, new GazeAwareBehavior(OnBtnDoubleClick) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
            bhavMapRightClick.Add(btnRightClick, new GazeAwareBehavior(OnBtnRightClick) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
            bhavMapSingleClick.Add(btnSingleClick, new GazeAwareBehavior(OnBtnSingleClick) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
            bhavMapSettings.Add(btnSettings, new GazeAwareBehavior(OnBtnSettings) { DelayMilliseconds = ValueNeverChange.DELAY_MILLISECONDS });
        }

        private void OnBtnDoubleClick(object sender, EventArgs e)
        {
            btnDoubleClick.PerformClick();
        }

        private void OnBtnRightClick(object sender, EventArgs e)
        {
            btnRightClick.PerformClick();
        }

        private void OnBtnSingleClick(object sender, EventArgs e)
        {
            btnSingleClick.PerformClick();
        }

        private void OnBtnSettings(object sender, EventArgs e)
        {
            btnSettings.PerformClick();
        }
    }
}
