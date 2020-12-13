using SSEDigitalV3.AccountFeatures;
using SSEDigitalV3.DataCore;
using SSEDigitalV3.NewSSEInterface;
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

namespace SSEDigitalV3
{
    /// <summary>
    /// Lógica interna para Info.xaml
    /// </summary>
    public partial class Info : Window , Intentable
    {
        public static string USE_V1_OPTION = "use_V1";
        public static string NEW_USER_CREATED_OPTION = "user_created";
        public static string USER_IN_OPTION = "user_signed_in";
        private Intent intent = null;
        public Info()
        {
            InitializeComponent();
        }
        public Info(ref Intent return_statement)
        {
            InitializeComponent();
            this.intent = return_statement;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (intent != null)
            {
                if (/*(bool)this.checkBox1.IsChecked*/false)
                {
                    intent.putValue("dont_ask", "true");
                }
                else
                {
                    intent.putValue("dont_ask", "false");
                }
                Console.WriteLine("porra");
                intent.putValue(App.KEY_MAIN_OPTION, Info.USE_V1_OPTION);
            }
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewUserForm form = new NewUserForm();
            form.ShowDialog();
            if (intent != null && form.getUserLog())
            {
                intent.putValue(App.KEY_MAIN_OPTION, Info.NEW_USER_CREATED_OPTION);
                this.Hide();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Sing-in
            LoginForm lf = new LoginForm();
            lf.ShowDialog();
            if (intent != null && lf.getUserLog())
            {
                intent.putValue(App.KEY_MAIN_OPTION, Info.USER_IN_OPTION);
                this.Hide();
            }
        }

        public Intent GetIntent()
        {
            return intent;
        }

        public void PutIntent(Intent intent)
        {
            this.intent=intent;
        }
    }
}
