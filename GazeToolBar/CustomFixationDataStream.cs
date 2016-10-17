using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeXFramework;
using Tobii.EyeX.Framework;
using Tobii.EyeX.Client;
using System.Threading;


namespace GazeToolBar
{
    public class CustomFixationDataStream
    {
        GazePointDataStream gazeStream;

        int bufferSize = 60;
        int bufferCurrentIndex = 0;
        int bufferFullIndex = 0;

        double xFixationThreashold = 1;
        double yFixationThreashold = 1;

        double[] xBuffer;
        double[] yBuffer;

        EFixationStreamEventType fixationState;

        GazePoint gPAverage;


        public delegate void CustomFixationEventHandler(object o, CustomFixationEventArgs e);

        public event CustomFixationEventHandler next;


        public CustomFixationDataStream()
        {
            gazeStream = Program.EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);
            //Create gate points event handler delegate
            EventHandler<GazePointEventArgs> gazeDel = new EventHandler<GazePointEventArgs>(updateGazeCoodinates);
            //register delegate with gaze data stream next event.
            gazeStream.Next += gazeDel;

            gPAverage = new GazePoint();

            xBuffer = new double[bufferSize];
            yBuffer = new double[bufferSize];

            fixationState = EFixationStreamEventType.waiting;

        }



        private void updateGazeCoodinates(object o, GazePointEventArgs currentGaze)
        {
            //Save the users gaze to a field that has global access in this class.
            //currentGazeLocationX = currentGaze.X;
            //currentGazeLocationY = currentGaze.Y;

            addCoordinateToBuffer(currentGaze.X, currentGaze.Y);

            gPAverage = average();

            generateFixationState(calculateVariance(), currentGaze.Timestamp);
    
        }


          private void generateFixationState(GazePoint gazeVariation, double timestamp)
        {
              //Set pointer to next fixation data bucket.
            CustomFixationEventArgs cpe = null;


              //Check gaze data variation and raise appropriate event.
            if (fixationState == EFixationStreamEventType.waiting && gazeVariation.x < xFixationThreashold && gazeVariation.y < yFixationThreashold)
            {
                cpe = new CustomFixationEventArgs(EFixationStreamEventType.start, timestamp, gPAverage.x, gPAverage.y);
                fixationState = EFixationStreamEventType.middle;
            }
            else if (fixationState == EFixationStreamEventType.middle && gazeVariation.x > xFixationThreashold && gazeVariation.y > yFixationThreashold)
            {
                cpe = new CustomFixationEventArgs(EFixationStreamEventType.end, timestamp, gPAverage.x, gPAverage.y);
                fixationState = EFixationStreamEventType.waiting;
            }
            else if (fixationState == EFixationStreamEventType.middle)
            {
                cpe = new CustomFixationEventArgs(EFixationStreamEventType.middle, timestamp, gPAverage.x, gPAverage.y);
            }


            if( cpe != null)
            {
                OnFixationStateChange(cpe);
            }


        }


        private void OnFixationStateChange(CustomFixationEventArgs newFixation)
        {
            if(next != null)
            {
                next(this, newFixation);
            }
        }



        //add coordinates to ring buffer, check and reset array index when at end of array, increment bufferfullindex to indicate when buffer has been full at least once.
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



           // Console.WriteLine("x sd " + xTotal);
           // Console.WriteLine("y sd " + yTotal);

            return new GazePoint(xTotal, yTotal);

        }

        public void ResetFixationDetectionState()
        {
            fixationState = EFixationStreamEventType.waiting;
            bufferCurrentIndex = 0;
            bufferFullIndex = 0;
            xBuffer = new double[bufferSize];
            yBuffer = new double[bufferSize];
            Thread.Sleep(100);
        }



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
