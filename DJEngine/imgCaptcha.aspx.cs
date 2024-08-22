using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net;
using System.IO;

namespace DJE
{
    public partial class imgCaptcha : System.Web.UI.Page
    {
        // ----- PROPERTIES ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private string _CaptchaURL = ConfigurationSettings.AppSettings["CAPTCHA"]; //"http://intranetdesa.jus.gov.ar/SeguridadWeb/imgCaptcha.aspx?Captcha=" '"http://localhost:1990/Captcha/imgCaptcha.aspx?Captcha=";
        public string CaptchaURL
        {
            get { return _CaptchaURL; }
            set { _CaptchaURL = value; }
        }

        // ----- METHODS ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        protected void Page_Load(object sender, EventArgs e)
        {
            CreateCaptcha();
        }

        private void CreateCaptcha()
        {
            try
            {
                //Direccion del CAPTCHA, se le pasa el valor (METODO GET) recibe la imagen

                // Prepara la cabecera del archivo
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AppendHeader("content-disposition", "attachment; filename=captcha.jpg");
                Response.ContentType = "image/jpeg";

                //Inserto Null en el captcha por si 
                Session["captchaValue"] = null;
                // Regenera el Captcha
                Session.Add("captchaValue", GenerateRandomCode());
                Session.Add("captchaUrl", _CaptchaURL + Session["captchaValue"].ToString());

                // Obtiene la imagen
                WebClient client = new WebClient();                
                Byte[] buffer = client.DownloadData(Session["captchaUrl"].ToString());

                // Pone la imagen en la salida
                Response.BinaryWrite(buffer);

                // Cierra la transmision del archivo
                Response.End();
            }
            catch (Exception ex)
            {
                //TODO: Comentar en Produccion
                //ErrorLogging(ex);
                throw ex;
            }
        }

        public static void ErrorLogging(Exception ex)
        {
            string strPath = @"C:\Error\Log.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }
        }

        private string GenerateRandomCode()
        {
            // Caracteres posibles
            string randomValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ23456789";

            // Codigo resultante
            string s = string.Empty;
            Random rand = new Random();

            for (int i = 0; i < 5; i++) //6 caracteres...
            {
                s = s + randomValue.Substring(rand.Next(0, randomValue.Length - 1), 1);
            }

            return s; // retorna el valor/codigo;
        }
    }
}

