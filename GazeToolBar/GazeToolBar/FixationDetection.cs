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

    public enum EFixationState { WaitingForInPutSelection, RunningFixationWithSelection };
    public class FixationDetection
    {
        public static EyeXHost eyeXHost;
        public static FixationDataStream fixationPointDataStream;
        EFixationState fixationState { get; set; }
        


        public FixationDetection(EyeXHost inputEyeXHost)
        {
            eyeXHost = inputEyeXHost;
            fixationPointDataStream = eyeXHost.CreateFixationDataStream(FixationDataMode.Slow);
            EventHandler<FixationEventArgs> runSelectedActionAtFixationDelegate = new EventHandler<FixationEventArgs>(RunSelectedActionAtFixation);
            fixationPointDataStream.Next += runSelectedActionAtFixationDelegate; 
        }


        private void RunSelectedActionAtFixation(object o, FixationEventArgs fixationDataBucket)
        {

        }

    }
}
