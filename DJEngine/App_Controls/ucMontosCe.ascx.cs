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
    public partial class ucMontosCe : System.Web.UI.UserControl
    {
        public string MontoMoneda
        {
            get { return txtMontoCe.Text.Trim(); }
            set { txtMontoCe.Text = value; }
        }

        public string proplblMontoCe
        {
            get { return lblMontoCe.Text; }
            set { lblMontoCe.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CargarCombos();
            }
        }

        protected void CustomValidator_Standar(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }
    }
}