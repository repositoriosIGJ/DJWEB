using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DJEngine.App_Controls
{
    public partial class ucValidacion : System.Web.UI.UserControl
    {
        public bool proppnlvalidacion
        {
            get { return pnlvalidacion.Visible; }
            set { pnlvalidacion.Visible = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlvalidacion.Visible = false;
            }
        }
    }
}