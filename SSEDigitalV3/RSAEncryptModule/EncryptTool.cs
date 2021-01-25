using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SSEDigitalV3.RSAEncryptModule
{
    class EncryptTool
    {
        private string path = Environment.CurrentDirectory + "\\SystemP.dt";
        private RSA rsa;

        public EncryptTool()
        {
            rsa = RSA.Create();
            GenKey_SaveInContainer("PublicSignKey");
        }

        public String Encrypt(String data)
        {
            byte[] convertedData = Encoding.UTF8.GetBytes(data);
            byte[] encryptedByteArray = rsa.Encrypt(convertedData, RSAEncryptionPadding.OaepSHA1);
            return Convert.ToBase64String(encryptedByteArray);
        }

        public String Decrypt(String data)
        {
            byte[] convertedData = Convert.FromBase64String(data); 
            byte[] encryptedByteArray = rsa.Decrypt(convertedData, RSAEncryptionPadding.OaepSHA1);
            return Encoding.UTF8.GetString(encryptedByteArray);
        }

        private void GenKey_SaveInContainer(string containerName)
        {
            if (File.Exists(path))
            {
                String gettedInfo = File.ReadAllText(path);
                rsa.FromXmlString(gettedInfo);
            }
            else
            {
                rsa = new RSACryptoServiceProvider();
                String toSave = rsa.ToXmlString(true);
                File.WriteAllText(path, toSave);
            }
        }

        private void DeleteKeyFromContainer(string containerName)
        {
            rsa.Clear();
            File.Delete(path);
        }
    }
}
