using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    public class StateManager
    {
        public enum state { Setup, Wait, KeyboardDisplayed, ActionButtonSelected, Zooming, Zoomed, ApplyAction, DisplayFeedback }



        public StateManager()
        {
            globalVars.currentState = state.Setup;
            //instatiate everything
            globalVars.currentState = state.Wait;

        }
        public void UpdateState()
        {
            state currentState = globalVars.currentState;
            switch (currentState)
            {
                case state.Setup:
                    if (true)//setup is finished
                    {
                        currentState = state.Wait;
                    }
                    break;
                case state.Wait:

                    if (true) //if a button has been selected
                    {
                        currentState = state.ActionButtonSelected;
                    }
                    else if (true) //Keyboard button is pressed
                    {
                        currentState = state.KeyboardDisplayed;
                    }
                    break;
                case state.ActionButtonSelected:
                    if (true)//gaze has happened
                    {
                        currentState = state.Zooming;
                    }
                    else if (true) //timeout has happened
                    {
                        currentState = state.Wait;
                    }
                    break;
                case state.Zooming:
                    if (true) //zoom has happened successfully
                    {
                        currentState = state.Zoomed;
                    }
                    else if (true)//zoom did not finish successfully
                    {
                        currentState = state.ApplyAction;
                    }
                    break;
                case state.ApplyAction:
                    if (true) // action has been applied / finished
                    {
                        currentState = state.Wait;
                    }
                    break;
            }
            globalVars.currentState = currentState;
        }
        public void Action()
        {

        }
        public static class globalVars
        {
            public static bool isKeyBoardUP { get; set; }
            public static state currentState { get; set; }
        }
    }
}
