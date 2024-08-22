using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DJEngine.Business;
using DJEngine.DataAccess.Entidades;
using System.Data;
using DJEngine.UsoGeneral;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace DJEngine.WebPages
{
    public partial class Imprimir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCss();
            Page.MaintainScrollPositionOnPostBack = true;
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.WorkFlowValidate(Page);

            if (!IsPostBack)
            {
                //btnNuevaDJ.Enabled = false;
                //btnNuevaDJ.Visible = false;
                //MostrarDatosPreImprimir();
            }
        }

        private void LoadCss()
        {
            string aspxpath = "~/App_Theme/Cascading/";
            string aspxname = (Request.Url.Segments[Request.Url.Segments.Length - 1]).Replace(".aspx", ".css");
            HtmlLink cssLink = new HtmlLink();
            cssLink.Href = aspxpath + aspxname;
            cssLink.Attributes.Add("rel", "stylesheet");
            cssLink.Attributes.Add("type", "text/css");
            Header.Controls.Add(cssLink);
        }

        //protected void MostrarDatosPreImprimir()
        //{
        //    //RECUPERA LOS DATOS DE LA ENTIDAD DE LA SESSION
        //    //DDJJ DJ = (DDJJ)Session["DatosEntidad"];
        //    //Entidad Ent = (Entidad)Session["Entidad"];


        //    //if (Ent.Constituida == true)
        //    //{
        //    //    lblEntidad.Visible = true;
        //    //    lblCuitEnt.Visible = false;
        //    //    lblTipoSocietario.Visible = true;
        //    //    lblNroCorrelativo.Visible = true;
        //    //    txtEntidad.Visible = true;
        //    //    txtCuitEnt.Visible = false;
        //    //    txtTipoSocietario.Visible = true;
        //    //    txtNroCorrelativo.Visible = true;

        //    //    txtEntidad.Text = Server.HtmlDecode(Ent.RazonSocial);
        //    //    //Lo estoy llenando pero no lo muestro ni lo uso
        //    //    txtCuitEnt.Text = Convert.ToString(Ent.Cuit);
        //    //    txtTipoSocietario.Text = Convert.ToString(Ent.TipoSocId);
        //    //    txtNroCorrelativo.Text = Convert.ToString(Ent.NroCorrelativo);
        //    //}
        //    //else
        //    //{
        //    //    lblEntidad.Visible = true;
        //    //    lblCuitEnt.Visible = true;
        //    //    txtEntidad.Visible = true;
        //    //    txtCuitEnt.Visible = true;

        //    //    txtEntidad.Text = Server.HtmlDecode(Ent.RazonSocial);
        //    //    txtCuitEnt.Text = Convert.ToString(Ent.Cuit);
        //    //}
        //}

        protected void btnImprimir_Click(object sender, ImageClickEventArgs e)
        {
            //btnNuevaDJ.Enabled = true;
            //btnNuevaDJ.Visible = true;
            //TODO: Harcodeo en false hasta hacer una impresion con seleccion de impresora, etc
            //bool imprimir = true;
            bool imprimir = false;
            GenerarReporte(imprimir);
        }

        protected void btnDescargar_Click(object sender, ImageClickEventArgs e)
        {
            //btnNuevaDJ.Enabled = true;
            //btnNuevaDJ.Visible = true;
            bool imprimir = false;
            GenerarReporte(imprimir);
        }

        protected void btnNuevaDJ_Click(object sender, ImageClickEventArgs e)
        {
            //TODO: Limpiar todos los datos en session y objetos
 
            //WorkFlow.WorkFlowRedirect(0);
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.ReiniciarDeclaracion();
        }

        public void GenerarReporte(bool imprimir)
        { 
            DJAbstract dj = (DJAbstract)Session["DJ"];
            dj.GenerarReporte(imprimir);
        }

        //protected void ImgBtnReader_Click(object sender, ImageClickEventArgs e)
        //{
        //    Response.Redirect("http://get.adobe.com/es/reader/");
        //}
    }
}
