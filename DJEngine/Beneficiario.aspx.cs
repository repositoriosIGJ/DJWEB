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
    public partial class Beneficiario : System.Web.UI.Page
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
                //if (d.TipoDJ_Id == (int)EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE_REPRESENTANTE)
                //    LblTitulo_2.Text = "Datos del Representante Legal";

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
                //Muestra o oculta los campos del porcentaje o caracter
                rblTipoBen_SelectedIndexChanged(null, null);
            }
        }

        protected void MostrarDatosEntidad()
        {
            //RECUPERA LOS DATOS DEL FIDEICOMISO DE LA SESSION
            Business.Entidad Ent = (Business.Entidad)Session["Entidad"];

            if (Ent.Constituida == true)
            {
                //Si esta inscripto muestro del fideicomiso
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
                //Si no esta inscripto muestro de la fideicomiso
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

            //Registro los datos de la DJ
            CargarCabecera();

            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.Siguiente();
        }

        protected void CargarPropiedades()
        {
            //Guardo en propiedades los datos del Beneficiario
            DJEngine.Business.Beneficiario BEN = new DJEngine.Business.Beneficiario();

            //Beneficiario
            BEN.Nombre = txtNombre.Text.Trim();
            BEN.Apellido = txtApellido.Text.Trim();
            BEN.TipoDocId = ucDocumento.propddlTipoDoc;
            BEN.NroDoc = ucDocumento.proptxtNroDoc.Trim();
            BEN.TipoFiscal = Convert.ToInt32(ucFiscal.propddlTipoFiscal);
            BEN.NroFiscal = ucFiscal.proptxtNroFiscal.Trim();
            BEN.DomicilioReal = ucDomicilioReal.proptxtDomicilio.Trim();
            BEN.Nacionalidad = txtNacionalidad.Text.Trim();
            BEN.FechaNac = Convert.ToDateTime(ucFechaNac.Fecha.Trim());
            BEN.Profesion = txtProfesion.Text.Trim();
            BEN.EstadoCivil = Convert.ToInt32(ucEstadoCivil.propddlEstadoCivil); //Nuevo
            BEN.Email = ucEmail.proptxtEmail.Trim(); //Nuevo
            BEN.TipoBen = Convert.ToInt32(rblTipoBen.SelectedValue); //Nuevo
            BEN.Observaciones = txaObserv.Text.Trim(); //Nuevo
            //Segun el Tipo de Beneficiario
            switch (BEN.TipoBen)
            {
                case 1: //Porcentaje de Participación en la Entidad (Directo)
                case 2: //Porcentaje de Participación en la Entidad (Indirecto)
                    BEN.Porcentaje = Convert.ToDecimal(txtPorcentaje.Text.Trim());
                    BEN.Caracter = "";  
                    break;
                case 3: //Caracter del Beneficiario
                    BEN.Porcentaje = -1;
                    BEN.Caracter = txtCaracter.Text.Trim(); //Nuevo  
                    break;
            }        

            //BEN.BENoNO = chkBenefSIoNO.Checked;

            Session["Beneficiario"] = BEN;
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

        protected void rblTipoBen_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Segun el Tipo de Beneficiario
            switch (rblTipoBen.SelectedValue)
            {
                case "1": //(Participación Directa) //Porcentaje de Participación en la Entidad (Directo)
                    lblPorcentaje.Text = "Porcentaje de Participación en la Entidad (Directo)";
                    divPorcentaje.Visible = true;
                    divCaracter.Visible = false;
                    break;
                case "2": //(Participación Indirecta) //Porcentaje de Participación en la Entidad (Indirecto)                    
                    lblPorcentaje.Text = "Porcentaje de Participación en la Entidad (Indirecto)";
                    divPorcentaje.Visible = true;
                    divCaracter.Visible = false;
                    break;
                case "3": //(Persona Humana que Ejerce el Control Final) //Caracter del Beneficiario
                    divPorcentaje.Visible = false;
                    divCaracter.Visible = true;
                    break;
            }

            //Si el checkbox Indique si NO hay persona humana que posea el caracter de beneficiario/s final/es esta marcado
            /*
            if (chkBenefSIoNO.Checked == true)
            {//Deshabilito y borro todos los campos del beneficiario
                txtNombre.Enabled = false;
                txtNombre.Text = "";
                cvNombre.Enabled = false;

                txtApellido.Enabled = false;
                txtApellido.Text = "";
                cvApellido.Enabled = false;

                ucDocumento.proptxtNroDoc = "";
                ucDocumento.propddlTipoDoc = 0;
                ucDocumento.Visible = false;

                ucFiscal.proptxtNroFiscal = "";
                ucFiscal.propddlTipoFiscal = 0;
                ucFiscal.Visible = false;

                ucDomicilioReal.proptxtDomicilio = "";
                ucDomicilioReal.Visible = false;

                txtNacionalidad.Enabled = false;
                txtNacionalidad.Text = "";
                cvNacionalidad.Enabled = false;

                ucFechaNac.proptxtFecha = "01/01/0001";
                ucFechaNac.Visible = false;
                                
                txtProfesion.Enabled = false;
                txtProfesion.Text = "";
                cvProfesion.Enabled = false;
                                
                txtPorcentaje.Enabled = false;
                txtPorcentaje.Text = "0";
                cvPorcentaje.Enabled = false;
            }
            else
            {//Habilito y borro todos los campos del beneficiario
                txtNombre.Enabled = true;
                txtNombre.Text = "";
                cvNombre.Enabled = true;

                txtApellido.Enabled = true;
                txtApellido.Text = "";
                cvApellido.Enabled = true;

                ucDocumento.proptxtNroDoc = "";
                ucDocumento.propddlTipoDoc = 0;
                ucDocumento.Visible = true;

                ucFiscal.proptxtNroFiscal = "";
                ucFiscal.propddlTipoFiscal = 0;
                ucFiscal.Visible = true;

                ucDomicilioReal.proptxtDomicilio = "";
                ucDomicilioReal.Visible = true;

                txtNacionalidad.Enabled = true;
                txtNacionalidad.Text = "";
                cvNacionalidad.Enabled = true;

                ucFechaNac.proptxtFecha = "";
                ucFechaNac.Visible = true;

                txtProfesion.Enabled = true;
                txtProfesion.Text = "";
                cvProfesion.Enabled = true;

                txtPorcentaje.Enabled = true;
                txtPorcentaje.Text = "";
                cvPorcentaje.Enabled = true;
            }
            */
        }
    }
}
