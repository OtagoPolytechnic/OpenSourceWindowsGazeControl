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
    public enum Edge { NoEdge = -1, Top, Right, Bottom, Left, TopLeft, TopRight, BottomLeft, BottomRight }
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
        public static bool ShortCutKeyPressed { get; set; }


    }

    public class StateManager
    {
        FixationDetection fixationWorker;
        ScrollControl scrollWorker;
        Form1 toolbar;
        ZoomLens zoomer;
        Point fixationPoint;
        Corner corner;
        Edge edge;
        Edge edge2;
        SystemState currentState;

        ShortcutKeyWorker shortCutKeyWorker;

        //optikey?

        /*Things that need to change in other classes
         * Toolbar must raise the actionbuttonselected flag when an action button is selected
         * FixationDetection must raise flag when a timeout happens
         * Zoomer needs to accept a fixation point from the StateManager or it needs to figure out it's second point and return it to the StateManager
         * StateManger needs to save the x,y from the zoomer and it also needs to know which action was to be performed (Form will raise the flag based on what action was selected)
         * */

        public StateManager(Form1 Toolbar, ShortcutKeyWorker shortCutKeyWorker)
        {
            toolbar = Toolbar;

            SystemFlags.currentState = SystemState.Setup;

            fixationWorker = new FixationDetection();

            scrollWorker = new ScrollControl(200, 5, 50, 20);

            SystemFlags.currentState = SystemState.Wait;

            SystemFlags.HasSelectedButtonColourBeenReset = true;

            zoomer = new ZoomLens(fixationWorker);

            Console.WriteLine(scrollWorker.deadZoneRect.LeftBound + "," + scrollWorker.deadZoneRect.RightBound + "," + scrollWorker.deadZoneRect.TopBound + "," + scrollWorker.deadZoneRect.BottomBound);
            corner = new Corner();

            this.shortCutKeyWorker = shortCutKeyWorker;

            Run();
        }
        public void Run()
        {
            UpdateState();
            Action();
        }
        public void EnterWaitState()
        {
            //these flags are here so that they get reset before anything else happens in the SM
            //these were previously in the action method but that causes issues because the update state is run again before all of the flags are reset.
            SystemFlags.FixationRunning = false;
            SystemFlags.actionButtonSelected = false;
            SystemFlags.FixationRunning = false;
            SystemFlags.Gaze = false;
            SystemFlags.timeOut = false;
            currentState = SystemState.Wait;
        }
        public void UpdateState()
        {
            currentState = SystemFlags.currentState;
            switch (currentState)
            {
                case SystemState.Wait:
                    Console.WriteLine("Wait State");
                    if (SystemFlags.actionButtonSelected) //if a button has been selected (raised by the form itself?)
                    {
                        currentState = SystemState.ActionButtonSelected;
                        SystemFlags.actionButtonSelected = false;
                    }
                    else if (SystemFlags.isKeyBoardUP) //Keyboard button is pressed
                    {
                        EnterWaitState();
                        //currentState = //SystemState.DisplayFeedback;
                        // SystemState.Wait;
                    }
                    else if (SystemFlags.ShortCutKeyPressed)
                    {
                        currentState = SystemState.Zooming;
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
                        EnterWaitState();
                        //currentState = //SystemState.DisplayFeedback;
                        //SystemState.Wait;
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
                        EnterWaitState();
                        //currentState = //SystemState.DisplayFeedback;
                        //    SystemState.Wait;
                        //get rid of zoom
                        zoomer.ResetZoomLens();
                    }

                    break;
                case SystemState.ScrollWait:

                    Console.WriteLine(currentState);

                    if (!SystemFlags.Scrolling)
                        EnterWaitState();
                    //currentState = SystemState.Wait;
                    break;
                case SystemState.ApplyAction:
                    Console.WriteLine("ApplyAction");
                    //action is applied in action()
                    if (SystemFlags.isKeyBoardUP)
                    {
                        currentState = SystemState.KeyboardDisplayed;
                    }
                    else if (SystemFlags.Scrolling)
                    {
                        currentState = SystemState.ScrollWait;
                    }
                    else EnterWaitState();//currentState = SystemState.Wait;
                    break;
                case SystemState.DisplayFeedback:
                    //feedback has been applied by action()
                    if (SystemFlags.isKeyBoardUP)
                    {
                        currentState = SystemState.KeyboardDisplayed;
                    }
                    else EnterWaitState();//currentState = SystemState.Wait;
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

                    if (SystemFlags.HasSelectedButtonColourBeenReset == false)
                    {
                        toolbar.resetButtonsColor();
                        SystemFlags.HasSelectedButtonColourBeenReset = true;
                    }
                    //set toolbar buttons to active
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

                    if (SystemFlags.ShortCutKeyPressed)
                    {
                        fixationPoint = shortCutKeyWorker.GetXY();
                        SystemFlags.ShortCutKeyPressed = false;
                    }
                    else
                    {

                        fixationPoint = fixationWorker.getXY();//get the location the user looked

                    }

                    //corner = (Corner)zoomer.checkCorners(fixationPoint);

                    //zoomer.checkEdge();
                    zoomer.determineDesktopLocation(fixationPoint, (int)Corner.NoCorner);
                    edge = zoomer.checkEdge();

                    //need to set the lens point based on which edge was triggered
                    //and then caluclate the offset for when the user actually clicks
                    zoomer.SetLensPoint(fixationPoint, edge);

                    zoomer.TakeScreenShot();
                    zoomer.CreateZoomLens(fixationPoint);//create a zoom lens at this location
                    SystemFlags.Gaze = false;
                    SystemFlags.FixationRunning = false;

                    break;
                case SystemState.ZoomWait:
                    if (!SystemFlags.FixationRunning)
                    {
                        fixationWorker.StartDetectingFixation();
                        SystemFlags.FixationRunning = true;
                    }
                    break;

                case SystemState.ApplyAction: //the fixation on the zoom lens has been detected

                    fixationPoint = fixationWorker.getXY();
                    zoomer.ResetZoomLens();//hide the lens
                    fixationPoint = zoomer.edgeOffset(edge, fixationPoint);
                    fixationPoint = zoomer.TranslateGazePoint(fixationPoint);//translate the form coordinates to the desktop
                    //fixationPoint = zoomer.CornerOffset(corner, fixationPoint);//account for corner offset (this method only does anything if the user has looked in a corner zone)


                    if (fixationPoint.X == -1)//check if it's out of bounds
                    {
                        if (SystemFlags.isKeyBoardUP)
                        {
                            SystemFlags.currentState = SystemState.KeyboardDisplayed;
                        }
                        else
                        {
                            EnterWaitState();//SystemFlags.currentState = SystemState.Wait;
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
