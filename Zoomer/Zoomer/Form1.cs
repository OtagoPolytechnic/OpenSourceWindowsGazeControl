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
using EyeXFramework;

namespace Zoomer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void OnMouseDown(int x, int y)
        {
            ZoomLens ZoomLens = new ZoomLens(x,y);
            ZoomLens.CreateZoomLens();
            ZoomLens.Dispose();
        }
    }
}