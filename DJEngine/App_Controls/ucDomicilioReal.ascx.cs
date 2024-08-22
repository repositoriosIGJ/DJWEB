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
    public partial class ucDomicilioReal : System.Web.UI.UserControl
    {
        public string proptxtDomicilio
        {
            get { return txtDomicilioReal.Text; }
            set { txtDomicilioReal.Text = value; }
        }

        public string proplblDomicilio
        {
            get { return lblDomicilioReal.Text; }
            set { lblDomicilioReal.Text = value; }
        }

        public bool proptxtDomicilioEnabled
        {
            get { return txtDomicilioReal.Enabled; }
            set { txtDomicilioReal.Enabled = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CustomValidator_DomicilioReal(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.ValidarDomicilio((CustomValidator)source, txtDomicilioReal.Text);
        }
    }
}