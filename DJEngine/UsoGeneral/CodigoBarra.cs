using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using QRCoder;
using System.IO;

namespace DJEngine.UsoGeneral
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class CodigoBarra
    {
        //public void GenerarCodigoBarra()
        //{
        //    #region Codigo de Barras

        //    //CODIGO DE BARRAS

        //    PdfContentByte overContent = stamper.GetOverContent(i);
        //    Barcode39 codebar = new Barcode39();

        //    codebar.Code = "122112321312";
        //    codebar.StartStopText = false;

        //    // Get barcode image placeholder
        //    float[] barcodeArea = stamper.AcroFields.GetFieldPositions("codBarras");
        //    iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(Convert.ToInt32(barcodeArea[1]), Convert.ToInt32(barcodeArea[2]), Convert.ToInt32(barcodeArea[3]), Convert.ToInt32(barcodeArea[4]));
        //    codebar.Size = 10;
        //    codebar.BarHeight = codebar.Size * 5f;

        //    iTextSharp.text.Image imageBarCode = codebar.CreateImageWithBarcode(overContent, null, null);
        //    imageBarCode.ScaleToFit(rect.Width, rect.Height);

        //    imageBarCode.SetAbsolutePosition(barcodeArea[1] + (rect.Width - imageBarCode.ScaledWidth) / 2, barcodeArea[2] + (rect.Height - imageBarCode.ScaledHeight) / 2);

        //    // Add barcode image

        //    overContent.AddImage(imageBarCode);

        //    #endregion
        //}

        public System.Drawing.Image GenerarImagenCodigoBarra(string NumCodBar)
        {
            try
            {
                //Cracion de Imagen
                System.Drawing.Image imgCodBar = BarcodeLib.Barcode.DoEncode(BarcodeLib.TYPE.CODE128,
                                                                             NumCodBar.ToString(),
                                                                             Color.Black,
                                                                             Color.White);


                //guardo el codigo de barra en una carpeta temporal

                //path += HttpContext.Current.Request.PhysicalApplicationPath + NumCodBar.ToString() + ".jpg";
                //imgCodBar.Save(path);

                /// return NumCodBar + ".jpg";
                return imgCodBar;

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Calculates the QR code data which than can be used in one of the rendering classes to generate a graphical representation.
        /// </summary>
        /// <param name="plainText">The payload which shall be encoded in the QR code</param>
        /// <param name="eccLevel">The level of error correction data</param>
        /// <param name="forceUtf8">Shall the generator be forced to work in UTF-8 mode?</param>
        /// <param name="utf8BOM">Should the byte-order-mark be used?</param>
        /// <param name="eciMode">Which ECI mode shall be used?</param>
        /// <param name="requestedVersion">Set fixed QR code target version.</param>
        /// <exception cref="QRCoder.Exceptions.DataTooLongException">Thrown when the payload is too big to be encoded in a QR code.</exception>
        /// <returns>Returns the raw QR code data which can be used for rendering.</returns>
        public System.Drawing.Image GenerarImagenQR(string NumCodBar)
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(NumCodBar, QRCodeGenerator.ECCLevel.Q, false, false, QRCodeGenerator.EciMode.Default, -1);
                //QRCodeData qrCodeData = qrGenerator.CreateQrCode(NumCodBar, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                System.Drawing.Image qrCodeImage = qrCode.GetGraphic(20);
                //Bitmap qrCodeImage = qrCode.GetGraphic(20);

                return qrCodeImage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
