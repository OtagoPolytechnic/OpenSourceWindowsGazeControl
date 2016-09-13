using EyeXFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazeToolBar
{
    public enum SystemState { Setup, Wait, KeyboardDisplayed, ActionButtonSelected, Zooming, ZoomWait, ApplyAction, DisplayFeedback, ScrollWait }
    public enum ActionToBePerformed { RightClick, LeftClick, DoubleClick, Scroll }

    public enum Corner { NoCorner = -1, TopLeft, TopRight, BottomLeft, BottomRight }
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
        public static bool Scrolling { get; set; }
        
    }

    public class StateManager
    {
        FixationDetection fixationWorker;
        ScrollControl scrollWorker;
        Form1 toolbar;
        ZoomLens zoomer;
        Point fixationPoint;
        Corner corner;
        //optikey?


        public StateManager(Form1 Toolbar)
        {
            toolbar = Toolbar;

            SystemFlags.currentState = SystemState.Setup;

            fixationWorker = new FixationDetection();

            scrollWorker = new ScrollControl(200, 50, 20);

            SystemFlags.currentState = SystemState.Wait;

            SystemFlags.HasSelectedButtonColourBeenReset = true;

            zoomer = new ZoomLens(fixationWorker);

            Console.WriteLine(scrollWorker.deadZoneRect.LeftBound + "," + scrollWorker.deadZoneRect.RightBound + "," + scrollWorker.deadZoneRect.TopBound + "," + scrollWorker.deadZoneRect.BottomBound );
            corner = new Corner();

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

                    if (SystemFlags.actionToBePerformed == ActionToBePerformed.Scroll)
                    {
                        currentState = SystemState.ApplyAction;
                    }
                    else
                    {
                        currentState = SystemState.ZoomWait;
                    }
                    break;
                case SystemState.ZoomWait:
                    Console.WriteLine("ZoomWait");
                    if (SystemFlags.Gaze)//if the second zoomGaze has happed an action needs to be performed
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
                case SystemState.ScrollWait:

                    Console.WriteLine(currentState);

                    if (!SystemFlags.Scrolling)
                        currentState = SystemState.Wait;
                    break;

                case SystemState.ApplyAction:
                    Console.WriteLine("ApplyAction");
                    //action is applied in action()
                    if (SystemFlags.isKeyBoardUP)
                    {
                        currentState = SystemState.KeyboardDisplayed;
                    }else if (SystemFlags.Scrolling)
                    {
                        currentState = SystemState.ScrollWait;
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
                    if (SystemFlags.HasSelectedButtonColourBeenReset == false)
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
                    corner = (Corner)zoomer.checkCorners(fixationPoint);
                    zoomer.determineDesktopLocation(fixationPoint, (int)(corner));
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
                case SystemState.ApplyAction: //the fixation on the zoom lens has been detected
                    fixationPoint = fixationWorker.getXY();
                    zoomer.ResetZoomLens();//hide the lens
                    fixationPoint = zoomer.TranslateGazePoint(fixationPoint);//translate the form coordinates to the desktop
                    fixationPoint = zoomer.CornerOffset(corner, fixationPoint);//account for corner offset (this method only does anything if the user has looked in a corner zone)
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
                        else if (SystemFlags.actionToBePerformed == ActionToBePerformed.Scroll)
                        {

                            SystemFlags.currentState = SystemState.ScrollWait;
                            SystemFlags.Scrolling = true;
                            VirtualMouse.SetCursorPos(fixationPoint.X, fixationPoint.Y);
                            scrollWorker.startScroll();
                           
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
