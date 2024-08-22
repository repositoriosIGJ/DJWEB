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
    public partial class ucEmail : System.Web.UI.UserControl
    {
        public string proptxtEmail
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CustomValidator_Email(object source, ServerValidateEventArgs args)
        {
            //args.IsValid = Validation.ValidarEmail((CustomValidator)source, txtEmail.Text.Trim());
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }
    }
}