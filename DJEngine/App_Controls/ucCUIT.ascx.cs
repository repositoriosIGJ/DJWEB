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
    public partial class ucCUIT : System.Web.UI.UserControl
    {
        public string proptxtCUIT
        {
            get { return txtCUIT.Text; }
            set { txtCUIT.Text = value; }
        }

        public string proplblCUIT
        {
            get { return lblCUIT.Text; }
            set { lblCUIT.Text = value; }
        }

        public bool propCUITEnabled
        {
            get { return cvCUIT.Enabled; }
            set { cvCUIT.Enabled = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CustomValidator_CUIT(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.ValidarCUIT((CustomValidator)source, txtCUIT.Text);
        }
    }
}