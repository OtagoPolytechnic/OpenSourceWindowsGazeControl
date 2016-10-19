using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeXFramework;
using Tobii.EyeX.Framework;
using Tobii.EyeX.Client;
using System.Timers;

namespace GazeToolBar
{
    public class GazeHighlight
    {

        Graphics canvas;
        int fixationPercent;
        int transparentValue = 50;
        IGazeHighlightShader gazeShader;
        GazeHighlightShaderFactory shaderMachine;
        Point currentGaze;
        GazePointDataStream gazeStream;
        Size highlightSize = new Size(40, 40);
        ZoomLens lensForm;


        public GazeHighlight(FixationDetection fixationWorker, Graphics zoomerCanvas, EHighlightShaderType shaderType, ZoomLens LensForm)
        {
            lensForm = LensForm;

            fixationWorker.currentProgress += setPercent;

            gazeStream = Program.EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);

            gazeStream.Next += SetCurrentGaze;
            
            canvas = zoomerCanvas;

            shaderMachine = new GazeHighlightShaderFactory();

            gazeShader = shaderMachine.CreateShader(shaderType);

            fixationPercent = 0;

            currentGaze = new Point();


           
        }


        public void DrawHightlight()
        {
            SolidBrush highlightbrush = gazeShader.GenerateBrush(fixationPercent, transparentValue);

            Point formCoordinates = lensForm.PointToClient(currentGaze);

            int centerAdjustment = highlightSize.Height / 2;

            formCoordinates.X = formCoordinates.X - centerAdjustment;
            formCoordinates.Y = formCoordinates.Y - centerAdjustment;

            canvas.FillEllipse(highlightbrush, formCoordinates.X, formCoordinates.Y, highlightSize.Width, highlightSize.Width);

        }



         
        public void SetCurrentGaze(object o , GazePointEventArgs currentGazePoint)
        {
            currentGaze.X = (int)Math.Floor(currentGazePoint.X);
            currentGaze.Y = (int)Math.Floor(currentGazePoint.Y);
        }


        private void setPercent(object o, FixationProgressEventArgs progress)
        {
            fixationPercent = progress.ProgressPercent;
        }



    }
}
