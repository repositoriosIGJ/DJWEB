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
    public partial class ucAsamblea : System.Web.UI.UserControl
    {

        public int propddlAsamblea
        {
            get { return ddlAsamblea.SelectedIndex; }
            set { ddlAsamblea.SelectedIndex = value; }
        }

        private int _propTipoSocId;

        public int propTipoSocId
        {
            get { return _propTipoSocId; }
            set { _propTipoSocId = value; }
        }

        private int _propTipoDJId;

        public int propTipoDJId
        {
            get { return _propTipoDJId; }
            set { _propTipoDJId = value; }
        }

        public int Asamblea
        {
            get { return Convert.ToInt32(ddlAsamblea.SelectedValue); }
            set
            {
                foreach (ListItem l in ddlAsamblea.Items)
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
            ddlAsamblea.DataSource = new TiposAsamblea().getTiposAsamblea();
            ddlAsamblea.DataBind();
            Combo.CargarLeyenda(ddlAsamblea);
        }

        protected void CustomValidator_Asamblea(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }
    }
}