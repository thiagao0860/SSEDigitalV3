using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;

namespace SSEDigitalV3.GlobalTools
{
    class QRCodeTools
    {
        public static Bitmap GerarQRCode(int width, int height, string text)
        {
            try
            {
                BarcodeWriter bw = new BarcodeWriter();
                EncodingOptions encOptions = new EncodingOptions() { Width = width, Height = height, Margin = 0};
                bw.Options = encOptions;
                bw.Format = ZXing.BarcodeFormat.QR_CODE;
           
                Bitmap resultado = new Bitmap(bw.Write(text));

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
