using SSEDigitalV3.ConsultSSE;
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
using System.Windows.Shapes;

namespace SSEDigitalV3.GlobalTools
{
    /// <summary>
    /// Lógica interna para LoadTool.xaml
    /// </summary>
    public partial class LoadTool : Window
    {
        private Window parent;
        public LoadTool(Window parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void onRenderedAsync(object sender, EventArgs e)
        {
           // while (!((confirmOrder)this.parent).ltst) Thread.Sleep(1000);
            //this.Close();
        }
    }
}
