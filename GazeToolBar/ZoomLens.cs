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
            mainCanvas = this.CreateGraphics();
            offScreenGraphics = Graphics.FromImage(offScreenBitmap);
            graphics = Graphics.FromImage(bmpScreenshot);
            this.FormBorderStyle = FormBorderStyle.None;
            fixdet = FixDet;

            gazeHighlight = new GazeHighlight(FixDet, offScreenGraphics, EHighlightShaderType.RedToGreen, this);
        }
        public Corner checkCorners(Point FixationPoint)
        {
            int maxDistance = bmpScreenshot.Width;
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
                    return (Corner)i;
                }
            }
            return Corner.NoCorner;
        }
        public Edge checkEdge()
        {
            Edge edge = Edge.NoEdge;
            if (this.DesktopLocation.Y < -100)//top
            {
                return Edge.Top;
            }
            if (this.DesktopLocation.X < -100)//left
            {
                return Edge.Left;
            }
            if (this.DesktopLocation.Y + this.Height > Screen.PrimaryScreen.Bounds.Size.Height + 100)//bottom
            {
                return Edge.Bottom;
            }
            if (this.DesktopLocation.X + this.Width > Screen.PrimaryScreen.Bounds.Size.Width + 100)//right
            {
                return Edge.Right;
            }
            return edge;
        }
        public void setZoomLensPositionCorner(Corner corner)
        {
            switch (corner)
            {
                case Corner.TopLeft:
                    this.DesktopLocation = new Point(0, 0);
                    lensPoint = new Point(0, 0);
                    break;
                case Corner.TopRight:
                    this.DesktopLocation = new Point(Screen.FromControl(this).Bounds.Width - this.Width, 0);
                    lensPoint = new Point(Screen.FromControl(this).Bounds.Width - bmpScreenshot.Width, 0);
                    break;
                case Corner.BottomLeft:
                    this.DesktopLocation = new Point(0, Screen.FromControl(this).Bounds.Height - this.Height);
                    lensPoint = new Point(0, Screen.FromControl(this).Bounds.Height - bmpScreenshot.Height);
                    break;
                case Corner.BottomRight:
                    this.DesktopLocation = new Point(Screen.FromControl(this).Bounds.Width - this.Width, Screen.FromControl(this).Bounds.Height - this.Height);
                    lensPoint = new Point(Screen.FromControl(this).Bounds.Width - bmpScreenshot.Width, Screen.FromControl(this).Bounds.Height - bmpScreenshot.Height);
                    break;
            }
        }
        public void setZoomLensPositionEdge(Edge edge, Point fixationPoint)
        {
            switch (edge)
            {
                case Edge.NoEdge:
                    break;
                case Edge.Top:
                    this.DesktopLocation = new Point(this.DesktopLocation.X, 0);
                    lensPoint = new Point(calculateLensPointX(fixationPoint.X), this.DesktopLocation.Y);
                    break;
                case Edge.Right:
                    this.DesktopLocation = new Point(Screen.PrimaryScreen.Bounds.Size.Width - this.Width, this.DesktopLocation.Y);
                    lensPoint = new Point(Screen.PrimaryScreen.Bounds.Size.Width - bmpScreenshot.Width, calculateLensPointY(fixationPoint.Y));
                    break;
                case Edge.Bottom:
                    this.DesktopLocation = new Point(this.DesktopLocation.X, Screen.PrimaryScreen.Bounds.Size.Height - this.Height);
                    lensPoint = new Point(calculateLensPointX(fixationPoint.X), Screen.PrimaryScreen.Bounds.Size.Height - bmpScreenshot.Height);
                    break;
                case Edge.Left:
                    this.DesktopLocation = new Point(0, this.DesktopLocation.Y);
                    lensPoint = new Point(this.DesktopLocation.X,calculateLensPointY(fixationPoint.Y));
                    break;
            }
        }
        private int calculateCornerDistance(Point fixationPoint, Point corner)
        {
            int returnInt = Math.Abs(fixationPoint.X - corner.X) + Math.Abs(fixationPoint.Y - corner.Y);

            //int retint = (int)Math.Sqrt(((corner.X - fixationPoint.X) ^ 2) + ((corner.Y - fixationPoint.Y) ^ 2));
            return returnInt;
        }
        public void CreateZoomLens(Point FixationPoint)
        {
            Size zoomSize = new Size(this.Size.Width / 2, this.Size.Height / 2);

            this.Show();//make lens visible
            offScreenGraphics.DrawImage(bmpScreenshot, 0, 0, 500, 500);
            this.TopMost = true;
            Console.WriteLine("ZoomLens.Bounds.X = " + this.Bounds.X);
            Console.WriteLine("ZoomLens.Bounds.Y = " + this.Bounds.Y);
            DrawTimer.Start();
            Application.DoEvents();
        }
        public void determineDesktopLocation(Point FixationPoint)
        {
            this.DesktopLocation = new Point(FixationPoint.X - (this.Width / 2), FixationPoint.Y - (this.Height / 2));
            SetLensPoint(FixationPoint, Edge.NoEdge);
        }
        private int calculateLensPointX(int fixationX)
        {
            int x;
            x = fixationX - (int)((this.Width / ZOOMLEVEL) * 1.25);
            x = x + this.Size.Width / 4;
            return x;
        }
        private int calculateLensPointY(int fixationY)
        {
            int y;
            y = fixationY - (int)((this.Height / ZOOMLEVEL) * 1.25);
            y = y + this.Size.Height / 4;
            return y;
        }
        public void SetLensPoint(Point FixationPoint, Edge edge)//determines the location of the zoomed in screenshot
        {
            switch (edge)
            {
                case Edge.NoEdge:
                    lensPoint.X = calculateLensPointX(FixationPoint.X);
                    lensPoint.Y = calculateLensPointY(FixationPoint.Y);
                    break;
                case Edge.Top:
                    lensPoint.X = calculateLensPointX(FixationPoint.X);
                    lensPoint.Y = this.DesktopLocation.Y;
                    break;
                case Edge.Right:
                    lensPoint.X = Screen.PrimaryScreen.Bounds.Size.Width - bmpScreenshot.Width;
                    lensPoint.Y = calculateLensPointY(FixationPoint.Y);
                    break;
                case Edge.Bottom:
                    lensPoint.X = calculateLensPointX(FixationPoint.X);
                    lensPoint.Y = Screen.PrimaryScreen.Bounds.Size.Height - bmpScreenshot.Height;
                    break;
                case Edge.Left:
                    lensPoint.X = this.DesktopLocation.X;
                    lensPoint.Y = calculateLensPointY(FixationPoint.Y);
                    break;
            }
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
        public Point edgeOffset(Edge edge, Point fixationPoint)
        {
            int offset = (int)(ZOOMLENS_SIZE * 0.34);/*This used to calculate the offset based on zoomlevel etc, but was lost in a git accident. RIP. This version works but only
                                                    * for zoom level 3*/
            switch (edge)
            {
                case Edge.NoEdge:
                    return fixationPoint;
                case Edge.Top:
                    fixationPoint.Y = fixationPoint.Y - offset;
                    break;
                case Edge.Right:
                    fixationPoint.X = fixationPoint.X + offset;
                    break;
                case Edge.Bottom:
                    fixationPoint.Y = fixationPoint.Y + offset;
                    break;
                case Edge.Left:
                    fixationPoint.X = fixationPoint.X - offset;
                    break;
            }
            return fixationPoint;
        }
        public Point cornerOffset(Corner corner, Point fixationPoint)
        { 
            int offset = (int)(ZOOMLENS_SIZE * 0.34);
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