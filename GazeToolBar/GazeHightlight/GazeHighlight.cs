using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeXFramework;
using System.Timers;

/*
 *  Class: GazeHighlight
 *  Name: Richard Horne
 *  Date: 11/11/2016
 *  Description: Overlay for zoomer window to indicate where a user is fixation and progress through the current fixation.
 */


namespace GazeToolBar
{
    public class GazeHighlight
    {
        //Fields
        Graphics canvas;
        int fixationPercent;
        int transparentValue = 50;
        IGazeHighlightShader gazeShader;
        GazeHighlightShaderFactory shaderMachine;
        Point currentGaze;
        Size highlightSize = new Size(40, 40);
        ZoomLens lensForm;

        //Constructor
        public GazeHighlight(FixationDetection fixationWorker, Graphics zoomerCanvas, EHighlightShaderType shaderType, ZoomLens LensForm)
        {
            lensForm = LensForm;

            fixationWorker.currentProgress += setPercent;
            
            canvas = zoomerCanvas;

            shaderMachine = new GazeHighlightShaderFactory();

            gazeShader = shaderMachine.CreateShader(shaderType);

            fixationPercent = 0;

            currentGaze = new Point();

        }


        //called zoomer to draw highlight over zoomer windo
        public void DrawHightlight()
        {
            //Create brush
            SolidBrush highlightbrush = gazeShader.GenerateBrush(fixationPercent, transparentValue);
            //Convert Screen coordinates to form coordinates
            Point formCoordinates = lensForm.PointToClient(currentGaze);

            int centerAdjustment = highlightSize.Height / 2;

            formCoordinates.X = formCoordinates.X - centerAdjustment;
            formCoordinates.Y = formCoordinates.Y - centerAdjustment;
            //Draw hightlight
            canvas.FillEllipse(highlightbrush, formCoordinates.X, formCoordinates.Y, highlightSize.Width, highlightSize.Width);

        }

        //Store current gaze location and percentage of progress through current fixation.
        private void setPercent(object o, FixationProgressEventArgs progress)
        {
            fixationPercent = progress.ProgressPercent;
            currentGaze.X = progress.X;
            currentGaze.Y = progress.Y;
        }

    }
}
