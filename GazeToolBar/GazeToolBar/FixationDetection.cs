using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeXFramework;
using Tobii.EyeX.Framework;
using Tobii.EyeX.Client;
using System.Timers;

namespace GazeToolBar
{

    public enum EFixationState { WaitingForInPutSelection, RunningFixationWithSelection };
    public class FixationDetection
    {
        private static Timer aTimer;

        public static EyeXHost eyeXHost;
        public static FixationDataStream fixationPointDataStream;
        EFixationState fixationState { get; set; }

        public delegate void ActionToRunAtFixation(int xpos, int ypos);

        private int xPosFixation = 0;
        private int yPosFixation = 0;

        public ActionToRunAtFixation SelectedFixationAcion { get; set; }

        int lengthOfTimeOfGazeBeforeRunningAction = 500;

        TestDrawClass drawtestTool;
        


        public FixationDetection(EyeXHost inputEyeXHost)
        {
            //Pass in eyexhost from form\class to manage eytracting system.
            eyeXHost = inputEyeXHost;
            fixationPointDataStream = eyeXHost.CreateFixationDataStream(FixationDataMode.Slow);
            EventHandler<FixationEventArgs> runSelectedActionAtFixationDelegate = new EventHandler<FixationEventArgs>(RunSelectedActionAtFixation);
            fixationPointDataStream.Next += runSelectedActionAtFixationDelegate;

            //Timer to run selected interaction with os\applcation user is trying to interact with, once gaze is longer than specified limit
            aTimer = new System.Timers.Timer(lengthOfTimeOfGazeBeforeRunningAction);
            aTimer.AutoReset = false;

            aTimer.Elapsed += runActionWhenTimerReachesLimit;

            drawtestTool = new TestDrawClass();
        }

        //This methof is run on gaze events, checks if it is the begining or end of a fixation and runs appropriate code.
        private void RunSelectedActionAtFixation(object o, FixationEventArgs fixationDataBucket)
        {

            if(fixationState == EFixationState.RunningFixationWithSelection)
            {
                if(fixationDataBucket.EventType == FixationDataEventType.Begin)
                {
                    aTimer.Start();
                    xPosFixation = (int)Math.Floor(fixationDataBucket.X);
                    yPosFixation = (int)Math.Floor(fixationDataBucket.Y);
                    Console.WriteLine("Fixation Started X" + fixationDataBucket.X + " Y" + fixationDataBucket.Y);
                    drawtestTool.DrawMouseLocation(xPosFixation, yPosFixation);
                } else if(fixationDataBucket.EventType == FixationDataEventType.End)
                {
                    aTimer.Stop();
                    Console.WriteLine("Fixation Stopped");
                }
            }
        }

        //this action is run when timer reaches lengthOfTimeOfGazeBeforeRunningAction limit and the elapesed event is run. 
        // doing it this as as we need a way of knowing when and where a fixation begins which the eyex provides, problem is it only provides when,
        //a fixation begins and where it ends, we haved to buid the logic to detect where it begins, check that its does not end in a specified time period,
        // and as long as it doens not end, run the required action at that location from the begining of the fixation.
        public void runActionWhenTimerReachesLimit(object o, ElapsedEventArgs e)
        {
            Console.WriteLine("Timer reached event, running required action");
            SelectedFixationAcion(xPosFixation, yPosFixation);
            fixationState = EFixationState.WaitingForInPutSelection;
        }


        public void SetupSelectedFixationAction(ActionToRunAtFixation inputActionToRun)
        {
            SelectedFixationAcion = inputActionToRun;
            fixationState = EFixationState.RunningFixationWithSelection;
        }
    }
}
