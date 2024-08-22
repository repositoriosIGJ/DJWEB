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
    public partial class ucFiscal : System.Web.UI.UserControl
    {
        public string proptxtNroFiscal
        {
            get { return txtNroFiscal.Text.Trim(); }
            set { txtNroFiscal.Text = value; }
        }

        //public bool propdivchkNoPoseo
        //{
        //    get { return divchkNoPoseo.Visible; }
        //    set { divchkNoPoseo.Visible = value; }
        //}

        //Deshabilita y Oculta el chkNoPoseo
        public bool propchkNoPoseo
        {
             set
            {
                divchkNoPoseo.Visible = value;
                chkNoPoseo.Enabled = value;
            }
        }

        public int propddlTipoFiscal
        {
            get { return Convert.ToInt32(ddlTipoFiscal.SelectedValue); }
            set
            {
                foreach (ListItem l in ddlTipoFiscal.Items)
                {
                    if (Convert.ToInt32(l.Value) == value)
                    {
                        l.Selected = true;
                        return;
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Cargo el css propio del usercontrol
            //LoadCss();

            if (!IsPostBack)
            {
                //TODO: Arreglar WebService LstTiposClaveFiscal
                CargarCombos();
            }
        }

        private void LoadCss()
        {
            string csspath = "~/App_Theme/Cascading/";
            //string aspxname = (Request.Url.Segments[Request.Url.Segments.Length - 1]).Replace(".ascx", ".css");
            string ascxname = this.GetType().Name.Substring(13, 8) + ".css";

            HtmlLink cssLink = new HtmlLink();
            cssLink.Href = csspath + ascxname;
            cssLink.Attributes.Add("rel", "stylesheet");
            cssLink.Attributes.Add("type", "text/css");
            //if (!Page.Header.Controls.Contains(cssLink))
            //{
            Page.Header.Controls.Add(cssLink);
            //}
        }

        public void CargarCombos()
        {
            ddlTipoFiscal.DataSource = new TiposFiscal().getTipoFiscal();
            ddlTipoFiscal.DataBind();
            Combo.CargarLeyenda(ddlTipoFiscal);
        }


        protected void CustomValidator_Standar(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }

        protected void chkNoPoseo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoPoseo.Checked == true)
            {
                lblTipoFiscal.CssClass = "lblTachado";
                ddlTipoFiscal.Enabled = false;
                ddlTipoFiscal.SelectedIndex = 0; //Harcodeo en 0 para identificar que no Posee Id Fiscal
                cvTipoFiscal.Enabled = false;

                lblNroFiscal.CssClass = "lblTachado";
                txtNroFiscal.Enabled = false;
                txtNroFiscal.Text = "";
                cvNroFiscal.Enabled = false;
            }
            else
            {
                lblTipoFiscal.CssClass = "lblNoTachado";
                ddlTipoFiscal.Enabled = true;
                ddlTipoFiscal.SelectedIndex = -1;
                cvTipoFiscal.Enabled = true;

                lblNroFiscal.CssClass = "lblNoTachado";
                txtNroFiscal.Enabled = true;
                txtNroFiscal.Text = "";
                cvNroFiscal.Enabled = true;
            }
        }
    }
}