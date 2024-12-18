using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace SocialMediaPlatform.Encryption
{
    public class AESEncryption
    {
        private readonly string _key = "zZT9nNmuuPT9cq4DaLzy3HrH5AveKOtCBl17ThQetg/425KzBv2OyXrdRN3OrJ84";
        private readonly string _iv = "Nb1WOLk4+1V7+Rs4Lm2E2bEqzpmQxWirpMnQhA0NwVHFflaLPFPPJS1d2jei+QaC";
        public AESEncryption()
        {           
        }
        
        public string EncryptStringToBytes(string plainText)
        {
            byte[] encrypted;

            // Create an Aes object with the specified key and IV.
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.ASCII.GetBytes(_key);
                aes.IV = Encoding.ASCII.GetBytes(_iv);

                // Create a new MemoryStream object to contain the encrypted bytes.
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Create a CryptoStream object to perform the encryption.
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        // Encrypt the plaintext.
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        encrypted = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        public string DecryptStringFromBytes(byte[] cipherText)
        {
            string decrypted;

            // Create an Aes object with the specified key and IV.
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.ASCII.GetBytes(_key);
                aes.IV = Encoding.ASCII.GetBytes(_iv);
                // Create a new MemoryStream object to contain the decrypted bytes.
                using (MemoryStream memoryStream = new MemoryStream(cipherText))
                {
                    // Create a CryptoStream object to perform the decryption.
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        // Decrypt the ciphertext.
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            decrypted = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return decrypted;
        }
    }
}