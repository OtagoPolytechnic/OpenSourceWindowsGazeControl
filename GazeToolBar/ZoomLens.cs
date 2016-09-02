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
        Graphics graphics;

        Graphics highLightGraphics;

        Bitmap bmpScreenshot;
        delegate void SetFormDelegate(int x, int y);
        FixationDetection fixdet;

        GazeHighlight gazeHighlight;

        

        public ZoomLens(FixationDetection FixDet)
        {
            InitializeComponent();

            
          
            this.Width = 500;//setting the lens size
            this.Height = 500;
            Console.WriteLine("This.width = " + this.Width);
            Console.WriteLine("This.width = " + this.Height);

            highLightGraphics = this.CreateGraphics();

            bmpScreenshot = new Bitmap(this.Width / ZOOMLEVEL, this.Height / ZOOMLEVEL);//set bitmap to same size as the lens
            graphics = this.CreateGraphics();
            graphics = Graphics.FromImage(bmpScreenshot);



            pictureBox1.Width = 20;//set picturebox to same size as form
            pictureBox1.Height = 20;
           // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;//make the image stretch to the bounds of the picturebox

            this.FormBorderStyle = FormBorderStyle.None;
            fixdet = FixDet;

            gazeHighlight = new GazeHighlight(FixDet, highLightGraphics, EHighlightShaderType.RedToGreen, this);

            
        }
        public void getRelativeCoords()
        {

        }
        public void CreateZoomLens(Point FixationPoint)
        {
            this.DesktopLocation = new Point(FixationPoint.X - (this.Width / 2), FixationPoint.Y - (this.Height / 2));//set the position of the lens and offset it by it's size /2 to center the lens on the location of the current event
            this.Show();//make lens visible
            
            Point lensPoint = new Point();
            Point empty = new Point(0, 0);

            lensPoint.X = FixationPoint.X - (int)((this.Width / ZOOMLEVEL) * 1.25 );//this sets the position on the screen which is being zoomed in. 
            lensPoint.Y = FixationPoint.Y - (int)((this.Height / ZOOMLEVEL) *1.25);

            Size zoomSize = new Size(this.Size.Width /2 , this.Size.Height / 2);
            graphics.CopyFromScreen(lensPoint.X + this.Size.Width / 4, lensPoint.Y + this.Size.Height / 4, empty.X, empty.Y, zoomSize, CopyPixelOperation.SourceCopy);

            bmpScreenshot.Save("bmpScreenshot.bmp");
            //pictureBox1.Image = bmpScreenshot;
            this.TopMost = true;
            DrawTimer.Start();
            Application.DoEvents();
        }
        public void ResetZoomLens()
        {
            DrawTimer.Stop();
            this.Hide();
        }
        public Point TranslateGazePoint(Point fixationPoint)
        {
            Point relativePoint = this.PointToClient(fixationPoint);
            Console.WriteLine("FormLeft =" + this.Left);
            Console.WriteLine("Form Width = " + this.Width);
            Console.WriteLine("original fixationPoint = " + fixationPoint);
            Console.WriteLine("relativePoint = " + relativePoint);
            if (relativePoint.X < 0 || relativePoint.Y < 0 || relativePoint.X > this.Width || relativePoint.Y > this.Height)
            {
                return new Point(-1, -1);//cheap hack. If it is out of bound at all, this will return -1, -1. The statemanager will cancel the zoom
            }
            return TranslateToDesktop(relativePoint.X, relativePoint.Y);
        }

        public Bitmap Zoom(Bitmap bmpScreenshot)//old method not needed for magnify version
        {
            //RectangleF destinationRect = new RectangleF(150, 20, 1.3f * bmpScreenshot.Width, 1.3f * bmpScreenshot.Height);
            RectangleF cropArea = new RectangleF(0, 0, .5f * bmpScreenshot.Width, .5f * bmpScreenshot.Height);


            //Rectangle cropArea = new Rectangle(ZOOMLEVEL, ZOOMLEVEL, bmpScreenshot.Width - (ZOOMLEVEL * 2), bmpScreenshot.Height - (ZOOMLEVEL * 2));
            Bitmap bmpImage = new Bitmap(bmpScreenshot);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }
        public Point TranslateToDesktop(int x, int y)//This method translate on form coordinates to desktop coordinates
        {
            Point returnPoint = new Point();

            int halfHeight = this.Width / 2;
            int halfWidth = this.Height / 2;
            int halfHeightDivZoom = halfHeight / ZOOMLEVEL;
            int halfWidthDivZoom = halfWidth / ZOOMLEVEL;

            int a = halfHeight - halfHeightDivZoom;
            a = this.Top + a;
            returnPoint.Y = a + (y / ZOOMLEVEL);

            int b = halfWidth - halfWidthDivZoom;
            b = this.Left + b;
            returnPoint.X = b + (x / ZOOMLEVEL);
            Console.WriteLine("returnPoint = " + returnPoint);
            return returnPoint;
        }

        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            highLightGraphics.DrawImage(bmpScreenshot, 0, 0);
            //graphics.Clear(Color.White);

            gazeHighlight.drawHightlight();
            Application.DoEvents();

            //graphics.FillEllipse(new SolidBrush(Color.Black), 231, 240, 20, 20);

        }
    }
}


