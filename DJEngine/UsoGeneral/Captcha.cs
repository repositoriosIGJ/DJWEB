using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace DJEngine.UsoGeneral
{
    public class Captcha
    {
        //private string _CaptchaURL = ConfigurationSettings.AppSettings["CAPTCHA"]; //"http://intranetdesa.jus.gov.ar/SeguridadWeb/imgCaptcha.aspx?Captcha=" '"http://localhost:1990/Captcha/imgCaptcha.aspx?Captcha=";
        //public string CaptchaURL
        //{
        //    get { return _CaptchaURL; }
        //    set { _CaptchaURL = value; }
        //}

        public string Valor { get; set; }

        public string URLImagen { get; set; }

        public static void CreateCaptcha()
        {
            // Regenera el Captcha
            //Valor = GenerateRandomCode();
            //URLImagen = _CaptchaURL + HttpContext.Current.Session["captchaValue"].ToString();
            HttpContext.Current.Session.Add("captchaValue", Captcha.GenerateRandomCode());
            //HttpContext.Current.Session.Add("captchaUrl", _CaptchaURL + HttpContext.Current.Session["captchaValue"].ToString());
            HttpContext.Current.Session.Add("captchaUrl", ConfigurationSettings.AppSettings["CAPTCHA"] + HttpContext.Current.Session["captchaValue"].ToString());
            
            //imgCaptcha.ImageUrl = Session["captchaUrl"].ToString();
        }

        private static string GenerateRandomCode()
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
