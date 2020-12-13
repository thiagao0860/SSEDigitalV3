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

namespace SSEDigitalV3.AccountFeatures
{
    /// <summary>
    /// Lógica interna para NewUserForm.xaml
    /// </summary>
    public partial class NewUserForm : Window
    {
        private bool isEditing = false;
        private bool ramal_selected = false;
        private User usr;
        public NewUserForm()
        {
            InitializeComponent();
            SSEMainDBConnector con = new SSEMainDBConnector();
            initCell(con.findAllCells());
        }
        public NewUserForm(Intent intent)
        {
            InitializeComponent();
            SSEMainDBConnector con = new SSEMainDBConnector();
            initCell(con.findAllCells());
            isEditing = true;
            String usrMatricula = intent.getString("UsrMatricula");
            SQLiteUserConnector db = new SQLiteUserConnector();
            usr = db.GetUserByMatricula(usrMatricula);
            this.textBoxMatricula.Text = usr.Matricula;
            this.textBoxNomeCompleto.Text = usr.Nome;
            this.textBoxEMail.Text = usr.Email;
            this.textBoxRamal.Text = usr.Ramal;
            this.textBoxCelula.Text = usr.CelulaString;
            this.textBoxSenha.Password = usr.Setor;
            this.textBoxConfirmarSenha.Password = usr.Setor;
            this.textBoxMatricula.IsEnabled = false;
        }
        public NewUserForm(User user)
        {
            InitializeComponent();
            SSEMainDBConnector con = new SSEMainDBConnector();
            initCell(con.findAllCells());
            isEditing = true;
            this.usr = user;
            this.textBoxMatricula.Text = usr.Matricula;
            this.textBoxNomeCompleto.Text = usr.Nome;
            this.textBoxEMail.Text = usr.Email;
            this.textBoxRamal.Text = usr.Ramal;
            this.textBoxCelula.Text = usr.CelulaString;
            this.textBoxSenha.Password = usr.Setor;
            this.textBoxConfirmarSenha.Password = usr.Setor;
            this.textBoxMatricula.IsEnabled = false;
        }

        private void initCell(List<CellDBWrapper> foundCells)
        {
            foreach (CellDBWrapper iterator in foundCells)
            {
                this.textBoxCelula.Items.Add(iterator.name);
            }
        }

        public bool getUserLog()
        {
            return MainConstants.getInstance().loged_User!=null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User prepared_user = new User();
                prepared_user.Nome = textBoxNomeCompleto.Text;
                prepared_user.Matricula = textBoxMatricula.Text;
                prepared_user.Email = textBoxEMail.Text;
                prepared_user.CelulaString = textBoxCelula.Text;
                prepared_user.Ramal = textBoxRamal.Text;

                if (textBoxSenha.Password.Equals(textBoxConfirmarSenha.Password))
                {
                    prepared_user.Setor = textBoxSenha.Password;
                }
                else
                {
                    textBoxSenha.Background = Brushes.Red;
                    textBoxConfirmarSenha.Background = Brushes.Red;
                    throw new Exception("Erro na confirmação da senha.");
                }
                if (validateUser(prepared_user))
                {
                    SQLiteUserConnector db = new SQLiteUserConnector();
                    if (!isEditing)
                    {
                        db.InsertUser(prepared_user);
                        String teste_matricula = prepared_user.Matricula;
                        prepared_user = null;
                        prepared_user = db.GetUserByMatricula(teste_matricula);
                        Console.WriteLine(prepared_user.Matricula);

                        MainConstants.getInstance().loged_User = prepared_user;

                        MessageBoxResult res = MessageBox.Show("Usuario cadastrado. Deseja cadastrar essa máquina " +
                            "como sua para não precisar digitar seus dados novamente?", "Sucess", MessageBoxButton.YesNo);
                        if (res == MessageBoxResult.Yes)
                        {
                            MACTriger adressMAC = new MACTriger(prepared_user);
                            db.InsertMAC(adressMAC);
                            Console.WriteLine(adressMAC.UniqueCode);
                        }
                        MessageBox.Show("Usuário inserido ao banco de dados.", "info", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        db.UpdateUser(prepared_user);
                        MessageBox.Show("Dados Atualizados no Banco de Dados. " +
                            "Reinicie o Programa para Atualizar as Informações.", "info", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool validateUser(User user)
        {
            bool return_statement = true;
            if (!(return_statement = return_statement && !(String.IsNullOrWhiteSpace(user.Matricula))))
            {
                this.textBoxMatricula.Background = Brushes.Red;
                throw new Exception("Campo Matrícula em Branco");
            }
            if (!(return_statement = return_statement && !(String.IsNullOrWhiteSpace(user.Nome))))
            {
                this.textBoxNomeCompleto.Background = Brushes.Red;
                throw new Exception("Campo Nome em Branco");
            }
            if (!(return_statement = return_statement && !(String.IsNullOrWhiteSpace(user.CelulaString))))
            {
                this.textBoxCelula.Background = Brushes.Red;
                throw new Exception("Campo Célula em Branco");
            }
            if (!(return_statement = return_statement && !(String.IsNullOrWhiteSpace(user.Email))))
            {
                this.textBoxEMail.Background = Brushes.Red;
                throw new Exception("Campo Email em Branco");
            }
            if (!(return_statement = return_statement && !(String.IsNullOrWhiteSpace(user.Ramal))))
            {
                this.textBoxRamal.Background = Brushes.Red;
                throw new Exception("Campo Ramal em Branco");
            }
            if (!(return_statement = return_statement && !(String.IsNullOrWhiteSpace(user.Setor))))
            {
                this.textBoxSenha.Background = Brushes.Red;
                this.textBoxConfirmarSenha.Background = Brushes.Red;
                throw new Exception("Campo Senha em Branco");
            }
            return return_statement;
        }

        private void textBoxRamal_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxRamal.Text = "";
        }

        private void textBoxEMail_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxEMail.Text = "";
        }

        private void textBoxNomeCompleto_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxNomeCompleto.Text = "";
        }

        private void textBoxMatricula_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxMatricula.Text = "";
        }

        private void textBoxSenha_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxSenha.Password = "";
        }

        private void textBoxConfirmarSenha_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxConfirmarSenha.Password = "";
        }
    }
}
