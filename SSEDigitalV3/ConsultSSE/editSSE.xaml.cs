using SSEDigitalV3.DataCore;
using SSEDigitalV3.MainDBConnector;
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
using System.Windows.Shapes;

namespace SSEDigitalV3.ConsultSSE
{
    /// <summary>
    /// Lógica interna para editSSE.xaml
    /// </summary>
    public partial class editSSE : Window
    {
        SSEDBWrapper sse;
        SSEMainDBConnector connector;

        public editSSE(SSEDBWrapper sse)
        {
            this.sse = sse;
            connector = new SSEMainDBConnector();
            InitializeComponent();
            constructor();
        }

        public editSSE(String id)
        {
            connector = new SSEMainDBConnector();
            SSEDBWrapper sse = connector.findSSE("id",id).ElementAt(0);
            this.sse = sse;
            InitializeComponent();
            constructor();
        }

        private void constructor()
        {
            this.textBoxTitulo.Text = "Editor de SSEs - " + this.sse.id; 
        }

        private void buttonExClick(object sender, MouseButtonEventArgs e)
        {
            connector.deleteSSE(this.sse.id);
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
