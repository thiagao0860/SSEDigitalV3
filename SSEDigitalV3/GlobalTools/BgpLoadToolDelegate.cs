using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSEDigitalV3.GlobalTools
{
    class BgpLoadToolDelegate
    {
        public LoadTool lt;
        public static void showTool()
        {
            lt = new LoadTool();
            try
            {
                lt.ShowDialog();
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine("Thread - caught ThreadAbortException - resetting.");
                Console.WriteLine("Exception message: {0}", e.Message);
                if (lt.IsVisible)
                {
                    lt.Close();
                }
                Thread.ResetAbort();
            }
            Thread.Sleep(1000);
            Console.WriteLine("Thread - finished working.");
        }
    }
}
