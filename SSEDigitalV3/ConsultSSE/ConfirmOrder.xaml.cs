using SSEDigitalV3.DataCore;
using SSEDigitalV3.ExcelIntegration;
using SSEDigitalV3.GlobalTools;
using SSEDigitalV3.MainDBConnector;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace SSEDigitalV3.ConsultSSE
{
    /// <summary>
    /// Lógica interna para ConfirmOrder.xaml
    /// </summary>
    /// 
    public class BgpConfirmOrder
    {
        string nPath;
        string nPOnumber;

        public BgpConfirmOrder(string nPath, string nPOnumber)
        {
            this.nPath = nPath;
            this.nPOnumber = nPOnumber;
        }

        public void processPO()
        {
            try
            {
                POWrapper po = (new GetDataFromPO(nPath)).findPOData();
                po.vPONumber = nPOnumber;
                SSEMainDBConnector connector = new SSEMainDBConnector();
                foreach (PORow iterator in po.servicesInfo)
                {
                    int separator_index = iterator.description.IndexOf("/");
                    if (separator_index <= 0 || separator_index >= iterator.description.Length) throw new Exception("Separador Especifico não encontrado.");
                    string id = iterator.description.Substring(0, separator_index);
                    string service_number = iterator.description.Substring(separator_index + 1);
                    List<SSEDBWrapper> sse_vector = connector.findSSE("id", id);
                    if (sse_vector.Count <= 0) { throw new Exception("SSE de Número: " + id + "não encontrada no Banco de Dados, por favor revise o template de entrada."); }
                    SSEDBWrapper sse = sse_vector.ElementAt(0);
                    sse.numero_da_PO = po.vPONumber;
                    sse.iss = iterator.iSSAliq.ToString();
                    sse.valor_do_orcamento_retorno = (float)iterator.unitValueSAP;
                    sse.numero_do_orcamento = service_number;
                    sse.data_recebimento = System.DateTime.Now;
                    connector.updateSSE(int.Parse(id), sse);
                }
                MessageBox.Show("PO inserida");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
    }

    public partial class confirmOrder : Window
    {
        String path = null;
        String ordem = null;
        public confirmOrder()
        {
            InitializeComponent();
        }

        private void getPathButton_onClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog  dialog = new OpenFileDialog();
            dialog.Title = "Selecionar Arquivo";
            dialog.Filter = " Excel Macro Enabled Files|*.xlsm| Excel Files|*.xlsx| All Files|*.*";
            dialog.DefaultExt = ".xlsm";
            dialog.ShowDialog();
            if (dialog.FileName == null) { throw new Exception("invalid name"); }
            this.path = dialog.FileName;
            this.pathTextBox.Text = this.path;
        }

        private void insertPOButton_onClick(object sender, RoutedEventArgs e)
        {
            insertPO();
        }

        

        private void helpButton_onClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\documentation\\help\\insertPOhelp.pdf");
        }

        public void insertPO()
        {
            BgpConfirmOrder bgpConfirmOrder = new BgpConfirmOrder(path, ordem);
            BgpLoadToolDelegate bgpLoadToolDelegate = new BgpLoadToolDelegate();
            Thread tbgpConfimOrder = new Thread(new ThreadStart(bgpConfirmOrder.processPO));
            Thread tbgpLoadToolDelegate = new Thread(new ThreadStart(BgpLoadToolDelegate.showTool));
            tbgpLoadToolDelegate.SetApartmentState(ApartmentState.STA);
            tbgpConfimOrder.SetApartmentState(ApartmentState.STA);
            tbgpConfimOrder.Start();
            tbgpLoadToolDelegate.Start();
            tbgpConfimOrder.Join();
            
            try
            {
                if (tbgpLoadToolDelegate.IsAlive) 
                {    
                    tbgpLoadToolDelegate.Abort();
                }
            } catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

    }
}
