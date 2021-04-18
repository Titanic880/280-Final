using System.Windows.Forms;
using System;

namespace Standards.Network
{
    /// <summary>
    /// THIS IS FOR REFERENCE, DO NOT COPY PASTE INTO THE END SOLUTION <= Fuk-u :D
    /// (^was me in a test solution)
    /// </summary>
    [Serializable]
    public class User_Input
    {
        /// <summary>
        /// True == Keyboard input;; False == mouse input 
        /// </summary>
        public bool Input_Type { get; set; } = true;

        /// <summary>
        /// Used to determine if the helper is asking to control
        /// </summary>
        public bool Request { get; set; } = false;
        public Keys Key_Pressed { get; set; }

        #region Mouse_Click
        /// <summary>
        /// Determines if the click was a left or right click
        /// True = Left;; False = right
        /// </summary>
        public bool Click_Side { get; set; }

        /// <summary>
        /// Stores the conversion ratios
        /// </summary>
        public double xRatio { get; set; }
        public double yRatio { get; set; }

        /// <summary>
        /// Stores the conversions
        /// </summary>
        public int xClick { get; set; }
        public int yClick { get; set; }
        #endregion Mouse_Click
    }
}
