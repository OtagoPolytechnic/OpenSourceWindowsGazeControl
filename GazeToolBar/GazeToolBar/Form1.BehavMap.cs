using EyeXFramework;
using System;
using System.Drawing;

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
        private void connectBehaveMap()
        {
            Program.EyeXHost.Connect(bhavMap);

            //Temp for 100 
            //Will change later
            bhavMap.Add(btnDoubleClick, new GazeAwareBehavior(OnBtnDoubleClick) { DelayMilliseconds = 100 });
            bhavMap.Add(btnRightClick, new GazeAwareBehavior(OnBtnRightClick) { DelayMilliseconds = 100 });
            bhavMap.Add(btnSingleClick, new GazeAwareBehavior(OnBtnSingleClick) { DelayMilliseconds = 100 });
            bhavMap.Add(btnSettings, new GazeAwareBehavior(OnBtnSettings) { DelayMilliseconds = 100 });
            bhavMap.Add(btnScoll, new GazeAwareBehavior(OnBtnScroll) { DelayMilliseconds = 100 });
            bhavMap.Add(btnKeyboard, new GazeAwareBehavior(OnBtnKeyboard) { DelayMilliseconds = 100 });
            bhavMap.Add(btnDragAndDrop, new GazeAwareBehavior(OnBtnDragAndDrop) { DelayMilliseconds = 100 });
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
            btnSingleClick.BackColor = ValueNeverChange.SelectedColor;
            btnSingleClick.PerformClick();
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
            ValueNeverChange.ResetBtnBackcolor(btnSingleClick, btnDoubleClick, btnRightClick, btnSettings, btnScoll, btnKeyboard, btnDragAndDrop);
        }
    }
}
