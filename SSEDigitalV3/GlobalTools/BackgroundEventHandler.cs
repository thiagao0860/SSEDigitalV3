using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font;
using iText.Kernel.Events;
using iText.IO.Image;
using SSEDigitalV3.DataCore;

namespace SSEDigitalV3.GlobalTools
{
    class BackgroundEventHandler : IEventHandler
    {
        protected Image img;
        private SSEDBWrapper id;

        public BackgroundEventHandler(Image img, SSEDBWrapper id)
        {
            this.img = img;
            this.id = id;
        }

        [Obsolete]
        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
            PdfDocument pdfDoc = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();

            PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(),
                page.GetResources(), pdfDoc);
            Rectangle area = page.GetPageSize();
            PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_BOLD);
            new Canvas(canvas, pdfDoc, area)
                .Add(img)
                .Add(new Paragraph(" \nSolicitação de Serviços Externos\nSSE n°: " + id.id)
                    .SetFont(font)
                    .SetFontColor(iText.Kernel.Colors.ColorConstants.WHITE)
                    .SetFontSize(16)
                    .SetTextAlignment(TextAlignment.CENTER))
                .Add(new Image(ImageDataFactory.Create(QRCodeTools.GerarQRCode(100,100, id.id +" "+ id.ToString()), System.Drawing.Color.DarkBlue))
                    .SetFixedPosition(20, 10)
                    .ScaleToFit(50,50))
                .Add(new Paragraph("Documento Consultável Eletrônicamente.")
                    .SetFont(font)
                    .SetFontColor(iText.Kernel.Colors.ColorConstants.WHITE)
                    .SetFontSize(8)
                    .SetFixedPosition(80,10,500));
        }
    }
}
