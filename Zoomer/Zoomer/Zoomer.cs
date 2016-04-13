using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoomer
{
    public class Zoomer
    {
        Graphics graphics;
        PictureBox picturebox1;

        public Zoomer(Graphics graphics, PictureBox picturebox1)
        {
            this.picturebox1 = picturebox1;
            this.graphics = graphics;
        }
        //this method should take in a bitmap and crop it down slightly
        public Bitmap cropImage(Bitmap bmpScreenshot)
        {
            Rectangle cropArea = new Rectangle(3,3, bmpScreenshot.Width - 6, bmpScreenshot.Height - 6);
            Bitmap bmpImage = new Bitmap(bmpScreenshot);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

    }
}
