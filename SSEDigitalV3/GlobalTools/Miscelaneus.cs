using SSEDigitalV3.DataCore;
using SSEDigitalV3.NewSSEInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SSEDigitalV3.GlobalTools
{
    class Miscelaneus
    {
        public static string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                rtb.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                rtb.Document.ContentEnd
            );

            // The Text property on a TextRange object returns a string
            // representing the plain text content of the TextRange.
            return textRange.Text;
        }

        public static SSEBean testInputSSE(SSEBean input,SSEdigital controler)
        {
            if (input.Fornecedor < SSEBean.FornecedorOpts.MIN_INDEX_OPT)
            {
                throw new InputError("Campo\"Fornecedor\" em branco.",controler.comboBoxProvider);
            }
            if (input.Tipo < 0)
            {
                throw new InputError("Campo\"Tipo\" em branco.",controler.comboBoxTipo);
            }
            if (input.CelulaInt < 0)
            {
                throw new InputError("Campo\"Celula\" em branco.",controler.comboBoxCelula);
            }
            if (testVoidReception(input.Codigo) && testVoidReception(input.Referencia))
            {
                throw new InputError("É preciso preencher pelo menos um dos dois valores:\n- Código\n- Referência",controler.textBoxCodigo);
                throw new InputError("É preciso preencher pelo menos um dos dois valores:\n- Código\n- Referência",controler.textBoxReferencia);
            }
            if (testVoidReception(input.Ordem))
            {
                throw new InputError("Campo\"Ordem\" em branco.",controler.textBoxOrdem);
            }
            if (testVoidReception(input.Ramal))
            {
                throw new InputError("Campo\"Ramal\" em branco.",controler.textBoxRamal);
            }
            if (!(input.Valor >= 0))
            {
                throw new InputError("Campo\"Valor\" em branco.",controler.textBoxValor);
            }
            if (!(input.ValorOrc >= 0))
            {
                throw new InputError("Campo\"Valor Orçado\" em branco.",controler.textBoxValorOrc);
            }
            if (!(input.Peso >= 0))
            {
                throw new InputError("Campo\"Peso\" em branco.",controler.textBoxPeso);
            }
            if (testVoidReception(input.Requisitante.Matricula))
            {
                throw new InputError("Campo requisitante obrigatório.",controler.textBoxRequisitante);
            }
            if (DateTime.Compare(input.Prazo, input.Data.AddDays(-1)) <= 0)
            {
                throw new InputError("Data de prazo anterior à data de geração da SSE.",controler.datePickerPrazo);
            }
            if ((!(input.Valor >= 0) || !(input.ValorOrc >= 0))
                && (!(input.Quantidade > 0)))
            {
                throw new InputError("Valor de \"Quantidade\" Inconsistente.",controler.numericUpDownQuantidade);
            }
            if ((input.Peso >= 0)
                && (!(input.Quantidade >= 0)))
            {
                throw new InputError("Valor de \"Quantidade\" Inconsistente.",controler.numericUpDownQuantidade);
            }
            return input;
        }

        private static Boolean testVoidReception(String recipe)
        {
            if (String.IsNullOrEmpty(recipe) && String.IsNullOrWhiteSpace(recipe)) return true;
            else return false;
        }
    }
}
