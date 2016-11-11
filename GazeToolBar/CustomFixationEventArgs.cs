using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Class: GazeToolBar
 *  Name: Richard Horne
 *  Date: 11/11/2016
 *  Description: Custom data bucket, information used to generate fixations in the FixationDetection class. 
 */

namespace GazeToolBar
{
    /// <summary>
    /// Fixation States
    /// </summary>
    public enum EFixationStreamEventType {Waiting, Start, Middle, End }

    public class CustomFixationEventArgs : EventArgs
    {
        //Fixation data type
        public EFixationStreamEventType Status{get;set;}
        //xy Screen coordinates
        public double X { get; set; }
        public double Y { get; set; }
        //Time stamp
        public double TimeStamp { get; set; }

        //Event data bucket constructor.
        public CustomFixationEventArgs(EFixationStreamEventType status, double timestamp, double x, double y)
        {
            Status = status;
            TimeStamp = timestamp;
            X = x;
            Y = y;
        }

    }
}
