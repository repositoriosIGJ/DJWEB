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
    public partial class ucEstadoCivil : System.Web.UI.UserControl
    {
        public int propddlEstadoCivil
        {
            get { return ddlEstadoCivil.SelectedIndex; }
            set { ddlEstadoCivil.SelectedIndex = value; }
        }

        public int EstadoCivil
        {
            get { return Convert.ToInt32(ddlEstadoCivil.SelectedValue); }
            set
            {
                foreach (ListItem l in ddlEstadoCivil.Items)
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
            ddlEstadoCivil.DataSource = new TiposEstadoCivil().getTipoEstadoCivil();
            ddlEstadoCivil.DataBind();
            Combo.CargarLeyenda(ddlEstadoCivil);
        }

        protected void CustomValidator_EstadoCivil(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }

    }
}