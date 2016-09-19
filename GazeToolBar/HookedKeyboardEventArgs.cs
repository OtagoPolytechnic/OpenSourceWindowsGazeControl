using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace GazeToolBar
{

   public class HookedKeyboardEventArgs : EventArgs
    {
       public Key KeyPressed { get; set; }

       public HookedKeyboardEventArgs(Key keyPressed)
       {
           KeyPressed = keyPressed; 
       }
    }
}
