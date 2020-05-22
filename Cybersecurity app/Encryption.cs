using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Cybersecurity_app
{
    /// <summary>
    /// Class: Encryption
    /// Write by: Florentin Eduard Decu
    /// Description: This class can be used to encrypt and decrypt data. Encryption used is AES ecryption one of the mose secure encryption
    /// </summary>
    public class Encryption
    {
        //Key used to encrypt and decrypt data 
        protected string key = "basdf23h2h235hkjhhj235jhop2765sd";

        /// <summary>
        /// Parameterless constructor 
        /// </summary>
        public Encryption()
        {
            
        }

        /// <summary>
        /// Function used to encrypt plain text. 
        /// </summary>
        /// <param name="plainText">Plain text</param>
        /// <returns></returns>
        public string EncryptData(string plainText)
        {
            //Create byte array used to encrypt data. Plain text will be changed to byte data 
            byte[] b = new byte[16];
            byte[] array;

            //Create aes encryption onject 
            using (Aes aes = Aes.Create())
            {
                //Encode the key 
                aes.Key = Encoding.UTF8.GetBytes(key);
                //Initialise vector 
                aes.IV = b;
                //Create encryption 
                ICryptoTransform cryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV);
                //Create a memory stream object 
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    //Create crypto strea link data to cryptographic transformation
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, cryptoTransform, CryptoStreamMode.Write))
                    {
                        //Encrypt the plain text to the memory 
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                        
                        //Get the encrypted data from the memory 
                        array = memoryStream.ToArray();
                    }
                }
            }
            //Save the result 
            string result = Convert.ToBase64String(array);

            //Return the restul 
            return result;
        }

        /// <summary>
        /// Function used to decrypt data 
        /// </summary>
        /// <param name="encryptedText">Encrypted data</param>
        /// <returns></returns>
        public string DecryptData(string encryptedText)
        {

            byte[] b = new byte[16];
            //Create a byte buffer
            byte[] buffer = Convert.FromBase64String(encryptedText);
            //Create aes encryption onject 
            using (Aes aes = Aes.Create())
            {
                //Encode the key 
                aes.Key = Encoding.UTF8.GetBytes(key);
                //Initialise vector 
                aes.IV = b;
                //Initialise the cryptografic transformation
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                //Create memory stream 
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    //Create crypto strea link data to cryptographic transformation
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        //Create stream readear and return the decrypted data as plain text 
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
