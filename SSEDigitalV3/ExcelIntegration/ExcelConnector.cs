using SSEDigitalV3.DataCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using Excel = Microsoft.Office.Interop.Excel;

namespace SSEDigitalV3.ExcelIntegration
{
    class ExcelConnector
    {
        private static readonly String SHEET_NAME = "SSEs";
        private String PATH;
        private Excel.Application xlApp;
        private Excel.Workbook xlWorkBook;
        private Excel.Worksheet xlWorkSheet;
        private static readonly object misValue = System.Reflection.Missing.Value;

        public ExcelConnector()
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "Relatório de SSE";
                dialog.FileName = "generated";
                dialog.Filter = "XLSX Files|*.xlsx";
                dialog.DefaultExt = ".xlsx";
                dialog.ShowDialog();
                if (dialog.FileName == null) { Application.Exit(); }
                String local = dialog.FileName;
                if (String.IsNullOrWhiteSpace(local)) { Application.Exit(); }
                PATH = local;
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Name = SHEET_NAME;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Problema na criaação do Arquivo");
                Console.WriteLine(ex.StackTrace);
                xlApp.Quit();
            }
        }

        public void closeConnection()
        {
            if (!(xlApp is null))
            {
                xlWorkBook.SaveAs(PATH, 51);
                liberarObjetos(xlWorkSheet);
                liberarObjetos(xlWorkBook);
                xlApp.Quit();
                xlApp = (Excel.Application)liberarObjetos(xlApp);
            }
        }

        public void makeRow(SSEDBWrapper sSE, Int32 index)
        {
            SSEBean curSSEItem = sSE.ISSEBean;
            xlWorkSheet.Cells[index+1, 1] = sSE.id.ToString();
            xlWorkSheet.Cells[index+1, 2] = curSSEItem.getSavebleFornecedor();
            xlWorkSheet.Cells[index+1, 3] = curSSEItem.Data.Date;
            xlWorkSheet.Cells[index+1, 4] = curSSEItem.getSavebleTipo();
            xlWorkSheet.Cells[index+1, 15] = curSSEItem.Prazo.Date;
            xlWorkSheet.Cells[index+1, 5] = curSSEItem.Codigo;
            xlWorkSheet.Cells[index+1, 6] = curSSEItem.Referencia;
            xlWorkSheet.Cells[index+1, 7] = curSSEItem.Descricao;
            xlWorkSheet.Cells[index+1, 12] = curSSEItem.Ordem;
            xlWorkSheet.Cells[index+1, 8] = curSSEItem.Requisitante.Nome;
            xlWorkSheet.Cells[index+1, 9] = curSSEItem.Ramal;
            xlWorkSheet.Cells[index+1, 10] = User.getSavebleCelula(curSSEItem.CelulaInt);
            xlWorkSheet.Cells[index+1, 11] = curSSEItem.Equipamento;
            xlWorkSheet.Cells[index+1, 13] = curSSEItem.Requisicao;
            xlWorkSheet.Cells[index+1, 14] = curSSEItem.Nota;
            xlWorkSheet.Cells[index+1, 17] = curSSEItem.Valor;
            xlWorkSheet.Cells[index+1, 18] = curSSEItem.ValorOrc;
            xlWorkSheet.Cells[index+1, 19] = curSSEItem.Prioridade;
            xlWorkSheet.Cells[index+1, 20] = curSSEItem.Peso;
            xlWorkSheet.Cells[index+1, 21] = curSSEItem.Quantidade;
        }

        #region toolbox for Excel
        private static Boolean testNullValue(Object cur)
        {
            string valor;
            if (cur is String)
            {
                valor = (string)cur;
            }
            else if (cur is Double)
            {
                valor = "" + cur;
            }
            else
            {
                valor = null;
            }
            return String.IsNullOrWhiteSpace(valor);
        }

        private static String forceStringValue(Object cur)
        {
            string valor;
            if (cur is String)
            {
                valor = (string)cur;
            }
            else if (cur is Double)
            {
                valor = "" + cur;
            }
            else
            {
                valor = null;
            }
            return valor;
        }

        private static Int32 getLastRow(Excel.Worksheet sheet, String testColum)
        {
            int MX = 0;
            String valor = "A";
            //percorre todas as linhas até encontar uma vazia
            while (!String.IsNullOrWhiteSpace(valor))
            {
                MX++;
                var cur = sheet.get_Range(testColum + MX, testColum + MX).Value;
                Console.WriteLine(valor);
                if (cur is String)
                {
                    valor = cur;
                }
                else if (cur is Double)
                {
                    valor = "" + cur;
                }
                else
                {
                    valor = null;
                }
            };
            return MX;
        }

        private Object liberarObjetos(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                System.Windows.MessageBox.Show("Ocorreu um erro durante a liberação do objeto " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
            return obj;
        }
        #endregion
    }
}
