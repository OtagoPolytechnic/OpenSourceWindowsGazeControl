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
    public partial class Form2 : Form
    {
        public PictureBox picture {get; set;}
        Graphics graphics;
        Zoomer zoom;
        Bitmap bmpScreenshot;
        public Form2()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            bmpScreenshot = new Bitmap(100, 100);
            graphics = Graphics.FromImage(bmpScreenshot);

            picture = new PictureBox();
            picture.Width = this.Width;
            picture.Height = this.Height;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;

            this.FormBorderStyle = FormBorderStyle.None;
            zoom = new Zoomer(graphics);
        }
        public void updatethis()
        {
            Point mousePoint = System.Windows.Forms.Cursor.Position;
            Point empty = new Point(0, 0);
            Size size = new Size(100, 100);
            

            graphics.CopyFromScreen(mousePoint.X - (size.Width / 2), mousePoint.Y - (size.Height / 2), empty.X, empty.Y, size, CopyPixelOperation.SourceCopy);


            for (int i = 0; i < 10; i++)
            {
                bmpScreenshot = zoom.cropImage(bmpScreenshot);
                picture.Image = bmpScreenshot;
                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
            }
        }
    }
}
