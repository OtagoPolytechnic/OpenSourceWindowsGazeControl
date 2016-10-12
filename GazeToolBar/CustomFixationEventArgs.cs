using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{

    public enum EFixationStreamEventType {waiting, start, middle, end }

    public class CustomFixationEventArgs : EventArgs
    {
        EFixationStreamEventType Status{get;set;}
        double X { get; set; }
        double Y { get; set; }
        double TimeStamp { get; set; }


        public CustomFixationEventArgs(EFixationStreamEventType status, double timestamp, double x, double y)
        {

            Status = status;
            TimeStamp = timestamp;
            X = x;
            Y = y;

        }





    }
}
