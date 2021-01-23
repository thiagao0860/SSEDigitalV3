using SSEDigitalV3.DataCore;
using SSEDigitalV3.GlobalTools;
using SSEDigitalV3.MainDBConnector;
using SSEDigitalV3.UserDBConnector;
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

namespace SSEDigitalV3.NewSSEInterface
{
    /// <summary>
    /// Lógica interna para SSEdigital.xaml
    /// </summary>
    public partial class SSEdigital : Window, SSEVisualInterface
    {
        private CultureInfo culture;
        private SSEMainDBConnector connector;
        private Intent intent= null;
        private User found_user = null;

        #region interface implementation
        ComboBox SSEVisualInterface.comboBoxProvider { get => this.comboBoxProvider; }
        ComboBox SSEVisualInterface.comboBoxTipo { get => this.comboBoxTipo;}
        ComboBox SSEVisualInterface.comboBoxCelula { get => this.comboBoxCelula;}
        TextBox SSEVisualInterface.textBoxOrdem { get => this.textBoxOrdem; }
        MaskedTextBox SSEVisualInterface.maskedTextBoxRequisicaoCompras { get => this.maskedTextBoxRequisicaoCompras; }
        TextBox SSEVisualInterface.textBoxRamal { get => this.textBoxRamal;}
        TextBox SSEVisualInterface.textBoxValor { get => this.textBoxValor;}
        TextBox SSEVisualInterface.textBoxValorOrc { get => this.textBoxValorOrc;}
        TextBox SSEVisualInterface.textBoxPeso { get => this.textBoxPeso; }
        TextBox SSEVisualInterface.textBoxRequisitante { get => this.textBoxRequisitante;}
        TextBox SSEVisualInterface.textBoxCodigo { get => this.textBoxCodigo; }
        TextBox SSEVisualInterface.textBoxReferencia { get => this.textBoxReferencia; }
        DatePicker SSEVisualInterface.datePickerPrazo { get => this.datePickerPrazo;}
        IntegerUpDown SSEVisualInterface.numericUpDownQuantidade { get => this.numericUpDownQuantidade;}
        #endregion

        public SSEdigital()
        {
            myConstructor();
        }

        public SSEdigital(ref Intent intent)
        {
            myConstructor();
            this.intent = intent;
            if (intent.getString("user_id") != null)
            {
                SQLiteUserConnector db = new SQLiteUserConnector();
                this.found_user = db.GetUserByID(intent.getString("user_id"));
                prepareForm(found_user);
            }
            this.labelAcountManager.IsEnabled = true;
            this.labelAcountManager.Content = getUserString();
        }

        public SSEdigital(User user)
        {
            myConstructor();
            this.found_user = user;
            prepareForm(found_user);
            this.labelAcountManager.IsEnabled = true;
            this.labelAcountManager.Content = getUserString();
        }

        private void myConstructor()
        {
            InitializeComponent();
            culture = MainConstants.getInstance().culture;
            this.TextBoxData.Text = System.DateTime.Now.Date.ToString(culture);
            this.connector = new SSEMainDBConnector();
            initTipo(connector.findAllTypes());
            initProvider(connector.findAllProviders());
            initCell(connector.findAllCells());
        }

        private void prepareForm(User user)
        {
            if (user == null) { return; }
            this.textBoxRamal.Text = user.Ramal;
            this.textBoxRamal.IsEnabled = false;
            this.comboBoxCelula.Text = user.CelulaString;
            this.comboBoxCelula.IsEnabled = false;
            this.textBoxRequisitante.Text = user.Matricula;
            this.textBoxRequisitante.IsEnabled = false;
        }

        private void initTipo(List<TypeDBWrapper> foundTypes)
        {
            foreach (TypeDBWrapper iterator in foundTypes){
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

        private SSEBean makeSSE()
        {
             SSEBean returnStatement = new SSEBean(System.DateTime.Now);
             returnStatement.Tipo = (short)SSEBean.parseTipoValue(this.comboBoxTipo.Text);
             returnStatement.Fornecedor = (short)SSEBean.parseFornecedorValue(this.comboBoxProvider.Text);
             returnStatement.Ordem = this.textBoxOrdem.Text;
             returnStatement.Codigo = this.textBoxCodigo.Text;
             returnStatement.Referencia = this.textBoxReferencia.Text;
             returnStatement.Nota = this.textBoxNota.Text;

            if (found_user == null)
            {
                returnStatement.Requisitante.Matricula = this.textBoxRequisitante.Text;
                returnStatement.Requisitante.Ramal = this.textBoxRamal.Text;
                returnStatement.CelulaInt = User.parseCelulaValue(this.comboBoxCelula.Text);
            }
            else
            {
                returnStatement.Requisitante = found_user;
            }

             returnStatement.Equipamento = this.textBoxEquipamento.Text;
             try
             {
                 returnStatement.Prazo = Convert.ToDateTime(this.datePickerPrazo.Text,culture);
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
            }catch(Exception ex)
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

            if (DateTime.Compare(returnStatement.Prazo, returnStatement.Data.AddDays(-1)) <= 0)
            {
                throw new InputError("Data de prazo anterior à data de geração da SSE.", this.datePickerPrazo);
            }
            #endregion

             returnStatement.Requisicao = this.maskedTextBoxRequisicaoCompras.Text;
             if ((bool)this.radioButton1.IsChecked) returnStatement.Prioridade = 1;
             else if ((bool)this.radioButton2.IsChecked) returnStatement.Prioridade = 2;
             else if ((bool)this.radioButton3.IsChecked) returnStatement.Prioridade = 3;
             else throw new InputError("Campo Prioridade vazio.", null);
            return returnStatement;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SSEBean toInsert= this.makeSSE();
                if (found_user == null)
                {
                    toInsert.Requisitante.Nome = UserInserter.myShow();
                }
                Miscelaneus.testInputSSE(toInsert, this);
                SSEInsertResponse dialog = new SSEInsertResponse(new SSEDBWrapper(toInsert),this,SSEInsertResponse.INSERT_SSE);
                dialog.ShowDialog();
            }
            catch(InputError ex)
            {
                if (ex.target != null)
                {
                    ex.target.Background = Brushes.Red;
                }
                System.Windows.MessageBox.Show(ex.appMessage,"Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string getUserString()
        {
            if (found_user != null)
            {
                return "Sua matrícula não é (" +
                    found_user.Matricula +
                    ")? gerenciar contas";
            }
            else
            {
                return null;
            }
        }

        private void onClose(object sender, EventArgs e)
        {
            /*
            if (found_user == null)
            {
                var win = Application.Current.Windows;
                foreach (Window iterator in win)
                {
                    iterator.Close();
                }
            }
            */
        }

    }
}
