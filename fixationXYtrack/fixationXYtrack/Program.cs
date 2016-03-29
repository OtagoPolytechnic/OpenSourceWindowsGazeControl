using EyeXFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tobii.EyeX.Framework;
using Tobii.EyeX.Client;

namespace fixationXYtrack
{
    class Program
    {

        public static double lastFixationStartTime = 0;
        public static double lastFixationEndTime = 0;

        public static double startXPoint = 0;
        public static double startYPoint = 0;

        public static double endXPoint = 0;
        public static double endYPoint = 0;

        public static double startToEndDuration = 0;


        public static void FixationDataHandler(object eventRaiser, FixationEventArgs fixationPointEvent)
        {
            if (fixationPointEvent.EventType == FixationDataEventType.Begin)
            {
                lastFixationStartTime = fixationPointEvent.Timestamp;
                startXPoint = fixationPointEvent.X;
                startYPoint = fixationPointEvent.Y;
            }if(fixationPointEvent.EventType == FixationDataEventType.End)
            {
                endXPoint = fixationPointEvent.X;
                endYPoint = fixationPointEvent.Y;
                lastFixationEndTime = fixationPointEvent.Timestamp;

                startToEndDuration = lastFixationEndTime - lastFixationStartTime;

                Console.WriteLine("Fixation Duration" + startToEndDuration.ToString());

            }



        }

        public static EyeXHost eyexHost;
        public static FixationDataStream fixationPointDatastream;
        static void Main(string[] args)
        {

            eyexHost = new EyeXHost();

            fixationPointDatastream = eyexHost.CreateFixationDataStream(FixationDataMode.Slow);


            eyexHost.Start();

            EventHandler<FixationEventArgs> displayFixation = new EventHandler<FixationEventArgs>(FixationDataHandler);

            fixationPointDatastream.Next += displayFixation;



        }
    }
}
