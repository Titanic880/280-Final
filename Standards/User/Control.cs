using System.Windows.Forms;
using System;

namespace Standards.User
{
    /// <summary>
    /// Primary object that is passed from helpee to helper to determine if they are allowed to use certain features
    /// (Heavily Intergrated as if checks)
    /// </summary>
    [Serializable]
    public class Control
    {
        #region Properties
        /// <summary>
        /// True == Control allowed ;; false == Control Blocked
        /// </summary>
        public bool KeyBoard { get; set; } = false;

        /// <summary>
        /// True == Control allowed ;; false == Control Blocked
        /// </summary>
        public bool Mouse { get; set; } = false;

        /// <summary>
        /// Determines if the timer is to be used
        /// </summary>
        public bool Use_Timer { get; set; } = true;
        /// <summary>
        /// How long the timer will allow the control before turning it off
        /// </summary>
        public int Timer { get; set; } = 60;
        #endregion Properties

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
            KeyBoard = false;
            Mouse = false;
            TimerComplete(this);
        }
        #endregion Timer_Control

        #region delegates
        /// <summary>
        /// Runs when the timer has completed its runtime
        /// </summary>
        public event TimerDone TimerComplete;
        public delegate void TimerDone(Control new_Control);
        #endregion
        #region Constructors
        /// <summary>
        /// Loads Control with default settings
        /// </summary>
        public Control() { }

        public Control(int Timer_Duration, bool Keyboard = true, bool Mouse = true, bool Use_Timer = true)
        {
            //Sets internal values
            Timer = Timer_Duration;
            this.Use_Timer = Use_Timer;
            this.KeyBoard = Keyboard;
            this.Mouse = Mouse;

            //Configures the timer
            timer = new Timer();
            timer.Interval += 100 * Timer;
            timer.Tick += Timer_Tick;

        }
        #endregion Constructors
        /// <summary>
        /// Run this after the helper has tied into the delegate and configured
        /// </summary>
        public void Start_Timer()
        {
            timer.Start();
        }
    }
}
