using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeXFramework;
using Tobii.EyeX.Framework;
using Tobii.EyeX.Client;
using System.Drawing;
using System.Timers;

namespace GazeToolBar
{
    enum ESrollState { Scrolling, NotScrolling}

    public struct noScollRect
    {
        public int LeftBound, RightBound, TopBound, BottomBound;

        public noScollRect(int leftBound, int rightBound, int topBound, int bottomBound)
        {
            LeftBound = leftBound;
            RightBound = rightBound;
            TopBound = topBound;
            BottomBound = bottomBound;
        }
    }

   public class ScrollControl
    {
        public int ScrollScalarValue { get; set; } 

        public noScollRect deadZoneRect;

        GazePointDataStream gazeStream;
        
        double currentGazeLocationX;
        double currentGazeLocationY;

        private Timer scrollStepTimer;

        private ESrollState currentState;

        public int DeadZoneHorizontalPercent { get; set; }
        public int DeadZoneVerticalPercent { get; set; }

        public int ScrollTimerDuration { get; set; }

        public ScrollControl(int scrollTimerDuration, int deadZoneHorizontalPercent, int deadZoneVerticalPercent)
        {

            ScrollTimerDuration = scrollTimerDuration;

            gazeStream = Program.EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);

            EventHandler<GazePointEventArgs> gazeDel = new EventHandler<GazePointEventArgs>(updateGazeCoodinates);
            
            gazeStream.Next += gazeDel;

            scrollStepTimer = new Timer(ScrollTimerDuration);
            scrollStepTimer.AutoReset = true;

            scrollStepTimer.Elapsed += scroll;

            DeadZoneHorizontalPercent = deadZoneHorizontalPercent;
            DeadZoneVerticalPercent = deadZoneVerticalPercent;

            SetDeadZoneBounds();

            currentState = ESrollState.NotScrolling;

            ScrollScalarValue = 5;

        }

       private void scroll(object O, ElapsedEventArgs e )
        {
           int xScrollValue = 0;
           int yScrollValue = 0;

           if(currentGazeLocationX > deadZoneRect.RightBound)
           {
               xScrollValue = calculateScrollSpeed(currentGazeLocationX, deadZoneRect.RightBound, ValueNeverChange.SCREEN_SIZE.Width, ScrollScalarValue, false);
           }
           if(currentGazeLocationX < deadZoneRect.LeftBound)
           {
               xScrollValue = calculateScrollSpeed(currentGazeLocationX, 0, deadZoneRect.LeftBound, ScrollScalarValue, true);
           }

           if (currentGazeLocationY > deadZoneRect.BottomBound)
           {
               yScrollValue = calculateScrollSpeed(currentGazeLocationY, deadZoneRect.BottomBound, ValueNeverChange.SCREEN_SIZE.Height, ScrollScalarValue, false);
           }
           if (currentGazeLocationY < deadZoneRect.TopBound)
           {
               yScrollValue = calculateScrollSpeed(currentGazeLocationY, 0, deadZoneRect.TopBound, ScrollScalarValue, true);
           }

           
           if(xScrollValue > 0 || yScrollValue > 0)
           VirtualMouse.Scroll(yScrollValue, xScrollValue);

        }




        private void updateGazeCoodinates(object o, GazePointEventArgs currentGaze)
        {
            currentGazeLocationX = currentGaze.X;
            currentGazeLocationY = currentGaze.Y;
        }

        private int calculateScrollSpeed(double axisCoordinate, int scaleMin, int scaleMax, int scrollScalarValue, bool ISNegativeScroll)
        {

            double rangeToCalcScrollSpeedOver = scaleMax - scaleMin;
            double calculatedInputFromCoordinate = 0;

            if (ISNegativeScroll)
            {
                calculatedInputFromCoordinate = scaleMax - axisCoordinate;
            }
            else
            {
                 calculatedInputFromCoordinate = axisCoordinate - scaleMin;
            }

            double ScrollSpeedInPercent = calculatedInputFromCoordinate / rangeToCalcScrollSpeedOver;

            int scaledScrollSpeed = (int) Math.Ceiling(ScrollSpeedInPercent * scrollScalarValue);

            if(ISNegativeScroll)
            {
                scaledScrollSpeed *= -1;
            }

            return scaledScrollSpeed;
        }






        public void startScroll()
        {
            SetDeadZoneBounds();

            scrollStepTimer.Start();
        }


        private void stopScroll()
        {
            scrollStepTimer.Stop();
        }

        public void SetDeadZoneBounds()
        {
            //Work out bounds of deadzone rectangle ie place where no scrolling happens when the user is looking there.

            int screenHolizontalCenter = ValueNeverChange.SCREEN_SIZE.Width / 2;
            int screenVerticalCenter = ValueNeverChange.SCREEN_SIZE.Height / 2;
            int deadZoneWidth = (int)(((double)DeadZoneHorizontalPercent / 100) * ValueNeverChange.SCREEN_SIZE.Width);
            int deadZoneHeight = (int)(((double)DeadZoneVerticalPercent / 100) * ValueNeverChange.SCREEN_SIZE.Height);
            int halfDeadZoneWidth = deadZoneWidth / 2;
            int halfDeadZoneHeight = deadZoneHeight / 2;

            deadZoneRect.LeftBound = screenHolizontalCenter - halfDeadZoneWidth;
            deadZoneRect.RightBound = screenHolizontalCenter + halfDeadZoneWidth;

            deadZoneRect.TopBound = screenVerticalCenter - halfDeadZoneHeight;
            deadZoneRect.BottomBound = screenVerticalCenter + halfDeadZoneHeight;
        
        }





    }
}
