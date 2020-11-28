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

namespace SSEDigitalV3.NewSSEInterface
{
    /// <summary>
    /// Interação lógica para LoadingPage.xam
    /// </summary>
    public partial class LoadingPage : Page
    {
        public LoadingPage()
        {
            InitializeComponent();
            
        }

        public void startLoading()
        {
            this.ProgressBarLoading.IsIndeterminate = true;
        }

        public void stopLoading()
        {
            this.ProgressBarLoading.IsIndeterminate = false;
        }
    }
}
