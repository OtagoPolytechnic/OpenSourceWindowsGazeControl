using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
*  Class: PointSmoother
*  Name: Richard Horne
*  Date: 11/11/2016
*  Description: A class to take a stream of points and fromt he collection of points return a average point. used to smooth out X and Y coordinates.
*/

namespace GazeToolBar
{
    /// <summary>
    /// Struct GazePoint custom coordinate representation.
    /// </summary>
    public struct GazePoint
    {
       public double x;
       public double y;

        public GazePoint(double X, double Y)
        {
            x = X;
            y = Y;
        }
    }


    public class PointSmoother
    {
        //Set Fields
        int bufferSize;
        int bufferCurrentIndex;
        //bufferFullIndex is used to keep track of if the buffer has been filled up at least once, it is increment in the addCoordinateToBuffer() method until the buffer
        // has been filled at least once, eg once bufferfullIndex equals the buffer size. This is then used to calculate average of points so that when the points are smoothed
        // null values are not added from the array and also so that the total in not divided by a value higher than the amount of values added to the total.
        int bufferFullIndex;
        double[] xBuffer;
        double[] yBuffer;

        //Create new instance and set buffer size
        public PointSmoother(int BufferSize)
        {
            bufferSize = BufferSize;
            bufferCurrentIndex = 0;
            bufferFullIndex = 0;

            yBuffer = new double[BufferSize];
            xBuffer = new double[BufferSize];
        }


        //Add a coordinate to the buffer and return the most recently calculated smoothed coordinate.
        public GazePoint UpdateAndGetSmoothPoint(double X, double Y)
        {
            addCoordinateToBuffer(X, Y);

            return smoothPointsFromBuffer();
        }


        //add coordinates to ring buffer, check and reset array index when at end of array, increment bufferfullindex to indicate when buffer has been full at least once.
        private void addCoordinateToBuffer(double x, double y)
        {

            if (bufferCurrentIndex == bufferSize)
            {
                bufferCurrentIndex = 0;
            }

            if( bufferFullIndex != bufferSize)
            {
                bufferFullIndex++;
            }

            xBuffer[bufferCurrentIndex] = x;
            yBuffer[bufferCurrentIndex] = y;

            bufferCurrentIndex++;
        }

        //work out average point location from current buffer contents.
        private GazePoint smoothPointsFromBuffer()
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
            returnSmoothPoint.y  = yTotal / bufferFullIndex;
    
            return returnSmoothPoint;
        }

    }
}
