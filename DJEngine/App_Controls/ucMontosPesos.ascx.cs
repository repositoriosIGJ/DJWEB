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
    public partial class ucMontosPesos : System.Web.UI.UserControl
    {
        public string MontoMoneda
        {
            get { return txtMontoMoneda.Text.Trim(); }
            set { txtMontoMoneda.Text = value; }
        }

        //public string MontoPesos
        //{
        //    get { return txtMontoPesos.Text.Trim(); }
        //    set { txtMontoPesos.Text = value; }
        //}

        public string proplblMontoMoneda
        {
            get { return lblMontoMoneda.Text; }
            set { lblMontoMoneda.Text = value; }
        }

        //public string proplblMontoPesos
        //{
        //    get { return lblMontoPesos.Text; }
        //    set { lblMontoPesos.Text = value; }
        //}

        //public string propddlMonedaDesc
        //{
        //    get { return ddlMoneda.SelectedItem.Text.Trim(); }
        //}

        //public int MonedaId
        //{
        //    get { return Convert.ToInt32(ddlMoneda.SelectedValue); }
        //    set
        //    {
        //        foreach (ListItem l in ddlMoneda.Items)
        //        {
        //            if (Convert.ToInt32(l.Value) == value)
        //            {
        //                l.Selected = true;
        //                return;
        //            }
        //        }
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CargarCombos();
            }
        }

        //public void CargarCombos()
        //{
        //    ddlMoneda.DataSource = new TiposMonedas().getTiposMonedas();
        //    ddlMoneda.DataBind();
        //    ddlMoneda.SelectedIndex = 0;
        //    //Combo.CargarLeyenda(ddlMoneda);
        //    //Deshabilito el monto en pesos
        //    OcultarMontoPesos(true);
        //}

        protected void CustomValidator_Standar(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }

        //protected void ddlMoneda_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlMoneda.SelectedValue == "1")
        //    {
        //        //"Pesos Argentinos"
        //        OcultarMontoPesos(true);
        //    }
        //    else
        //    {
        //        //"Monedas Extrajeras"
        //        OcultarMontoPesos(false);
        //    }
        //}

        ////Oculta el monto en pesos y deshabilita el textbox y su validador
        //public void OcultarMontoPesos(bool Ocultar)
        //{
        //    if (Ocultar)
        //    {//Oculto el Monto en Pesos
        //        trMontoPesos.Visible = false;  
        //        txtMontoPesos.Enabled = false;
        //        cvMontoPesos.Enabled = false;
        //    }
        //    else
        //    {//Muestro el Monto en Pesos
        //        trMontoPesos.Visible = true;
        //        txtMontoPesos.Enabled = true;
        //        cvMontoPesos.Enabled = true;
        //    }
        //}

        //public void ReiniciarCombos()
        //{
        //    ddlMoneda.SelectedIndex = 0;
        //    OcultarMontoPesos(true);
        //}
    }
}