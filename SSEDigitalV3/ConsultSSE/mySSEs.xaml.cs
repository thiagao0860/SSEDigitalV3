using SSEDigitalV3.DataCore;
using SSEDigitalV3.ExcelIntegration;
using SSEDigitalV3.GlobalTools;
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

        private User usr;
        
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
            List<SSEDBWrapper> my_sses;
            if (usr.CelulaString.Equals("ALMOX"))
            {
                my_sses = connector2.findAllSSEs();
            }
            else
            {
                my_sses = connector2.findSSE("solicitante", usr.Matricula);
            }
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
            SSEMainDBConnector connector3 = new SSEMainDBConnector();
            List<SSEDBWrapper> my_sses;
            if (usr.CelulaString.Equals("ALMOX"))
            {
                my_sses = connector3.findAllSSEs();
            }
            else
            {
                my_sses = connector3.findSSE("solicitante", usr.Matricula);
            }
            ExcelConnector con = new ExcelConnector();
            for(int i =0; i<my_sses.Count ; i++)
            {
                con.makeRow(my_sses.ElementAt(i), i+1);
            }
            con.closeConnection();
        }

        private void buttonPDFHandle(object sender, MouseButtonEventArgs e)
        {
            IList<DataGridCellInfo> selection= this.DataGridSSEs.SelectedCells;
            SSEMainDBConnector connector = new SSEMainDBConnector();
            if (selection.Count>0)
            {
                for (int i=0;i<selection.Count;i=i+this.DataGridSSEs.Columns.Count)
                {
                    int sse_id = ((DataInserter)selection.ElementAt(i).Item).id;
                    SSEDBWrapper sse = connector.findSSE("id", sse_id.ToString()).ElementAt(0);
                    (new PrinterTools(sse)).printSSE();
                }
            }
            else{
                MessageBox.Show("Selecione as SSE's que deseja imprimir.","Info");
            }
        }

        private void buttonEmailHandle(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Under Construction");
        }

        private void editSSEClick(object sender, MouseButtonEventArgs e)
        {
            int id = ((DataInserter)this.DataGridSSEs.SelectedCells.ElementAt(0).Item).id;
            SSEMainDBConnector connector = new SSEMainDBConnector();
            SSEDBWrapper sse = connector.findSSE("id", id.ToString()).ElementAt(0);
            (new editSSE(sse)).ShowDialog();
        }
    }
}
