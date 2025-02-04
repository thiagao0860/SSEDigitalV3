﻿using SSEDigitalV3.DataCore;
using SSEDigitalV3.NewSSEInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
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

        public static SSEBean testInputSSE(SSEBean input, SSEVisualInterface controler)
        {
            if (input.Fornecedor < SSEBean.FornecedorOpts.MIN_INDEX_OPT)
            {
                throw new InputError("Campo\"Fornecedor\" em branco.", controler.comboBoxProvider);
            }
            if (input.Tipo < 0)
            {
                throw new InputError("Campo\"Tipo\" em branco.", controler.comboBoxTipo);
            }
            if (input.CelulaInt < 0)
            {
                throw new InputError("Campo\"Celula\" em branco.", controler.comboBoxCelula);
            }
            if (testVoidReception(input.Codigo) && testVoidReception(input.Referencia))
            {
                throw new InputError("É preciso preencher pelo menos um dos dois valores:\n- Código\n- Referência", controler.textBoxCodigo);
                throw new InputError("É preciso preencher pelo menos um dos dois valores:\n- Código\n- Referência", controler.textBoxReferencia);
            }
            if (testVoidReception(input.Ordem))
            {
                throw new InputError("Campo\"Ordem\" em branco.", controler.textBoxOrdem);
            }
            if (testVoidReception(input.Ramal))
            {
                throw new InputError("Campo\"Ramal\" em branco.", controler.textBoxRamal);
            }
            if (!(input.Valor >= 0))
            {
                throw new InputError("Campo\"Valor\" em branco.", controler.textBoxValor);
            }
            if (!(input.ValorOrc >= 0))
            {
                throw new InputError("Campo\"Valor Orçado\" em branco.", controler.textBoxValorOrc);
            }
            if (!(input.Peso >= 0))
            {
                throw new InputError("Campo\"Peso\" em branco.", controler.textBoxPeso);
            }
            if (testVoidReception(input.Requisitante.Matricula))
            {
                throw new InputError("Campo requisitante obrigatório.", controler.textBoxRequisitante);
            }
            if ((!(input.Valor >= 0) || !(input.ValorOrc >= 0))
                && (!(input.Quantidade > 0)))
            {
                throw new InputError("Valor de \"Quantidade\" Inconsistente.", controler.numericUpDownQuantidade);
            }
            if ((input.Peso >= 0)
                && (!(input.Quantidade >= 0)))
            {
                throw new InputError("Valor de \"Quantidade\" Inconsistente.", controler.numericUpDownQuantidade);
            }
            Match m = Regex.Match(input.Requisicao,@"\d{10}/\d{2}");
            if(!input.Requisitante.CelulaString.Equals("EP") && !m.Success)
            {
                throw new InputError("Valor de \"Requisição de Compras\" Inconsistente.", controler.maskedTextBoxRequisicaoCompras);
            }
            return input;
        }

        private static Boolean testVoidReception(String recipe)
        {
            if (String.IsNullOrEmpty(recipe) && String.IsNullOrWhiteSpace(recipe)) return true;
            else return false;
        }

        public static String getFirstWord(String foundNome) {
            try
            {
                if (foundNome.IndexOf(" ")>0)
                {
                    return foundNome.Substring(0, foundNome.IndexOf(" "));
                }
                else
                {
                    return foundNome;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return foundNome;
            }

         }

        public static void finishApp()
        {
            var win = Application.Current.Windows;
            foreach (Window iterator in win)
            {
                iterator.Close();
            }
        }
    }
}
