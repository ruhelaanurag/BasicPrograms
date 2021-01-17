using Microsoft.SqlServer.Server;
using System.IO;
using System.Security.Cryptography;

namespace SampleProject
{
    public class AESEncryption
    {
        [SqlProcedure]
        public static string Encrypt(string keyStr, string messageObj)
        {
            string retVal = string.Empty;
            string message = messageObj.ToString();
            // Check arguments.
            if (string.IsNullOrEmpty(message))
            {
                // Nothing to encrypt!!
                return string.Empty;
            }
            
            AesCryptoServiceProvider m_myAes = null;
            m_myAes = new AesCryptoServiceProvider();
            m_myAes.Mode = CipherMode.CBC;
            m_myAes.KeySize = 128;
            m_myAes.BlockSize = 128;
            m_myAes.Padding = PaddingMode.PKCS7;

            byte[] key = new byte[16];

            byte[] myKey = System.Text.Encoding.UTF8.GetBytes(keyStr);
            for (int i = 0; i < key.Length; i++)
            {
                key[i] = myKey[i];
                if (myKey.Length < i)
                    break;
            }

            // We shall keep key and IV to be same.
            m_myAes.Key = key;
            m_myAes.IV = key;

            byte[] encrypted;

            // Create a decrytor to perform the stream transform.
            ICryptoTransform encryptor = m_myAes.CreateEncryptor(m_myAes.Key, m_myAes.IV);

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(message);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }

            retVal = System.Convert.ToBase64String(encrypted);

            // Return the base64 string of encrypted bytes from the memory stream.
            return retVal;
        }

        [SqlProcedure]
        public static string Decrypt(string keyStr, string encryptedDataObj)
        {
            string encryptedData = encryptedDataObj.ToString();
            AesCryptoServiceProvider m_myAes = null;
            m_myAes = new AesCryptoServiceProvider();
            m_myAes.Mode = CipherMode.CBC;
            m_myAes.KeySize = 128;
            m_myAes.BlockSize = 128;
            m_myAes.Padding = PaddingMode.PKCS7;

            byte[] key = new byte[16];

            byte[] myKey = System.Text.Encoding.UTF8.GetBytes(keyStr);
            for (int i = 0; i < key.Length; i++)
            {
                key[i] = myKey[i];
                if (myKey.Length < i)
                    break;
            }

            // We shall keep key and IV to be same.
            m_myAes.Key = key;
            m_myAes.IV = key;

            // Check arguments.
            if (string.IsNullOrEmpty(encryptedData))
            {
                return string.Empty;
                //   throw new ArgumentNullException("encryptedData");
            }

            byte[] cipherText = System.Convert.FromBase64String(encryptedData);

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create a decrytor to perform the stream transform.
            ICryptoTransform decryptor = m_myAes.CreateDecryptor(m_myAes.Key, m_myAes.IV);

            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }

            return plaintext;
        }
    }
}
