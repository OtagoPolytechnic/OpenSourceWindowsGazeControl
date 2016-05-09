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
            
            //graphics = this.CreateGraphics();
            //zoom = new Zoomer(graphics);


            //bmpScreenshot = new Bitmap(100, 100);
            //graphics = Graphics.FromImage(bmpScreenshot);


            MouseDown += OnMouseDown;
        }

        private void OnMouseDown(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            form.updatethis();
            
        }
    }
}