using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using DJEngine.DataAccess.Tipos;
using System.Data;
using DJEngine.DataAccess.Entidades;
using DJEngine.Business;
using System.Text.RegularExpressions;
using DJEngine.UsoGeneral;

namespace DJEngine.WebEntities
{
    public partial class EntidadF : System.Web.UI.Page
    {
        public Business.Entidad Fid { get; set; }
        //public Business.Entidad Ent { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //LoadCss();
            Page.MaintainScrollPositionOnPostBack = true;

            DJAbstract d = (DJAbstract)Session["DJ"];

            //Valida que la pagina fuera la correcta
            d.WorkFlow.WorkFlowValidate(Page);

            Session["captchaValidate"] = "1";

            if (!IsPostBack)
            {
                try
                {
                    MostrarConstituida(true);

                    ////Pregunto si se trata de la DJ02 para mostrar solo la busqueda de entidad consituida
                    //if (d.TipoDJ_Id == (int)EnumDJ.EDDJJ.DOMICILIO_DIGITAL)
                    //    SoloConstituida(true);

                    //Session["Fideicomiso"] = null;
                    Session["DatosEntidad"] = null;
                    Session["Entidad"] = null;
                    Session["captchaValue"] = null;
                    Session["captchaValidate"] = "1";

                    //RECUPERA LOS DATOS DEL FIDEICOMISO DE LA SESSION
                    Fid = (Business.Entidad)Session["Fideicomiso"];

                    ddlTipoDeEntidad.DataSource = new TiposSocietario().getTipoSocietarioFiltrado(d.TipoDJ_Id);
                    ddlTipoDeEntidad.DataBind();

                    ddlTipoDeEntidadConstituida.DataSource = new TiposSocietario().getTipoSocietarioFiltrado(d.TipoDJ_Id);
                    ddlTipoDeEntidadConstituida.DataBind();

                    //Cambio Label Domicilio Real por Sede Social
                    ucDomicilioRealC.proplblDomicilio = "Sede Social";
                    ucDomicilioRealOJ.proplblDomicilio = "Sede Social";

                    MostrarDatosFideicomiso();
                }
                catch (Exception ex)
                {
                    throw new Exception("No pudo cargar el combo Tipo Societario:" + ex.Message);
                }
            }
        }

        protected void MostrarDatosFideicomiso()
        {
            if (Fid.Constituida == true)
            {
                //Si esta inscripto muestro de la entidad
                //Denominacion, TipoSocietario y NroCorrelativo
                lblEntidadRef.Visible = true;
                lblTipoSocietarioRef.Visible = true;
                lblNroCorrelativoRef.Visible = true;
                txtEntidadRef.Visible = true;
                txtTipoSocietarioRef.Visible = true;
                txtNroCorrelativoRef.Visible = true;

                txtEntidadRef.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(Convert.ToString(Fid.RazonSocial), 1);
                if (txtEntidadRef.Text.Length >= 40)
                    txtEntidadRef.Text = txtEntidadRef.Text.Substring(0, 40) + "...";

                txtTipoSocietarioRef.Text = Fid.TipoSocDesc;
                txtNroCorrelativoRef.Text = Fid.NroCorrelativo.ToString();
            }
            else
            {
                //Si no esta inscripto muestro de la entidad
                //Denominacion y TipoSocietario
                lblEntidadRef.Visible = true;
                lblTipoSocietarioRef.Visible = true;
                txtEntidadRef.Visible = true;
                txtTipoSocietarioRef.Visible = true;
                lblNroCorrelativoRef.Visible = false;
                txtNroCorrelativoRef.Visible = false;

                txtEntidadRef.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(Convert.ToString(Fid.RazonSocial), 1);
                if (txtEntidadRef.Text.Length >= 40)
                    txtEntidadRef.Text = txtEntidadRef.Text.Substring(0, 40) + "...";

                txtTipoSocietarioRef.Text = Fid.TipoSocDesc;
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

        protected void CargarPropiedadesBuscarNroCorrelativo(WSIGJGeneric.Entidad WsEnt)
        {
            Business.Entidad Ent = new Business.Entidad();

            //Constituida
            Ent.Constituida = true;
            Ent.RazonSocial = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.RazonSocial, 1);
            Ent.Cuit = WsEnt.Cuit;
            Ent.NroCorrelativo = WsEnt.NroCorrelativo;
            Ent.TipoSocId = WsEnt.TipoSocId;
            Ent.TipoSocDesc = new TiposSocietario(Ent.TipoSocId).Descripcion;
            Ent.SedeSocial = ucDomicilioRealC.proptxtDomicilio.Trim();

            Session["Entidad"] = Ent;
        }

        protected void CargarPropiedades()
        {
            //DataSet ds = (DataSet)Session["ds1"];
            Business.Entidad Ent = new Business.Entidad();
            //GridViewRow row = gvSociedades.SelectedRow;

            //Constituida
            if (Convert.ToInt32(rblConstituida.SelectedValue) == 1)
            {
                //Las propiedades se cargaron antes en el metodo CargarPropiedadesBuscarNroCorrelativo
                //return;
            }
            else //En otra Jurisdiccion
            {
                Ent.Constituida = false;
                Ent.RazonSocial = CharacterTreat.ConvertirPrimeraLetraMayuscula(Convert.ToString(txtEntidad.Text.Trim()), 1);
                //No pedimos el Cuit para no constituida
                Ent.Cuit = null;
                //No hay NroCorrelativo para no constituida
                Ent.NroCorrelativo = null;
                Ent.TipoSocId = Convert.ToInt32(ddlTipoDeEntidad.SelectedValue);
                Ent.TipoSocDesc = new TiposSocietario(Ent.TipoSocId).Descripcion;
                Ent.SedeSocial = ucDomicilioRealOJ.proptxtDomicilio.Trim();

                Session["Entidad"] = Ent;
            } 
        }

        protected void btnBuscarNroCorrOtra_Click(object sender, EventArgs e)
        {
            ucCaptchaEntidad.propCaptchaEnabled = true;
            Session["captchaValue"] = null;
            Session["CaptchaValidate"] = null;
            
            MostrarConstituida(true);
        }

        protected void btnBuscarNroCorr_Click(object sender, EventArgs e)
        {
            Entidad Ent = new Entidad();

            DJEngine.WSIGJGeneric.IGJ_Generic wsGeneric = new DJEngine.WSIGJGeneric.IGJ_Generic();

            //ucCaptchaEntidad.propCaptchaEnabled = false;

            Page.Validate();

            if (Page.IsValid)
            {
                WSIGJGeneric.Entidad WsEnt = wsGeneric.GetSociedadPOO(Convert.ToInt32(txtNroCorrelativo.Text.Trim()));                

                //Pregunto si Existe una Entidad Constituida para ese Nro Correlativo
                if (WsEnt != null)
                {
                    //Pregunto si el Tipo Societario de la base es igual al que eligio el usuario en el combo
                    if (WsEnt.TipoSocId == Convert.ToInt32(ddlTipoDeEntidadConstituida.SelectedValue))
                    {
                        //Cargo las propiedades en sesion cada vez que busco por numero correlativo para no perder todos los datos
                        CargarPropiedadesBuscarNroCorrelativo(WsEnt);

                        if (txtEntidadC.Text.Trim() != "" && txtTipoSocietario.Text.Trim() != "")
                        {
                            ucCaptchaEntidad.btnRecargarCaptcha_Click(null, null);
                        }
                        cvNoExisteNroCorr.IsValid = true;
                        pnlvalidacion.Visible = false;
                        txtNroCorrelativo.Enabled = false;
                        ddlTipoDeEntidadConstituida.Enabled = false;
                        ddlTipoDeEntidadConstituida.Visible = false;
                        divdatosentidad.Visible = true;
                        divTipoDeEntidadC.Visible = false;
                        divcaptchaentidad.Visible = false;
                        MostrarContinuar(true);
                        LoadDatos(WsEnt);
                    }
                    else
                    {
                        cvTipoDeEntidadConstituida.IsValid = false;
                        string ErrorTipoDeEntidad = "El Tipo Societario no se corresponde al N&uacute;mero Correlativo ingresado";
                        cvTipoDeEntidadConstituida.ErrorMessage = "[" + "TIPO DE ENTIDAD" + "] " + ErrorTipoDeEntidad + "&nbsp;";
                        cvTipoDeEntidadConstituida.Text = "x";
                        pnlvalidacion.Visible = true;
                        txtNroCorrelativo.Enabled = true;
                        ddlTipoDeEntidadConstituida.Enabled = true;
                        //ucDomicilioRealC.Enabled = true;
                        ucDomicilioRealC.Visible = true;
                        divdatosentidad.Visible = false;
                        divTipoDeEntidadC.Visible = true;
                        divcaptchaentidad.Visible = true;
                        txtEntidadC.Text = "";
                        txtTipoSocietario.Text = "";
                        txtSedeSocialDato.Text = "";
                    }
                }
                else
                {
                    cvNoExisteNroCorr.IsValid = false;
                    string ErrorNroCorr = "El N&uacute;mero Correlativo no se corresponde a una Entidad existente";
                    cvNoExisteNroCorr.ErrorMessage = "[" + "NUMERO CORRELATIVO" + "] " + ErrorNroCorr + "&nbsp;";
                    cvNoExisteNroCorr.Text = "x";
                    pnlvalidacion.Visible = true;
                    txtNroCorrelativo.Enabled = true;
                    ddlTipoDeEntidadConstituida.Enabled = true;
                    //ucDomicilioRealC.Enabled = true;
                    ucDomicilioRealC.Visible = true;
                    divdatosentidad.Visible = false;
                    divTipoDeEntidadC.Visible = true;
                    divcaptchaentidad.Visible = true;
                    txtEntidadC.Text = "";
                    txtTipoSocietario.Text = "";
                    txtSedeSocialDato.Text = "";
                }
            }
            else
            {
                cvNoExisteNroCorr.IsValid = true;
                cvTipoDeEntidadConstituida.IsValid = true;
                pnlvalidacion.Visible = true;
                divdatosentidad.Visible = false;
                txtEntidadC.Text = "";
                txtTipoSocietario.Text = "";
                txtSedeSocialDato.Text = "";
            }
        }

        public void LoadDatos(WSIGJGeneric.Entidad WsEnt)
        {
            //Ingreso la Razon Social de la Entidad Entera en el textbox
            txtEntidadC.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.RazonSocial, 1);
            
            //Pregunto si la Razon Social de la Entidad Entera tiene un largo mayor a 22 caracteres para recortarla
            if (txtEntidadC.Text.Length > 40)
            {
                txtEntidadC.Text = txtEntidadC.Text.Substring(0, 40) + "...";
            }

            //Ingreso el tipo societario entero en el textbox
            txtTipoSocietario.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.TipoSoc, 1);
            txtSedeSocialDato.Text = ucDomicilioRealC.proptxtDomicilio.Trim();
        }   

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            //if (rblConstituida.SelectedIndex == 1)
            //{
            //Valido todos los controles de la pagina web
            Page.Validate();            

            if (!Page.IsValid)
            {
                pnlvalidacion.Visible = true;
                return;
            }
            //}

            DDJJ DJ = (DDJJ)Session["DatosEntidad"];
            Business.Entidad Ent = (Business.Entidad)Session["Entidad"];

            DJAbstract d = (DJAbstract)Session["DJ"];
            
            if (rblConstituida.SelectedIndex == 0)
            {
                //Constituida
                if (txtNroCorrelativo.Text != "" && txtEntidadC.Text != "" && txtTipoSocietario.Text != "")
                {
                    CargarPropiedades();
                    d.WorkFlow.Siguiente();
                }
                else
                {
                    d.WorkFlow.Refrescar();
                }
            }
            else //No Constituida
            {
                if (txtEntidad.Text != "" && ddlTipoDeEntidad.SelectedIndex != -1)
                {
                    CargarPropiedades();
                    d.WorkFlow.Siguiente();
                }
                else
                {
                    //Mostrar mensaje de error para completar los 2 campos
                    d.WorkFlow.Refrescar();
                }
            }
        }

        protected void rblConstituida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblConstituida.SelectedIndex == 0)
            {//Constituida
                MostrarConstituida(true);
            }
            else
            {//No Constituida
                MostrarConstituida(false);
            }
        }

        public void SoloConstituida(bool Constituida)
        {
            pnlwfk_1.Visible = false;
        }

        public void MostrarConstituida(bool Constituida)
        {
            if (Constituida)
            {//Constituida
                pnlwfk_2.Visible = true;
                pnlwfk_3.Visible = false;

                pnlvalidacion.Visible = false;
                ucCaptchaEntidad.btnRecargarCaptcha_Click(null, null);
                txtNroCorrelativo.Text = "";
                txtNroCorrelativo.Enabled = true;
                ddlTipoDeEntidadConstituida.Enabled = true;
                ddlTipoDeEntidadConstituida.Visible = true;
                ddlTipoDeEntidadConstituida.SelectedIndex = -1;
                divdatosentidad.Visible = false;
                divTipoDeEntidadC.Visible = true;
                divcaptchaentidad.Visible = true;
                txtEntidadC.Text = "";
                txtTipoSocietario.Text = "";
                ucDomicilioRealC.proptxtDomicilio = "";
                MostrarContinuar(false);
            }
            else
            {//No Constituida
                pnlwfk_2.Visible = false;
                pnlwfk_3.Visible = true;

                pnlvalidacion.Visible = false;
                //ucCaptchaEntidad.btnRecargarCaptcha_Click(null, null);
                txtEntidad.Text = "";
                ddlTipoDeEntidad.SelectedIndex = -1;
                ucDomicilioRealOJ.proptxtDomicilio = "";
                MostrarContinuar(true);
            }
        }

        public void MostrarContinuar(bool Continuar)
        {
            if (Continuar)
            {
                btnContinuar.ImageUrl = "~/App_Theme/Imagenes/btnvacio.png";
                btnContinuar.Enabled = true;
            }
            else
            {
                btnContinuar.ImageUrl = "~/App_Theme/Imagenes/btncontinuard.png";
                btnContinuar.Enabled = false;
            }
        }

        protected void CustomValidator_Standar(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.Anterior(); 
        }       
    }
}