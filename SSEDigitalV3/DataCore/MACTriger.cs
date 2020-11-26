using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SSEDigitalV3.DataCore
{
    class MACTriger
    {
        public string MACValue;
        public string UniqueCode;
        public  User stance_user;
        public MACTriger(User sUser)
        {
            stance_user = sUser;
            if (sUser.Nome == null)
            {
                Exception e= new Exception("Try trigger MAC without User");
                throw e;
            }
            MACValue = getMAC();
            UniqueCode = getMAC() + getUser();
        }
        public static string getMAC()
        {
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                String enderecoMAC = string.Empty;
                foreach (NetworkInterface adapter in nics)
                {
                    // retorna endereço MAC do primeiro cartão
                    if (enderecoMAC == String.Empty)
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        enderecoMAC = adapter.GetPhysicalAddress().ToString();
                    }
                }
                return enderecoMAC;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string getUser()
        {
            try
            {
                return System.Windows.Forms.SystemInformation.UserName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string getUniqueCode()
        {
            try
            {
                return getMAC() + getUser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
