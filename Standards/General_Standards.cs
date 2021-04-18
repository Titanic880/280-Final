using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
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
        /// Generates a pair of keys
        /// </summary>
        public static void GeneratePair(bool type = false)
        {
            //Builds the RSA crypto that the keys are built in
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);

            if (type)
            {
                string privateKeyText = rsa.ToXmlString(true);
                File.WriteAllText("Key", privateKeyText);
            }
            else
            {
                string publicKeyText = rsa.ToXmlString(false);
                File.WriteAllText("Key", publicKeyText);
            }
        }

        /// <summary>
        /// Encrypts the data passed into it
        /// </summary>
        /// <returns></returns>
        public static byte[] Encrypt(string text)
        {
            if (!File.Exists("key"))
                return default;
            //Builds the encryption service
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(File.ReadAllText("key"));

            byte[] text_Bytes = Encoding.Default.GetBytes(text);
            return rsa.Encrypt(text_Bytes, true);
        }

        /// <summary>
        /// Decrypts the byte[] to a string of text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Decrypt(byte[] text)
        {
            //Checks for the key
            if (!File.Exists("key"))
                return "Key not found!";
            //Builds the encryption service
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(File.ReadAllText("key"));

            return Encoding.Default.GetString(rsa.Decrypt(text, true));
        }


        #endregion Encryption
        private static byte[] Convert_ByteArr(string text)
        {
            List<byte> ret = new List<byte>();
            char[] chars = text.ToArray();

            foreach (char a in chars)
                ret.Add(Convert.ToByte(a));

            return ret.ToArray();
        }

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
