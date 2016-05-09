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
        Graphics graphics;
        Zoomer zoom;
        Bitmap bmpScreenshot;
        Size size;
        public Form2()
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
        public void updatethis()
        {
            Point mousePoint = System.Windows.Forms.Cursor.Position;
            Point empty = new Point(0, 0);
            
            
            graphics.CopyFromScreen(mousePoint.X - (size.Width / 2), mousePoint.Y - (size.Height / 2), empty.X, empty.Y, size, CopyPixelOperation.SourceCopy);
            
            pictureBox1.Image = bmpScreenshot;



            //System.Threading.Thread.Sleep(100);
            //Application.DoEvents();
            //for (int i = 0; i < 10; i++)
            //{
            //    bmpScreenshot = zoom.zoom(bmpScreenshot);
            //    bmpScreenshot.Save("test" + i + ".bmp");
            //    picture.Image = bmpScreenshot;
            //    System.Threading.Thread.Sleep(100);
            //    Application.DoEvents();
            //}
        }
    }
}
