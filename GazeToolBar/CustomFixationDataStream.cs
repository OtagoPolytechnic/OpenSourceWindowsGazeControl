using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeXFramework;
using Tobii.EyeX.Framework;
using Tobii.EyeX.Client;
using System.Threading;
using EyeXFramework.Forms;

/*
 *  Class: CustomFixationDataStream
 *  Name: Richard Horne
 *  Date: 11/11/2016
 *  Description: Custom fixation datastream, Monitors stream of XY coordinates of a users gaze, and from this data calculates the standard deviation variance from the gaze average. 
 *  It then raises appropriate events when the users gaze is moving less than a specified threshold.
 */


namespace GazeToolBar
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomFixationDataStream
    {
        //Gaze Data stream to subscribe to.
        GazePointDataStream gazeStream;

        //Ring buffer size
        int bufferSize = 50;
        int bufferCurrentIndex = 0;
        int bufferFullIndex = 0;

        //Fixation variance threshold
        double xFixationThreashold = .9;
        double yFixationThreashold = .3;

        //ring buffer arrays.
        double[] xBuffer;
        double[] yBuffer;

        EFixationStreamEventType fixationState;

        //Global variable containing the current gaze average location.
        GazePoint gPAverage;

        //Deceleration of event that is raised when fixation occurs.
        public delegate void CustomFixationEventHandler(object o, CustomFixationEventArgs e);
        public event CustomFixationEventHandler next;

        //Constructor
        public CustomFixationDataStream(FormsEyeXHost EyeXHost)
        {

            gazeStream = EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);
            //Create gate points event handler delegate
            EventHandler<GazePointEventArgs> gazeDel = new EventHandler<GazePointEventArgs>(updateGazeCoodinates);
            //register delegate with gaze data stream next event.
            gazeStream.Next += gazeDel;

            gPAverage = new GazePoint();

            xBuffer = new double[bufferSize];
            yBuffer = new double[bufferSize];

            fixationState = EFixationStreamEventType.Waiting;

        }


        /// <summary>
        /// Method get subscribed to eye tracker gaze event data stream, then runs methods that convert users current gaze into fixation events.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="currentGaze"></param>
        private void updateGazeCoodinates(object o, GazePointEventArgs currentGaze)
        {

            addCoordinateToBuffer(currentGaze.X, currentGaze.Y);

            gPAverage = average();

            generateFixationState(calculateVariance(), currentGaze.Timestamp);
    
        }


        /// <summary>
        /// Checks input data from variance calculation and raises appropriate event depending on this data and the CustomfixationDetectionStreams current state
        /// </summary>
        /// <param name="gazeVariation"></param>
        /// <param name="timestamp"></param>
          private void generateFixationState(GazePoint gazeVariation, double timestamp)
        {
              //Set pointer to next fixation data bucket.
            CustomFixationEventArgs cpe = null;


              //Check gaze data variation, current state and create appropriate event. Then set the CustomfixationDetectionStreams state.
            if (fixationState == EFixationStreamEventType.Waiting && gazeVariation.x < xFixationThreashold && gazeVariation.y < yFixationThreashold)
            {
                cpe = new CustomFixationEventArgs(EFixationStreamEventType.Start, timestamp, gPAverage.x, gPAverage.y);
                fixationState = EFixationStreamEventType.Middle;
            }
            else if (fixationState == EFixationStreamEventType.Middle && gazeVariation.x > xFixationThreashold && gazeVariation.y > yFixationThreashold)
            {
                cpe = new CustomFixationEventArgs(EFixationStreamEventType.End, timestamp, gPAverage.x, gPAverage.y);
                fixationState = EFixationStreamEventType.Waiting;
            }
            else if (fixationState == EFixationStreamEventType.Middle)
            {
                cpe = new CustomFixationEventArgs(EFixationStreamEventType.Middle, timestamp, gPAverage.x, gPAverage.y);
            }


              //raise the event.
            if( cpe != null)
            {
                onFixationStateChange(cpe);
            }


        }

        //Method that raises fixation event.
        private void onFixationStateChange(CustomFixationEventArgs newFixation)
        {
            if(next != null)
            {
                next(this, newFixation);
            }
        }



        //add coordinates to ring buffer, check and reset array index when at end of array, increment bufferfullindex to indicate when buffer has been full for the first time, then overwrite previous data.
        private void addCoordinateToBuffer(double x, double y)
        {

            if (bufferCurrentIndex == bufferSize)
            {
                bufferCurrentIndex = 0;
            }

            if (bufferFullIndex != bufferSize)
            {
                bufferFullIndex++;
            }

            xBuffer[bufferCurrentIndex] = x;
            yBuffer[bufferCurrentIndex] = y;

            bufferCurrentIndex++;
        }

        private GazePoint calculateVariance()
        {
            double xTotal = 0;
            double yTotal = 0;

           

            for (int arrayIndex = 0; arrayIndex < bufferFullIndex; arrayIndex++)
            {
                xTotal += Math.Pow(xBuffer[arrayIndex], 2);
                yTotal += Math.Pow(yBuffer[arrayIndex], 2);
            }

            xTotal = xTotal / bufferFullIndex;
            yTotal = yTotal / bufferFullIndex;

            xTotal = Math.Sqrt(xTotal);
            yTotal = Math.Sqrt(yTotal);

            xTotal = xTotal - gPAverage.x;
            yTotal = yTotal - gPAverage.y;



            return new GazePoint(xTotal, yTotal);

        }


        /// <summary>
        /// Reset fixation data stream to its waiting state, this solves and issue when fixations are in close proximity, by stopping the stream getting stuck in the middle stae of a fixation. 
        /// </summary>
        public void ResetFixationDetectionState()
        {
            fixationState = EFixationStreamEventType.Waiting;
            bufferCurrentIndex = 0;
            bufferFullIndex = 0;
            xBuffer = new double[bufferSize];
            yBuffer = new double[bufferSize];
            Thread.Sleep(100);
        }

        /// <summary>
        /// Calculates the average location of the users gaze, could be combined into calculateVariance() method.
        /// </summary>
        /// <returns>Average of buffers current set of data</returns>
        private GazePoint average()
        {
            double xTotal = 0;
            double yTotal = 0;
            
            GazePoint returnSmoothPoint;

            for (int arrayIndex = 0; arrayIndex < bufferFullIndex; arrayIndex++)
            {
                xTotal += xBuffer[arrayIndex];
                yTotal += yBuffer[arrayIndex];
            }

            returnSmoothPoint.x = xTotal / bufferFullIndex;
            returnSmoothPoint.y = yTotal / bufferFullIndex;

            return returnSmoothPoint;
        }

    }
}
