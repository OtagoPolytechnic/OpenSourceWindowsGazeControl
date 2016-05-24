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

        const int LENSSIZE = 1200;// how big the actual lens is
        const int ZOOMLEVEL = 2;// this is controls how far the lens will zoom in
        int x, y;
        Graphics graphics;
        Bitmap bmpScreenshot;
        delegate void SetFormDelegate(int x, int y);
        FixationDetection fixationWorker;
        public ZoomLens(FixationDetection fixationWorker)
        {

            //get gaze coordinates
            //find the offset based on how big the screenshot will be
            //take a screenshot at the coordinates
            //make a form %percentage size of the screenshot %percentage = the zoom percentage
            //off set the form so it is above the original coordinates
            //wait to see where the user is looking
            //translate where the user looked on the form to 
            InitializeComponent();
            this.fixationWorker = fixationWorker;
            //this.x = x;
            //this.y = y;
            this.Width = LENSSIZE;//setting the lens size
            this.Height = LENSSIZE;

            bmpScreenshot = new Bitmap(this.Width / ZOOMLEVEL, this.Height / ZOOMLEVEL);//set bitmap to same size as the lens
            graphics = this.CreateGraphics();
            graphics = Graphics.FromImage(bmpScreenshot);



            pictureBox1.Width = this.Width;//set picturebox to same size as form
            pictureBox1.Height = this.Height;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;//make the image stretch to the bounds of the picturebox

            this.FormBorderStyle = FormBorderStyle.None;
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
            Point lensPoint = new Point();
            Point empty = new Point(0, 0);
            lensPoint.X = x; //- (this.Width / 2);//this sets the position on the screen which is being zoomed in. 
            lensPoint.Y = y; //- (this.Height / 2);
            graphics.CopyFromScreen(lensPoint.X - (bmpScreenshot.Width /2), lensPoint.Y - (bmpScreenshot.Height /2) , empty.X, empty.Y, bmpScreenshot.Size, CopyPixelOperation.SourceCopy);

            bmpScreenshot = Zoom(bmpScreenshot);
            pictureBox1.Image = bmpScreenshot;
            Application.DoEvents();
            //somehow check for when another fixation happens on the form?
            System.Threading.Thread.Sleep(10000);


            //somehow get current looking location 
            //Point clickPoint = TranslateToDesktop(newX, newY);
            //Make the @ the newX and newY Point
            this.Dispose();
        }
        public Bitmap Zoom(Bitmap bmpScreenshot)
        {
            //RectangleF destinationRect = new RectangleF(150, 20, 1.3f * bmpScreenshot.Width, 1.3f * bmpScreenshot.Height);
            RectangleF cropArea = new RectangleF(0, 0, .5f * bmpScreenshot.Width, .5f * bmpScreenshot.Height);


            //Rectangle cropArea = new Rectangle(ZOOMLEVEL, ZOOMLEVEL, bmpScreenshot.Width - (ZOOMLEVEL * 2), bmpScreenshot.Height - (ZOOMLEVEL * 2));
            Bitmap bmpImage = new Bitmap(bmpScreenshot);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }
        public Point TranslateToDesktop(int x, int y)
        {
            Point returnPoint = new Point();
            returnPoint.X = x - (this.Width / 2) * (1 / ZOOMLEVEL) + (this.Left + (this.Width / 2));
            returnPoint.Y = y - (this.Height / 2) * (1 / ZOOMLEVEL) + (this.Top + (this.Height / 2));
            return returnPoint;
        }
    }
}

