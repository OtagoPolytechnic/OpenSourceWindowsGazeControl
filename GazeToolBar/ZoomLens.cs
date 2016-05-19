using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazeToolBar
{
    public partial class ZoomLens : Form
    {

        const int LENSSIZE = 200;// how big the actual lens is
        const int ZOOMLEVEL = 30;// this is controls how far the lens will zoom in
        int x, y;
        Graphics graphics;
        Zoomer zoomer;
        Bitmap bmpScreenshot;
        delegate void SetFormDelegate(int x, int y);
        public ZoomLens()
        {
            InitializeComponent();
            //this.x = x;
            //this.y = y;
            this.Width = LENSSIZE;//setting the lens size
            this.Height = LENSSIZE;

            bmpScreenshot = new Bitmap(this.Width, this.Height);//set bitmap to same size as the lens
            graphics = this.CreateGraphics();
            graphics = Graphics.FromImage(bmpScreenshot);



            pictureBox1.Width = this.Width;//set picturebox to same size as form
            pictureBox1.Height = this.Height;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;//make the image stretch to the bounds of the picturebox

            this.FormBorderStyle = FormBorderStyle.None;
            zoomer = new Zoomer(graphics);

        }
        public void CreateZoomLens(int x, int y)
        {
            if (this.InvokeRequired)
            {
                SetFormDelegate sfd = new SetFormDelegate(SetForm);
                this.Invoke(sfd, new Object[] { x, y });
            }

            for (int i = 0; i < ZOOMLEVEL; i++)
            {
                bmpScreenshot = zoomer.Zoom(bmpScreenshot);
                pictureBox1.Image = bmpScreenshot;
                System.Threading.Thread.Sleep(50);
                Application.DoEvents();
            }
            //perform click here @ the center of the form
            this.Dispose();
        }
        public void SetForm(int x, int y)
        {
            this.DesktopLocation = new Point(x - (this.Width / 2), y - (this.Height / 2));//set the position of the lens and offset it by it's size /2 to center the lens on the location of the current event
            this.Show();//make lens visible
            Point lensPoint = new Point();
            Point empty = new Point(0, 0);
            lensPoint.X = x - (this.Width / 2);//this sets the position on the screen which is being zoomed in. 
            lensPoint.Y = y - (this.Height / 2);
            graphics.CopyFromScreen(lensPoint.X, lensPoint.Y, empty.X, empty.Y, this.Size, CopyPixelOperation.SourceCopy);
            for (int i = 0; i < ZOOMLEVEL; i++)
            {
                bmpScreenshot = zoomer.Zoom(bmpScreenshot);
                pictureBox1.Image = bmpScreenshot;
                System.Threading.Thread.Sleep(50);
                Application.DoEvents();
            }
            this.Dispose();
        }
    }
}

