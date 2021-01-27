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
    /// 
    public class BgpSSEInsertResponse
    {
        public static int INSERT_SSE = 1;
        public static int UPDATE_SSE = 2;
        private int target;
        private SSEDBWrapper sse;
        private SSEInsertResponse parent;
        
        public BgpSSEInsertResponse(SSEDBWrapper sse, int target,SSEInsertResponse parent)
        {
            this.sse = sse;
            this.target = target;
            this.parent = parent;
        }

        public void insertToDataBase()
        {
            SSEMainDBConnector conector = new SSEMainDBConnector();
            Console.WriteLine("Date operation started");
            int status = 0;
            if (target == INSERT_SSE)
            {
                status = conector.insertSSE(sse);
                if (status > 0)
                {
                    sse.id = status;
                    this.parent.Dispatcher.Invoke(() =>
                    {
                        this.parent.inserted_host.Navigate(new SSEinserted(sse, parent, parent.sseWindow));
                    });
                }
            }
            else if (target == UPDATE_SSE)
            {
                if (sse.id > 0)
                {
                    if (conector.updateSSE((int)(sse.id), sse))
                    {
                        status = 1;
                        this.parent.Dispatcher.Invoke(() =>
                        {
                            this.parent.inserted_host.Navigate(new SSEupdated(sse, parent, parent.sseWindow));
                        });
                    }
                }
                else
                {
                    MessageBox.Show("SSE inexistente");
                }
            }
            
        }
    }

    public partial class SSEInsertResponse : Window
    {
        public static int INSERT_SSE = 1;
        public static int UPDATE_SSE = 2;
        public Window sseWindow;
        public SSEInsertResponse(SSEDBWrapper sse, Window sseWin , int target)
        {
            InitializeComponent();
            
            sseWindow = sseWin;

            BgpSSEInsertResponse bgpInsertResponse = new BgpSSEInsertResponse(sse, target, this);
            Thread tbgpInsertToDatabaseDelegate = new Thread(new ThreadStart(bgpInsertResponse.insertToDataBase));
            tbgpInsertToDatabaseDelegate.SetApartmentState(ApartmentState.STA);
            tbgpInsertToDatabaseDelegate.Start();
            this.inserted_host.Navigate(new LoadingPage());
        }

        
    }
}
