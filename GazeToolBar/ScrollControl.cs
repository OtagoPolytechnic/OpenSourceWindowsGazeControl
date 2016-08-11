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
    class ScrollControl
    {
        GazePointDataStream gazeStream;
        
        double currentGazeLocationX;
        double currentGazeLocationY;

        private Timer scrollStepTimer;


        public int ScrollTimerDuration { get; set; }

        public ScrollControl(int scrollTimerDuration)
        {
            ScrollTimerDuration = scrollTimerDuration;

            gazeStream = Program.EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);

            EventHandler<GazePointEventArgs> gazeDel = new EventHandler<GazePointEventArgs>(updateGazeCoodinates);
            
            gazeStream.Next += gazeDel;


            scrollStepTimer = new Timer(ScrollTimerDuration); 
        }


        private void updateGazeCoodinates(object o, GazePointEventArgs currentGaze)
        {
            currentGazeLocationX = currentGaze.X;
            currentGazeLocationY = currentGaze.Y;
        }

        private int calculateScrollAmount(double axisCoordinate, int ScaleSpace)
        {
            return 0;
        }


        private void StopScroll()
        {

        }

    }
}
