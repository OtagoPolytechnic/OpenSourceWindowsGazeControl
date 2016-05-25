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

        private int delayBeforeButtonSelected = 500;
        private void connectBehaveMap()
        {
            Program.EyeXHost.Connect(bhavMap);

            //Temp for 100 
            //Will change later
            bhavMap.Add(btnDoubleClick, new GazeAwareBehavior(OnBtnDoubleClick) { DelayMilliseconds = delayBeforeButtonSelected });
            //bhavMap.Add(btnDoubleClick, new GazeAwareBehavior(OnGazeShowBorder));
            bhavMap.Add(btnRightClick, new GazeAwareBehavior(OnBtnRightClick) { DelayMilliseconds = delayBeforeButtonSelected });

            bhavMap.Add(btnSingleLeftClick, new GazeAwareBehavior(OnBtnSingleClick) { DelayMilliseconds = delayBeforeButtonSelected });
            bhavMap.Add(btnSettings, new GazeAwareBehavior(OnBtnSettings) { DelayMilliseconds = delayBeforeButtonSelected });
            bhavMap.Add(btnScoll, new GazeAwareBehavior(OnBtnScroll) { DelayMilliseconds = delayBeforeButtonSelected });
            bhavMap.Add(btnKeyboard, new GazeAwareBehavior(OnBtnKeyboard) { DelayMilliseconds = delayBeforeButtonSelected });
            bhavMap.Add(btnDragAndDrop, new GazeAwareBehavior(OnBtnDragAndDrop) { DelayMilliseconds = delayBeforeButtonSelected });
        }

        private void OnGazeShowBorder(object s, GazeAwareEventArgs e)
        {
            Button sentButton = s as Button;
            if(sentButton != null)
            {
                sentButton.BackColor = (e.HasGaze) ? Color.Red : Color.FromArgb(173, 83, 201);
            }
        }


        private void OnBtnDoubleClick(object sender, EventArgs e)
        {
            //Reset the button color to its origin color
            resetButtonsColor();
            //Set this button to other color, so people know this button has selected
            btnDoubleClick.BackColor = ValueNeverChange.SelectedColor;
            //Click this button
            btnDoubleClick.PerformClick();
        }

        private void OnBtnRightClick(object sender, EventArgs e)
        {
            resetButtonsColor();
            btnRightClick.BackColor = ValueNeverChange.SelectedColor;
            btnRightClick.PerformClick();
        }

        private void OnBtnSingleClick(object sender, EventArgs e)
        {
            resetButtonsColor();
            btnSingleLeftClick.BackColor = ValueNeverChange.SelectedColor;
            btnSingleLeftClick.PerformClick();
        }

        private void OnBtnSettings(object sender, EventArgs e)
        {
            resetButtonsColor();
            btnSettings.BackColor = ValueNeverChange.SelectedColor;
            btnSettings.PerformClick();
        }

        private void OnBtnScroll(object sender, EventArgs e)
        {
            resetButtonsColor();
            btnScoll.BackColor = ValueNeverChange.SelectedColor;
            btnScoll.PerformClick();
        }

        private void OnBtnKeyboard(object sender, EventArgs e)
        {
            resetButtonsColor();
            btnKeyboard.BackColor = ValueNeverChange.SelectedColor;
            btnKeyboard.PerformClick();
        }

        private void OnBtnDragAndDrop(object sender, EventArgs e)
        {
            resetButtonsColor();
            btnDragAndDrop.BackColor = ValueNeverChange.SelectedColor;
            btnDragAndDrop.PerformClick();
        }

        private void resetButtonsColor()
        {
            ValueNeverChange.ResetBtnBackcolor(btnSingleLeftClick, btnDoubleClick, btnRightClick, btnSettings, btnScoll, btnKeyboard, btnDragAndDrop);
        }
    }
}
