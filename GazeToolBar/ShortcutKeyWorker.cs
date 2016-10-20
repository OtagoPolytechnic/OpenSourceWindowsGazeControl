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

namespace GazeToolBar
{
    public class ShortcutKeyWorker
    {

        //Fields
        GazePointDataStream gazeStream;

        double currentGazeLocationX;
        double currentGazeLocationY;

        Keyboardhook keyBoardHook;
        public ShortcutKeyWorker(Keyboardhook KeyboardObserver)
        {
            keyBoardHook = KeyboardObserver;
            keyBoardHook.OnKeyPressed += RunKeyFunction;

            //Connect to eyeX engine gaze stream. 
            gazeStream = Program.EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);
            //Create gate points event handler delegate
            EventHandler<GazePointEventArgs> gazeDel = new EventHandler<GazePointEventArgs>(updateGazeCoodinates);
            //register delegate with gaze data stream next event.
            gazeStream.Next += gazeDel;





        }

        //Test functionality, tests ok, next step is to allow the user to program in and assign different keys to different gazetoolbar functions via the settings form.
        public void RunKeyFunction(object o, HookedKeyboardEventArgs pressedKey)
        {
            switch(pressedKey.KeyPressed){
                case Key.F2:
                    //signal to state manager the action to be performed.
                    SystemFlags.ShortCutKeyPressed = true;
                    SystemFlags.actionToBePerformed = ActionToBePerformed.LeftClick;

            break;

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
