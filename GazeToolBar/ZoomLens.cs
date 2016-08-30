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
        public int checkCorners(Point FixationPoint)
        {
            int maxDistance = 300;
            int screenWidth = Screen.FromControl(this).Bounds.Width;
            int screenHeight = Screen.FromControl(this).Bounds.Height;

            Point topLeft = new Point(0, 0);
            Point topRight = new Point(screenWidth, 0);
            Point bottomLeft = new Point(0, screenHeight);
            Point bottomRight = new Point(screenWidth, screenHeight);

            Point[] Corners = { topLeft, topRight, bottomLeft, bottomRight };

            for (int i = 0; i < Corners.Length; i++)
            {
                if (calculateCornerDistance(FixationPoint, Corners[i]) < maxDistance)
                {
                    return i;
                }
            }
            return -1;
        }
        private int calculateCornerDistance(Point fixationPoint, Point corner)
        {
            int returnInt =  Math.Abs(fixationPoint.X - corner.X) + Math.Abs(fixationPoint.Y - corner.Y);

            //int retint = (int)Math.Sqrt(((corner.X - fixationPoint.X) ^ 2) + ((corner.Y - fixationPoint.Y) ^ 2));
            return returnInt;
        }
        public void CreateZoomLens(Point FixationPoint)
        {
            int corner = checkCorners(FixationPoint);
            Point lensPoint = new Point();
            Size zoomSize = new Size(this.Size.Width / 2, this.Size.Height / 2);
            if (corner != -1)
            {
                //create corner zoom
                switch (corner)
                {
                    case 0:
                        this.DesktopLocation = new Point(0, 0);
                        Console.WriteLine("TopLeft corner detected");
                        lensPoint.X = 0;
                        lensPoint.Y = 0;
                        graphics.CopyFromScreen(lensPoint.X , lensPoint.Y, 0, 0, zoomSize, CopyPixelOperation.SourceCopy);
                        break;
                    case 1:
                        this.DesktopLocation = new Point(Screen.FromControl(this).Bounds.Width - this.Width, 0);
                        Console.WriteLine("TopRight corner detected");
                        lensPoint.X = Screen.FromControl(this).Bounds.Width - bmpScreenshot.Width;
                        lensPoint.Y = 0;
                        graphics.CopyFromScreen(lensPoint.X, lensPoint.Y, 0, 0, zoomSize, CopyPixelOperation.SourceCopy);
                        break;
                    case 2:
                        this.DesktopLocation = new Point(0, Screen.FromControl(this).Bounds.Height - this.Height);
                        Console.WriteLine("BottomLeft corner detected");
                        lensPoint.X = 0;
                        lensPoint.Y = Screen.FromControl(this).Bounds.Height - bmpScreenshot.Height;
                        graphics.CopyFromScreen(lensPoint.X, lensPoint.Y, 0, 0, zoomSize, CopyPixelOperation.SourceCopy);
                        break;
                    case 3:
                        this.DesktopLocation = new Point(Screen.FromControl(this).Bounds.Width - this.Width, Screen.FromControl(this).Bounds.Height - this.Height);
                        Console.WriteLine("BottomRight corner detected");
                        lensPoint.X = Screen.FromControl(this).Bounds.Width - bmpScreenshot.Width;
                        lensPoint.Y = Screen.FromControl(this).Bounds.Height - bmpScreenshot.Height;
                        graphics.CopyFromScreen(lensPoint.X, lensPoint.Y, 0, 0, zoomSize, CopyPixelOperation.SourceCopy);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //set the position of the lens and offset it by it's size /2 to center the lens on the location of the current event
                this.DesktopLocation = new Point(FixationPoint.X - (this.Width / 2), FixationPoint.Y - (this.Height / 2));
                lensPoint.X = FixationPoint.X - (int)((this.Width / ZOOMLEVEL) * 1.25);//this sets the position on the screen which is being zoomed in. 
                lensPoint.Y = FixationPoint.Y - (int)((this.Height / ZOOMLEVEL) * 1.25);
                graphics.CopyFromScreen(lensPoint.X + this.Size.Width / 4, lensPoint.Y + this.Size.Height / 4, 0, 0, zoomSize, CopyPixelOperation.SourceCopy);
            }
            this.Show();//make lens visible
            
            
            Point empty = new Point(0, 0);
            //lensPoint is the position the actual screenshot is taken
            

            
            

            //bmpScreenshot.Save("bmpScreenshot.bmp");
            pictureBox1.Image = bmpScreenshot;
            this.TopMost = true;
            Console.WriteLine("ZoomLens.Bounds.X = " + this.Bounds.X);
            Console.WriteLine("ZoomLens.Bounds.Y = " + this.Bounds.Y);
            Application.DoEvents();
        }
        private void ZoomScreenshot(Point lensPoint)
        {
            
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

