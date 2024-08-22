using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DJEngine.DataAccess.Tipos;
using DJEngine.UsoGeneral;

namespace DJEngine.App_Controls
{
    public partial class ucDocumento : System.Web.UI.UserControl
    {
        public string proptxtNroDoc
        {
            get { return txtNroDoc.Text.Trim(); }
            set { txtNroDoc.Text = value; }
        }

        //public int propddlTipoDoc
        //{
        //    get { return Convert.ToInt32(ddlTipoDoc.SelectedValue); }
        //    //set { ddlTipoDoc.SelectedIndex = value; }
        //}

        public int propddlTipoDoc
        {
            get { return Convert.ToInt32(ddlTipoDoc.SelectedValue); }
            set
            {
                foreach (ListItem l in ddlTipoDoc.Items)
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
            if (!IsPostBack)
            {
                CargarCombos();
            }
        }

        public void CargarCombos()
        {
            ddlTipoDoc.DataSource = new TiposDocumento().getTipoDocumento();
            ddlTipoDoc.DataBind();
            Combo.CargarLeyenda(ddlTipoDoc);
        }


        //protected void CustomValidator_Standar(object source, ServerValidateEventArgs args)
        protected void CustomValidator_TipoDoc(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }

        protected void CustomValidator_NroDoc(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.ValidarNroDoc((CustomValidator)source, ddlTipoDoc.SelectedValue, txtNroDoc.Text);
        }

        protected void ddlTipoDoc_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

    }
}