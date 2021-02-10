using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace RestoreBackup
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void pathSystemLogButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Selecionar Arquivo";
            dialog.DefaultExt = ".db";
            dialog.ShowDialog();
            if (dialog.FileName == null) { throw new Exception("invalid name"); }
            this.pathSystemLogTextBox.Text = dialog.FileName;
        }

        private void pathCoreDBButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Selecionar Arquivo";
            dialog.DefaultExt = ".db";
            dialog.ShowDialog();
            if (dialog.FileName == null) { throw new Exception("invalid name"); }
            this.pathCoreDBTextBox.Text = dialog.FileName;
        }

        private void cancelButtonclick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void restoreButtonClick(object sender, RoutedEventArgs e)
        {
            if (validateUser())
            {
                restoreBackup();
                MessageBox.Show("Dados Restaurados");
            }
            else
            {
                MessageBox.Show("Dados Incongruentes");
                this.Close();
            }
        }

        public void restoreBackup()
        {
            String arq1 = File.ReadAllText(this.pathSystemLogTextBox.Text);
            byte[] byteArq1 = Encoding.ASCII.GetBytes(arq1);
            FileStream fs = new FileStream(Environment.CurrentDirectory + "\\SystemLog.db", FileMode.Create, FileAccess.Write);
            BinaryWriter bn = new BinaryWriter(fs);
            bn.Write(byteArq1);
            fs.Close();
            bn.Close();

            String arq2 = File.ReadAllText(this.pathCoreDBTextBox.Text);
            byte[] byteArq2 = Encoding.ASCII.GetBytes(arq2);
            fs = new FileStream(Environment.CurrentDirectory + "\\CoreDatabase.db", FileMode.Create, FileAccess.Write);
            bn = new BinaryWriter(fs);
            bn.Write(byteArq2);
        }

        public bool validateUser()
        {
            bool returnStatement= true;
            returnStatement = (returnStatement && this.userTextBox.Text.Equals("00000000"));
            returnStatement = (returnStatement && this.senhaTextBox.Text.Equals("SSEdigital-0"));
            return returnStatement;
        }
    }
}
