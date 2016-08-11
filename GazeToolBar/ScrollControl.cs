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

    struct noScollRect
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
        noScollRect deadZoneRect;

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

            DeadZoneHorizontalPercent = deadZoneHorizontalPercent;
            DeadZoneVerticalPercent = deadZoneVerticalPercent;

            SetDeadZoneBounds();

            currentState = ESrollState.NotScrolling;
        }


        private void updateGazeCoodinates(object o, GazePointEventArgs currentGaze)
        {
            currentGazeLocationX = currentGaze.X;
            currentGazeLocationY = currentGaze.Y;
        }

        private int calculateScrollSpeed(double axisCoordinate, int ScaleMin, int scaleMax, int speedMultiplier)
        {
            return 0;
        }

        private void startScroll()
        {
            SetDeadZoneBounds();

            
        }


        private void stopScroll()
        {

        }

        public void SetDeadZoneBounds()
        {
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
