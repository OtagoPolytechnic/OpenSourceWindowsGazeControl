using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

/*
 *  Class: HookedKeyboardEventArgs
 *  Name: Richard Horne
 *  Date: 11/11/2016
 *  Description: Event Raised by Fixation KeyboardHook when ever a keyboard key is pressed, transfers this key press to subscribed objects.
 */


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
