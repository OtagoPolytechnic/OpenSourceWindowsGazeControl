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
        Graphics graphics;
        Zoomer zoom;
        Bitmap bmpScreenshot;
        Size size;
        public ZoomLens()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
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
            this.Show();
            Point mousePoint = new Point();
            mousePoint.X = x;
            mousePoint.Y = y;
            Point empty = new Point(0, 0);
            
            graphics.CopyFromScreen(mousePoint.X - (size.Width / 2), mousePoint.Y - (size.Height / 2), empty.X, empty.Y, size, CopyPixelOperation.SourceCopy);
            
            for (int i = 0; i < 10; i++)
            {
                bmpScreenshot = zoom.zoom(bmpScreenshot);
                pictureBox1.Image = bmpScreenshot;
                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
            }
            this.Dispose();
        }
    }
}
