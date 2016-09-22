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

    //public enum EToolBarFunction { LeftClick, RightClick, DoubleClick, Scroll, DragAndDrop}

    public class ShortcutKeyWorker
    {
        

        //Fields
        GazePointDataStream gazeStream;

        double currentGazeLocationX;
        double currentGazeLocationY;

        Dictionary<ActionToBePerformed, String> keyAssignments;

        Keyboardhook keyBoardHook;
        public ShortcutKeyWorker(Keyboardhook KeyboardObserver)//, Dictionary<EToolBarFunction, String> KeyAssignments)
        {
            keyBoardHook = KeyboardObserver;
            keyBoardHook.OnKeyPressed += RunKeyFunction;

            //keyAssignments = KeyAssignments;

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
