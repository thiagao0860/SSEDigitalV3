using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace SSEDigitalV3.DataCore
{
    interface SSEVisualInterface
    {
        ComboBox comboBoxProvider { get;}
        ComboBox comboBoxTipo { get;  }
        ComboBox comboBoxCelula { get;}
        TextBox textBoxOrdem { get;  }
        MaskedTextBox maskedTextBoxRequisicaoCompras { get; }
        TextBox textBoxRamal { get;  }
        TextBox textBoxValor { get;  }
        TextBox textBoxValorOrc { get; }
        TextBox textBoxPeso { get;  }
        TextBox textBoxRequisitante { get;}
        TextBox textBoxCodigo { get;}
        TextBox textBoxReferencia { get;}
        DatePicker datePickerPrazo { get; }
        IntegerUpDown numericUpDownQuantidade { get;}
    }
}
