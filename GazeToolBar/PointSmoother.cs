using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{

    public struct SmoothPoint
    {
       public double x;
       public double y;

        public SmoothPoint(double X, double Y)
        {
            x = X;
            y = Y;
        }
    }

    public class PointSmoother
    {
        int bufferSize;
        int bufferCurrentIndex;
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



        public SmoothPoint GetSmoothPoint(double X, double Y)
        {


            addCoordinateToBuffer(X, Y);



            return SmoothPointsFromBuffer();
        }


        private void addCoordinateToBuffer(double x, double y)
        {

            if (bufferCurrentIndex == bufferSize)
            {
                bufferCurrentIndex = 0;
            }

            xBuffer[bufferCurrentIndex] = x;
            yBuffer[bufferCurrentIndex] = y;

            bufferCurrentIndex++;
        }

        private SmoothPoint SmoothPointsFromBuffer()
        {
            double xTotal = 0;
            double yTotal = 0;
            SmoothPoint returnSmoothPoint;
             
            for(int arrayIndex = 0; arrayIndex < bufferFullIndex)
            {
                xTotal += xBuffer[arrayIndex];
                yTotal += yBuffer[arrayIndex];
            }

            returnSmoothPoint.x = xTotal / bufferFullIndex;
            returnSmoothPoint.y  = yTotal /bufferFullIndex;

            return returnSmoothPoint;
        }




        



    }
}
