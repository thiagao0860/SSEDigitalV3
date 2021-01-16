using SSEDigitalV3.DataCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace SSEDigitalV3.ExcelIntegration
{
    
    class GetDataFromPO
    {
        private String PATH;
        private static readonly String SHEET_NAME_DATA_LIST = "Cópia PO"; //TODO:trocar string por integer 
        private static readonly String SHEET_NAME_HEADER = "TemplatePO"; //TODO:trocar string por integer 
        
        public GetDataFromPO(string path)
        {
            this.PATH = path;
        }

        public POWrapper findPOData()
        {
            Excel.Application xlApp = null;
            try
            {
                object misValue = System.Reflection.Missing.Value;
                xlApp = new Excel.Application();
                xlApp.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityForceDisable;
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(this.PATH);
                Excel.Worksheet xlWorkSheet_DataList = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(GetDataFromPO.SHEET_NAME_DATA_LIST);
                Excel.Worksheet xlWorkSheet_Header = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(GetDataFromPO.SHEET_NAME_HEADER);

                POWrapper found = new POWrapper();
                found.vSetor = forceStringValue(xlWorkSheet_Header.get_Range("H5").Value2);
                found.vMaterial = forceStringValue(xlWorkSheet_Header.get_Range("H7").Value2);
                found.vServiceDetails = forceStringValue(xlWorkSheet_Header.get_Range("H9").Value2);
                found.fornecedor = forceStringValue(xlWorkSheet_Header.get_Range("H13").Value2);
                found.vCNPJ = forceStringValue(xlWorkSheet_Header.get_Range("P13").Value2);
                found.vInternalCNPJ = forceStringValue(xlWorkSheet_Header.get_Range("P15").Value2);

                int line = 5;
                while (!forceStringValue(xlWorkSheet_DataList.get_Range("B"+line).Value2).Equals("0")) {
                    PORow serviceRow = getRow(line, xlWorkSheet_DataList);
                    found.servicesInfo.Add(serviceRow);
                    line++;
                }

                xlWorkBook.Close(misValue, misValue, misValue);
                liberarObjetos(xlWorkSheet_DataList);
                liberarObjetos(xlWorkSheet_Header);
                liberarObjetos(xlWorkBook);
                xlApp = (Excel.Application)liberarObjetos(xlApp);
                return found;
            }
            catch (Exception e)
            {
                Console.WriteLine("input : " + e.Message);
            }
            finally
            {
                if (!(xlApp is null))
                {
                    xlApp.Quit();
                }
            }
            return null;
        }

        
        private static PORow getRow(Int32 line, Excel.Worksheet sheet)
        {
            try
            {
                PORow wrapper = new PORow();
                wrapper.description = forceStringValue( sheet.get_Range("B" + line).Value2);
                wrapper.amount = forceDoubleValue( sheet.get_Range("C" + line).Value2);
                wrapper.classificacaoFiscal_NCM = forceStringValue( sheet.get_Range("D" + line).Value2);
                wrapper.cenntro_de_Custo = forceStringValue( sheet.get_Range("E" + line).Value2);
                wrapper.codServico = forceStringValue(sheet.get_Range("F" + line).Value2);
                wrapper.unitValue = forceDoubleValue(sheet.get_Range("G" + line).Value2);
                wrapper.iSSMode = forceStringValue(sheet.get_Range("H" + line).Value2);
                wrapper.iSSAliq = forceDoubleValue(sheet.get_Range("I" + line).Value2);
                wrapper.iCMSdest = forceStringValue(sheet.get_Range("K" + line).Value2);
                wrapper.iCMSaliq = forceDoubleValue(sheet.get_Range("L" + line).Value2);
                wrapper.iPIdest = forceStringValue(sheet.get_Range("M" + line).Value2);
                wrapper.iPIaliq = forceDoubleValue( sheet.get_Range("N" + line).Value2);
                wrapper.unitValueSAP = forceDoubleValue(sheet.get_Range("O" + line).Value2);
                wrapper.iCMSST = forceStringValue(sheet.get_Range("P" + line).Value2);
                return wrapper;
            }
            catch (Exception e)
            {
                Console.WriteLine("look error Message:" + e.Message);
                Console.WriteLine("look error ST:" + e.StackTrace);
                return null;
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
                throw new Exception("tipo: " + (cur.GetType()).ToString() +"nao suportado.");
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
                valor = "" + cur.ToString();
            }
            else if (cur is Int16 || cur is Int32 || cur is Int64)
            {
                valor = "" + cur.ToString();
            }
            else
            {
                throw new Exception("tipo: " + (cur.GetType()).ToString() + "nao suportado.");
            }
            return valor;
        }

        private static Double forceDoubleValue(Object cur)
        {
            double valor;
            if (cur is String)
            {
                valor = Double.Parse((String)cur);
            }
            else if (cur is Double)
            {
                valor = (double)cur;
            }
            else if (cur is Int16 || cur is Int32 || cur is Int64)
            {
                valor = (double)cur;
            }
            else
            {
                throw new Exception("tipo: " + (cur.GetType()).ToString() + "nao suportado.");
            }
            return valor;
        }

        private static Int64 forceIntegerValue(Object cur)
        {
            Int64 valor;
            if (cur is String)
            {
                valor = Int64.Parse((String)cur);
            }
            else if (cur is Double)
            {
                valor = (Int64)cur;
            }
            else if (cur is Int16 || cur is Int32 || cur is Int64)
            {
                valor = (Int64)cur;
            }
            else
            {
                throw new Exception("tipo: " + (cur.GetType()).ToString() + "nao suportado.");
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
