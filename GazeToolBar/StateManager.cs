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
    public enum SystemState { Setup, Wait, KeyboardDisplayed, ActionButtonSelected, Zooming, ZoomWait, ApplyAction, DisplayFeedback }
    public enum ActionToBePerformed { RightClick, LeftClick, DoubleClick }
   
    public static class SystemFlags
    {
        public static bool isKeyBoardUP { get; set; }
        public static bool actionButtonSelected { get; set; }
        public static ActionToBePerformed actionToBePerformed { get; set; }
        public static SystemState currentState { get; set; }
        public static bool Gaze { get; set; }
        public static bool timeOut { get; set; }
    }
    
    public class StateManager
    {
        FixationDetection fixationWorker;
        Form1 toolbar;
        ZoomLens zoomer;
        Point fixationPoint;
        //optikey

        /*Things that need to change in other classes
         * Toolbar must raise the actionbuttonselected flag when an action button is selected
         * FixationDetection must raise flag when a timeout happens
         * Zoomer needs to accept a fixation point from the StateManager or it needs to figure out it's second point and return it to the StateManager
         * StateManger needs to save the x,y from the zoomer and it also needs to know which action was to be performed (Form will raise the flag based on what action was selected)
         * */

        public StateManager()
        {
            SystemFlags.currentState = SystemState.Setup;

            fixationWorker = new FixationDetection();


            SystemFlags.currentState = SystemState.Wait;
            Run();
        }
        public void Run()
        {
            while (true)
            {
                UpdateState();
                Action();
            }
        }
        public void UpdateState()
        {
            SystemState currentState = SystemFlags.currentState;
            switch (currentState)
            {
                case SystemState.Wait:
                    if (SystemFlags.actionButtonSelected) //if a button has been selected (raised by the form itself?)
                    {
                        currentState = SystemState.ActionButtonSelected;
                        SystemFlags.actionButtonSelected = false;
                    }
                    else if (SystemFlags.isKeyBoardUP) //Keyboard button is pressed
                    {
                        currentState = //SystemState.DisplayFeedback;
                            SystemState.Wait;
                    }
                    break;
                case SystemState.ActionButtonSelected:
                    if (SystemFlags.Gaze)
                    {
                        currentState = SystemState.Zooming;
                    }
                    else if (SystemFlags.timeOut)
                    {
                        currentState = //SystemState.DisplayFeedback;
                            SystemState.Wait;
                        SystemFlags.timeOut = false;
                    }
                    break;
                case SystemState.Zooming:
                    currentState = SystemState.ZoomWait;
                    break;
                case SystemState.ZoomWait:
                    if (SystemFlags.Gaze)//if the second zoomGazehashapped an action needs to be performed
                    {
                        currentState = SystemState.ApplyAction;
                    }
                    else if (SystemFlags.timeOut)
                    {
                        currentState = //SystemState.DisplayFeedback;
                            SystemState.Wait;
                        //get rid of zoom
                    }
                    break;
                case SystemState.ApplyAction:
                    //action is applied in action()
                    if (SystemFlags.isKeyBoardUP)
                    {
                        currentState = SystemState.KeyboardDisplayed;
                    }
                    else currentState = SystemState.Wait;
                    break;
                case SystemState.DisplayFeedback:
                    //feedback has been applied by action()
                    if (SystemFlags.isKeyBoardUP)
                    {
                        currentState = SystemState.KeyboardDisplayed;
                    }
                    else currentState = SystemState.Wait;
                    break;
            }
            SystemFlags.currentState = currentState;
        }
        public void Action()
        {
            switch (SystemFlags.currentState)
            {
                case SystemState.Setup:
                    break;
                case SystemState.Wait:
                    //set toolbar buttons to active
                    break;
                case SystemState.KeyboardDisplayed:
                    //set keyboard toolbar buttons to active
                    break;
                case SystemState.ActionButtonSelected:
                    //turn off form buttons
                    break;
                case SystemState.Zooming:
                    zoomer = new ZoomLens();
                    fixationPoint = fixationWorker.getXY();
                    zoomer.CreateZoomLens(fixationPoint);
                    SystemFlags.Gaze = false;
                    break;
                case SystemState.ZoomWait:
                    break;
                case SystemState.ApplyAction:
                    fixationPoint = fixationWorker.getXY();
                    fixationPoint = zoomer.TranslateGazePoint(fixationPoint);
                    if (fixationPoint.X == -1)
                    {
                        if (SystemFlags.isKeyBoardUP)
                        {
                            SystemFlags.currentState = SystemState.KeyboardDisplayed;
                        }
                        else
                        {
                            SystemFlags.currentState = SystemState.Wait;
                        }
                    }
                    else
                    {
                        //delete zoomer form or form hide or something
                        if (SystemFlags.actionToBePerformed == ActionToBePerformed.LeftClick)
                        {
                            VirtualMouse.LeftMouseClick(fixationPoint.X, fixationPoint.Y);
                        }
                        else if (SystemFlags.actionToBePerformed == ActionToBePerformed.RightClick)
                        {
                            VirtualMouse.RightMouseClick(fixationPoint.X, fixationPoint.Y);
                        }
                        else if (SystemFlags.actionToBePerformed == ActionToBePerformed.DoubleClick)
                        {
                            VirtualMouse.LeftDoubleClick(fixationPoint.X, fixationPoint.Y);
                        }
                    }

                    break;
                case SystemState.DisplayFeedback:
                    //Inform the user that gazing has ended (maybe a sound tone, or changing the button's colour)
                    break;
            }
        }

    }
}
