using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace DJEngine.App_Controls
{
    public partial class ucCaptcha : System.Web.UI.UserControl
    {
        public bool propCaptchaEnabled
        {
            get { return cvCaptcha.Enabled; }
            set { cvCaptcha.Enabled = value; }
        }

        public string proptxtCaptcha
        {
            get { return txtucCaptcha.Text; }
            set { txtucCaptcha.Text = value; }
        }

        public bool proplblCaptchaErrorVisible
        {
            get { return DivCuadroCaptchaError.Visible; }
            set { DivCuadroCaptchaError.Visible = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Cargo el css propio del usercontrol
            LoadCss();
        }

        public void btnRecargarCaptcha_Click(object sender, ImageClickEventArgs e)
        {
            //TODO: Implementar un Captcha mas seguro para que no se muestre
            //imgCaptcha.ImageUrl = Session["captchaUrl"].ToString();

            //Borro Mensaje de Error del Captcha con cada postback
            proplblCaptchaErrorVisible = false;
            //Borro el Campo de Texto del Captcha con cada postback
            proptxtCaptcha = "";

            propCaptchaEnabled = true;

            string secondStr = DateTime.Now.Second.ToString();
            imgCaptcha.ImageUrl = "~/imgCaptcha.aspx?ID=" + secondStr;
        }

        private void LoadCss()
        {
            string csspath = "~/App_Theme/Cascading/";
            //string aspxname = (Request.Url.Segments[Request.Url.Segments.Length - 1]).Replace(".ascx", ".css");
            string ascxname = this.GetType().Name.Substring(13).Replace("_ascx", ".css");
            
            HtmlLink cssLink = new HtmlLink();
            cssLink.Href = csspath + ascxname;
            cssLink.Attributes.Add("rel", "stylesheet");
            cssLink.Attributes.Add("type", "text/css");
            //if (!Page.Header.Controls.Contains(cssLink))
            //{
            Page.Header.Controls.Add(cssLink);
            //}
        }

        protected void CustomValidator_Captcha(object source, ServerValidateEventArgs args)
        {
            if ((String)HttpContext.Current.Session["CaptchaValidate"] != null)
            {
                args.IsValid = Validation.Validar((CustomValidator)source, args.Value);

                //Pregunto si es valido para mostrar mensaje de error en el cuadro del captcha
                if (args.IsValid)
                {
                    proplblCaptchaErrorVisible = false;
                }
                else
                {
                    if (cvCaptcha.ErrorMessage.Length > 60)
                    {
                        //"[CODIGO DE VALIDACION] Campo Obligatorio. Debe Cargar algún Valor."
                        lblCaptchaError.Text = cvCaptcha.ErrorMessage.Substring(23, 17);
                    }
                    else
                    {
                        //"[CODIGO DE VALIDACION] El texto ingresado es incorrecto"
                        lblCaptchaError.Text = cvCaptcha.ErrorMessage.Substring(23);
                    }

                    proplblCaptchaErrorVisible = true;
                }
            }
        }
    }
}