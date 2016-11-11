using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeXFramework;
using Tobii.EyeX.Framework;
using Tobii.EyeX.Client;
using System.Drawing;
using System.Timers;
using EyeXFramework.Forms;


/*
 *  Class: ScrollControl
 *  Name: Richard Horne
 *  Date: 11/11/2016
 *  Description: Tracks a users gaze and computes this into actions that scroll the in-focus window up, down, left and right.
 */


namespace GazeToolBar
{
    // Struct that is used to define the bounds of the dead zone(zone where when users is looking there is no scrolling input to the current window that has focus.
    public struct NoScollRect
    {
        public int LeftBound, RightBound, TopBound, BottomBound;

        public NoScollRect(int leftBound, int rightBound, int topBound, int bottomBound)
        {
            LeftBound = leftBound;
            RightBound = rightBound;
            TopBound = topBound;
            BottomBound = bottomBound;
        }
    }

   public class ScrollControl
    {
       //Fields

       //Sets the speed of scrolling, each increment of 1 is equivalent to 1 roll click of the scroll wheel on a real mouse.
        public int ScrollScalarValue { get; set; } 

       //Used to define bounds where no scrolling happens when a user is looking in this location
        public NoScollRect deadZoneRect;

       //Event stream used to capture data about where user is currently looking on screen.
        GazePointDataStream gazeStream;
        
       //Current location of where user is looking.
        double currentGazeLocationX;
        double currentGazeLocationY;

       //timer used to fire scroll method at regular interval.
        private Timer scrollStepTimer;

       //Properties
        public int DeadZoneHorizontalPercent { get; set; }
        public int DeadZoneVerticalPercent { get; set; }

        public int ScrollStepTimerDuration { get; set; }


       //Constructor
        public ScrollControl(int scrollStepTimerDuration, int InitialScrollScalarValue, int deadZoneHorizontalPercent, int deadZoneVerticalPercent, FormsEyeXHost EyeXHost)
        {
            //set scroll step timer duration.
            ScrollStepTimerDuration = scrollStepTimerDuration;

            //Connect to eyeX engine gaze stream. 
            gazeStream = EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);

            //Create gate points event handler delegate
            EventHandler<GazePointEventArgs> gazeDel = new EventHandler<GazePointEventArgs>(updateGazeCoodinates);
            //register delegate with gaze data stream next event.
            gazeStream.Next += gazeDel;

            //set up scroll step timer
            scrollStepTimer = new Timer(ScrollStepTimerDuration);
            //Set to auto reset so that it fires events continuously at the ScrollStepTimerDuration
            scrollStepTimer.AutoReset = true;

            //Register scroll method with timer elapsed event.
            scrollStepTimer.Elapsed += scroll;

            //Set initial deadzone size of screen percent.
            DeadZoneHorizontalPercent = deadZoneHorizontalPercent;
            DeadZoneVerticalPercent = deadZoneVerticalPercent;

            //run SetDeadZoneBounds method to set up the deadZoneRect field initially.
            SetDeadZoneBounds();

            //pass in ScrollscalarValue, this will be set by the users saved settings.
            ScrollScalarValue = InitialScrollScalarValue;

        }

        //This method is run when the scrollStepTime raises an elapsed event. The method checks if the latest gaze coordinate from the user is out side the
       // deadZoneRect, if the coordinates are outside this zone the value is then passed to the calculate scroll speed method which returns and integer value of how
       // many mouse wheel clicks to scroll.
       private void scroll(object O, ElapsedEventArgs e ) 
        {
           int xScrollValue = 0;
           int yScrollValue = 0;

           //check if users gaze on X axis is greater the right bound deadZoneRect
           if(currentGazeLocationX > deadZoneRect.RightBound)
           {
               //Calculate how much to scroll
               xScrollValue = calculateScrollSpeed(currentGazeLocationX, deadZoneRect.RightBound, ValueNeverChange.SCREEN_SIZE.Width, ScrollScalarValue, false);
           }
           //check if users gaze on X axis is less than left bound of deadZoneRect
           if(currentGazeLocationX < deadZoneRect.LeftBound)
           {
               xScrollValue = calculateScrollSpeed(currentGazeLocationX, 0, deadZoneRect.LeftBound, ScrollScalarValue, true);
           }

           if (currentGazeLocationY > deadZoneRect.BottomBound)
           {
               yScrollValue = calculateScrollSpeed(currentGazeLocationY, deadZoneRect.BottomBound, ValueNeverChange.SCREEN_SIZE.Height, ScrollScalarValue, false);
           }
           if (currentGazeLocationY < deadZoneRect.TopBound)
           {
               yScrollValue = calculateScrollSpeed(currentGazeLocationY, 0, deadZoneRect.TopBound, ScrollScalarValue, true);
           }

           //only scroll is the value is greater than 0
           if (Math.Abs(xScrollValue) > 0 || Math.Abs(yScrollValue) > 0)
           {//pass amount to scroll in respective direction
               VirtualMouse.Scroll(yScrollValue, xScrollValue * -1);// xScrollValue * -1 is used to correct scroll direction on x axis
           }

        }



       //This method is subscribed to a stream of user gaze points, which is a stream of points which are coordinates of where the users gaze currently is on screen.
        private void updateGazeCoodinates(object o, GazePointEventArgs currentGaze)
        {
            //Save the users gaze to a field that has global access in this class.
            currentGazeLocationX = currentGaze.X;
            currentGazeLocationY = currentGaze.Y;

            //if the users gaze goes off screen, Stop Scroll control running, this returns control back to the statemanager.
            if( checkIFGazeOffScreen(currentGaze.X,currentGaze.Y))
            {
                stopScroll();
            }

        }

       //This method calculates the scroll speed for the input axis coordinate, and bounds
        private int calculateScrollSpeed(double axisCoordinate, int scaleMin, int scaleMax, int scrollScalarValue, bool ISNegativeScroll)
        {
            //ScaleMin and scaleMax are the start and end measurements that are outside the deadZoneRect bounds, this gives you a range of how
            // much distance in pixels of none deadZoneRect to calculate the scroll speed.
            double rangeToCalcScrollSpeedOver = scaleMax - scaleMin;

            double calculatedInputFromCoordinate = 0;

            //IsNegative is used to determine where to calculate the difference from the input coordinate against the range. For example on the X axis
            // if we are working out how much to scroll left  the user is looking at the left had side of the screen between x0 and xleftbound of deadZoneRect
            //or if they are looking to the right the user is looking between xrightbound of deadZonerect and  xscreen width.
            if (ISNegativeScroll)
            {
                calculatedInputFromCoordinate = scaleMax - axisCoordinate;
            }
            else
            {
                 calculatedInputFromCoordinate = axisCoordinate - scaleMin;
            }

            //work out the percentage of how much the user is gazing over the range 
            double ScrollSpeedInPercent = calculatedInputFromCoordinate / rangeToCalcScrollSpeedOver;

            //Times the percentage by the scalar value to give the speed to scroll.
            int scaledScrollSpeed = (int) Math.Floor(ScrollSpeedInPercent * scrollScalarValue);

            //If is negative, reverse the scroll speed value to scroll in the opposite direction.
            if(!ISNegativeScroll)
            {
                scaledScrollSpeed *= -1;
            }

            //Return scroll speed.
            return scaledScrollSpeed;
        }


       //Check if the coordinates are out side the bounds of the primary screen.
       private bool checkIFGazeOffScreen(double gazeX, double gazeY)
       {
           if( gazeX > ValueNeverChange.SCREEN_SIZE.Width || gazeX < 0
                || gazeY > ValueNeverChange.PRIMARY_SCREEN.Height || gazeY < 0)
           {
               return true;
           }
           return false;
       }



       //Public method for the sate machine to start scroll control running.
        public void StartScroll()
        {
            SetDeadZoneBounds();

            scrollStepTimer.Start();
        }


       //Stop Scroll control
        public void stopScroll()
        {//Raise flag with state manager
            SystemFlags.scrolling = false;
            //Stop timer from running event to check if scrolling is needed.
            scrollStepTimer.Stop();
        }

        public void SetDeadZoneBounds()
        {
            //Work out bounds of deadZoneRect rectangle ie place where no scrolling happens when the user is looking there.

            //Find Center of each axis
            int screenHolizontalCenter = ValueNeverChange.SCREEN_SIZE.Width / 2;
            int screenVerticalCenter = ValueNeverChange.SCREEN_SIZE.Height / 2;

            //work out how many pixels the deadZone is on each axis
            int deadZoneWidth = (int)(((double)DeadZoneHorizontalPercent / 100) * ValueNeverChange.SCREEN_SIZE.Width);
            int deadZoneHeight = (int)(((double)DeadZoneVerticalPercent / 100) * ValueNeverChange.SCREEN_SIZE.Height);
           
            //half this amount.
            int halfDeadZoneWidth = deadZoneWidth / 2;
            int halfDeadZoneHeight = deadZoneHeight / 2;

            //Set deaZone bounds from center of each axis
            deadZoneRect.LeftBound = screenHolizontalCenter - halfDeadZoneWidth;
            deadZoneRect.RightBound = screenHolizontalCenter + halfDeadZoneWidth;

            deadZoneRect.TopBound = screenVerticalCenter - halfDeadZoneHeight;
            deadZoneRect.BottomBound = screenVerticalCenter + halfDeadZoneHeight;
        
        }





    }
}
