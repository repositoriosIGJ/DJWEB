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
    public partial class ucDictamen : System.Web.UI.UserControl
    {

        public int propddlDictamen
        {
            get { return ddlDictamen.SelectedIndex; }
            set { ddlDictamen.SelectedIndex = value; }
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

        public int Dictamen
        {
            get { return Convert.ToInt32(ddlDictamen.SelectedValue); }
            set
            {
                foreach (ListItem l in ddlDictamen.Items)
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
            ddlDictamen.DataSource = new TiposDictamen().getTiposDictamen();
            ddlDictamen.DataBind();
            Combo.CargarLeyenda(ddlDictamen);
        }

        protected void CustomValidator_Dictamen(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }
    }
}