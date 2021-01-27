using System;
using System.IO;
using System.Security.Cryptography;

namespace SSEDigitalV3.RSAEncryptModule
{
    class KeyProtector
    {
        private static byte[] key = { 0x00, 0x08, 0x06, 0x00, 0x00, 0x08, 0x06, 0x00, 0x00, 0x08, 0x06, 0x00, 0x00, 0x08, 0x06, 0x00 };
        public static void SetEncryptString(String path, String tosave)
        {
            try
            {
                FileStream myStream = new FileStream(path, FileMode.OpenOrCreate);
                Aes aes = Aes.Create();
                aes.Key = key;
                byte[] iv = aes.IV;
                myStream.Write(iv, 0, iv.Length);
                CryptoStream cryptStream = new CryptoStream(
                    myStream,
                    aes.CreateEncryptor(),
                    CryptoStreamMode.Write);
                StreamWriter sWriter = new StreamWriter(cryptStream);
                sWriter.WriteLine(tosave);
                sWriter.Close();
            }
            catch
            {  
                Console.WriteLine("The Key Encryption failed.");
                throw;
            }
        }

        public static String GetDecryptString(String path)
        {
            try
            {
                FileStream myStream = new FileStream(path, FileMode.Open);
                Aes aes = Aes.Create();
                byte[] iv = new byte[aes.IV.Length];
                myStream.Read(iv, 0, iv.Length);
                CryptoStream cryptStream = new CryptoStream(
                   myStream,
                   aes.CreateDecryptor(key, iv),
                   CryptoStreamMode.Read);
                StreamReader sReader = new StreamReader(cryptStream);
                String retLine = sReader.ReadLine();
                sReader.Close();
                return retLine;
            }
            catch
            {
                Console.WriteLine("The Key Decryption failed.");
                throw;
            }
        }


    }
}
