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
using System.Threading;
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
    /// 
    public class BgpMainWindow
    {
        private User usr;
        private bool createToOther = false;
        public BgpMainWindow(User usr)
        {
            this.usr = usr;
        }

        public BgpMainWindow(User usr,Boolean createToOther)
        {
            this.usr = usr;
            this.createToOther = createToOther;
        }

        public void createNewSSEWindow()
        {
            if (createToOther)
            {
               (new SSEdigital()).ShowDialog();
            }
            else
            {
               (new SSEdigital(usr)).ShowDialog();
            }
        }

        public void createMySSEsWindow()
        {
            (new mySSEs(usr)).ShowDialog();
        }

        public void createNewUserFormWindow()
        {
            (new NewUserForm(usr)).ShowDialog();
        }

        public void createExitProcess()
        {
            String adressMAC = MACTriger.getUniqueCode();
            SQLiteUserConnector db = new SQLiteUserConnector();
            db.deleteMAC(adressMAC);
            Console.WriteLine(adressMAC);
            MessageBox.Show("Usuario deletado deste computador. Reinicie o Programa para Atualizar as Informações.", "Deleted", MessageBoxButton.OK);
        }
    }

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
            bool createToOther= false;
            if (foundUser.CelulaString.Equals("ALMOX"))
            {
                MessageBoxResult result = MessageBox.Show("Você está criando esta SSE para outro usuário?", "Nominal", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    createToOther=true;
                }
                if (result == MessageBoxResult.No)
                {
                    createToOther=false;
                }
            }
            BgpMainWindow bgpMainWindow = new BgpMainWindow(this.foundUser,createToOther);
            BgpLoadToolDelegate bgpLoadToolDelegate = new BgpLoadToolDelegate();
            Thread tbgpMainWindow = new Thread(new ThreadStart(bgpMainWindow.createNewSSEWindow));
            Thread tbgpLoadToolDelegate = new Thread(new ThreadStart(BgpLoadToolDelegate.showTool));
            tbgpLoadToolDelegate.SetApartmentState(ApartmentState.STA);
            tbgpMainWindow.SetApartmentState(ApartmentState.STA);
            tbgpMainWindow.Start();
            tbgpLoadToolDelegate.Start();
        }

        private void Card2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            BgpMainWindow bgpMainWindow = new BgpMainWindow(this.foundUser);
            BgpLoadToolDelegate bgpLoadToolDelegate = new BgpLoadToolDelegate();
            Thread tbgpMainWindow = new Thread(new ThreadStart(bgpMainWindow.createMySSEsWindow));
            Thread tbgpLoadToolDelegate = new Thread(new ThreadStart(BgpLoadToolDelegate.showTool));
            tbgpLoadToolDelegate.SetApartmentState(ApartmentState.STA);
            tbgpMainWindow.SetApartmentState(ApartmentState.STA);
            tbgpMainWindow.Start();
            tbgpLoadToolDelegate.Start();
        }

        private void Card3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            BgpMainWindow bgpMainWindow = new BgpMainWindow(this.foundUser);
            BgpLoadToolDelegate bgpLoadToolDelegate = new BgpLoadToolDelegate();
            Thread tbgpMainWindow = new Thread(new ThreadStart(bgpMainWindow.createNewUserFormWindow));
            Thread tbgpLoadToolDelegate = new Thread(new ThreadStart(BgpLoadToolDelegate.showTool));
            tbgpLoadToolDelegate.SetApartmentState(ApartmentState.STA);
            tbgpMainWindow.SetApartmentState(ApartmentState.STA);
            tbgpMainWindow.Start();
            tbgpLoadToolDelegate.Start();
        }

        private void Card4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            BgpMainWindow bgpMainWindow = new BgpMainWindow(this.foundUser);
            BgpLoadToolDelegate bgpLoadToolDelegate = new BgpLoadToolDelegate();
            Thread tbgpMainWindow = new Thread(new ThreadStart(bgpMainWindow.createExitProcess));
            Thread tbgpLoadToolDelegate = new Thread(new ThreadStart(BgpLoadToolDelegate.showTool));
            tbgpLoadToolDelegate.SetApartmentState(ApartmentState.STA);
            tbgpMainWindow.SetApartmentState(ApartmentState.STA);
            tbgpMainWindow.Start();
            tbgpLoadToolDelegate.Start();
            tbgpMainWindow.Join();
            this.Close();
        }

        private void initMainLabel()
        {
            String foundNome = foundUser.Nome;
            this.labelTitulo.Content = "Ola, " + Miscelaneus.getFirstWord(foundNome);
            this.labelConectAss.Content = "Conectado Como: "+ foundUser.Nome;
            this.labelMatricula.Content = "Matricula: " + foundUser.Matricula;
            this.labelRamal.Content = "Ramal: " + foundUser.Ramal;
            if (foundUser.CelulaString.Equals("ALMOX"))
            {
                this.InsertPOButton.Visibility = Visibility.Visible;
            }
        } 

        //My personalized close icon
        private void PackIcon_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var win = Application.Current.Windows;
            foreach(Window iterator in win)
            {
                iterator.Close();
            }
        }

        private void insertPOClick(object sender, MouseButtonEventArgs e)
        {
            (new confirmOrder()).ShowDialog();
        }
    }
}
