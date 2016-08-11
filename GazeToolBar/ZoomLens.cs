using EyeXFramework;
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
        const int ZOOMLEVEL = 3;// this is controls how far the lens will zoom in
        const int ZOOMLENS_SIZE = 500;//setting the width & height of the ZoomLens
        Graphics graphics;
        Bitmap bmpScreenshot;

        FixationDetection fixdet;
        public ZoomLens(FixationDetection FixDet)
        {
            InitializeComponent();
            this.Width = ZOOMLENS_SIZE;
            this.Height = ZOOMLENS_SIZE;
            //This bitmap is the zoomed in area. It's the bit of the screen that gets magnified
            bmpScreenshot = new Bitmap(this.Width / ZOOMLEVEL, this.Height / ZOOMLEVEL);
            graphics = this.CreateGraphics();
            graphics = Graphics.FromImage(bmpScreenshot);
            //This picturebox is what displays the zoomed in screenshot
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;//make the image stretch to the bounds of the picturebox
            this.FormBorderStyle = FormBorderStyle.None;
            fixdet = FixDet;
        }
        /*This method uses the passed in point to create a lens that will zoom in on a portion of the screen
         * TODO: Make sure this accounts for screen boundaries
         */
        public void CreateZoomLens(Point FixationPoint)
        {
            //set the position of the lens and offset it by it's size /2 to center the lens on the location of the current event
            this.DesktopLocation = new Point(FixationPoint.X - (this.Width / 2), FixationPoint.Y - (this.Height / 2));
            this.Show();//make lens visible
            
            Point lensPoint = new Point();
            Point empty = new Point(0, 0);
            //lensPoint is the position the actual screenshot is taken
            lensPoint.X = FixationPoint.X - (int)((this.Width / ZOOMLEVEL) * 1.25);//this sets the position on the screen which is being zoomed in. 
            lensPoint.Y = FixationPoint.Y - (int)((this.Height / ZOOMLEVEL) * 1.25);

            Size zoomSize = new Size(this.Size.Width /2 , this.Size.Height / 2);
            graphics.CopyFromScreen(lensPoint.X + this.Size.Width / 4, lensPoint.Y + this.Size.Height / 4, empty.X, empty.Y, zoomSize, CopyPixelOperation.SourceCopy);

            //bmpScreenshot.Save("bmpScreenshot.bmp");
            pictureBox1.Image = bmpScreenshot;
            this.TopMost = true;
            Application.DoEvents();
        }
        public void ResetZoomLens()
        {
            this.Hide();
        }
        //This method takes a point on the zoomed-in form and translates it to the equivalent desktop coordinates
        public Point TranslateGazePoint(Point fixationPoint)
        {
            Point relativePoint = this.PointToClient(fixationPoint);//this gets the on form coordinates from the fixation point(which is screen coordinates)
            //check to see if the user actually fixated on the ZoomLens
            if (relativePoint.X < 0 || relativePoint.Y < 0 || relativePoint.X > this.Width || relativePoint.Y > this.Height)
            {
                return new Point(-1, -1);//cheap hack. If it is out of bound at all, this will return -1, -1. The statemanager will cancel the zoom
            }
            //pass in the on form coordinates for calculation
            return TranslateToDesktop(relativePoint.X, relativePoint.Y);
        }
        private Point TranslateToDesktop(int x, int y)//This method translates on form coordinates to desktop coordinates
        {
            Point returnPoint = new Point();

            int halfHeight = this.Width / 2;
            int halfWidth = this.Height / 2;
            int halfHeightDivZoom = halfHeight / ZOOMLEVEL;
            int halfWidthDivZoom = halfWidth / ZOOMLEVEL;

            int finalY = halfHeight - halfHeightDivZoom;
            finalY = this.Top + finalY;
            returnPoint.Y = finalY + (y / ZOOMLEVEL);

            int finalX = halfWidth - halfWidthDivZoom;
            finalX = this.Left + finalX;
            returnPoint.X = finalX + (x / ZOOMLEVEL);
            return returnPoint;
        }
    }
}

