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

namespace SSEDigitalV3.GlobalTools
{
    /// <summary>
    /// Lógica interna para UserInserter.xaml
    /// </summary>
    public partial class UserInserter : Window
    {
        public String userName;
        public UserInserter()
        {
            InitializeComponent();
        }

        public static String myShow()
        {
            UserInserter ui= new UserInserter();
            ui.ShowDialog();
            return ui.userName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.userName = this.textBoxName.Text;
            this.Close();
        }
    }
}
