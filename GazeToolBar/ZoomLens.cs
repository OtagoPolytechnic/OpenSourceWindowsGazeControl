using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EyeXFramework;

namespace GazeToolBar
{
    public partial class ZoomLens : Form
    {
        const int ZOOMLEVEL = 2;// this is controls how far the lens will zoom in
        int x, y;
        Graphics graphics;
        Bitmap bmpScreenshot;
        delegate void SetFormDelegate(int x, int y);

        FixationDetection fixdet;
        EyeXHost eyeHost;
        public ZoomLens()
        {
            //wait to see where the user is looking
            //translate where the user looked on the form to 
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width / 4;//setting the lens size
            this.Height = Screen.PrimaryScreen.Bounds.Height / 4;

            bmpScreenshot = new Bitmap(this.Width / ZOOMLEVEL, this.Height / ZOOMLEVEL);//set bitmap to same size as the lens
            graphics = this.CreateGraphics();
            graphics = Graphics.FromImage(bmpScreenshot);



            pictureBox1.Width = this.Width;//set picturebox to same size as form
            pictureBox1.Height = this.Height;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;//make the image stretch to the bounds of the picturebox

            this.FormBorderStyle = FormBorderStyle.None;
            eyeHost = new EyeXHost();
            fixdet = new FixationDetection(eyeHost);
            //fixdet.SetupSelectedFixationAction();//pass in getrelativecoords
        }
        public void getRelativeCoords()
        {
 
        }
        public void CreateZoomLens(int x, int y)
        {
            if (this.InvokeRequired)
            {
                SetFormDelegate sfd = new SetFormDelegate(SetForm);
                this.Invoke(sfd, new Object[] { x, y });
            }
            //perform click here @ the center of the form
        }
        public void SetForm(int x, int y)
        {
            this.DesktopLocation = new Point(x - (this.Width / 2), y - (this.Height / 2));//set the position of the lens and offset it by it's size /2 to center the lens on the location of the current event
            this.Show();//make lens visible

            graphics.CopyFromScreen(x - (bmpScreenshot.Width / 2), y - (bmpScreenshot.Height / 2), 0, 0, bmpScreenshot.Size, CopyPixelOperation.SourceCopy);

            pictureBox1.Image = bmpScreenshot;

            Application.DoEvents();

            //somehow check for when another fixation happens on the form?
            
            System.Threading.Thread.Sleep(10000);//find a better way than sleep


            //somehow get current looking location 
            //Point clickPoint = TranslateToDesktop(newX, newY);
            //Make the @ the newX and newY Point
            this.Dispose();
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
            returnPoint.X = x - (this.Width / 2) * (1 / ZOOMLEVEL) + (this.Left + (this.Width / 2));
            returnPoint.Y = y - (this.Height / 2) * (1 / ZOOMLEVEL) + (this.Top + (this.Height / 2));
            return returnPoint;
        }
    }
}

