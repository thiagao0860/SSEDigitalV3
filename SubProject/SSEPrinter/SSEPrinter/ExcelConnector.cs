using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Xml.Schema;
using Excel = Microsoft.Office.Interop.Excel;

namespace SSEDigital
{
    public class ExcelConnector
    {
        private static String PATH;
        private static readonly String SHEET_NAME = "BD";
        private static readonly String NAMES_SHEET_NAME = "NOMES";
        private static ExcelConnector ourInstance = new ExcelConnector();
        public Boolean attUser;
        public SSEBean curSaving;
        private int tableLenght=0;
        private int namesTableLenght=0;

        public object ReadOnly { get; private set; }

        private ExcelConnector()
        {
            PATH = Environment.CurrentDirectory.ToString() + "\\generate.xlsx";
            Console.WriteLine(PATH);
        }

        public static ExcelConnector getInstance()
        {
            return ourInstance;
        }

        public SSEBean findDBById(String id)
        {
            Console.WriteLine(PATH);
            Excel.Application xlApp = null;
            try
            {
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Worksheet xlNamesSheet;
                object misValue = System.Reflection.Missing.Value;
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                Console.WriteLine(PATH);
                xlWorkBook = xlApp.Workbooks.Open(PATH, misValue, ReadOnly: true, misValue, "Almox-25", "Almox-25",
                                             misValue, misValue, misValue, Editable: false, misValue, misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(SHEET_NAME);
                int line = Int32.Parse(id);
                SSEBean found = getSSE(line, xlWorkSheet);
                
                xlWorkBook.Close(misValue, misValue, misValue);
                liberarObjetos(xlWorkSheet);
                liberarObjetos(xlWorkBook);
                xlApp = (Excel.Application)liberarObjetos(xlApp);
                return found;
            }catch( Exception e)
            {
                Console.WriteLine(e.Message);
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

        

        

        private static SSEBean getSSE(Int32 line, Excel.Worksheet sheet)
        {
            var cur = sheet.get_Range("A"+line, "A"+line).Value;
            if (testNullValue(cur))
            {
                return null;
            }
            SSEBean returnStatement = new SSEBean();
            

            var transcription = sheet.get_Range("A" + line, "A" + line).Value;
            if (!testNullValue(cur))
            {
                returnStatement.id = forceStringValue(transcription);
                returnStatement.Fornecedor = forceStringValue(sheet.get_Range("B" + line, "B" + line).Value);
                returnStatement.Data = forceStringValue(sheet.get_Range("C" + line, "C" + line).Value);
                returnStatement.Tipo = forceStringValue(sheet.get_Range("D" + line, "D" + line).Value);
                returnStatement.Codigo = forceStringValue(sheet.get_Range("E" + line, "E" + line).Value);
                returnStatement.Referencia = forceStringValue(sheet.get_Range("F" + line, "F" + line).Value);
                returnStatement.Descricao = forceStringValue(sheet.get_Range("G" + line, "G" + line).Value);
                returnStatement.Requisitante = forceStringValue(sheet.get_Range("H" + line, "H" + line).Value);
                returnStatement.Ramal = forceStringValue(sheet.get_Range("I" + line, "I" + line).Value);
                returnStatement.Celula = forceStringValue(sheet.get_Range("J" + line, "J" + line).Value);
                returnStatement.Equipamento = forceStringValue(sheet.get_Range("K" + line, "K" + line).Value);
                returnStatement.Ordem = forceStringValue(sheet.get_Range("L" + line, "L" + line).Value);
                returnStatement.Requisicao = forceStringValue(sheet.get_Range("M" + line, "M" + line).Value);
                returnStatement.Nota = forceStringValue(sheet.get_Range("N" + line, "N" + line).Value);
                returnStatement.Prazo = forceStringValue(sheet.get_Range("O" + line, "O" + line).Value);
               // returnStatement.Recebimento = forceStringValue(sheet.get_Range("P" + line, "P" + line).Value);
                returnStatement.Valor = forceStringValue(sheet.get_Range("Q" + line, "Q" + line).Value);
                returnStatement.ValorOrc = forceStringValue(sheet.get_Range("R" + line, "R" + line).Value);
                returnStatement.Prioridade = forceStringValue(sheet.get_Range("S" + line, "S" + line).Value);
                returnStatement.Peso = forceStringValue(sheet.get_Range("T" + line, "T" + line).Value);
                returnStatement.Quantidade = forceStringValue(sheet.get_Range("U" + line, "U" + line).Value);
                //returnStatement = forceStringValue(sheet.get_Range("V" + line, "V" + line).Value);
                //returnStatement = forceStringValue(sheet.get_Range("W" + line, "W" + line).Value);
                //returnStatement.Area = forceStringValue(sheet.get_Range("X" + line, "X" + line).Value);
            }
            return returnStatement; 
        }

        private static Boolean testNullValue(Object cur)
        {
            string valor;
            if (cur is String)
            {
                valor =(string) cur;
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
