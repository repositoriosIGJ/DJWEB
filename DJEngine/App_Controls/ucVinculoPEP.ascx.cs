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
    public partial class ucVinculoPEP : System.Web.UI.UserControl
    {
        public int Vinculo
        {
            get { return Convert.ToInt32(ddlVinculoPEP.SelectedValue); }
            set
            {

                foreach (ListItem l in ddlVinculoPEP.Items)
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
            ddlVinculoPEP.DataSource = VinculoPEP.Vinculos; ;
            ddlVinculoPEP.DataBind();
            Combo.CargarLeyenda(ddlVinculoPEP);
           
        }

        protected void CustomValidator_VinculoPEP(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }

        public override string ToString()
        {
            return ddlVinculoPEP.SelectedItem.Text.ToUpper();
        }
        
    }
}