using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeXFramework;
using Tobii.EyeX.Framework;
using Tobii.EyeX.Client;

namespace GazeToolBar
{
    public class CustomFixationDataStream
    {
        GazePointDataStream gazeStream;

        int bufferSize = 60;
        int bufferCurrentIndex = 0;
        int bufferFullIndex = 0;
        double[] xBuffer;
        double[] yBuffer;



        public CustomFixationDataStream()
        {
            gazeStream = Program.EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);
            //Create gate points event handler delegate
            EventHandler<GazePointEventArgs> gazeDel = new EventHandler<GazePointEventArgs>(updateGazeCoodinates);
            //register delegate with gaze data stream next event.
            gazeStream.Next += gazeDel;

            xBuffer = new double[bufferSize];
            yBuffer = new double[bufferSize];

        }



        private void updateGazeCoodinates(object o, GazePointEventArgs currentGaze)
        {
            //Save the users gaze to a field that has global access in this class.
            //currentGazeLocationX = currentGaze.X;
            //currentGazeLocationY = currentGaze.Y;

            addCoordinateToBuffer(currentGaze.X, currentGaze.Y);
            calculateVariance();
    

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

        private void calculateVariance()
        {
            double xTotal = 0;
            double yTotal = 0;

            SmoothPoint averageOfPoints = average();

            for (int arrayIndex = 0; arrayIndex < bufferFullIndex; arrayIndex++)
            {
                xTotal += Math.Pow(xBuffer[arrayIndex], 2);
                yTotal += Math.Pow(yBuffer[arrayIndex], 2);
            }

            xTotal = xTotal / bufferFullIndex;
            yTotal = yTotal / bufferFullIndex;

            xTotal = Math.Sqrt(xTotal);
            yTotal = Math.Sqrt(yTotal);

            xTotal = xTotal - averageOfPoints.x;
            yTotal = yTotal - averageOfPoints.y;

            Console.WriteLine("x sd " + xTotal );
            Console.WriteLine("y sd " + yTotal );
        }


        private SmoothPoint average()
        {
            double xTotal = 0;
            double yTotal = 0;
            SmoothPoint returnSmoothPoint;

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
