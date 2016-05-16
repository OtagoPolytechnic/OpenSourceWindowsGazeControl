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
using Tobii;


namespace clickOnButtonWithEyes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Program.EyeXHost.Connect(behaviorMap1);

            behaviorMap1.Add(button1, new GazeAwareBehavior(OnButton1Gaze) { DelayMilliseconds = 500 });
            behaviorMap1.Add(button2, new GazeAwareBehavior(OnButton2Gaze) { DelayMilliseconds = 500 });

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void OnButton2Gaze(object Sender, GazeAwareEventArgs e)
        {
            button2.PerformClick();
            if (e.HasGaze)
            {
                button2.BackColor = Color.Red;
            }
            else
            {
                button2.BackColor = Color.Gold;
            }

        }


        private void OnButton1Gaze(object Sender, GazeAwareEventArgs e)
        {
            button1.PerformClick();
            if (e.HasGaze)
            {
                button1.BackColor = Color.Red;
            }
            else
            {
                button1.BackColor = Color.Gold;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button clicked");
            
        }
    }
}
