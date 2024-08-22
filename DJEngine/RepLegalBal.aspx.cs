using System;
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
    public partial class RepLegalBal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCss();
            Page.MaintainScrollPositionOnPostBack = true;

            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.WorkFlowValidate(Page);

            if (!IsPostBack)
            {
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
                //lblRelacionPPRPEP.CssClass = "lblTachado";
                MostrarDatosEntidad();

                //Deshabilita y Oculta el chkNoPoseo
                ucFiscalREPBAL.propchkNoPoseo = false;

                //Oculta Captcha para Desarrollo
                if (Session["CaptchaHabilitado"] != null)
                {
                    if ((bool)Session["CaptchaHabilitado"] == false)
                    {
                        this.ucCaptchaPersona.Visible = false;
                    }
                }
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
                //txtSedeSocial.Visible = true;

                txtEntidad.Text = Ent.RazonSocial.ToString();
                //Lo estoy llenando pero no lo muestro ni lo uso
                //txtCuitEnt.Text = Ent.Cuit.ToString();
                //txtTipoSocietario.Text = new TiposSocietario(Ent.TipoSocId).Descripcion;
                txtTipoSocietario.Text = Ent.TipoSocDesc;
                txtNroCorrelativo.Text = Ent.NroCorrelativo.ToString();
                //txtSedeSocial.Text = Ent.SedeSocial;
            }
            else
            {
                //Si no esta constituida muestro de la entidad
                //Denominacion y TipoSocietario
                lblEntidad.Visible = true;
                lblTipoSocietario.Visible = true;
                txtEntidad.Visible = true;
                txtTipoSocietario.Visible = true;
                //txtSedeSocial.Visible = true;

                txtEntidad.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(Convert.ToString(Ent.RazonSocial), 1);
                if (txtEntidad.Text.Length >= 40)
                    txtEntidad.Text = txtEntidad.Text.Substring(0, 40) + "...";

                //txtTipoSocietario.Text = new TiposSocietario(Ent.TipoSocId).Descripcion;
                txtTipoSocietario.Text = Ent.TipoSocDesc;
                //txtSedeSocial.Text = Ent.SedeSocial;
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
            try
            {
                //Valido todos los controles de la pagina web
                Page.Validate();

                if (!Page.IsValid)
                {
                    pnlvalidacion.Visible = true;
                    return;
                }

                CargarPropiedades();

                //Registro los datos de la DJ
                if (CargarCabecera())
                {//Se persistieron bien los datos de la DJ
                    DJAbstract d = (DJAbstract)Session["DJ"];
                    d.WorkFlow.Siguiente();
                }
                else
                {//Se persistieron mal los datos de la DJ
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarPropiedades()
        {
            //Guardo en propiedades los datos del Representante Legal
            DJEngine.Business.RepLegalBal REP = new DJEngine.Business.RepLegalBal();

            //Representante Legal
            REP.Nombre = txtNombreREPBAL.Text.Trim();
            REP.Apellido = txtApellidoREPBAL.Text.Trim();
            REP.TipoDoc = ucDocumentoREPBAL.propddlTipoDoc;
            REP.NroDoc = ucDocumentoREPBAL.proptxtNroDoc.Trim();
            REP.TipoClaveFiscal = Convert.ToInt32(ucFiscalREPBAL.propddlTipoFiscal);
            REP.NroClaveFiscal = ucFiscalREPBAL.proptxtNroFiscal.Trim();
            //REP.DomicilioReal = ucDomicilioReal.proptxtDomicilio.Trim();

            Session["RepLegalBal"] = REP;
        }

        protected bool CargarCabecera()
        {
            DJAbstract d = (DJAbstract)Session["DJ"];

            if (d.RegistrarDJ())
            {
                Session["DJ"] = d;
                return true;
            }
            else
            {
                Session["DJ"] = null;
                return false;
            }
        }
    }
}
