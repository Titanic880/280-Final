using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System;

namespace Standards.User
{
    /// <summary>
    /// this stores the generic user that will be saved/read from the database
    /// THIS SHOULD NEVER BE PASSED OVER THE TCP CONNECTION
    /// BECAUSE THIS IS FOR A PROTOTYPE, BOTH SIDES WILL HAVE DATABASE PROTOCOL BUILT INTO THEM
    /// if made past prototype, a central server Project will be needed that can handle the database Systems
    /// </summary>
    public class User_Data
    {
        #region Properties
        /// <summary>
        /// Primary Database ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name the person will prefer to go by
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// First name of the user
        /// </summary>
        public string F_Name { get; set; }

        /// <summary>
        /// Should always be hashed
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The image of the profile stored in a byte format
        /// </summary>
        public byte[] Profile_Image { get; set; }
        #endregion Properties

        public User_Data()
        {

        }

        public byte[] Convert_To_Bytes(Bitmap img)
        {
            byte[] ret = null;
            throw new NotImplementedException();
            return ret;
        }

        public Bitmap Convert_From_Bytes(byte[] img)
        {
            Bitmap ret = null;
            throw new NotImplementedException();
            return ret;
        }

        #region Overrides
        /// <summary>
        /// Sets the Basic string value to 'UserName'
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return UserName;
        }

        /// <summary>
        /// This is due to a problem I had on the 275 final
        /// (I ran into issues when comparing users against eachother)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Checks if the compare is a user_data
            if (obj is User_Data comparee)
                //Compares against the Cared for data
                if (comparee.F_Name == this.F_Name
                    && comparee.UserName == this.UserName
                    && comparee.Password == this.Password)
                    return true;
            //if the above checks fail
            return false;
        }

        /// <summary>
        /// System no like when this no exist ....
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion Overrides
    }
}
