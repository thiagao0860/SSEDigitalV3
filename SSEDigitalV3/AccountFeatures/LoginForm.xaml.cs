using SSEDigitalV3.DataCore;
using SSEDigitalV3.UserDBConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
    /// Lógica interna para LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        private bool senha_changed = false;
        private bool user_logedin = false;
        public LoginForm()
        {
            InitializeComponent();
        }
        public bool getUserLog()
        {
            return user_logedin;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User to_insert = new User();
                if (!this.senha_changed)
                {
                    throw new Exception("campo 'senha' em branco");
                }
                to_insert.Matricula = this.textBoxMatricula.Text;
                to_insert.Setor = this.textBoxSenha.Password;
                SQLiteUserConnector db = new SQLiteUserConnector();
                if (validateUser(to_insert))
                {
                    User found = db.GetUserByMatricula(to_insert.Matricula);
                    if (found == null)
                    {
                        throw new Exception("Usuario não Encontrado");
                    }
                    if (!found.Setor.Equals(to_insert.Setor))
                    {
                        throw new Exception("Senha Incorreta");
                    }
                    this.user_logedin = true;
                    MainConstants.getInstance().loged_User = found;

                    MessageBoxResult res = MessageBox.Show(null, "Usuario logado. Deseja cadastrar essa máquina " +
                        "como sua para não precisar digitar seus dados novamente?", "Sucess", MessageBoxButton.YesNo);

                    if (res.Equals(MessageBoxResult.Yes))
                    {
                        MACTriger adressMAC = new MACTriger(found);
                        db.InsertMAC(adressMAC);
                        Console.WriteLine(adressMAC.UniqueCode);
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool validateUser(User user)
        {
            bool return_statement = true;
            if (!(return_statement = return_statement && !(String.IsNullOrWhiteSpace(user.Matricula))))
            {
                this.textBoxMatricula.Background = Brushes.Red;
                throw new Exception("Campo Matrícula em Branco");
            }
            if (!(return_statement = return_statement && !(String.IsNullOrWhiteSpace(user.Setor))))
            {
                this.textBoxSenha.Background = Brushes.Red;
                throw new Exception("Campo Senha em Branco");
            }
            return return_statement;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBoxMatricula.Text.Equals("Matrícula") || String.IsNullOrWhiteSpace(textBoxMatricula.Text))
            {
                this.textBoxMatricula.Background = Brushes.Red;
                MessageBox.Show(null, "Campo Matrícula em Branco", "Recuperação de Senha", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            string usrMatricula = this.textBoxMatricula.Text;
            SQLiteUserConnector db = new SQLiteUserConnector();
            User usr = db.GetUserByMatricula(usrMatricula);
            if (usr == null)
            {
                this.textBoxMatricula.Background = Brushes.Red;
                MessageBox.Show(null, "Matricula não Encontrada no Banco de Dados."
                    , "Recuperação de Senha", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            usr.Setor = alfanumericoAleatorio(8);
            db.UpdateUser(usr);
            RunAsync(usr);
        }

        static async Task RunAsync(User usr)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST
                var recuperatorCode = new RecuperatorBean() { email = usr.Email, senha = usr.Setor };
                HttpResponseMessage response = await client.PostAsJsonAsync(MainConstants.getInstance().restApiURI, recuperatorCode);
                if (response.IsSuccessStatusCode)
                {   //PUT
                    Console.WriteLine("Sent");
                    MessageBox.Show(null, "Sua nova senha foi enviada para seu Email."
                        , "Recuperação de Senha", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        public static string alfanumericoAleatorio(int tamanho)
        {
            var chars = "abcdefghijklmnopqrstuvxwyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        private void textBoxMatricula_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxMatricula.Text = "";
        }

        private void textBoxSenha_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxSenha.Password = "";
            this.senha_changed = true;
        }
    }
}
