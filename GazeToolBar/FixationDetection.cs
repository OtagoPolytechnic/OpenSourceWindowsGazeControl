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
 *  Purpose: To enable code to be run when a user fixates on location on the screen. The last fixation coordinates can be passed retrieved once a fixation has occurred.
 */

namespace GazeToolBar
{
    //State the Fixation detection can be in.
    public enum EFixationState { WaitingForFixationRequest, DetectingFixation };


    
    
    public class FixationDetection
    {

       public delegate void FixationProgressEvent( object o, FixationProgressEventArgs e);

       public event FixationProgressEvent currentProgress;

       private double fixationProgressStartTimeStamp;

       private double fixationProgressCurrentTimeStamp;

       



        //Timer to measure if a how long it has been since the fixation started. 
        private Timer fixationTimer;
        private Timer timeOutTimer;

        //Fixation data stream, used to attached to fixation events.
        public static FixationDataStream fixationPointDataStream;
       
        public int FixationDetectionTimeLength { get; set; }
        public int FixationTimeOutLength { get; set; }
        //State variable of FixationDetection class.

        private EFixationState fixationState;

        //Field to record location of beginning fixation location.
        private int xPosFixation = 0;
        private int yPosFixation = 0;







        public FixationDetection()
        {
            fixationPointDataStream = Program.EyeXHost.CreateFixationDataStream(FixationDataMode.Slow);
            
            EventHandler<FixationEventArgs> FixationEventStreamDelegate = new EventHandler<FixationEventArgs>(DetectFixation);
            
            fixationPointDataStream.Next += FixationEventStreamDelegate;

            //Timer to run selected interaction with OS\aapplication user is trying to interact with, once gaze is longer than specified limit
            //the delegate that has been set in SelectedFixationAcion is run but the timer elapsed event.
            FixationDetectionTimeLength = 1000;

            FixationTimeOutLength = 5000;

            timeOutTimer = new Timer(FixationTimeOutLength);

            timeOutTimer.AutoReset = false;

            timeOutTimer.Elapsed += FixationTimeOut;


            fixationTimer = new System.Timers.Timer(FixationDetectionTimeLength);

            fixationTimer.AutoReset = false;

            fixationTimer.Elapsed += runActionWhenTimerReachesLimit;
        }

        //This method of is run on gaze events, checks if it is the beginning or end of a fixation and runs appropriate code.
        private void DetectFixation(object o, FixationEventArgs fixationDataBucket)
        {
         
            if(fixationState == EFixationState.DetectingFixation)
            {

                if(fixationDataBucket.EventType == FixationDataEventType.Begin)
                {
                    fixationTimer.Start();

                    fixationProgressStartTimeStamp = fixationDataBucket.Timestamp;

                    Console.WriteLine("Fixation Begin X" + fixationDataBucket.X + " Y" + fixationDataBucket.Y);
                }
                
                if(fixationDataBucket.EventType == FixationDataEventType.Data)
                {
                    calculateFixationProgressPercent(fixationDataBucket.Timestamp);
                    xPosFixation = (int)Math.Floor(fixationDataBucket.X);
                    yPosFixation = (int)Math.Floor(fixationDataBucket.Y);
                }
                
                if(fixationDataBucket.EventType == FixationDataEventType.End)
                {
                    fixationTimer.Stop();
                    //Debug
                    Console.WriteLine("Fixation Stopped due to end datatype");
                }
            }
        }


        public void runActionWhenTimerReachesLimit(object o, ElapsedEventArgs e)
        {
            timeOutTimer.Stop();

            //Once the fixation has run, set the state of fixation detection back to waiting.
            fixationState = EFixationState.WaitingForFixationRequest;
            SystemFlags.Gaze = true;
            //Debug
            Console.WriteLine("Timer reached event, running required action");
        }

        public void FixationTimeOut(object o, ElapsedEventArgs e)
        {
            fixationTimer.Stop();

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
            timeOutTimer.Start();
        }

        public Point getXY()
        {
            return new Point(xPosFixation, yPosFixation);
        }


        private void calculateFixationProgressPercent(double currentTimeStamp)
        {

            double currentFixationlength = currentTimeStamp - fixationProgressStartTimeStamp;

            double progressPercent = (currentFixationlength / FixationDetectionTimeLength) * ValueNeverChange.ONE_HUNDERED;

           
            onFixationProgressEvent((int)progressPercent);
        }


        public void onFixationProgressEvent(int progressPercent )
        {
            FixationProgressEventArgs FPEA = new FixationProgressEventArgs(progressPercent);

            Console.WriteLine("Fixation percentage " + progressPercent);

            if(currentProgress != null)
            {
                currentProgress(this, FPEA);
            }


        }
    }
}
