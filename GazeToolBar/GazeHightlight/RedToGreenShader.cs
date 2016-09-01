using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    public class RedToGreenShader : IGazeHighlightShader
    {
        public RedToGreenShader()
        {

        }

        public SolidBrush GenerateBrush(int scalarValue)
        {

            double R = scalarValue / 100;
            double G = 1 - R;


            int r = (int)Math.Floor(255 * R);
            int g = (int)Math.Floor(255 * G);
            int b = 0;

            //create brush colour and return
            
            return new SolidBrush(Color.FromArgb(r, g, b));
            
        }
    }
}
