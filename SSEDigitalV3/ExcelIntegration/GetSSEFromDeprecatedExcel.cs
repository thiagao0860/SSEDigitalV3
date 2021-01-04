using SSEDigitalV3.DataCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace SSEDigitalV3.ExcelIntegration
{
    public class GetSSEFromDeprecatedExcel
    {
        private static String PATH;
        private static readonly String SHEET_NAME = "BD";
        private static readonly String NAMES_SHEET_NAME = "NOMES";
        private static GetSSEFromDeprecatedExcel ourInstance = new GetSSEFromDeprecatedExcel();
        public Boolean attUser;
        public SSEBean curSaving;
        private int tableLenght = 0;
        private int namesTableLenght = 0;

        public object ReadOnly { get; private set; }

        private GetSSEFromDeprecatedExcel()
        {
            PATH = Environment.CurrentDirectory.ToString() + "\\copy_generate.xlsx";
            Console.WriteLine(PATH);
        }

        public static GetSSEFromDeprecatedExcel getInstance()
        {
            return ourInstance;
        }

        public SSEDBWrapper findDBById(String id)
        {
            Console.WriteLine(PATH);
            Excel.Application xlApp = null;
            try
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Worksheet xlNamesSheet;
                object misValue = System.Reflection.Missing.Value;
                xlApp = new Excel.Application();
                Console.WriteLine(PATH);
                xlWorkBook = xlApp.Workbooks.Open(PATH, misValue, ReadOnly: true, misValue, "SSEdigital-0", "SSEdigital-0",
                                             misValue, misValue, misValue, Editable: false, misValue, misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(SHEET_NAME);
                int line = Int32.Parse(id);
                SSEDBWrapper found = getSSE(line, xlWorkSheet);

                xlWorkBook.Close(misValue, misValue, misValue);
                liberarObjetos(xlWorkSheet);
                liberarObjetos(xlWorkBook);
                xlApp = (Excel.Application)liberarObjetos(xlApp);
                return found;
            }
            catch (Exception e)
            {
                Console.WriteLine("input : " + e.StackTrace);
            }
            finally
            {
                if (!(xlApp is null))
                {
                    xlApp.Quit();
                    Console.WriteLine(PATH);
                }
            }
            return null;
        }


        private static SSEDBWrapper getSSE(Int32 line, Excel.Worksheet sheet)
        {
            try
            {
                var cur = sheet.get_Range("A" + line, "A" + line).Value;
                if (testNullValue(cur))
                {
                    return null;
                }
                SSEBean returnStatement = new SSEBean();

                var transcription = sheet.get_Range("A" + line, "A" + line).Value;
                if (!testNullValue(cur))
                {
                    returnStatement.id = forceStringValue(transcription);
                    returnStatement.Fornecedor = short.Parse(forceStringValue(sheet.get_Range("B" + line, "B" + line).Value));
                    returnStatement.Data = DateTime.ParseExact(forceStringValue(sheet.get_Range("D" + line, "D" + line).Value), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    returnStatement.Tipo = short.Parse(forceStringValue(sheet.get_Range("E" + line, "E" + line).Value));
                    returnStatement.Codigo = forceStringValue(sheet.get_Range("G" + line, "G" + line).Value);
                    returnStatement.Referencia = forceStringValue(sheet.get_Range("H" + line, "H" + line).Value);
                    returnStatement.Descricao = forceStringValue(sheet.get_Range("I" + line, "I" + line).Value);
                    returnStatement.Requisitante.Matricula = forceStringValue(sheet.get_Range("J" + line, "J" + line).Value);
                    returnStatement.Ramal = forceStringValue(sheet.get_Range("L" + line, "L" + line).Value);
                    returnStatement.CelulaString = forceStringValue(sheet.get_Range("M" + line, "M" + line).Value);
                    returnStatement.Equipamento = forceStringValue(sheet.get_Range("N" + line, "N" + line).Value);
                    returnStatement.Ordem = forceStringValue(sheet.get_Range("O" + line, "O" + line).Value);
                    returnStatement.Requisicao = forceStringValue(sheet.get_Range("P" + line, "P" + line).Value);
                    returnStatement.Nota = forceStringValue(sheet.get_Range("Q" + line, "Q" + line).Value);
                    returnStatement.Prazo = DateTime.ParseExact(forceStringValue(sheet.get_Range("R" + line, "R" + line).Value), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    returnStatement.Valor = float.Parse(forceStringValue(sheet.get_Range("T" + line, "T" + line).Value), new CultureInfo("en-US"));
                    returnStatement.ValorOrc = float.Parse(forceStringValue(sheet.get_Range("U" + line, "U" + line).Value), new CultureInfo("en-US"));
                    returnStatement.Prioridade = int.Parse(forceStringValue(sheet.get_Range("V" + line, "V" + line).Value));
                    returnStatement.Peso = float.Parse(forceStringValue(sheet.get_Range("W" + line, "W" + line).Value), new CultureInfo("en-US"));
                    returnStatement.Quantidade = int.Parse(forceStringValue(sheet.get_Range("X" + line, "X" + line).Value));
                }

                SSEDBWrapper wrapper = new SSEDBWrapper(returnStatement);

                    wrapper.id = long.Parse(forceStringValue(transcription));
                    wrapper.iss = forceStringValue(sheet.get_Range("AB" + line, "AB" + line).Value);
                    wrapper.codigo_do_servico = forceStringValue(sheet.get_Range("AC" + line, "AC" + line).Value);
                    wrapper.codigo_do_produto = forceStringValue(sheet.get_Range("AD" + line, "AD" + line).Value);
                    wrapper.numero_do_orcamento = forceStringValue(sheet.get_Range("AE" + line, "AE" + line).Value);
                    wrapper.numero_da_PO = forceStringValue(sheet.get_Range("AF" + line, "AF" + line).Value);
                if (!testNullValue(sheet.get_Range("AF" + line, "AF" + line))){
                    wrapper.valor_do_orcamento_retorno = float.Parse(forceStringValue(sheet.get_Range("AF" + line, "AF" + line).Value),new CultureInfo("en-US"));
                }
                if (sheet.get_Range("S" + line, "S" + line).Value != null)
                {
                    wrapper.data_recebimento = DateTime.FromOADate(Double.Parse(sheet.get_Range("S" + line, "S" + line).Value2.ToString()));
                }
                return wrapper;
            }
            catch (Exception e)
            {
                Console.WriteLine("look error Message:" + e.Message);
                Console.WriteLine("look error ST:" + e.StackTrace);
                return null;
            }
            finally
            {
                
            }
        }

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
            else if (cur is int)
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
            else if (cur is Int16 || cur is Int32 || cur is Int64)
            {
                valor = "" + cur.ToString();
            }
            else
            {
                valor = null;
            }
            return valor;
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
            }
            finally
            {
                GC.Collect();
            }
            return obj;
        }


    }

}
