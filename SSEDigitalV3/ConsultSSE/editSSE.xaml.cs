using SSEDigitalV3.DataCore;
using SSEDigitalV3.GlobalTools;
using SSEDigitalV3.MainDBConnector;
using SSEDigitalV3.NewSSEInterface;
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
using Xceed.Wpf.Toolkit;

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
        MaskedTextBox SSEVisualInterface.maskedTextBoxRequisicaoCompras { get => this.maskedTextBoxRequisicaoCompras; }
        TextBox SSEVisualInterface.textBoxRamal { get => this.textBoxRamal; }
        TextBox SSEVisualInterface.textBoxValor { get => this.textBoxValor; }
        TextBox SSEVisualInterface.textBoxValorOrc { get => this.textBoxValorOrc; }
        TextBox SSEVisualInterface.textBoxPeso { get => this.textBoxPeso; }
        TextBox SSEVisualInterface.textBoxRequisitante { get => this.textBoxRequisitante; }
        TextBox SSEVisualInterface.textBoxCodigo { get => this.textBoxCodigo; }
        TextBox SSEVisualInterface.textBoxReferencia { get => this.textBoxReferencia; }
        DatePicker SSEVisualInterface.datePickerPrazo { get => this.datePickerPrazo; }
        Xceed.Wpf.Toolkit.IntegerUpDown SSEVisualInterface.numericUpDownQuantidade { get => this.numericUpDownQuantidade; }
        #endregion

        public editSSE(SSEDBWrapper sse,Boolean enableEdit)
        {
            this.sse = sse;
            connector = new SSEMainDBConnector();
            InitializeComponent();
            constructor();
            if (enableEdit)
            {
                enableALL();
            }
            else
            {
                unableALL();
            }
        }

        public editSSE(String id,Boolean enableEdit)
        {
            connector = new SSEMainDBConnector();
            SSEDBWrapper sse = connector.findSSE("id",id).ElementAt(0);
            this.sse = sse;
            InitializeComponent();
            constructor();
            if (enableEdit)
            {
                enableALL();
            }
            else
            {
                unableALL();
            }
        }

        private void enableALL()
        {
            this.comboBoxTipo.IsEnabled = true;
            this.comboBoxProvider.IsEnabled = true;
            this.textBoxRequisitante.IsEnabled = true;
            this.textBoxOrdem.IsEnabled = true;
            this.textBoxCodigo.IsEnabled = true;
            this.textBoxReferencia.IsEnabled = true;
            this.textBoxNota.IsEnabled = true;
            this.textBoxRamal.IsEnabled = true;
            this.comboBoxCelula.IsEnabled = true;
            this.textBoxEquipamento.IsEnabled = true;
            this.datePickerPrazo.IsEnabled = true;
            this.richTextBoxDescricao.IsEnabled = true;
            this.maskedTextBoxRequisicaoCompras.IsEnabled = true;

            this.textBoxValor.IsEnabled = true;
            this.textBoxValorOrc.IsEnabled = true;
            this.textBoxPeso.IsEnabled = true;
            this.numericUpDownQuantidade.IsEnabled = true;

            this.DatePickerDataRecebimento.IsEnabled = true;
            this.TextBoxISS.IsEnabled = true;
            this.TextBoxCodServico.IsEnabled = true;
            this.TextBoxCodProduto.IsEnabled = true;
            this.TextBoxNumPO.IsEnabled = true;
            this.TextBoxNumOrc.IsEnabled = true;
            this.TextBoxNumValorOrcRetorno.IsEnabled = true;

            this.deleteSSEButton.IsEnabled = true;
            this.ButtonSave.IsEnabled = true;

            this.radioButton1.IsEnabled = true;
            this.radioButton2.IsEnabled = true;
            this.radioButton3.IsEnabled = true;
        }

        private void unableALL()
        {
            this.comboBoxTipo.IsEnabled = false;
            this.comboBoxProvider.IsEnabled = false;
            this.textBoxRequisitante.IsEnabled = false;
            this.textBoxOrdem.IsEnabled = false;
            this.textBoxCodigo.IsEnabled = false;
            this.textBoxReferencia.IsEnabled = false;
            this.textBoxNota.IsEnabled = false;
            this.textBoxRamal.IsEnabled = false;
            this.comboBoxCelula.IsEnabled = false;
            this.textBoxEquipamento.IsEnabled = false;
            this.datePickerPrazo.IsEnabled = false;
            this.richTextBoxDescricao.IsEnabled = false;
            this.maskedTextBoxRequisicaoCompras.IsEnabled = false;

            this.textBoxValor.IsEnabled = false;
            this.textBoxValorOrc.IsEnabled = false;
            this.textBoxPeso.IsEnabled = false;
            this.numericUpDownQuantidade.IsEnabled = false;

            this.DatePickerDataRecebimento.IsEnabled = false;
            this.TextBoxISS.IsEnabled = false;
            this.TextBoxCodServico.IsEnabled = false;
            this.TextBoxCodProduto.IsEnabled = false;
            this.TextBoxNumPO.IsEnabled = false;
            this.TextBoxNumOrc.IsEnabled = false;
            this.TextBoxNumValorOrcRetorno.IsEnabled = false;

            this.deleteSSEButton.IsEnabled = false;
            this.ButtonSave.IsEnabled = false;

            this.radioButton1.IsEnabled = false;
            this.radioButton2.IsEnabled = false;
            this.radioButton3.IsEnabled = false;
        }

        private void constructor()
        {
            this.connector = new SSEMainDBConnector();
            initTipo(connector.findAllTypes());
            initProvider(connector.findAllProviders());
            initCell(connector.findAllCells());
            showSavedData();
        }

        private void showSavedData()
        {
            this.textBoxTitulo.Text = "Editor de SSEs - " + this.sse.id;
            this.comboBoxTipo.SelectedIndex = this.sse.ISSEBean.Tipo-1;
            this.comboBoxProvider.SelectedIndex = this.sse.ISSEBean.Fornecedor-1;
            this.textBoxOrdem.Text = this.sse.ISSEBean.Ordem;
            this.maskedTextBoxRequisicaoCompras.Text = this.sse.ISSEBean.Requisicao;
            this.textBoxCodigo.Text = this.sse.ISSEBean.Codigo;
            this.textBoxReferencia.Text = this.sse.ISSEBean.Referencia;
            this.textBoxNota.Text = this.sse.ISSEBean.Nota;
            this.textBoxData.Text = this.sse.ISSEBean.Data.ToString();
            this.textBoxRamal.Text = this.sse.ISSEBean.Ramal;
            this.comboBoxCelula.Text = this.sse.ISSEBean.CelulaString;
            this.textBoxRequisitante.Text = this.sse.ISSEBean.Requisitante.Matricula;
            this.textBoxEquipamento.Text = this.sse.ISSEBean.Equipamento;
            this.datePickerPrazo.SelectedDate = this.sse.ISSEBean.Prazo;
            if (sse.ISSEBean.Prioridade == 1) this.radioButton1.IsChecked=true;
            else if (sse.ISSEBean.Prioridade == 2) this.radioButton2.IsChecked=true;
            else if (sse.ISSEBean.Prioridade == 3) this.radioButton3.IsChecked=true;
            else throw new InputError("Campo Prioridade vazio.", null);
            TextRange textRange = new TextRange(
               this.richTextBoxDescricao.Document.ContentStart,
               this.richTextBoxDescricao.Document.ContentEnd
            );
            textRange.Text = this.sse.ISSEBean.Descricao;
            this.textBoxValor.Text = this.sse.ISSEBean.Valor.ToString();
            this.textBoxValorOrc.Text = this.sse.ISSEBean.ValorOrc.ToString();
            this.textBoxPeso.Text = this.sse.ISSEBean.Peso.ToString();
            this.numericUpDownQuantidade.Text = this.sse.ISSEBean.Quantidade.ToString();
            this.DatePickerDataRecebimento.SelectedDate = this.sse.data_recebimento;
            this.TextBoxISS.Text = this.sse.iss;
            this.TextBoxCodServico.Text = this.sse.codigo_do_servico;
            this.TextBoxCodProduto.Text = this.sse.codigo_do_produto;
            this.TextBoxNumOrc.Text = this.sse.numero_do_orcamento;
            this.TextBoxNumPO.Text = this.sse.numero_da_PO;
            this.TextBoxNumValorOrcRetorno.Text = this.sse.valor_do_orcamento_retorno.ToString();
        }

        private void initTipo(List<TypeDBWrapper> foundTypes)
        {
            foreach (TypeDBWrapper iterator in foundTypes)
            {
                this.comboBoxTipo.Items.Add(iterator.tipo);
            }
        }

        private void initProvider(List<ProviderDBWrapper> foundProviders)
        {
            foreach (ProviderDBWrapper iterator in foundProviders)
            {
                this.comboBoxProvider.Items.Add(iterator.fornecedor);
            }
        }

        private void initCell(List<CellDBWrapper> foundCells)
        {
            foreach (CellDBWrapper iterator in foundCells)
            {
                this.comboBoxCelula.Items.Add(iterator.name);
            }
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
                SSEDBWrapper toUpdate = this.makeCompleteSSEs();
                Miscelaneus.testInputSSE(toUpdate.ISSEBean, this);
                SSEInsertResponse dialog = new SSEInsertResponse(toUpdate, this, SSEInsertResponse.UPDATE_SSE);
                dialog.ShowDialog();
            }
            catch (InputError ex)
            {
                if (ex.target != null)
                {
                    ex.target.Background = Brushes.Red;
                }
                System.Windows.MessageBox.Show(ex.appMessage, "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private SSEBean makeSSE()
        {
            SSEBean returnStatement = new SSEBean(this.sse.ISSEBean.Data);
            returnStatement.id = this.sse.id.ToString();
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

            returnStatement.Requisicao = this.maskedTextBoxRequisicaoCompras.Text;
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
            sSEDBWrapper.id = this.sse.id;
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
