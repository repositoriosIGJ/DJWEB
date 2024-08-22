


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
    public partial class ucAcciones : System.Web.UI.UserControl
    {
        public string CantAcciones
        {
            get { return txtCantAcciones.Text; }
            set { txtCantAcciones.Text = value; }
        }

        public string CantVotos
        {
            get { return txtCantVotos.Text; }
            set { txtCantVotos.Text  = value; }
        }

        public string Porcentaje
        {
            get { return txtPorcentaje.Text; }
            set { txtPorcentaje.Text = value; }
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