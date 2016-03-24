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
using Tobii.EyeX.Framework;

namespace formdisplayXY
{
    public partial class Form1 : Form
    {
        EyeXHost IXHost;
        

        public Form1()
        {
            InitializeComponent();

            IXHost = new EyeXHost();

            //IXHost.Start();

            var stream = IXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);

            stream.Next +=
                 

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.button1.Click += new EventHandler(bob);
        }

        private void lbX_Click(object sender, EventArgs e)
        {

        }

        private void bob(object fred, EventArgs jim)
        {
           // MessageBox.Show("heres bob");
           // jim.
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
         
        }

        
      /*  private void xyObserver(object sender, GazePointEventArgs e)
        {
           // lbX.Text = e.X.ToString("F2");
          //  lbY.Text = e.Y.ToString("F2");

            //Console.WriteLine("y-Axis" + e.Y.ToString());
           // Console.WriteLine("x- axis " +  e.X.ToString());
            
        } */

        



    }
}
