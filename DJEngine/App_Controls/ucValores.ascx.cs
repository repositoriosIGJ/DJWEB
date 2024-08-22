using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DJEngine.DataAccess.Tipos;
using DJEngine.UsoGeneral;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;

namespace DJEngine.App_Controls
{
    public partial class ucValores : System.Web.UI.UserControl
    {
        public string Cantidad
        {
            get { return txtCantidad.Text.Trim(); }
            set { txtCantidad.Text = value; }
        }

        public string ValCorUni
        {
            get { return txtValCorUni.Text.Trim(); }
            set { txtValCorUni.Text = value; }
        }

        public string ValCorTot
        {
            get { return txtValCorTot.Text.Trim(); }
            set { txtValCorTot.Text = value; }
        }

        //public bool proplblValoresErrorVisible
        //{
        //    get { return this.DivCuadroValoresError.Visible; }
        //    set { this.DivCuadroValoresError.Visible = value; }
        //}

        public bool proplblValoresErrorVisible
        {
            get { return this.lblValoresError.Visible; }
            set { this.lblValoresError.Visible = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Cargo el css propio del usercontrol
            LoadCss();
        }

        protected void btnCalcular_Click(object sender, ImageClickEventArgs e)
        {
            //Pregunto si ambos campos son distintos de vacio
            if (txtCantidad.Text != "" && txtValCorUni.Text != "")
            {
                Regex isNumber = new Regex(@"^\+?([1-9]\d*)$");
                Regex isDecimal = new Regex(@"^(\d+|\d{0,13}[,]\d{0,2})%?$");

                //Verifico que sea un numero entero positivo (mayor a 0)
                Match okCantidad = isNumber.Match(txtCantidad.Text.Trim());
                //Verifico que sea un numero con un maximo 13 digitos y 2 decimales
                Match okValCorUni = isDecimal.Match(txtValCorUni.Text.Trim());

                //Reviso que ambos campos sean numericos
                if (okValCorUni.Success && okCantidad.Success)
                {
                    proplblValoresErrorVisible = false;
                    lblValoresError.Text = "";
                    txtValCorTot.Enabled = true;
                    //Multiplico la Cantidad x el Valor Corriente Unitario y lo asigno al campo del Valor Corriente Total
                    txtValCorTot.Text = Convert.ToString(Convert.ToInt64(txtCantidad.Text.Trim()) * Convert.ToDecimal(txtValCorUni.Text.Trim()));
                    txtValCorTot.Enabled = false;
                }
                else if (okValCorUni.Success && !okCantidad.Success)
                {
                    proplblValoresErrorVisible = true;
                    lblValoresError.Text = "La Cantidad debe ser un numero mayor a 0";
                    //Habilito, Reinicio y Deshabilito el Campo Valor Corriente Total
                    txtValCorTot.Enabled = true;
                    txtValCorTot.Text = "";
                    txtValCorTot.Enabled = false;
                }
                else if (!okValCorUni.Success && okCantidad.Success)
                {
                    proplblValoresErrorVisible = true;
                    lblValoresError.Text = "El Valor Corriente Unitario deber ser un numero de maximo 13 digitos con 2 decimales.";
                    //Habilito, Reinicio y Deshabilito el Campo Valor Corriente Total
                    txtValCorTot.Enabled = true;
                    txtValCorTot.Text = "";
                    txtValCorTot.Enabled = false;
                }
                else
                {
                    proplblValoresErrorVisible = true;
                    lblValoresError.Text = "Error en la Cantidad (mayor a 0) y en el Valor Corriente Unitario (max. 13 dig. y 2 dec.)";
                    //Habilito, Reinicio y Deshabilito el Campo Valor Corriente Total
                    txtValCorTot.Enabled = true;                    
                    txtValCorTot.Text = "";
                    txtValCorTot.Enabled = false;
                }
            }
            else
            {
                proplblValoresErrorVisible = true;
                lblValoresError.Text = "Por favor complete los campos Cantidad y Valor Corriente Unitario";
                //Habilito, Reinicio y Deshabilito el Campo Valor Corriente Total
                txtValCorTot.Enabled = true;
                txtValCorTot.Text = "";
                txtValCorTot.Enabled = false;
            }
        }

        //Muestro u Oculta y deshabilita todos los textbox y sus validadores
        public void MostrarCamposValores(bool Mostrar)
        {
            //Cantidad
            txtCantidad.Visible = Mostrar;
            txtCantidad.Enabled = Mostrar;
            txtCantidad.Text = "";
            cvCantidad.Enabled = Mostrar;
            //Valor Corriente Unitario
            txtValCorUni.Visible = Mostrar;
            txtValCorUni.Enabled = Mostrar;
            txtValCorUni.Text = "";
            cvValCorUni.Enabled = Mostrar;
            //Valor Corriente Total
            txtValCorTot.Visible = Mostrar;
            txtValCorTot.Enabled = Mostrar;
            txtValCorTot.Text = "";
            cvValCorTot.Enabled = Mostrar;
        }


        protected void CustomValidator_Standar(object source, ServerValidateEventArgs args)
        {
            proplblValoresErrorVisible = false;
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);

            //if ((String)HttpContext.Current.Session["CaptchaValidate"] != null)
            //{
            //    args.IsValid = Validation.Validar((CustomValidator)source, args.Value);

            //    Pregunto si es valido para mostrar mensaje de error en el cuadro del captcha
            //    if (args.IsValid)
            //    {
            //        proplblValoresErrorVisible = false;
            //    }
            //    else
            //    {
            //        if (cvCaptcha.ErrorMessage.Length > 60)
            //        {
            //            //"[CODIGO DE VALIDACION] Campo Obligatorio. Debe Cargar algún Valor."
            //            lblCaptchaError.Text = cvCaptcha.ErrorMessage.Substring(23, 17);
            //        }
            //        else
            //        {
            //            //"[CODIGO DE VALIDACION] El texto ingresado es incorrecto"
            //            lblCaptchaError.Text = cvCaptcha.ErrorMessage.Substring(23);
            //        }

            //        proplblValoresErrorVisible = true;
            //    }
            //}            
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
            Page.Header.Controls.Add(cssLink);
        }
    }
}