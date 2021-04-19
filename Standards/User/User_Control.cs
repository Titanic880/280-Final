using System.Windows.Forms;
using System;

namespace Standards.User
{
    /// <summary>
    /// The primary logic of the Control checks
    /// </summary>
    public class User_Control : Control_Data
    {
        #region Timer_Control
        /// <summary>
        /// Primary Timer object (using Timer)
        /// </summary>
        private readonly Timer timer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            //Turns off the timer
            timer.Stop();

            //Additional check to make sure control isnt revoked un-intentionally
            if (Use_Timer)
            {
                //Sets access values
                KeyBoard = false;
                Mouse = false;
                //Sends to the helper class
                TimerComplete(this);
            }
        }
        #endregion Timer_Control

        #region delegates
        /// <summary>
        /// Runs when the timer has completed its runtime
        /// </summary>
        public event TimerDone TimerComplete;
        public delegate void TimerDone(User_Control new_Control);
        #endregion
        #region Constructors
        /// <summary>
        /// Loads Control with default settings
        /// </summary>
        public User_Control() { }

        /// <summary>
        /// Primary constructor that fills the data via base class
        /// </summary>
        /// <param name="d"></param>
        public User_Control(Control_Data d):base(d)
        {

        }
        public User_Control(int Timer_Duration, bool Keyboard = true, bool Mouse = true, bool Use_Timer = true)
        {
            //Sets internal values
            Timer_Time = Timer_Duration;
            this.Use_Timer = Use_Timer;
            this.KeyBoard = Keyboard;
            this.Mouse = Mouse;

            //Configures the timer
            timer = new Timer();
            timer.Interval += 100 * Timer_Time;
            timer.Tick += Timer_Tick;

        }
        #endregion Constructors
        /// <summary>
        /// Run this after the helper has tied into the delegate and configured
        /// </summary>
        public void Restart_Timer()
        {
            timer.Stop();
            timer.Start();
        }
    }
}
