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
        LoadingPage lp;
        SSEDBWrapper sse;
        public SSEInsertResponse(SSEDBWrapper sse)
        {
            InitializeComponent();
            this.lp = new LoadingPage();
            this.inserted_host.Navigate(lp);
            this.sse = sse;

        }

        private void hasShowed(object sender, RoutedEventArgs e)
        {
            lp.startLoading();
            SSEMainDBConnector conector = new SSEMainDBConnector();
            Console.WriteLine("text");
            int status = conector.insertSSE(sse);
            lp.stopLoading();
            if (status > 0)
            {
                sse.id = status;
                this.inserted_host.Navigate(new SSEinserted(sse));
            }
        }
    }
}
