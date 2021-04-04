using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using SSEDigital;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSEPrinter
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            Console.WriteLine("Gerrando PDF...");
            Console.WriteLine(Environment.CurrentDirectory.ToString());
            Console.WriteLine(args[0]);
            SSEBean cur = ExcelConnector.getInstance().findDBById(args[0]);
            //SSEBean cur = new SSEBean();            
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "PDF Files|*.pdf";
            dialog.DefaultExt = ".pdf";
            dialog.ShowDialog();
            String local = dialog.FileName;
            String FILE_NAME = Environment.CurrentDirectory.ToString() + "\\pagestyle.png";
            FileStream dest = new FileStream(local, FileMode.Create);
            //PdfOutputStream stream = new PdfOutputStream(dest);
            var writer = new PdfWriter(dest);
            var pdf = new PdfDocument(writer);
            iText.Layout.Element.Image img = new iText.Layout.Element.Image(ImageDataFactory.Create(FILE_NAME))
                                                                     .ScaleToFit(PageSize.A4.GetWidth(), PageSize.A4.GetHeight())
                                                                     .SetFixedPosition(0, 0);
            BackgroundEventHandler handler = new BackgroundEventHandler(img, cur.id);
            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, handler);
            var document = new Document(pdf);
            // Create a PdfFont
            document.SetTopMargin(120);
            document.SetBottomMargin(100);
            PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_BOLD);
            // Add a Paragraph

            // Create a List
            //The last argument defines which cell will be added: a header or the usual one
            Table table = makeFirstTable(cur);
            document.Add(table);

            document.Add(new Paragraph("\n\n"));
            document.Add(new Paragraph("- Descrição:"));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("    " + cur.Descricao));
            document.Add(new Paragraph("\n\n"));

            Table table2 = makeConstantTable();
            document.Add(table2);
            document.Close();
            return 0;
        }


        private static Table makeFirstTable(SSEBean sse)
        {
            Table table = new Table(UnitValue.CreatePercentArray(new float[] { 25, 25, 25, 25 }), false).UseAllAvailableWidth();
            Cell cell = new Cell(1, 2).Add(new Paragraph("Fornecedor:\n" + sse.Fornecedor));
            myPrepareCell(table, cell, 0);
            cell = new Cell(1, 1).Add(new Paragraph("Nota:\n" + sse.Nota));
            myPrepareCell(table, cell, 0);
            cell = new Cell(1, 1).Add(new Paragraph("Data:\n" + sse.Data));
            myPrepareCell(table, cell, 0);
            cell = new Cell(1, 1).Add(new Paragraph("Tipo:\n" + sse.Tipo));

            myPrepareCell(table, cell, 1);
            cell = new Cell(1, 1).Add(new Paragraph("Requisitante:\n" + sse.Requisitante));
            myPrepareCell(table, cell, 1);
            cell = new Cell(1, 1).Add(new Paragraph("Ramal:\n" + sse.Ramal));
            myPrepareCell(table, cell, 1);
            cell = new Cell(1, 1).Add(new Paragraph("Célula:\n" + sse.Celula));
            myPrepareCell(table, cell, 1);
            cell = new Cell(1, 2).Add(new Paragraph("Ordem ou Centro de Custos:\n" + sse.Ordem));

            myPrepareCell(table, cell, 0);
            cell = new Cell(1, 1).Add(new Paragraph("Requisição:\n" + sse.Requisicao));
            myPrepareCell(table, cell, 0);
            cell = new Cell(1, 1).Add(new Paragraph("Equipamento:\n" + sse.Equipamento));
            myPrepareCell(table, cell, 0);

            cell = new Cell(1, 1).Add(new Paragraph("Código:\n" + sse.Codigo));
            myPrepareCell(table, cell, 1);
            cell = new Cell(1, 1).Add(new Paragraph("Referência:\n" + sse.Referencia));
            myPrepareCell(table, cell, 1);
            cell = new Cell(1, 1).Add(new Paragraph("Prazo:\n" + sse.Prazo));
            myPrepareCell(table, cell, 1);
            cell = new Cell(1, 1).Add(new Paragraph("Prioridade:\n" + sse.Prioridade));
            myPrepareCell(table, cell, 1);

            cell = new Cell(1, 1).Add(new Paragraph("Valor:\n" + sse.Valor));
            myPrepareCell(table, cell, 0);
            cell = new Cell(1, 1).Add(new Paragraph("Valor Orç.:\n" + sse.ValorOrc));
            myPrepareCell(table, cell, 0);
            cell = new Cell(1, 1).Add(new Paragraph("Peso:\n" + sse.Peso));
            myPrepareCell(table, cell, 0);
            cell = new Cell(1, 1).Add(new Paragraph("Quantidade:\n" + sse.Quantidade));
            myPrepareCell(table, cell, 0);
            return table;
        }

        private static Table makeConstantTable()
        {
            Table table = new Table(UnitValue.CreatePercentArray(new float[] { 25, 25, 25, 25 }), false).UseAllAvailableWidth();
            Cell cell = new Cell(1, 1).Add(new Paragraph("Emissor:\n\n\n"));
            myPrepareCell(table, cell, 0);
            cell = new Cell(1, 1).Add(new Paragraph("Recebedor:\n\n\n"));
            myPrepareCell(table, cell, 0);
            cell = new Cell(1, 1).Add(new Paragraph("Aprovação Orç.:\n\n\n"));
            myPrepareCell(table, cell, 0);
            cell = new Cell(1, 1).Add(new Paragraph("Aprovação Gestor:\n\n\n"));
            myPrepareCell(table, cell, 0);

            cell = new Cell(1, 2).Add(new Paragraph("Aprovado por:\n\n\n\n "));
            myPrepareCell(table, cell, 1);
            cell = new Cell(1, 1).Add(new Paragraph("Almoxarifado:\n\n\n\n "));
            myPrepareCell(table, cell, 1);
            cell = new Cell(1, 1).Add(new Paragraph("Portaria:\n\n\n\n "));
            myPrepareCell(table, cell, 1);

            cell = new Cell(1, 2).Add(new Paragraph("Observações:\n\n\n\n "));
            myPrepareCell(table, cell, 0);
            cell = new Cell(1, 1).Add(new Paragraph("\n\n\n\n "));
            myPrepareCell(table, cell, 0);
            cell = new Cell(1, 1).Add(new Paragraph("\n\n\n\n "));
            myPrepareCell(table, cell, 0);
            return table;
        }

        private static void myPrepareCell(Table table, Cell cell, int opt)
        {
            if (opt == 0)
            {
                Border bdr = new iText.Layout.Borders.InsetBorder(3);
                bdr.SetColor(iText.Kernel.Colors.ColorConstants.WHITE);
                cell.SetBorder(bdr);
                //cell.SetStrokeColor(iText.Kernel.Colors.ColorConstants.WHITE);
                cell.SetBackgroundColor(new iText.Kernel.Colors.DeviceRgb(217, 217, 242));
                table.AddCell(cell);
            }
            if (opt == 1)
            {
                Border bdr = new iText.Layout.Borders.InsetBorder(3);
                bdr.SetColor(iText.Kernel.Colors.ColorConstants.WHITE);
                cell.SetBorder(bdr);
                cell.SetBackgroundColor(new iText.Kernel.Colors.DeviceRgb(240, 240, 240));
                table.AddCell(cell);
            }
        }
    }
}
