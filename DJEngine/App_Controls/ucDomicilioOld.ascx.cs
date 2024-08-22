using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DJEngine.DataAccess.Tipos;
using System.Web.UI.HtmlControls;
using DJEngine.UsoGeneral;

namespace DJEngine.App_Controls
{
    public partial class ucDomicilioOld : System.Web.UI.UserControl
    {
       public string Ciudad
        {
            get { return txtCiudad.Text; }
            set { txtCiudad.Text = value; }
        }

        public string Calle
        {
            get { return txtCalle.Text; }
            set { txtCalle.Text = value; }
        }

        public string CP
        {
            get { return txtCP.Text; }
            set { txtCP.Text = value; }
        }

        public string Numero
        {
            get { return txtNumero.Text; }
            set { txtNumero.Text = value;}
        }

        public Business.DomicilioInfo Domicilio
        {
            get {
                    Business.DomicilioInfo dinf = new DJEngine.Business.DomicilioInfo();
                    dinf.Calle = txtCalle.Text;
                    dinf.Ciudad = txtCiudad.Text;
                    dinf.CP = txtCP.Text;
                    dinf.Numero = txtNumero.Text;

                
                    return dinf; 
            
            }
            set {

                if (value != null)
                {
                    txtCalle.Text = value.Calle;
                    txtCiudad.Text = value.Ciudad;
                    txtCP.Text = value.CP;
                    txtNumero.Text = value.Numero;

                }
                else
                {
                    txtCalle.Text = "";
                    txtCiudad.Text = "";
                    txtCP.Text = "";
                    txtNumero.Text = "";

                }
            
            }
        
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cargo el css propio del usercontrol
            LoadCss();

            if (!IsPostBack)
            {
                //TODO: Arreglar WebService LstTiposClaveFiscal
               // CargarCombos();
            }
        }

        private void LoadCss()
        {
            string csspath = "~/App_Theme/Cascading/";
            //string aspxname = (Request.Url.Segments[Request.Url.Segments.Length - 1]).Replace(".ascx", ".css");
            string ascxname = this.GetType().Name.Substring(13, 9) + ".css";

            HtmlLink cssLink = new HtmlLink();
            cssLink.Href = csspath + ascxname;
            cssLink.Attributes.Add("rel", "stylesheet");
            cssLink.Attributes.Add("type", "text/css");
            //if (!Page.Header.Controls.Contains(cssLink))
            //{
            Page.Header.Controls.Add(cssLink);
            //}
        }

            

        protected void CustomValidator_Standar(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }

      
    }
}