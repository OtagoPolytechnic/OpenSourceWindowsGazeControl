using EyeXFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    public enum SystemState { Setup, Wait, KeyboardDisplayed, ActionButtonSelected, Zooming, Zoomed, ApplyAction, DisplayFeedback }
    public enum ActionToBePerformed { RightClick, LeftClick, DoubleClick }
   
    public static class globalVars
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
        EyeXHost eyeXhost;
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
            globalVars.currentState = SystemState.Setup;

            eyeXhost = new EyeXHost();
            eyeXhost.Start();
            fixationWorker = new FixationDetection(eyeXhost);

            Form1 form = new Form1(eyeXhost);

            globalVars.currentState = SystemState.Wait;

        }
        public void UpdateState()
        {
            SystemState currentState = globalVars.currentState;
            switch (currentState)
            {
                case SystemState.Wait:
                    if (globalVars.actionButtonSelected) //if a button has been selected (raised by the form itself?)
                    {
                        currentState = SystemState.ActionButtonSelected;
                        globalVars.actionButtonSelected = false;
                    }
                    else if (globalVars.isKeyBoardUP) //Keyboard button is pressed
                    {
                        currentState = //SystemState.DisplayFeedback;
                            SystemState.Wait;
                    }
                    break;
                case SystemState.ActionButtonSelected:
                    if (globalVars.Gaze)
                    {
                        currentState = SystemState.Zooming;
                    }
                    else if (globalVars.timeOut)
                    {
                        currentState = //SystemState.DisplayFeedback;
                            SystemState.Wait;
                        globalVars.timeOut = false;
                    }
                    break;
                case SystemState.Zooming:
                    currentState = SystemState.Zoomed;
                    break;
                case SystemState.Zoomed:
                    if (globalVars.Gaze)//if the second zoomGazehashapped an action needs to be performed
                    {
                        currentState = SystemState.ApplyAction;
                    }
                    else if (globalVars.timeOut)
                    {
                        currentState = //SystemState.DisplayFeedback;
                            SystemState.Wait;
                    }
                    break;
                case SystemState.ApplyAction:
                    //action is applied in action()
                    if (globalVars.isKeyBoardUP)
                    {
                        currentState = SystemState.KeyboardDisplayed;
                    }
                    else currentState = SystemState.Wait;
                    break;
                case SystemState.DisplayFeedback:
                    //feedback has been applied by action()
                    if (globalVars.isKeyBoardUP)
                    {
                        currentState = SystemState.KeyboardDisplayed;
                    }
                    else currentState = SystemState.Wait;
                    break;
            }
            globalVars.currentState = currentState;
        }
        public void Action()
        {
            switch (globalVars.currentState)
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
                    if (globalVars.Gaze)
                    {
                        fixationPoint = fixationWorker.getXY();
                        globalVars.Gaze = false;
                    }
                    break;
                case SystemState.Zooming:
                    zoomer = new ZoomLens(eyeXhost);
                    fixationPoint = zoomer.CreateZoomLens(fixationPoint);
                    break;
                case SystemState.Zoomed:
                    if (globalVars.Gaze)
                    {
                        zoomer.clickGazePoint(fixationPoint);//this returns the middle of the form for now, later it will translate the coordinates and give a real location
                    }
                    //get another fixation point and pass it to the zoomer
                    //zoomer can check if that point is on it's own and can translate the coords to desktop
                    break;
                case SystemState.ApplyAction:
                    if (globalVars.actionToBePerformed == ActionToBePerformed.LeftClick)
                    {
                        VirtualMouse.LeftMouseClick(fixationPoint.X, fixationPoint.Y);
                    }
                    else if (globalVars.actionToBePerformed == ActionToBePerformed.RightClick)
                    {
                        VirtualMouse.RightMouseClick(fixationPoint.X, fixationPoint.Y);
                    }
                    else if (globalVars.actionToBePerformed == ActionToBePerformed.DoubleClick)
                    {
                        VirtualMouse.LeftDoubleClick(fixationPoint.X, fixationPoint.Y);
                    }
                    break;
                case SystemState.DisplayFeedback:
                    //Inform the user that gazing has ended (maybe a sound tone, or changing the button's colour)
                    break;
            }
        }

    }
}
