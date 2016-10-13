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
        Graphics offScreenGraphics;
        Graphics mainCanvas;
        public Bitmap bmpScreenshot;
        Bitmap offScreenBitmap;
        int corner;//this is used to determine if a user has looked at a corner section of the screen
        Point lensPoint;

        FixationDetection fixdet;

        GazeHighlight gazeHighlight;

        public ZoomLens(FixationDetection FixDet)
        {
            InitializeComponent();
            lensPoint = new Point();
            this.Width = ZOOMLENS_SIZE;
            this.Height = ZOOMLENS_SIZE;
            offScreenBitmap = new Bitmap(this.Width, this.Height);
            //This bitmap is the zoomed in area. It's the bit of the screen that gets magnified
            bmpScreenshot = new Bitmap(this.Width / ZOOMLEVEL, this.Height / ZOOMLEVEL);
            // graphics = this.CreateGraphics();

            //DrawToScreen = this.CreateGraphics();
            mainCanvas = this.CreateGraphics();
            offScreenGraphics = Graphics.FromImage(offScreenBitmap);
            graphics = Graphics.FromImage(bmpScreenshot);

            //This picturebox is what displays the zoomed in screenshot
            //pictureBox1.Width = this.Width;
            //pictureBox1.Height = this.Height;
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;//make the image stretch to the bounds of the picturebox
            this.FormBorderStyle = FormBorderStyle.None;
            fixdet = FixDet;

            gazeHighlight = new GazeHighlight(FixDet, offScreenGraphics, EHighlightShaderType.RedToGreen, this);
        }
        public int checkCorners(Point FixationPoint)
        {
            int maxDistance = bmpScreenshot.Size.Width;
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
            int returnInt = Math.Abs(fixationPoint.X - corner.X) + Math.Abs(fixationPoint.Y - corner.Y);

            //int retint = (int)Math.Sqrt(((corner.X - fixationPoint.X) ^ 2) + ((corner.Y - fixationPoint.Y) ^ 2));
            return returnInt;
        }
        public void CreateZoomLens(Point FixationPoint)
        {
            //corner = checkCorners(FixationPoint);
            //lensPoint is the position the actual screenshot is taken
            //Point lensPoint = new Point();
            Size zoomSize = new Size(this.Size.Width / 2, this.Size.Height / 2);

            this.Show();//make lens visible
            //pictureBox1.Image = bmpScreenshot;
            offScreenGraphics.DrawImage(bmpScreenshot, 0, 0, 500, 500);
            this.TopMost = true;
            Console.WriteLine("ZoomLens.Bounds.X = " + this.Bounds.X);
            Console.WriteLine("ZoomLens.Bounds.Y = " + this.Bounds.Y);
            DrawTimer.Start();
            Application.DoEvents();
        }
        public void determineDesktopLocation(Point FixationPoint, int corner)
        {
            if (corner != -1)
            {
                switch (corner)
                {
                    case 0:
                        this.DesktopLocation = new Point(0, 0);
                        SetLensPoint(0, 0);
                        Console.WriteLine("Top left corner detected");
                        break;
                    case 1:
                        this.DesktopLocation = new Point(Screen.FromControl(this).Bounds.Width - this.Width, 0);
                        SetLensPoint(Screen.FromControl(this).Bounds.Width - bmpScreenshot.Width, 0);
                        Console.WriteLine("Top right corner detected");
                        break;
                    case 2:
                        this.DesktopLocation = new Point(0, Screen.FromControl(this).Bounds.Height - this.Height);
                        SetLensPoint(0, Screen.FromControl(this).Bounds.Height - bmpScreenshot.Height);
                        Console.WriteLine("Bottom left corner detected");
                        break;
                    case 3:
                        this.DesktopLocation = new Point(Screen.FromControl(this).Bounds.Width - this.Width, Screen.FromControl(this).Bounds.Height - this.Height);
                        SetLensPoint(Screen.FromControl(this).Bounds.Width - bmpScreenshot.Width, Screen.FromControl(this).Bounds.Height - bmpScreenshot.Height);
                        Console.WriteLine("Bottom right corner detected");
                        break;
                }
            }
            else
            {
                this.DesktopLocation = new Point(FixationPoint.X - (this.Width / 2), FixationPoint.Y - (this.Height / 2));
                Point newLensPoint = new Point();
                /*Yeah this is pretty horrible*/
                newLensPoint.X = FixationPoint.X - (int)((this.Width / ZOOMLEVEL) * 1.25);
                newLensPoint.Y = FixationPoint.Y - (int)((this.Height / ZOOMLEVEL) * 1.25);
                newLensPoint.X = newLensPoint.X + this.Size.Width / 4;
                newLensPoint.Y = newLensPoint.Y + this.Size.Width / 4;
                SetLensPoint(newLensPoint.X, newLensPoint.Y);
            }
        }
        private void SetLensPoint(int x, int y)
        {
            lensPoint.X = x;
            lensPoint.Y = y;
            //return lensPoint;
        }
        public void TakeScreenShot()
        {
            Size zoomSize = new Size(this.Size.Width / 2, this.Size.Height / 2);
            graphics.CopyFromScreen(lensPoint.X, lensPoint.Y, 0, 0, zoomSize, CopyPixelOperation.SourceCopy);
        }
        public void ResetZoomLens()
        {
            DrawTimer.Stop();
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
            return TranslateToDesktop(relativePoint.X, relativePoint.Y);
        }
        private Point TranslateToDesktop(int x, int y)//This method translates on form coordinates to desktop coordinates
        {
            //somehow check if the user has looked in a corner or not, maybe a bool flag or something
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
        public Point CornerOffset(Corner corner, Point fixationPoint)
        {
            int offset = (int)(ZOOMLENS_SIZE * 0.34);/*This used to calculate the offset based on zoomlevel etc, but was lost in a git accident. RIP. This version works but only
                                                    * for zoom level 3*/
            switch (corner)
            {
                case Corner.NoCorner:
                    return fixationPoint;
                case Corner.TopLeft:
                    fixationPoint.X = fixationPoint.X - offset;
                    fixationPoint.Y = fixationPoint.Y - offset;
                    return fixationPoint;
                case Corner.TopRight:
                    fixationPoint.X = fixationPoint.X + offset;
                    fixationPoint.Y = fixationPoint.Y - offset;
                    return fixationPoint;
                case Corner.BottomLeft:
                    fixationPoint.X = fixationPoint.X - offset;
                    fixationPoint.Y = fixationPoint.Y + offset;
                    return fixationPoint;
                case Corner.BottomRight:
                    fixationPoint.X = fixationPoint.X + offset;
                    fixationPoint.Y = fixationPoint.Y + offset;
                    return fixationPoint;
            }
            return fixationPoint;
        }

        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            offScreenGraphics.DrawImage(bmpScreenshot, 0, 0, 500, 500);

            gazeHighlight.drawHightlight();

            mainCanvas.DrawImage(offScreenBitmap, 0, 0);
        }
    }
}