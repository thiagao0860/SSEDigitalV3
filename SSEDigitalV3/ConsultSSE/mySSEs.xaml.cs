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
            public string requisitante { set; get; }
            public string data { set; get; }
            public string tipo { set; get; }
            public string fornecedor { set; get; }
            public string description { set; get; }
            public string ordem { set; get; }
            public string codigo { set; get; }
            public string referencia { set; get; }
            public string prazo { set; get; }
            public string prioridade { set; get; }
            public string valor { set; get; }
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
                this.DataGridSSEs.Items.Add(new DataInserter {
                    id=(int)iterator.id , 
                    requisitante=iterator.ISSEBean.Requisitante.Matricula.ToString(), 
                    data=iterator.ISSEBean.Data.ToString(), 
                    tipo=iterator.ISSEBean.getSavebleTipo(), 
                    fornecedor=iterator.ISSEBean.getSavebleFornecedor(),  
                    description=iterator.ISSEBean.Descricao,
                    ordem=iterator.ISSEBean.Ordem,
                    codigo=iterator.ISSEBean.Codigo,
                    referencia=iterator.ISSEBean.Referencia,
                    prazo=iterator.ISSEBean.Prazo.ToString(),
                    prioridade=iterator.ISSEBean.Prioridade.ToString(),
                    valor=iterator.ISSEBean.Valor.ToString()
                });
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
