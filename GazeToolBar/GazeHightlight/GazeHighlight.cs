using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeXFramework;
using Tobii.EyeX.Framework;
using Tobii.EyeX.Client;

namespace GazeToolBar
{
    public class GazeHighlight
    {

        Graphics canvas;
        int fixationPercent;
        IGazeHighlightShader gazeShader;
        GazeHighlightShaderFactory shaderMachine;
        PointF currentGaze;
        GazePointDataStream gazeStream;

        public GazeHighlight(FixationDetection fixationWorker, Graphics zoomerCanvas, EHighlightShaderType shaderType)
        {
            fixationWorker.currentProgress += setPercent;
            
            gazeStream = Program.EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);

            gazeStream.Next += setCurrentGaze;
            
            canvas = zoomerCanvas;

            shaderMachine = new GazeHighlightShaderFactory();

            gazeShader = shaderMachine.CreateShader(shaderType);

            fixationPercent = 0;

            currentGaze = new PointF();
        }



         
        public void setCurrentGaze(object o , GazePointEventArgs currentGazePoint)
        {
            currentGaze.X = (float)currentGazePoint.X;
            currentGaze.Y = (float)currentGazePoint.Y;
        }


        public void setPercent(object o, FixationProgressEventArgs progress)
        {
            fixationPercent = progress.ProgressPercent;
        }



    }
}
