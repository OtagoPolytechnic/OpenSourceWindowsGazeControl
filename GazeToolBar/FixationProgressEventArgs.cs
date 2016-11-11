using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 *  Class: FixationProgressEventArgs
 *  Name: Richard Horne
 *  Date: 11/11/2016
 *  Description: Event Raised by Fixation detection during the course of a running fixation detection, the event contains the percentage of how far through the fixation is to completion.
 */

namespace GazeToolBar
{
    public class FixationProgressEventArgs : EventArgs
    {
        public int ProgressPercent { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public FixationProgressEventArgs(int progressPercent, int x, int y )
        {
            ProgressPercent = progressPercent;
            X = x;
            Y = y;
        }
    }
}
