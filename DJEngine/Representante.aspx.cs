﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DJEngine.Business;
using DJEngine.DataAccess.Tipos;
using DJEngine.UsoGeneral;

namespace DJEngine.WebEntities
{
    public partial class Representante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCss();
            Page.MaintainScrollPositionOnPostBack = true;

            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.WorkFlowValidate(Page);

            if (!IsPostBack)
            {
                //Pregunto si se trata de la DJ07 para cambiar el titulo
                if (d.TipoDJ_Id == (int)EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE_REPRESENTANTE)
                    LblTitulo_2.Text = "Datos del Representante Legal";

                //ddlTipoDocREP.DataSource = new TiposDocumento().getTipoDocumento();
                //ddlTipoDocREP.DataBind();

                pnlvalidacion.Visible = false;

                //Oculto Labels y Textbox
                lblEntidad.Visible = false;
                //lblCuitEnt.Visible = false;
                lblTipoSocietario.Visible = false;
                lblNroCorrelativo.Visible = false;
                txtEntidad.Visible = false;
                //txtCuitEnt.Visible = false;
                txtTipoSocietario.Visible = false;
                txtNroCorrelativo.Visible = false;
                //lblCaptchaError.Visible = false;
                lblCaptchaErrorvld.Visible = false;
                //lblRelacionPEP.CssClass = "lblTachado";
                MostrarDatosEntidad();
            }
        }

        protected void MostrarDatosEntidad()
        {
            //RECUPERA LOS DATOS DE LA ENTIDAD DE LA SESSION
            Business.Entidad Ent = (Business.Entidad)Session["Entidad"];

            if (Ent.Constituida == true)
            {
                //Si esta constituida muestro de la entidad
                //Denominacion, TipoSocietario y NroCorrelativo
                lblEntidad.Visible = true;
                //lblCuitEnt.Visible = false;
                lblTipoSocietario.Visible = true;
                lblNroCorrelativo.Visible = true;
                txtEntidad.Visible = true;
                //txtCuitEnt.Visible = false;
                txtTipoSocietario.Visible = true;
                txtNroCorrelativo.Visible = true;

                txtEntidad.Text = Ent.RazonSocial.ToString();
                //Lo estoy llenando pero no lo muestro ni lo uso
                //txtCuitEnt.Text = Ent.Cuit.ToString();
                txtTipoSocietario.Text = new TiposSocietario(Ent.TipoSocId).Descripcion;
                txtNroCorrelativo.Text = Ent.NroCorrelativo.ToString();
            }
            else
            {
                //Si no esta constituida muestro de la entidad
                //Denominacion y TipoSocietario
                lblEntidad.Visible = true;
                lblTipoSocietario.Visible = true;
                txtEntidad.Visible = true;
                txtTipoSocietario.Visible = true;

                txtEntidad.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(Convert.ToString(Ent.RazonSocial), 1);
                if (txtEntidad.Text.Length >= 40)
                    txtEntidad.Text = txtEntidad.Text.Substring(0, 40) + "...";

                txtTipoSocietario.Text = new TiposSocietario(Ent.TipoSocId).Descripcion;
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
            //Tambien Levanto el Generico de Diseño de Formularios
            cssLink.Href = "~/App_Theme/Cascading/FormDesign.css";
            Header.Controls.Add(cssLink);
        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.Anterior();
        }

        protected void CustomValidator_Standar(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }

        protected void btnContinuar_Click(object sender, ImageClickEventArgs e)
        {
            //Valido todos los controles de la pagina web
            Page.Validate();

            if (!Page.IsValid)
            {
                pnlvalidacion.Visible = true;
                return;
            }

            CargarPropiedades();
            //CargarCabeceraPPE();
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.Siguiente();
        }

        protected void CargarPropiedades()
        {
            //Guardo en propiedades los datos de la Persona Politicamente Expuesta
            DJEngine.Business.Representante REP = new DJEngine.Business.Representante();

            //Representante
            REP.Nombre = txtNombreREP.Text.Trim();
            REP.Apellido = txtApellidoREP.Text.Trim();
            //REP.TipoDoc = ddlTipoDocREP.SelectedIndex;
            REP.TipoDoc = ucDocumentoREP.propddlTipoDoc;
            //REP.NroDoc = txtNroDocREP.Text.Trim();
            REP.NroDoc = ucDocumentoREP.proptxtNroDoc.Trim();
            //REP.TipoClaveFiscal = Convert.ToInt32(ddlTipoClaveFiscalREP.SelectedItem.Value);
            REP.TipoClaveFiscal = Convert.ToInt32(ucFiscalREP.propddlTipoFiscal);
            REP.NroClaveFiscal = ucFiscalREP.proptxtNroFiscal.Trim();

            Session["Representante"] = REP;
        }
    }
}
