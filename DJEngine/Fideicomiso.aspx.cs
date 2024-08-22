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
    public partial class Fideicomiso : System.Web.UI.Page
    {
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
                    //rblConstituida_SelectedIndexChanged(null, null);
                    MostrarConstituida(true);

                    Session["Fideicomiso"] = null;
                    //Session["DatosEntidad"] = null;
                    //Session["Entidad"] = null;
                    Session["captchaValue"] = null;
                    Session["captchaValidate"] = "1";

                    //Carga de Combos para Tipo Societario de Fideicomiso (175)
                    //ddlTipoDeEntidad.DataSource = new TiposSocietario().getTipoSocietarioFiltrado(d.TipoDJ_Id);
                    DataSet dsaux = new TiposSocietario().getTipoSocietario();
                    //harcodeo el tipo societario 175 para que solo se muestre FIDEICOMISO
                    DataRow[] result = dsaux.Tables["Table1"].Select("CODIGO = 175");

                    DataTable dtaux = dsaux.Tables["Table1"].Clone();

                    foreach (DataRow row in result)
                    {
                        dtaux.ImportRow(row);
                    }

                    dsaux.Tables.Clear();
                    dsaux.Tables.Add(dtaux);

                    ddlTipoDeEntidad.DataSource = dsaux;
                    ddlTipoDeEntidad.DataBind();
                    ddlTipoDeEntidad.Enabled = false;

                    //ddlTipoDeEntidadConstituida.DataSource = new TiposSocietario().getTipoSocietarioFiltrado(d.TipoDJ_Id);
                    ddlTipoDeEntidadConstituida.DataSource = dsaux;
                    ddlTipoDeEntidadConstituida.DataBind();
                    ddlTipoDeEntidadConstituida.Enabled = false;

                    //dtaux.Clear();
                    //dsaux.Clear();
                }
                catch (Exception ex)
                {
                    throw new Exception("No pudo cargar el combo Tipo Societario:" + ex.Message);
                }
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
            Business.Entidad Fid = new Business.Entidad();            

            //Constituida
            Fid.Constituida = true;
            Fid.RazonSocial = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.RazonSocial, 1); ;
            Fid.Cuit = WsEnt.Cuit;
            Fid.NroCorrelativo = WsEnt.NroCorrelativo;
            Fid.TipoSocId = WsEnt.TipoSocId;
            Fid.TipoSocDesc = new TiposSocietario(Fid.TipoSocId).Descripcion;

            Session["Fideicomiso"] = Fid;
            //Lo cargo en sesion como Entidad porque tiene las mismas propiedades y se va a usar en la sig pagina
            //Session["Entidad"] = Fid;
        }

        protected void CargarPropiedades()
        {
            Business.Entidad Fid = new Business.Entidad();

            //Incripto
            if (Convert.ToInt32(rblConstituida.SelectedValue) == 1)
            {
                //Las propiedades se cargaron antes en el metodo CargarPropiedadesBuscarNroCorrelativo
                //return;
            }
            else //No Inscripto
            {
                Fid.Constituida = false;
                Fid.RazonSocial = CharacterTreat.ConvertirPrimeraLetraMayuscula(Convert.ToString(txtEntidad.Text.Trim()), 1);
                //No pedimos el Cuit para no constituida
                Fid.Cuit = null;
                //No hay NroCorrelativo para no constituida
                Fid.NroCorrelativo = null;
                Fid.TipoSocId = Convert.ToInt32(ddlTipoDeEntidad.SelectedValue);
                Fid.TipoSocDesc = new TiposSocietario(Fid.TipoSocId).Descripcion;

                Session["Fideicomiso"] = Fid;
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
            DJEngine.WSIGJGeneric.IGJ_Generic wsGeneric = new DJEngine.WSIGJGeneric.IGJ_Generic();

            Page.Validate();

            if (Page.IsValid)
            {
                WSIGJGeneric.Entidad WsEnt = wsGeneric.GetSociedadPOO(Convert.ToInt32(txtNroCorrelativo.Text.Trim()));

                //Pregunto si Existe un Fideicomiso Inscripto para ese Nro Correlativo
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
                        ddlTipoDeEntidadConstituida.Enabled = false;
                        divdatosentidad.Visible = false;
                        divTipoDeEntidadC.Visible = true;
                        divcaptchaentidad.Visible = true;
                        txtEntidadC.Text = "";
                        txtTipoSocietario.Text = "";
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
                    divdatosentidad.Visible = false;
                    divTipoDeEntidadC.Visible = true;
                    divcaptchaentidad.Visible = true;
                    txtEntidadC.Text = "";
                    txtTipoSocietario.Text = "";
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
            }
        }

        public void LoadDatos(WSIGJGeneric.Entidad WsEnt)
        {
            Business.Entidad Fid = new Business.Entidad();
            Fid = (Business.Entidad)HttpContext.Current.Session["Fideicomiso"];

            //Ingreso la Razon Social de la Entidad Entera en el textbox
            txtEntidadC.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.RazonSocial, 1);

            //Pregunto si la Razon Social de la Entidad Entera tiene un largo mayor a 22 caracteres para recortarla
            if (txtEntidadC.Text.Length > 40)
            {
                txtEntidadC.Text = txtEntidadC.Text.Substring(0, 40) + "...";
            }

            //Ingreso el tipo societario entero en el textbox
            //txtTipoSocietario.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.TipoSoc, 1);
            txtTipoSocietario.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(Fid.TipoSocDesc, 1);
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            //Valido todos los controles de la pagina web
            Page.Validate();

            if (!Page.IsValid)
            {
                pnlvalidacion.Visible = true;
                return;
            }

            //DDJJ DJ = (DDJJ)Session["DatosEntidad"];
            //Business.Entidad Ent = (Business.Entidad)Session["Entidad"];
            //Business.Fideicomiso Fid = (Business.Fideicomiso)Session["Fideicomiso"];

            DJAbstract d = (DJAbstract)Session["DJ"];

            if (rblConstituida.SelectedIndex == 0)
            {
                //Inscripto
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
            else //No Inscripto
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
            {//Inscripto
                MostrarConstituida(true);
            }
            else
            {//No Inscripto
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
            {//Inscripto
                pnlwfk_2.Visible = true;
                pnlwfk_3.Visible = false;

                pnlvalidacion.Visible = false;
                ucCaptchaEntidad.btnRecargarCaptcha_Click(null, null);
                txtNroCorrelativo.Text = "";
                txtNroCorrelativo.Enabled = true;
                ddlTipoDeEntidadConstituida.Enabled = false;
                ddlTipoDeEntidadConstituida.Visible = true;
                ddlTipoDeEntidadConstituida.SelectedIndex = -1;
                divdatosentidad.Visible = false;
                divTipoDeEntidadC.Visible = true;
                divcaptchaentidad.Visible = true;
                txtEntidadC.Text = "";
                txtTipoSocietario.Text = "";
                MostrarContinuar(false);
            }
            else
            {//No Inscripto
                pnlwfk_2.Visible = false;
                pnlwfk_3.Visible = true;

                pnlvalidacion.Visible = false;
                //ucCaptchaEntidad.btnRecargarCaptcha_Click(null, null);
                txtEntidad.Text = "";
                ddlTipoDeEntidad.SelectedIndex = -1;
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
