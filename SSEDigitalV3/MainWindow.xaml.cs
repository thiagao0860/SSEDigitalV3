using SSEDigitalV3.AccountFeatures;
using SSEDigitalV3.ConsultSSE;
using SSEDigitalV3.DataCore;
using SSEDigitalV3.GlobalTools;
using SSEDigitalV3.NewSSEInterface;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SSEDigitalV3
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private User foundUser;


        public MainWindow(User foundUser)
        {
            this.foundUser = foundUser;
            InitializeComponent();
            initMainLabel();
        }
        public MainWindow(ref Intent intent)
        { 
            if (intent.getString("user_id") != null)
            {
                SQLiteUserConnector db = new SQLiteUserConnector();
                this.foundUser = db.GetUserByID(intent.getString("user_id"));
            }
            InitializeComponent();
            initMainLabel();
        }

        private void Card1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            (new SSEdigital(foundUser)).ShowDialog(); 
        }

        private void Card2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            (new mySSEs(foundUser)).Show();
        }

        private void Card3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            (new NewUserForm(foundUser)).Show();
        }

        private void Card4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            String adressMAC = MACTriger.getUniqueCode();
            SQLiteUserConnector db = new SQLiteUserConnector();
            db.deleteMAC(adressMAC);
            Console.WriteLine(adressMAC);
            MessageBox.Show(this, "Usuario deletado deste computador. Reinicie o Programa para Atualizar as Informações.", "Deleted", MessageBoxButton.OK);
            this.Close();
        }

        private void initMainLabel()
        {
            String foundNome = foundUser.Nome;
            this.labelTitulo.Content = "Ola, " + Miscelaneus.getFirstWord(foundNome);
            this.labelConectAss.Content = "Conectado Como: "+ foundUser.Nome;
            this.labelMatricula.Content = "Matricula: " + foundUser.Matricula;
            this.labelRamal.Content = "Ramal: " + foundUser.Ramal;
        } 

        //My personalized close icon
        private void PackIcon_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
