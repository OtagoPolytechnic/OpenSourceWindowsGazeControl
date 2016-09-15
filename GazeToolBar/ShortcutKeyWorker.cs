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


        public void RunKeyFunction(object o, HookedKeyboardEventArgs pressedKey)
        {
            switch(pressedKey.KeyPressed){
                case Key.F2:
                    //SystemFlags.actionButtonSelected = true;//raise action button flag
                    SystemFlags.ShortCutKeyPressed = true;
                    SystemFlags.actionToBePerformed = ActionToBePerformed.LeftClick;
            break;

            }
        }


        private void updateGazeCoodinates(object o, GazePointEventArgs currentGaze)
        {
            //Save the users gaze to a field that has global access in this class.
            currentGazeLocationX = currentGaze.X;
            currentGazeLocationY = currentGaze.Y;

        }


        public Point GetXY()
        {
            return new Point((int)currentGazeLocationX, (int)currentGazeLocationY);

        }
    }
}
