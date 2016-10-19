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
using EyeXFramework.Forms;

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

    /// <summary>
    /// Monitor Gaze fixation data and raise systems flag when this occurs.
    /// </summary>
    public class FixationDetection
    {
        //Use to toggle extra point smoothing on and off
       bool usePointSmother = false;

       //Deceleration of event used to drive Gaze highlight, event contains data that shows the percentage through the current fixation.
       public delegate void FixationProgressEvent( object o, FixationProgressEventArgs e);
       public event FixationProgressEvent currentProgress;
       
        private double fixationProgressStartTimeStamp;

       
        //Timer to measure if a how long it has been since the fixation started. 
        private Timer fixationTimer;
        private Timer timeOutTimer;

        //Fixation data stream, used to attached to fixation events.
        //public static FixationDataStream fixationPointDataStream;
        //EventHandler<FixationEventArgs> FixationEventStreamDelegate;
       
        public int FixationDetectionTimeLength { get; set; }
        public int FixationTimeOutLength { get; set; }
        //State variable of FixationDetection class.

        private EFixationState fixationState;

        //Field to record location of beginning fixation location.
        private int xPosFixation = 0;
        private int yPosFixation = 0;


        //Worker class to further smooth points if required.
        private PointSmoother pointSmootherWorker;
        private int pointSmootherBufferSize = 100;

        //Fixation data stream.
        CustomFixationDataStream customfixStream;

        public FixationDetection(FormsEyeXHost EyeXHost)
        {

            customfixStream = new CustomFixationDataStream(EyeXHost);

            customfixStream.next += detectFixation;

            //Timer to run selected interaction with OS\aapplication user is trying to interact with, once gaze is longer than specified limit
            //the delegate that has been set in SelectedFixationAcion is run but the timer elapsed event.
            FixationDetectionTimeLength = 1200;

            FixationTimeOutLength = 5000;

            timeOutTimer = new Timer(FixationTimeOutLength);

            timeOutTimer.AutoReset = false;

            timeOutTimer.Elapsed += fixationTimeOut;


            fixationTimer = new System.Timers.Timer(FixationDetectionTimeLength);

            fixationTimer.AutoReset = false;

            fixationTimer.Elapsed += runActionWhenTimerReachesLimit;
        }



        
        /// <summary>
        /// This method of is run on gaze events, checks if it is the beginning or end of a fixation and runs appropriate code.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="fixationDataBucket"></param>
        private void detectFixation(object o, CustomFixationEventArgs fixationDataBucket)
        {
            //Check if FixationDetection needs to be monitoring CustomFixation data stream.
            if (fixationState == EFixationState.DetectingFixation)
            {

                GazePoint currentSmoothPoint;

                //If databucket state is the start of a fixation
                if (fixationDataBucket.Status == EFixationStreamEventType.start)
                {
                    fixationTimer.Start();
                    fixationProgressStartTimeStamp = fixationDataBucket.TimeStamp;

                    //Instantiate new point smoother, this clears out and previous in the ring buffer.
                    pointSmootherWorker = new PointSmoother(pointSmootherBufferSize);

                    Console.WriteLine("Fixation Begin X" + fixationDataBucket.X + " Y" + fixationDataBucket.Y);
                }
                //if fixation data is in the middle of a fixation, use the data returned to highlight progress and draw users current gaze location to the screen.
                if (fixationDataBucket.Status == EFixationStreamEventType.middle)
                {
                    //Check if point smoothing is required.
                    if (usePointSmother)
                    {
                        //Data smoothing being done in CustomFixationDectection, 
                        currentSmoothPoint = pointSmootherWorker.UpdateAndGetSmoothPoint(fixationDataBucket.X, fixationDataBucket.Y);
                        xPosFixation = (int)Math.Floor(currentSmoothPoint.x);
                        yPosFixation = (int)Math.Floor(currentSmoothPoint.y);
                    }
                    else
                    {
                        //Slightly smoothed data from the Customfixation data stream 
                        xPosFixation = (int)Math.Floor(fixationDataBucket.X);
                        yPosFixation = (int)Math.Floor(fixationDataBucket.Y);
                    }

                    calculateFixationProgressPercent(fixationDataBucket.TimeStamp);

                }
                //if the fixation ends before the fixation timer completes, reset the fixation timer.
                if (fixationDataBucket.Status == EFixationStreamEventType.end)
                {
                    fixationTimer.Stop();
                    //Debug
                    Console.WriteLine("Fixation Stopped due to end datatype");
                }
            }
        }

        /// <summary>
        /// Reset Fixation detection to waiting state and raise flag with state manager that the fixation detection has competed, once a fixation stream runs from a start state 
        /// without being interrupted by a end state before the fixation timer completes. This is run by the FixationTomer elapsed event.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void runActionWhenTimerReachesLimit(object o, ElapsedEventArgs e)
        {
            timeOutTimer.Stop();
            //Once the fixation has run, set the state of fixation detection back to waiting.
            fixationState = EFixationState.WaitingForFixationRequest;
            SystemFlags.Gaze = true;
            //Debug
            Console.WriteLine("Timer reached event, running required action");
        }

        /// <summary>
        /// Method run on timeOutTimer elapse event.
        /// Used to reset FixationDetection back to its initial waiting state if a user does not successfully fixate on the screen before the time specified by FixationTimeOutLength.
        /// it also signals to the State manager that con fixation completed by raising the SystemFlags.timeOut flag.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void fixationTimeOut(object o, ElapsedEventArgs e)
        {
            customfixStream.ResetFixationDetectionState();

            fixationTimer.Stop();

            SystemFlags.timeOut = true;
            fixationState = EFixationState.WaitingForFixationRequest;
        }

        

        /// <summary>
        //This method has the Action that will be run once a fixation is confirmed passed in and stored in SelectedFicationAction. It also sets the state to RunningFixationDetection, 
        //which sets logic in RunSelectedActionAtFixation to run on fixationPointDataStream.Next events.
        /// </summary>
        public void StartDetectingFixation()
        {
            customfixStream.ResetFixationDetectionState();
          
            pointSmootherWorker = new PointSmoother(pointSmootherBufferSize);

            Console.WriteLine("Start detection call");
            fixationState = EFixationState.DetectingFixation;
            timeOutTimer.Start();
        }

        /// <summary>
        /// Public method for classes using FixationDetection to get the most recent coordinates of a fixation.
        /// </summary>
        /// <returns>Point of must recent fixation</returns>
        public Point getXY()
        {
            return new Point(xPosFixation, yPosFixation);
        }

        /// <summary>
        /// Calculates progress through current fixation,the call method to raise an event containing the current progress percentage.
        /// </summary>
        /// <param name="currentTimeStamp"></param>
        private void calculateFixationProgressPercent(double currentTimeStamp)
        {

            double currentFixationlength = currentTimeStamp - fixationProgressStartTimeStamp;

            double progressPercent = (currentFixationlength / FixationDetectionTimeLength) * ValueNeverChange.ONE_HUNDERED;

           
            onFixationProgressEvent((int)progressPercent);
        }

        /// <summary>
        /// Raises event to advertise current fixations progress.
        /// </summary>
        /// <param name="progressPercent"></param>
        private void onFixationProgressEvent(int progressPercent )
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
