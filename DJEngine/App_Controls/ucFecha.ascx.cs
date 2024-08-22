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
    public partial class ucFecha : System.Web.UI.UserControl
    {

        public string proptxtFecha
        {
            get { return txtFecha.Text; }
            set { txtFecha.Text = value; }
        }

        public string proplblFecha
        {
            get { return lblFecha.Text; }
            set { lblFecha.Text = value; }
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