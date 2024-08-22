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
    public partial class ucFechaRub : System.Web.UI.UserControl
    {

        public string proptxtFecha
        {
            get { return txtFechaRub.Text; }
            set { txtFechaRub.Text = value; }
        }

        public string proplblFecha
        {
            get { return lblFechaRub.Text; }
            set { lblFechaRub.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void CustomValidator_Standar(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }
    }    
}