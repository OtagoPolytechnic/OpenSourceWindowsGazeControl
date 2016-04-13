using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoomer
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Zoomer zoom;
        Bitmap bmpScreenshot;
        public Form1()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            zoom = new Zoomer(graphics, pictureBox1);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


            bmpScreenshot = new Bitmap(100, 100);
            graphics = Graphics.FromImage(bmpScreenshot);


            pictureBox1.Image = bmpScreenshot;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point mousePoint = System.Windows.Forms.Cursor.Position;
            Point empty = new Point(0, 0);
            Size size = new Size(100, 100);

            graphics.CopyFromScreen(mousePoint.X - 50, mousePoint.Y - 50, empty.X, empty.Y, size, CopyPixelOperation.SourceCopy);



            for (int i = 0; i < 10; i++)
            {
                bmpScreenshot = zoom.cropImage(bmpScreenshot);
                pictureBox1.Image = bmpScreenshot;
                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
            }
        }
    }
}
