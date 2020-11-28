using SSEDigitalV3.DataCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SSEDigitalV3.NewSSEInterface
{
    /// <summary>
    /// Interação lógica para SSEinserted.xam
    /// </summary>
    public partial class SSEinserted : Page
    {
        SSEDBWrapper sse;

        public SSEinserted(SSEDBWrapper sse)
        {
            InitializeComponent();
            this.sse = sse;
            this.textBlockNome.Text = "SSE Nº: " + sse.id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
