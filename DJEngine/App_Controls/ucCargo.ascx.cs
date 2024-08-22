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
    public partial class ucCargo : System.Web.UI.UserControl
    {

        public int propddlCargo
        {
            get { return ddlCargo.SelectedIndex; }
            set { ddlCargo.SelectedIndex = value; }
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

        public int Cargo
        {
            get { return Convert.ToInt32(ddlCargo.SelectedValue); }
            set
            {
                foreach (ListItem l in ddlCargo.Items)
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
            ddlCargo.DataSource = new TiposCargo().getTiposCargoFiltrado(propTipoSocId);
            ddlCargo.DataBind();
            Combo.CargarLeyenda(ddlCargo);

            if (propTipoDJId == Convert.ToInt32(EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE_FIDEICOMISO_FISICA))
            {
                //Deshabilito el combo de cargo para Fideicomiso, para que solo se pueda seleccionar Fiduciario
                ddlCargo.SelectedValue = "24";
                ddlCargo.Items.RemoveAt(0);
                ddlCargo.Enabled = false;
            }
        }

        protected void CustomValidator_Cargo(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }
    }
}