using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazeToolBar
{
    public class Zoomer
    {
        Graphics graphics;
        private const int ZOOMSPEED = 1;
        public Zoomer(Graphics graphics)
        {
            this.graphics = graphics;
        }
        public Bitmap Zoom(Bitmap bmpScreenshot)
        {
            Rectangle cropArea = new Rectangle(ZOOMSPEED, ZOOMSPEED, bmpScreenshot.Width - (ZOOMSPEED * 2), bmpScreenshot.Height Bitmap bmpImage = new Bitmap(bmpScreenshot);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }
    }
}
