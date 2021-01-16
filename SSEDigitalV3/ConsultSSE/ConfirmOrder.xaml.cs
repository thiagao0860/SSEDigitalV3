using SSEDigitalV3.DataCore;
using SSEDigitalV3.ExcelIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace SSEDigitalV3.ConsultSSE
{
    /// <summary>
    /// Lógica interna para ConfirmOrder.xaml
    /// </summary>
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
            POWrapper po = (new GetDataFromPO(path)).findPOData();
            
        }

        private void helpButton_onClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\documentation\\help\\insertPOhelp.pdf");
        }
    }
}
