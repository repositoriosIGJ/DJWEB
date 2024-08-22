using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DJEngine.Business;
using DJEngine.UsoGeneral;
using DJEngine.DataAccess.Tipos;
using DJEngine.DataAccess.Entidades;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;

namespace DJEngine.App_Controls
{
    public partial class ucBuscadorEnt : System.Web.UI.UserControl
    {
        public string Text
        {
            get {return txtNroCorrelativo.Text;}
            set {txtNroCorrelativo.Text = value;}
        }

        public string RazonSocial
        {
            get { return lblTpoSoc.Text; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Cargo el css propio del usercontrol
            LoadCss();
            //DivCuadroBusEntError.Visible = false;

            if (!IsPostBack)
            {
                //CargarCombos();
            }
        }

        private void LoadCss()
        {
            string csspath = "~/App_Theme/Cascading/";
            string ascxname = this.GetType().Name.Substring(13).Replace("_ascx", ".css");

            HtmlLink cssLink = new HtmlLink();
            cssLink.Href = csspath + ascxname;
            cssLink.Attributes.Add("rel", "stylesheet");
            cssLink.Attributes.Add("type", "text/css");

            Page.Header.Controls.Add(cssLink);
        }

        //public void CargarCombos()
        //{
        //    DJAbstract d = (DJAbstract)Session["DJ"];
        //    ddlTipoSoc.DataSource = new TiposSocietario().getTipoSocietarioFiltrado(d.TipoDJ_Id);
        //    ddlTipoSoc.DataBind();
        //}

        //protected void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        //{
        //    DivFlotante.Visible = !DivFlotante.Visible;
        //    pnlBuscadorAvanzado.Visible = DivFlotante.Visible;

        //    //Reinicio los datos anteriormente ingresados en el buscador avanzado
        //    gridSociedades.Visible = false;
        //    DivCuadroBusEntError.Visible = false;
        //    txtRazonSocial.Text = "";
        //    ddlTipoSoc.SelectedItem.Value = "-1";            
        //}

        protected void btnBuscarNroCorrelativo_Click(object sender, EventArgs e)
        {
            Entidad Ent = new Entidad();

            DJEngine.WSIGJGeneric.IGJ_Generic wsGeneric = new DJEngine.WSIGJGeneric.IGJ_Generic();

            Page.Validate();

            if (Page.IsValid == true)
            {
                WSIGJGeneric.Entidad WsEnt = wsGeneric.GetSociedadPOO(Convert.ToInt32(txtNroCorrelativo.Text));
                if ((txtNroCorrelativo.Text != "") && (WsEnt != null))
                {
                    //Ingreso la Razon Social de la Entidad Entera en el label
                    lblNomEnt.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.RazonSocial, 1);
                    //Asigno la propiedad title con la Razon Social entera para que se muestre en el Tool Tip.
                    lblNomEnt.Attributes.Add("title", "<span class='tooltipTitle'>Razón SocialLL</span><br /> Nombre de la EntidadDD."); 
                    //Pregunto si la Razon Social de la Entidad Entera tiene un largo mayor a 22 caracteres para recortarla
                    if (lblNomEnt.Text.Length > 22)
                    {
                        lblNomEnt.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.RazonSocial, 1).Substring(0, 22) + "...";
                    }

                    //Ingreso el tipo societario entero en el label
                    lblTpoSoc.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.TipoSoc,1);
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "Test", "");
                }
                else
                {
                    lblNomEnt.Text = "";
                    lblTpoSoc.Text = "";
                }
            }
        }

        //protected void lnkNroCorr_Click(object sender, EventArgs e)
        //{
        //    txtNroCorrelativo.Text = ((LinkButton)sender).CommandArgument;
        //    Entidad Ent = new Entidad();

        //    DJEngine.WSIGJGeneric.IGJ_Generic wsGeneric = new DJEngine.WSIGJGeneric.IGJ_Generic();
        //    WSIGJGeneric.Entidad WsEnt = wsGeneric.GetSociedadPOO(Convert.ToInt32(txtNroCorrelativo.Text));

        //    int NroCorr = Convert.ToInt32(((LinkButton)sender).CommandArgument);

        //    wsGeneric.GetSociedadPOO(NroCorr);

        //    lblNomEnt.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.RazonSocial, 1);
        //    if (lblNomEnt.Text.Length > 22)
        //    {
        //        lblNomEnt.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.RazonSocial, 1).Substring(0, 22) + "...";
        //    }

        //    lblTpoSoc.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.TipoSoc, 1);

        //    gridSociedades.DataSource = null;
        //    gridSociedades.SelectedIndex = -1;
        //    gridSociedades.DataBind();

        //    txtRazonSocial.Text = "";

        //    DivFlotante.Visible = false;
        //    pnlBuscadorAvanzado.Visible = false;
        //}

        //protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (txtRazonSocial.Text != "" && txtRazonSocial.Text.Length > 2 && ddlTipoSoc.SelectedItem.Value != "-1")
        //    {
        //        gridSociedades.Visible = true;

        //        DJEngine.WSIGJGeneric.IGJ_Generic wsGeneric = new DJEngine.WSIGJGeneric.IGJ_Generic();

        //        //RECUPERA LOS DATOS DE LA ENTIDAD DE LA SESSION
        //        gridSociedades.DataSource = wsGeneric.GetSociedadesPOO("%" + txtRazonSocial.Text);

        //        gridSociedades.DataBind();
        //    }
        //    else
        //    {
        //        DivCuadroBusEntError.Visible = true;

        //        string Opcion = "0";
                
        //        lblBusEntError.Text = "";

        //        if (txtRazonSocial.Text == "")
        //        {
        //            lblBusEntError.Text = "Debe ingresar una Razón Social";
        //            Opcion = "1";
        //        }

        //        if (txtRazonSocial.Text.Length < 3)
        //        {
        //            lblBusEntError.Text = "Debe ingresar una Razón Social mayor a 2 caracteres";
        //            Opcion += "2";

        //            if (Opcion == "12")
        //            {
        //                lblBusEntError.Text = "Debe ingresar una Razón Social";
        //            }
        //        }

        //        if (ddlTipoSoc.SelectedItem.Value == "-1")
        //        {                    
        //            Opcion += "3";

        //            if (Opcion == "023" || Opcion == "123" || Opcion == "13" || Opcion == "23")
        //            {
        //                lblBusEntError.Text += " y seleccionar un Tipo Societario";
        //            }
        //            else
        //            {
        //                lblBusEntError.Text = "Debe seleccionar un Tipo Societario";
        //            }
        //        }

                
        //    }
        //}

        protected void gridSociedades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}