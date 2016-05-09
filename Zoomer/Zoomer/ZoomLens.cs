using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoomer
{
    public partial class ZoomLens : Form
    {

        private const int LENSSIZE = 200;
        Graphics graphics;
        Zoomer zoom;
        Bitmap bmpScreenshot;
        Size size;
        public ZoomLens()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            this.Width = LENSSIZE;
            this.Height = LENSSIZE;
            bmpScreenshot = new Bitmap(this.Width, this.Height);
            graphics = Graphics.FromImage(bmpScreenshot);

            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            size = new Size(this.Width, this.Height);

            this.FormBorderStyle = FormBorderStyle.None;
            zoom = new Zoomer(graphics);
            
        }
        public void CreateZoomLens(int x, int y)
        {
            this.DesktopLocation = new Point(x - (size.Width /2), y - (size.Height /2));
            this.Show();
            Point lensPoint = new Point();
            Point empty = new Point(0, 0);
            lensPoint.X = x;
            lensPoint.Y = y;

            
            graphics.CopyFromScreen(lensPoint.X - (size.Width / 2), lensPoint.Y - (size.Height / 2), empty.X, empty.Y, size, CopyPixelOperation.SourceCopy);
            
            for (int i = 0; i < 30; i++)
            {
                bmpScreenshot = zoom.zoom(bmpScreenshot);
                pictureBox1.Image = bmpScreenshot;
                System.Threading.Thread.Sleep(50);
                Application.DoEvents();
            }
            this.Dispose();
        }
    }
}
