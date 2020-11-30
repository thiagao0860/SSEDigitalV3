using SSEDigitalV3.DataCore;
using SSEDigitalV3.MainDBConnector;
using SSEDigitalV3.UserDBConnector;
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
    /// Lógica interna para mySSEs.xaml
    /// </summary>
    public partial class mySSEs : Window
    {
        private User usr;
        public struct DataInserter
        {
            public int id { set; get; }
            public string description { set; get; }
        }
        public mySSEs(User usr)
        {
            InitializeComponent();
            this.usr = usr;
            initializeTable();
        }
        public mySSEs(Intent intent_usr)
        {
            InitializeComponent();
            SQLiteUserConnector connector = new SQLiteUserConnector();
            this.usr = connector.GetUserByMatricula(intent_usr.getString("matricula"));
            initializeTable();
        }

        public void initializeTable()
        {
            SSEMainDBConnector connector2 = new SSEMainDBConnector();
            List<SSEDBWrapper> my_sses = connector2.findSSE("solicitante",usr.Matricula);
            foreach (SSEDBWrapper iterator in my_sses)
            {
                this.DataGridSSEs.Items.Add(new DataInserter {id=(int)iterator.id , description=iterator.ISSEBean.Descricao});
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonExcelHandle(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Under Construction");
        }

        private void buttonPDFHandle(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Under Construction");
        }

        private void buttonEmailHandle(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Under Construction");
        }
    }
}
