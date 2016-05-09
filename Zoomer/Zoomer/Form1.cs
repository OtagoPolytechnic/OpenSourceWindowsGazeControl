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
        public Form1()
        {
            InitializeComponent();
            MouseDown += OnMouseDown;
            
        }

        private void OnMouseDown(object sender, EventArgs e)
        {
            ZoomLens ZoomLens = new ZoomLens();
            int x = System.Windows.Forms.Cursor.Position.X;
            int y = System.Windows.Forms.Cursor.Position.Y;
            ZoomLens.CreateZoomLens(x,y);
            ZoomLens.Dispose();
        }
    }
}