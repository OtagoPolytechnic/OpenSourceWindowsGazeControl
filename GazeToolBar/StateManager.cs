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
        public static bool FixationRunning { get; set; }
        public static bool HasSelectedButtonColourBeenReset { get; set; }
    }

    public class StateManager
    {
        FixationDetection fixationWorker;
        Form1 toolbar;
        ZoomLens zoomer;
        Point fixationPoint;
        //optikey?


        public StateManager(Form1 Toolbar)
        {
            toolbar = Toolbar;

            SystemFlags.currentState = SystemState.Setup;

            fixationWorker = new FixationDetection();

            SystemFlags.currentState = SystemState.Wait;

            SystemFlags.HasSelectedButtonColourBeenReset = true;

            zoomer = new ZoomLens(fixationWorker);

            Run();
        }
        public void Run()
        {
            UpdateState();
            Action();
        }

        /*The statemanager works by running the update state, which determines what state the system needs to be in.
         * Then the state action method is run, this method will run the appropriate code based on what state the system is in.
         */
        public void UpdateState()
        {
            SystemState currentState = SystemFlags.currentState;
            switch (currentState)
            {
                case SystemState.Wait:
                    Console.WriteLine("Wait State");
                    // moved to apply action zoomer.ResetZoomLens();
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
                    Console.WriteLine("ActionButtonSelected");
                    SystemFlags.HasSelectedButtonColourBeenReset = false;
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
                    Console.WriteLine("Zooming");
                    currentState = SystemState.ZoomWait;
                    break;
                case SystemState.ZoomWait:
                    Console.WriteLine("ZoomWait");
                    
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
                    Console.WriteLine("ApplyAction");
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
                    break;//no action
                case SystemState.Wait:
                    //turn reset state to wait mode
                    SystemFlags.FixationRunning = false;
                    SystemFlags.actionButtonSelected = false;
                    SystemFlags.FixationRunning = false;
                    SystemFlags.Gaze = false;
                    SystemFlags.timeOut = false;
                    if(SystemFlags.HasSelectedButtonColourBeenReset == false)
                    {
                        toolbar.resetButtonsColor();
                        SystemFlags.HasSelectedButtonColourBeenReset = true;
                    }
                    break;
                case SystemState.KeyboardDisplayed:
                    //set keyboard toolbar buttons to active
                    break;
                case SystemState.ActionButtonSelected:
                    if (!SystemFlags.FixationRunning)
                    {
                        fixationWorker.StartDetectingFixation();
                        SystemFlags.FixationRunning = true;
                    }
                    //turn off form buttons
                    break;
                case SystemState.Zooming:
                    fixationPoint = fixationWorker.getXY();//get the location the user looked
                    int corner = zoomer.checkCorners(fixationPoint);
                    //Point lensPoint = new Point();
                    //Point DesktopLocation = new Point();
                    zoomer.determineDesktopLocation(fixationPoint, corner);
                    zoomer.TakeScreenShot();
                    zoomer.CreateZoomLens(fixationPoint);//create a zoom lens at this location

                    SystemFlags.Gaze = false;
                    SystemFlags.FixationRunning = false;
                    break;
                case SystemState.ZoomWait://waiting for the fixation on the zoom window
                    if (!SystemFlags.FixationRunning)
                    {
                        fixationWorker.StartDetectingFixation();
                        SystemFlags.FixationRunning = true;
                    }
                    break;
                case SystemState.ApplyAction://the fixation on the zoom lens has been detected
                    fixationPoint = fixationWorker.getXY();
                    zoomer.ResetZoomLens();//hide the lens
                    fixationPoint = zoomer.TranslateGazePoint(fixationPoint);//translate the form coordinates to the desktop
                    if (fixationPoint.X == -1)//check if it's out of bounds
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
