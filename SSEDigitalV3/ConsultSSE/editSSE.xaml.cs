using SSEDigitalV3.DataCore;
using SSEDigitalV3.GlobalTools;
using SSEDigitalV3.MainDBConnector;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace SSEDigitalV3.ConsultSSE
{
    /// <summary>
    /// Lógica interna para editSSE.xaml
    /// </summary>
    public partial class editSSE : Window, SSEVisualInterface
    {
        SSEDBWrapper sse;
        SSEMainDBConnector connector;
        CultureInfo culture =MainConstants.getInstance().culture;

        #region interface implementation
        ComboBox SSEVisualInterface.comboBoxProvider { get => this.comboBoxProvider; }
        ComboBox SSEVisualInterface.comboBoxTipo { get => this.comboBoxTipo; }
        ComboBox SSEVisualInterface.comboBoxCelula { get => this.comboBoxCelula; }
        TextBox SSEVisualInterface.textBoxOrdem { get => this.textBoxOrdem; }
        TextBox SSEVisualInterface.textBoxRamal { get => this.textBoxRamal; }
        TextBox SSEVisualInterface.textBoxValor { get => this.textBoxValor; }
        TextBox SSEVisualInterface.textBoxValorOrc { get => this.textBoxValorOrc; }
        TextBox SSEVisualInterface.textBoxPeso { get => this.textBoxPeso; }
        TextBox SSEVisualInterface.textBoxRequisitante { get => this.textBoxRequisitante; }
        DatePicker SSEVisualInterface.datePickerPrazo { get => this.datePickerPrazo; }
        Xceed.Wpf.Toolkit.IntegerUpDown SSEVisualInterface.numericUpDownQuantidade { get => this.numericUpDownQuantidade; }
        #endregion

        public editSSE(SSEDBWrapper sse)
        {
            this.sse = sse;
            connector = new SSEMainDBConnector();
            InitializeComponent();
            constructor();
        }

        public editSSE(String id)
        {
            connector = new SSEMainDBConnector();
            SSEDBWrapper sse = connector.findSSE("id",id).ElementAt(0);
            this.sse = sse;
            InitializeComponent();
            constructor();
        }

        private void constructor()
        {
            this.textBoxTitulo.Text = "Editor de SSEs - " + this.sse.id; 
        }

        private void buttonExClick(object sender, MouseButtonEventArgs e)
        {
            connector.deleteSSE(this.sse.id);
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SSEDBWrapper toInsert = this.makeCompleteSSEs();
                Miscelaneus.testInputSSE(toInsert.ISSEBean, this);
                //SSEInsertResponse dialog = new SSEInsertResponse(new SSEDBWrapper(toInsert), this);
                //dialog.ShowDialog();
            }
            catch (InputError ex)
            {
                if (ex.target != null)
                {
                    ex.target.Background = Brushes.Red;
                }
                MessageBox.Show(ex.appMessage, "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private SSEBean makeSSE()
        {
            SSEBean returnStatement = new SSEBean(System.DateTime.Now);
            returnStatement.Tipo = (short)SSEBean.parseTipoValue(this.comboBoxTipo.Text);
            returnStatement.Fornecedor = (short)SSEBean.parseFornecedorValue(this.comboBoxProvider.Text);
            returnStatement.Requisitante.Matricula = this.textBoxRequisitante.Text;
            returnStatement.Ordem = this.textBoxOrdem.Text;
            returnStatement.Codigo = this.textBoxCodigo.Text;
            returnStatement.Referencia = this.textBoxReferencia.Text;
            returnStatement.Nota = this.textBoxNota.Text;
            returnStatement.Requisitante.Ramal = this.textBoxRamal.Text;

            returnStatement.CelulaInt = User.parseCelulaValue(this.comboBoxCelula.Text);
            returnStatement.Equipamento = this.textBoxEquipamento.Text;
            try
            {
                returnStatement.Prazo = Convert.ToDateTime(this.datePickerPrazo.Text, culture);
            }
            catch (Exception e)
            {
                throw new InputError(e.Message, this.datePickerPrazo);
            }
            returnStatement.Descricao = Miscelaneus.StringFromRichTextBox(this.richTextBoxDescricao);

            #region parsing values 
            try
            {
                returnStatement.Valor = float.Parse(this.textBoxValor.Text, culture);
            }
            catch (Exception ex)
            {
                throw new InputError(ex.Message, this.textBoxValor);
            }
            try
            {
                returnStatement.ValorOrc = float.Parse(this.textBoxValorOrc.Text, culture);
            }
            catch (Exception ex)
            {
                throw new InputError(ex.Message, this.textBoxValorOrc);
            }
            try
            {
                returnStatement.Peso = float.Parse(this.textBoxPeso.Text, culture);
            }
            catch (Exception ex)
            {
                throw new InputError(ex.Message, this.textBoxPeso);
            }
            try
            {
                returnStatement.Quantidade = int.Parse(this.numericUpDownQuantidade.Text, culture);
            }
            catch (Exception ex)
            {
                throw new InputError(ex.Message, this.numericUpDownQuantidade);
            }
            #endregion

            returnStatement.Requisicao = this.textBoxRequisicaoCompras.Text;
            if ((bool)this.radioButton1.IsChecked) returnStatement.Prioridade = 1;
            else if ((bool)this.radioButton2.IsChecked) returnStatement.Prioridade = 2;
            else if ((bool)this.radioButton3.IsChecked) returnStatement.Prioridade = 3;
            else throw new InputError("Campo Prioridade vazio.", null);
            return returnStatement;
        }
    
        private SSEDBWrapper makeCompleteSSEs()
        {
            SSEBean bean = makeSSE();
            SSEDBWrapper sSEDBWrapper = new SSEDBWrapper(bean);

            sSEDBWrapper.data_recebimento = this.DatePickerDataRecebimento.SelectedDate.Value;
            sSEDBWrapper.iss = TextBoxISS.Text;
            sSEDBWrapper.codigo_do_servico = TextBoxCodServico.Text;
            sSEDBWrapper.codigo_do_produto = TextBoxCodProduto.Text;
            sSEDBWrapper.numero_da_PO = TextBoxNumPO.Text;
            sSEDBWrapper.valor_do_orcamento_retorno = float.Parse(TextBoxNumValorOrcRetorno.Text);

            return sSEDBWrapper;
        }

    }
}
