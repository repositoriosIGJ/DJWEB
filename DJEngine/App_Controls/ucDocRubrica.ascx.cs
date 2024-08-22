using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DJEngine.DataAccess.Tipos;
using DJEngine.UsoGeneral;
using DJEngine.Business;

namespace DJEngine.App_Controls
{
    public partial class ucDocRubrica : System.Web.UI.UserControl
    {

        public int propddlDocRubrica
        {
            get { return ddlDocRubrica.SelectedIndex; }
            set { ddlDocRubrica.SelectedIndex = value; }
        }

        public int DocRubrica
        {
            get { return Convert.ToInt32(ddlDocRubrica.SelectedValue); }
            set
            {
                foreach (ListItem l in ddlDocRubrica.Items)
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
            ddlDocRubrica.DataSource = new TiposDocRubrica().getTiposDocRubrica();
            ddlDocRubrica.DataBind();
            Combo.CargarLeyenda(ddlDocRubrica);
        }

        protected void CustomValidator_DocRubrica(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }

        protected void ddlDocRubrica_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}