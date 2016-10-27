using EyeXFramework;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GazeToolBar
{
    /*
        Date: 17/05/2016
        Name: Derek Dai
        Description: Partial class of form1, so just make it more clear
    */
    partial class Form1
    {
        /// <summary>
        /// Connect behave map with buttons
        /// and add event to the behave map
        /// </summary>
        /// 

        private int delayBeforeButtonSelected = 1000;
        private void connectBehaveMap()
        {
            eyeXHost.Connect(bhavMap);
            eyeXHost.Connect(bhavMapHLCurrentGazeOnBT);

            
            //Will change later
            bhavMap.Add(btnDoubleClick, new GazeAwareBehavior(OnBtnDoubleClick) { DelayMilliseconds = delayBeforeButtonSelected });
            bhavMap.Add(btnRightClick, new GazeAwareBehavior(OnBtnRightClick) { DelayMilliseconds = delayBeforeButtonSelected });
            bhavMap.Add(btnSingleLeftClick, new GazeAwareBehavior(OnBtnSingleClick) { DelayMilliseconds = delayBeforeButtonSelected });
            bhavMap.Add(btnSettings, new GazeAwareBehavior(OnBtnSettings) { DelayMilliseconds = delayBeforeButtonSelected });
            bhavMap.Add(btnScoll, new GazeAwareBehavior(OnBtnScroll) { DelayMilliseconds = delayBeforeButtonSelected });
            bhavMap.Add(btnKeyboard, new GazeAwareBehavior(OnBtnKeyboard) { DelayMilliseconds = delayBeforeButtonSelected });
            //bhavMap.Add(btnDragAndDrop, new GazeAwareBehavior(OnBtnDragAndDrop) { DelayMilliseconds = delayBeforeButtonSelected });

            bhavMap.Add(pnlHiLteRightClick, new GazeAwareBehavior(OnGazeChangeBTColour));
            bhavMap.Add(pnlHighLightDoubleClick, new GazeAwareBehavior(OnGazeChangeBTColour));
            //bhavMap.Add(pnlHighLightDragAndDrop, new GazeAwareBehavior(OnGazeChangeBTColour));
            bhavMap.Add(pnlHighLightScrol, new GazeAwareBehavior(OnGazeChangeBTColour));
            bhavMap.Add(pnlHighLightSettings, new GazeAwareBehavior(OnGazeChangeBTColour));
            bhavMap.Add(pnlHighLightSingleLeft, new GazeAwareBehavior(OnGazeChangeBTColour));
            bhavMap.Add(pnlHighLightKeyboard, new GazeAwareBehavior(OnGazeChangeBTColour));

            
        }


        //toggle border on and off on gaze to gaze to give feed back.
        private void OnGazeChangeBTColour(object s, GazeAwareEventArgs e)
        {
            var sentButton = s as Panel;
            if(sentButton != null)
            {
                sentButton.BackColor = (e.HasGaze) ? Color.Red : Color.Black;
            }
        }


        private void OnBtnDoubleClick(object sender, GazeAwareEventArgs e)
        {
            if (e.HasGaze)
            {
                //Reset the button color to its origin color
                resetButtonsColor();
                //Set this button to other color, so people know this button has selected
                btnDoubleClick.BackColor = ValueNeverChange.SelectedColor;
                //Click this button
                btnDoubleClick.PerformClick();
            }
        }

        private void OnBtnRightClick(object sender, GazeAwareEventArgs e)
        {
            if (e.HasGaze)
            {
                resetButtonsColor();
                btnRightClick.BackColor = ValueNeverChange.SelectedColor;
                btnRightClick.PerformClick();
            }
        }

        private void OnBtnSingleClick(object sender, GazeAwareEventArgs e)
        {
            if (e.HasGaze)
            {
                resetButtonsColor();
                btnSingleLeftClick.BackColor = ValueNeverChange.SelectedColor;
                btnSingleLeftClick.PerformClick();
            }
        }

        private void OnBtnSettings(object sender, GazeAwareEventArgs e)
        {
            if (e.HasGaze)
            {
                resetButtonsColor();
                btnSettings.PerformClick();
            }
        }

        private void OnBtnScroll(object sender, GazeAwareEventArgs e)
        {
            if (e.HasGaze)
            {
                resetButtonsColor();
                btnScoll.BackColor = ValueNeverChange.SelectedColor;
                btnScoll.PerformClick();
            }
        }

        private void OnBtnKeyboard(object sender, GazeAwareEventArgs e)
        {
            if (e.HasGaze)
            {
                resetButtonsColor();
                btnKeyboard.PerformClick();
            }
        }

        //private void OnBtnDragAndDrop(object sender, EventArgs e)
        //{
        //    resetButtonsColor();
        //    btnDragAndDrop.BackColor = ValueNeverChange.SelectedColor;
        //    btnDragAndDrop.PerformClick();
        //}

        public void resetButtonsColor()
        {
            ResetBtnBackcolor(btnSingleLeftClick, btnDoubleClick, btnRightClick, btnSettings, btnScoll, btnKeyboard);
        }

        /// <summary>
        /// By calling this method all the buttons that passed in will be reset its color
        /// </summary>
        /// <param name="button">Buttons that will be reset on</param>
        void ResetBtnBackcolor(params Button[] button)
        {
            foreach (Button b in button)
            {
                b.BackColor = Color.Black;
            }
        }
    }
}
