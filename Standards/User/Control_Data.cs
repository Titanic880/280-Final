using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standards.User
{
    /// <summary>
    /// Primary object that is passed from helpee to helper to determine if they are allowed to use certain features
    /// (Heavily Intergrated as if checks)
    /// </summary>
    [Serializable]
    public class Control_Data
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
        public int Timer_Time { get; set; } = 60;
        #endregion Properties

        public Control_Data()
        {

        }
        public Control_Data(Control_Data data)
        {
            this.KeyBoard = data.KeyBoard;
            this.Mouse = data.Mouse;
            this.Use_Timer = data.Use_Timer;
            this.Timer_Time = data.Timer_Time;
        }
    }
}
