using EyeXFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    public enum SystemState { Setup, Wait, KeyboardDisplayed, ActionButtonSelected, Zooming, Zoomed, ApplyAction, DisplayFeedback }
    public class StateManager
    {
        EyeXHost eyeXhost;
        FixationDetection fixationWorker;
        Form1 toolbar;
        Zoomer zoomer;
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

            Form1 form = new Form1(fixationWorker);

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
                        currentState = SystemState.DisplayFeedback;
                    }
                    break;
                case SystemState.ActionButtonSelected:
                    if (globalVars.firstZoomGaze)
                    {
                        currentState = SystemState.Zooming;
                    }
                    else if (globalVars.timeOut)
                    {
                        currentState = SystemState.DisplayFeedback;
                    }
                    break;
                case SystemState.Zooming:
                    currentState = SystemState.Zoomed;
                    break;
                case SystemState.Zoomed:
                    if (globalVars.secondZoomGaze)//if the second zoomGazehashapped an action needs to be performed
                    {
                        currentState = SystemState.ApplyAction;
                    }
                    else if (globalVars.timeOut)
                    {
                        currentState = SystemState.DisplayFeedback;
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
                    //get a fixation point and save what action was selected
                    //or timeOut
                    break;
                case SystemState.Zooming:
                    //create zoomer and have it zoom on the current fixation point
                    break;
                case SystemState.Zoomed:
                    //get another fixation point and pass it to the zoomer
                    //zoomer can check if that point is on it's own and can translate the coords to desktop
                    break;
                case SystemState.ApplyAction:
                    //get the desktop x,y from the zoomer
                    //give x,y and currentAction to virtualMouse
                    break;
                case SystemState.DisplayFeedback:
                    //Inform the user that gazing has ended (maybe a sound tone, or changing the button's colour)
                    break;
            }
        }
        public static class globalVars
        {
            public static bool isKeyBoardUP { get; set; }
            public static bool actionButtonSelected { get; set; }
            public static SystemState currentState { get; set; }
            public static bool firstZoomGaze { get; set; }
            public static bool secondZoomGaze { get; set; }
            public static bool timeOut { get; set; }
        }
    }
}
