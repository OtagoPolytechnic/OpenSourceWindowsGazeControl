using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Class: RedToGreenShader
 *  Name: Richard Horne
 *  Date: 11/11/2016
 *  Description: Implements IgazeHighlighShader. Produces a graphs brush based on a scaler(in this case a percentage from 0-100) and returns a color
 *  from red to green to indicate progress through a  fixation.
 */

namespace GazeToolBar
{
    public class RedToGreenShader : IGazeHighlightShader
    {
        public RedToGreenShader()
        {
            //empty
        }

        public SolidBrush GenerateBrush(int scalarValue, int transValue)
        {
            int scalarPercent = scalarValue;

            if(scalarPercent > 100)
            {
                scalarPercent = 100;
            }

            double R = (double)scalarPercent / 100;
            double G = (double)1 - R;


            int r = (int)Math.Floor(255 * R);
            int g = (int)Math.Floor(255 * G);
            int b = 0;

            //create brush colour and return
            return new SolidBrush(Color.FromArgb(transValue,r, g, b));
            
        }
    }
}
