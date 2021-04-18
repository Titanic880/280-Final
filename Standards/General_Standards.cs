using System.Security.Cryptography;
using System.Windows.Forms;
using System.Text;
using System.Linq;
using System.Net;
using System;

namespace Standards
{
    /// <summary>
    /// All public Standards that the project uses to connect/Sync/Desync Data
    /// </summary>
    public static class General_Standards
    {
        /// <summary>
        /// Port the application Runs on
        /// </summary>
        public const int Port = 25567;

        //Salt :)
        private const string SultyBoio = "AMNJLSKDJANDL:AKNDP{L:ADMA:ADS:OFIJ";


        #region Encryption
        /// <summary>
        /// Encrypts the data passed into it
        /// </summary>
        /// <returns></returns>
        public static string Encrypt()
        {
            string ret = null;
            throw new NotImplementedException();
            return ret;
        }

        /// <summary>
        /// Decrypts the data passed into it
        /// </summary>
        /// <returns></returns>
        public static string Decrypt()
        {
            string ret = null;
            throw new NotImplementedException();
            return ret;
        }


        #endregion Encryption

        #region Hashing
        //https://www.c-sharpcorner.com/article/compute-sha256-hash-in-c-sharp/ ;; Minor modifications made
        //https://passwordsgenerator.net/sha256-hash-generator/ ;; easy testing
        public static string Hasher(string plainText)
        {
            using (SHA256 hasher = SHA256.Create())
            {
                byte[] bytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(plainText + SultyBoio));
                string ret = null;
                for (int i = 0; i < bytes.Length; i++)
                    ret += bytes[i].ToString("x2");

                return ret;
            }
        }
        #endregion Hashing
    }
}
