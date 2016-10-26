using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeXFramework;
using Tobii.EyeX.Framework;
using Tobii.EyeX.Client;
using System.Windows.Input;
using System.Drawing;
using EyeXFramework.Forms;

namespace GazeToolBar
{

    public class ShortcutKeyWorker
    {
        

        //Fields
        GazePointDataStream gazeStream;
        EventHandler<GazePointEventArgs> gazeDel;

        double currentGazeLocationX;
        double currentGazeLocationY;

       public  Dictionary<ActionToBePerformed, String> keyAssignments { get; set; }

        KeyboardHook keyBoardHook;
        public ShortcutKeyWorker(KeyboardHook KeyboardObserver, Dictionary<ActionToBePerformed, String> KeyAssignments, FormsEyeXHost EyeXHost)//, Dictionary<EToolBarFunction, String> KeyAssignments)
        {
            keyBoardHook = KeyboardObserver;
            keyBoardHook.OnKeyPressed += RunKeyFunction;

            keyAssignments = KeyAssignments;

            //Connect to eyeX engine gaze stream. 
            gazeStream = EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);
            //Create gate points event handler delegate
            gazeDel = new EventHandler<GazePointEventArgs>(updateGazeCoodinates);
            //register delegate with gaze data stream next event.
            gazeStream.Next += gazeDel;

        }

        public void StopKeyboardWorker()
        {
            keyBoardHook.OnKeyPressed -= RunKeyFunction;
        }
        public void StartKeyBoardWorker(){
            keyBoardHook.OnKeyPressed += RunKeyFunction;
        }

        //Test functionality, tests ok, next step is to allow the user to program in and assign different keys to different gazetoolbar functions via the settings form.
        public void RunKeyFunction(object o, HookedKeyboardEventArgs pressedKey)
        {

            String keyString = pressedKey.KeyPressed.ToString();

            if (keyString == keyAssignments[ActionToBePerformed.LeftClick])
            {
                SystemFlags.ShortCutKeyPressed = true;
                
                SystemFlags.actionToBePerformed = ActionToBePerformed.LeftClick;
            }
            else if (keyString == keyAssignments[ActionToBePerformed.RightClick])
            {
                SystemFlags.ShortCutKeyPressed = true;
                
                SystemFlags.actionToBePerformed = ActionToBePerformed.RightClick;
            }
            else if (keyString == keyAssignments[ActionToBePerformed.DoubleClick])
            {
                SystemFlags.ShortCutKeyPressed = true;
       
                SystemFlags.actionToBePerformed = ActionToBePerformed.DoubleClick;
            }
            else if (keyString == keyAssignments[ActionToBePerformed.Scroll])
            {
                
                SystemFlags.ShortCutKeyPressed = true;
                SystemFlags.actionToBePerformed = ActionToBePerformed.Scroll;
            }

        }


        private void updateGazeCoodinates(object o, GazePointEventArgs currentGaze)
        {
            //Save the users current gaze location.
            currentGazeLocationX = currentGaze.X;
            currentGazeLocationY = currentGaze.Y;

        }

        //returns the users current gaze as a point.
        public Point GetXY()
        {
            return new Point((int)currentGazeLocationX, (int)currentGazeLocationY);
           
        }
    }
}
