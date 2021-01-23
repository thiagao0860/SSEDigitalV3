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
        private Window parent=null;
        public LoadTool(Window parent)
        {
            this.parent = parent;
            InitializeComponent();
        }
        public LoadTool()
        {
            InitializeComponent();
        }

        private void onDeactivated(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
