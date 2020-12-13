using SSEDigitalV3.DataCore;
using SSEDigitalV3.MainDBConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SSEDigitalV3.NewSSEInterface
{
    /// <summary>
    /// Lógica interna para SSEInsertResponse.xaml
    /// </summary>
    public partial class SSEInsertResponse : Window
    {
        public static int INSERT_SSE = 1;
        public static int UPDATE_SSE = 2;
        private int target;
        LoadingPage lp;
        SSEDBWrapper sse;
        Window sseWindow;
        public SSEInsertResponse(SSEDBWrapper sse, Window sseWin , int target)
        {
            InitializeComponent();
            this.lp = new LoadingPage();
            this.inserted_host.Navigate(lp);
            this.sse = sse;
            sseWindow = sseWin;
            this.target = target;
        }

        private void hasShowed(object sender, RoutedEventArgs e)
        {
            lp.startLoading();
            SSEMainDBConnector conector = new SSEMainDBConnector();
            Console.WriteLine("Date operation started");
            int status=0;
            if (target == INSERT_SSE)
            {
                status = conector.insertSSE(sse);
                lp.stopLoading();
                if (status > 0)
                {
                    sse.id = status;
                    this.inserted_host.Navigate(new SSEinserted(sse, this, sseWindow));
                }
            }
            else if (target == UPDATE_SSE)
            {
                if (sse.id > 0)
                {
                    if (conector.updateSSE((int)sse.id, sse)) status = 1;
                    lp.stopLoading();
                    if (status > 0)
                    {
                        this.inserted_host.Navigate(new SSEupdated(sse, this, sseWindow));
                    }
                }
                else
                {
                    throw new Exception("process try to update a SSE but it does not exist");
                }
            }
        }
    }
}
