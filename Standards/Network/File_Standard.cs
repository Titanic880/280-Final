using System;

namespace Standards.Network
{
    [Serializable]
    public class File_Standard
    {
        /// <summary>
        /// The original name of the file
        /// </summary>
        public string File_Name { get; set; }
        /// <summary>
        /// The file Extension of the file
        /// </summary>
        public string File_Ext { get; set; }

        /// <summary>
        /// If false then its an encrypted message
        /// </summary>
        public bool Is_File { get; set; } = false;
        /// <summary>
        /// Contents of the file
        /// </summary>
        public byte[] File_Contents { get; set; }

        /// <summary>
        /// REMOVE WHEN ENCRYPTION WORKS
        /// </summary>
        public string Message { get; set; }
        #region Overrides
        /// <summary>
        /// Returns the full file name (Name+Ext)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return File_Name + File_Ext;
        }

        /// <summary>
        /// Determines if the contents are the same
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Checks if the object is of the same class
            if (obj is File_Standard comparee)
                if (comparee.File_Contents == this.File_Contents)
                    return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion Overrides
    }
}
