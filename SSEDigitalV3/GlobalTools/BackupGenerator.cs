using SSEDigitalV3.DataCore;
using SSEDigitalV3.UserDBConnector;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SSEDigitalV3.GlobalTools
{
    class BackupGenerator
    {
        private CultureInfo culture;

        public BackupGenerator()
        {
            this.culture = MainConstants.getInstance().culture;
        }

        public void restoreBackup()
        {
            String arq = File.ReadAllText(Environment.CurrentDirectory + "\\SystemLog(RESTORED).db");
            byte[] byteArq = Encoding.Default.GetBytes(arq);
            FileStream fs = new FileStream(Environment.CurrentDirectory + "\\SystemLog.db", FileMode.Create, FileAccess.Write);
            BinaryWriter bn = new BinaryWriter(fs);
            bn.Write(byteArq);
        }

        public void createBackup()
        {
            RunAsync();
        }

        async Task RunAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST
                File.Copy(Environment.CurrentDirectory + "\\SystemLog.db", Environment.CurrentDirectory + "\\SystemLog-r.db");
                File.Copy(Environment.CurrentDirectory + "\\CoreDatabase.db", Environment.CurrentDirectory + "\\CoreDatabase-r.db");

                FileStream fs1 = new FileStream(Environment.CurrentDirectory + "\\SystemLog-r.db", FileMode.Open, FileAccess.Read);
                BinaryReader bn1 = new BinaryReader(fs1, Encoding.Default);
                byte[] byteArq1 = bn1.ReadBytes((int)fs1.Length);
                String arq1 = Encoding.Default.GetString(byteArq1);
                fs1.Close();
                bn1.Close();
                
                fs1 = new FileStream(Environment.CurrentDirectory + "\\CoreDatabase-r.db", FileMode.Open, FileAccess.Read);
                bn1 = new BinaryReader(fs1, Encoding.Default);
                byte[] byteArq2 = bn1.ReadBytes((int)fs1.Length);
                String arq2 = Encoding.Default.GetString(byteArq2);
                
                BackupBean backupBean = new BackupBean()
                {
                    id = System.DateTime.Now.Date.ToString(culture),
                    arquivo = arq1,
                    core=arq2
                };

                HttpResponseMessage response = await client.PostAsJsonAsync(
                    "https://prod-114.westeurope.logic.azure.com:443/workflows/aff3de2bf480426384ea9a21179ce57e/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=M7Kzb2o2amegH_LE2Di3rbVRPN46G4mPF9_DKxiQw7k"
                    , backupBean);
                if (response.IsSuccessStatusCode)
                {   //PUT
                    Console.WriteLine("Sent");
                    SQLiteUserConnector connector = new SQLiteUserConnector();
                    DateTime newDate = System.DateTime.Now.Date;
                    connector.PutStringValue("lastBackup", newDate.ToString(culture));
                }
                File.Delete(Environment.CurrentDirectory + "\\SystemLog-r.db");
                File.Delete(Environment.CurrentDirectory + "\\CoreDatabase-r.db");
            }
        }
    }
}