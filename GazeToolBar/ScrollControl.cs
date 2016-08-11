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
    class ScrollControl
    {
        GazePointDataStream gazeStream;
        


        public ScrollControl()
        {
            gazeStream = Program.EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);

            EventHandler<GazePointEventArgs> gazeDel = new EventHandler<GazePointEventArgs>(updateGazeCoodinates);
            
            gazeStream.Next += gazeDel;
        }


        private void updateGazeCoodinates(object o, GazePointEventArgs currentGazePoint)
        {

        }

        private int calculateVirtScrollAmount()
        {

        }

        private int calculateHoriScrollAmount()
        {
 
        }

        private void StopScroll()
        {

        }

    }
}
