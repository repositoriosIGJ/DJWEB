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
    public partial class ucCuentaBanco : System.Web.UI.UserControl
    {
        public string labelEntBancaria
        {
            set { lblEntBancaria.Text = value; }
        }

        public string labelNroCuenta
        {
            set { lblNroCuenta.Text = value; }
        }

        public string labelTipoCuenta
        {
            set { lblTipoCuenta.Text = value; }
        }

        public string EntBancaria
        {
            get { return txtEntBancaria.Text.Trim(); }
            set { txtEntBancaria.Text = value; }
        }

        public string NroCuenta
        {
            get { return txtNroCuenta.Text.Trim(); }
            set { txtNroCuenta.Text = value; }
        }

        public int TipoCuenta
        {
            get { return Convert.ToInt32(ddlTipoCuenta.SelectedValue); }
            set
            {
                foreach (ListItem l in ddlTipoCuenta.Items)
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
                CargarCombo();
            }
        }

        public void CargarCombo()
        {
            ddlTipoCuenta.DataSource = new TiposCuentaBanco().getTipoCuentaBanco();
            ddlTipoCuenta.DataBind();
            Combo.CargarLeyenda(ddlTipoCuenta);
        }

        protected void CustomValidator_Standar(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }

        protected void ddlTipoCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}