using EyeXFramework;
using EyeXFramework.Forms;
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
    public enum SystemState { Wait, ActionButtonSelected, Zooming, ZoomWait, ApplyAction, ScrollWait }
    public enum ActionToBePerformed { RightClick, LeftClick, DoubleClick, Scroll }
    public enum Corner { NoCorner = -1, TopLeft, TopRight, BottomLeft, BottomRight }
    public enum Edge { NoEdge = -1, Top, Right, Bottom, Left, TopLeft, TopRight, BottomLeft, BottomRight }

    public static class SystemFlags
    {
        public static bool isKeyBoardUP { get; set; }
        public static bool actionButtonSelected { get; set; }
        public static ActionToBePerformed actionToBePerformed { get; set; }
        public static SystemState currentState { get; set; }
        public static bool gaze { get; set; }
        public static bool timeOut { get; set; }
        public static bool fixationRunning { get; set; }
        public static bool hasSelectedButtonColourBeenReset { get; set; }
        public static bool scrolling { get; set; }
        public static bool shortCutKeyPressed { get; set; }
    }
    public class StateManager
    {
        public FixationDetection fixationWorker;
        ScrollControl scrollWorker;
        Form1 toolbar;
        ZoomLens zoomer;
        Point fixationPoint;
        Corner corner;
        Edge edge;
        SystemState currentState;
        FormsEyeXHost eyeXHost;
        bool cornerBool = false;
        bool edgeBool = false;

        ShortcutKeyWorker shortCutKeyWorker;
        

        public StateManager(Form1 Toolbar, ShortcutKeyWorker shortCutKeyWorker, FormsEyeXHost EyeXHost)
        {
            eyeXHost = EyeXHost;
            toolbar = Toolbar;

            SystemFlags.currentState = SystemState.Wait;

            fixationWorker = new FixationDetection(eyeXHost);

            scrollWorker = new ScrollControl(200, 5, 50, 20, eyeXHost);

            SystemFlags.currentState = SystemState.Wait;

            SystemFlags.hasSelectedButtonColourBeenReset = true;

            zoomer = new ZoomLens(fixationWorker, eyeXHost);

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
            SystemFlags.fixationRunning = false;
            SystemFlags.actionButtonSelected = false;
            SystemFlags.fixationRunning = false;
            SystemFlags.gaze = false;
            SystemFlags.timeOut = false;
            currentState = SystemState.Wait;
        }
        //The update method is responsible for transitioning from state to state. Once a state is changed the action() method is run
        public void UpdateState()
        {
            currentState = SystemFlags.currentState;
            switch (currentState)
            {
                case SystemState.Wait:
                    if (SystemFlags.actionButtonSelected) //if a button has been selected from the toolbar
                    {
                        currentState = SystemState.ActionButtonSelected;
                        SystemFlags.actionButtonSelected = false;
                    }
                    else if (SystemFlags.shortCutKeyPressed)
                    {
                        currentState = SystemState.Zooming;
                    }
                    break;
                case SystemState.ActionButtonSelected:
                    SystemFlags.hasSelectedButtonColourBeenReset = false;
                    if (SystemFlags.gaze)
                    {
                        currentState = SystemState.Zooming;
                    }
                    else if (SystemFlags.timeOut)
                    {
                        EnterWaitState();
                        SystemFlags.timeOut = false;
                    }
                    break;
                case SystemState.Zooming:
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
                    if (SystemFlags.gaze)//if the second zoomGaze has happed an action needs to be performed
                    {
                        currentState = SystemState.ApplyAction;
                    }
                    else if (SystemFlags.timeOut)
                    {
                        EnterWaitState();
                        zoomer.ResetZoomLens();
                    }
                    break;
                case SystemState.ScrollWait:
                    if (!SystemFlags.scrolling)
                    {
                        EnterWaitState();
                    }
                    break;
                case SystemState.ApplyAction:
                    if (SystemFlags.scrolling)
                    {
                        currentState = SystemState.ScrollWait;
                    }
                    else
                    {
                        EnterWaitState();
                    }
                    break;
            }
            SystemFlags.currentState = currentState;
        }
        //The action state is responsible for completing each action that must take place during each state
        public void Action()
        {
            switch (SystemFlags.currentState)
            {
                case SystemState.Wait:
                    if (SystemFlags.hasSelectedButtonColourBeenReset == false)
                    {
                        toolbar.resetButtonsColor();
                        SystemFlags.hasSelectedButtonColourBeenReset = true;
                    }
                    break;
                case SystemState.ActionButtonSelected:
                    scrollWorker.stopScroll();
                    if (!SystemFlags.fixationRunning)
                    {
                        fixationWorker.StartDetectingFixation();
                        SystemFlags.fixationRunning = true;
                    }
                    break;
                case SystemState.Zooming:
                    if (SystemFlags.shortCutKeyPressed)//if a user defined click key is pressed
                    {
                        fixationPoint = shortCutKeyWorker.GetXY();
                        SystemFlags.shortCutKeyPressed = false;
                    }
                    else
                    {
                        fixationPoint = fixationWorker.getXY();//get the location the user looked
                    }
                    //zoomLens setup
                    zoomer.determineDesktopLocation(fixationPoint);
                    //checking if the user looked in a corner
                    corner = zoomer.checkCorners(fixationPoint);
                    //Checking if a user looked near an edge
                    edge = zoomer.checkEdge();
                    cornerBool = false;
                    edgeBool = false;
                    if (corner != Corner.NoCorner)//if the user looked in a corner
                    {
                        zoomer.setZoomLensPositionCorner(corner);//set the lens into the corner
                        cornerBool = true;
                    }
                    else if (edge != Edge.NoEdge)//if there is no corner and the user looked near the edge of the screen
                    {
                        zoomer.setZoomLensPositionEdge(edge, fixationPoint);//set lens to edge
                        edgeBool = true;
                    }

                    zoomer.TakeScreenShot();//This is taking the screenshot that will be zoomed in on
                    zoomer.CreateZoomLens(fixationPoint);//create a zoom lens at this location
                    //disable neccesary flags
                    SystemFlags.gaze = false;
                    SystemFlags.fixationRunning = false;
                    break;
                case SystemState.ZoomWait://waiting for user to fixate
                    if (!SystemFlags.fixationRunning)
                    {
                        fixationWorker.StartDetectingFixation();
                        SystemFlags.fixationRunning = true;
                    }
                    break;
                case SystemState.ApplyAction: //the fixation on the zoom lens has been detected

                    fixationPoint = fixationWorker.getXY();
                    zoomer.ResetZoomLens();//hide the lens
                    fixationPoint = zoomer.TranslateGazePoint(fixationPoint);//translate the form coordinates to the desktop

                    //Checking if the user has zoomed in on an edge or a corner and offsetting the zoomed in click calculations to account for the
                    //different location of the screenshot
                    //e.g when a corner is selected the program zooms into the corner instead of the middle of the zoomlens, this means that for the final point to be accurate
                    //there must be an offset to account for the different zoom direction.
                    if (cornerBool)
                    {
                        fixationPoint = zoomer.cornerOffset(corner, fixationPoint);
                    }
                    else if (edgeBool)
                    {
                        fixationPoint = zoomer.edgeOffset(edge, fixationPoint);
                    }
                    if (fixationPoint.X == -1)//check if it's out of bounds
                    {
                        EnterWaitState();
                    }
                    else
                    {
                        //execute the appropriate action
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
                            SystemFlags.scrolling = true;
                            VirtualMouse.SetCursorPos(fixationPoint.X, fixationPoint.Y);
                            scrollWorker.StartScroll();
                        }
                    }
                    break;
            }
        }
    }
}
