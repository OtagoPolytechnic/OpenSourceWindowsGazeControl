using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeXFramework;
using Tobii.EyeX.Framework;
using Tobii.EyeX.Client;
using System.Timers;
using System.Drawing;

/*
 *  Class: FixationDetection
 *  Name: Richard Horne
 *  Date: 10/05/2015
 *  Description: This class is to encapsulate the required logic to detect an user eyes fixation on a point of the screen from the behaviors provided by the eyeX engine.
 *  Purpose: To enable code to be run when a user fixates on location on the screen. A method can be passed in and run once the fixation is confirmed.
 */

namespace GazeToolBar
{
    //State the Fixation detection can be in.
    public enum EFixationState { WaitingForFixationRequest, DetectingFixation };
    
    
    public class FixationDetection
    {
        //Timer to measure if a how long it has been since the fixation started. 
        private static Timer fixationTimer;
        public static Timer timeOutTimer;

        //Fixation data stream, used to attached to fixation events.
        public static FixationDataStream fixationPointDataStream;
       
        public int FixationDetectionTimeLength { get; set; }
        //State variable of FixationDetection class.

        private EFixationState fixationState;

        //Field to record location of beginning fixation location.
        private int xPosFixation = 0;
        private int yPosFixation = 0;

        bool fixtest = false;




        public FixationDetection()
        {
            fixationPointDataStream = Program.EyeXHost.CreateFixationDataStream(FixationDataMode.Slow);
            
            EventHandler<FixationEventArgs> FixationEventStreamDelegate = new EventHandler<FixationEventArgs>(RunSelectedActionAtFixation);
            
            fixationPointDataStream.Next += FixationEventStreamDelegate;

            //Timer to run selected interaction with OS\aapplication user is trying to interact with, once gaze is longer than specified limit
            //the delegate that has been set in SelectedFixationAcion is run but the timer elapsed event.
            FixationDetectionTimeLength = 1000;

            timeOutTimer = new Timer(5000);

            timeOutTimer.AutoReset = false;

            timeOutTimer.Elapsed += FixationTimeOut;


            fixationTimer = new System.Timers.Timer(FixationDetectionTimeLength);

            fixationTimer.AutoReset = false;

            fixationTimer.Elapsed += runActionWhenTimerReachesLimit;
        }

        //This method of is run on gaze events, checks if it is the beginning or end of a fixation and runs appropriate code.
        private void RunSelectedActionAtFixation(object o, FixationEventArgs fixationDataBucket)
        {
            Console.WriteLine(fixtest.ToString());

            if(fixtest)
            {
                Console.WriteLine("detecting fixation");

                if(fixationDataBucket.EventType == FixationDataEventType.Begin)
                {
                    fixationTimer.Start();
                    xPosFixation = (int)Math.Floor(fixationDataBucket.X);
                    yPosFixation = (int)Math.Floor(fixationDataBucket.Y);
                    //Debug 
                    Console.WriteLine("Fixation Started X" + fixationDataBucket.X + " Y" + fixationDataBucket.Y);
                    
                }
                
                if(fixationDataBucket.EventType == FixationDataEventType.Data)
                {
                    xPosFixation = (int)Math.Floor(fixationDataBucket.X);
                    yPosFixation = (int)Math.Floor(fixationDataBucket.Y);
                }
                
                if(fixationDataBucket.EventType == FixationDataEventType.End)
                {
                    fixationTimer.Stop();
                    //Debug
                    Console.WriteLine("Fixation Stopped");
                }
            }
        }

        //This action is run when the timer reaches lengthOfTimeOfGazeBeforeRunningAction and the elapsed event on the timer is fired. 
        //doing it this as we need a way of knowing when and where a fixation begins which the eyex provides, problem is it only provides when
        //a fixation begins and where it ends, we have to build the logic to detect where it begins, check that its does not end in a specified time period,
        //and as long as it does not end, run the required action at that location from the beginning of the fixation.
        public void runActionWhenTimerReachesLimit(object o, ElapsedEventArgs e)
        {
            //Debug
            Console.WriteLine("Timer reached event, running required action");
            //Run the method stored in SelectfixationAction
            //SelectedFixationAcion(xPosFixation, yPosFixation);//(may need to work on some  logic to detect and handle if the selectedFicationAction ran successfully).

            //Once the fixation has run, set the state of fixation detection back to waiting.
            fixationState = EFixationState.WaitingForFixationRequest;
            fixtest = false;
           
            SystemFlags.Gaze = true;
            
        }
        public void FixationTimeOut(object o, ElapsedEventArgs e)
        {
            SystemFlags.timeOut = true;
            fixationState = EFixationState.WaitingForFixationRequest;
        }


        //This method has the Action that will be run once a fixation is confirmed passed in and stored in SelectedFicationAction. It also sets the state to RunningFixationDetection, 
        //which sets logic in RunSelectedActionAtFixation to run on fixationPointDataStream.Next events.
        public void StartDetectingFixation()
        {
            //SelectedFixationAcion = inputActionToRun;
            Console.WriteLine("Start detection call");
            fixationState = EFixationState.DetectingFixation;
            fixtest = true;
        }
        public Point getXY()
        {
            return new Point(xPosFixation, yPosFixation);
        }
    }
}
