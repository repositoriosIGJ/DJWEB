using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DJEngine.DataAccess.Tipos;
using System.Web.UI.HtmlControls;
//using DJEngine.DataAccess.Entidades;
using DJEngine.Business;
using System.Text.RegularExpressions;
using DJEngine.UsoGeneral;

namespace DJEngine.WebEntities
{
    public partial class Persona : System.Web.UI.Page
    {
        public Business.Entidad Ent { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCss();
            Page.MaintainScrollPositionOnPostBack = true;

            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.WorkFlowValidate(Page);

            //RECUPERA LOS DATOS DE LA ENTIDAD DESDE LA SESSION PERO SINO RECUPERA EL FIDEICOMISO SI LA DJ ES DE FIDEICOMISO
            if (d.TipoDJ_Id == Convert.ToInt32(EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE_FIDEICOMISO_FISICA))
            {
                Ent = (Business.Entidad)Session["Fideicomiso"];
            }
            else
            {
                Ent = (Business.Entidad)Session["Entidad"];
            }

            if (!IsPostBack)
            {
                CargarCombos();

                if (d.TipoDJ_Id == Convert.ToInt32(EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE_ESCRIBANOS))
                {
                    lblHeader_1.Text = "Indique si el declarante es una Persona Expuesta Políticamente";
                    lblHeader_1b.Text = "Indique si es Personas Expuestas Politicamente por parentesco o cercania";
                    //lblHeader_1b.Text = "Indique si el interesado está incluido en los Incisos \"B\" o \"I\"";
                }
                else if (d.TipoDJ_Id == Convert.ToInt32(EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE_REPRESENTANTE))
                {
                    lblHeader_1.Text = "Indique si el interesado es una Persona Expuesta Políticamente";
                    lblHeader_1b.Text = "Indique si es Personas Expuestas Politicamente por parentesco o cercania";
                    //lblHeader_1b.Text = "Indique si el interesado está incluido en los Incisos \"B\" o \"I\"";
                }
                else if (d.TipoDJ_Id == Convert.ToInt32(EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE_FIDEICOMISO_FISICA))
                {
                    lblHeader_1.Text = "Indique si usted es una Persona Expuesta Políticamente";
                    lblHeader_1b.Text = "Indique si es Personas Expuestas Politicamente por parentesco o cercania";
                    //lblHeader_1b.Text = "Indique si usted está incluido en los Incisos \"B\" o \"I\"";
                    //Deshabilito el combo de cargo para Fideicomiso, para que solo se pueda seleccionar Fiduciario
                    ddlCargoPEP.SelectedValue = "24";
                    ddlCargoPEP.Items.RemoveAt(0);
                    ddlCargoPEP.Enabled = false;
                }
                else
                {
                    lblHeader_1.Text = "Indique si usted es una Persona Expuesta Políticamente";
                    lblHeader_1b.Text = "Indique si es Personas Expuestas Politicamente por parentesco o cercania";
                    //lblHeader_1b.Text = "Indique si usted está incluido en los Incisos \"B\" o \"I\"";
                }

                pnlvalidacion.Visible = false;

                Session["PersonaEP"] = null;

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
                this.ucCaptchaPersona.proplblCaptchaErrorVisible = false;
                //lblCaptchaErrorvld.Visible = false;
                //lblRelacionPEP.CssClass = "lblTachado";
                MostrarDatosEntidad();
            }
        }

        private void CargarCombos()
        {
            ddlCargoPEP.DataSource = new TiposCargo().getTiposCargoFiltrado(Ent.TipoSocId);
            ddlCargoPEP.DataBind();

            Combo.CargarLeyenda(ddlCargoPEP);
        }

        public static string[] LimpiarCaracter(string[] nombres)
        {
            string[] aux = nombres;

            for (int i = 0; i < nombres.Length; i++)
            {
                aux[i] = (Convert.ToString(nombres[i])).Replace("_", " ");
            }
            return aux;
        }

        protected void MostrarDatosEntidad()
        {
            //RECUPERA LOS DATOS DE LA ENTIDAD DE LA SESSION
            //Business.Entidad Ent = (Business.Entidad)Session["Entidad"];

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

                txtEntidad.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(Convert.ToString(Ent.RazonSocial), 1);
                if (txtEntidad.Text.Length >= 40)
                    txtEntidad.Text = txtEntidad.Text.Substring(0, 40) + "...";

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

        protected bool CargarCabeceraPPE()
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

        protected void CargarPropiedades()
        {
            //Guardo en propiedades los datos de la Persona Politicamente Expuesta
            PersonaEP PEP = new PersonaEP();

            //Necesito Convertir el Id del Indice del combo al Id Real del Cargo porque esta filtrado
            //ddlCargoPEP.SelectedIndex;

            if (Convert.ToInt32(rblPEPoF.SelectedValue) == 1)
            {//Soy Persona Expuesta Politicamente o Incluido en algun Inciso
                PEP.PEPoF = true;
            }
            else
            {//No Soy Persona Expuesta Politicamente ni Incluido en algun Inciso
                PEP.PEPoF = false;
            }

            PEP.NombrePEP = txtNombrePEP.Text.Trim();
            PEP.ApellidoPEP = txtApellidoPEP.Text.Trim();
            //TODO: Probando User Control Documento
            //PEP.TipoDocPEPId = ddlTipoDocPEPId.SelectedIndex;
            //PEP.NroDocPEP = txtNroDocPEP.Text.Trim();
            PEP.TipoDocPEPId = ucDocumentoPEP.propddlTipoDoc;
            PEP.NroDocPEP = ucDocumentoPEP.proptxtNroDoc.Trim();
            PEP.CargoPEP = new TiposCargo(Convert.ToInt32(ddlCargoPEP.SelectedValue)).Acronimo;
            PEP.CargoPEPId = Convert.ToInt32(Convert.ToInt32(ddlCargoPEP.SelectedValue));
            PEP.DomicilioRealPEP = ucDomicilioPEP.proptxtDomicilio.Trim();
            PEP.TipoFiscalPEP = Convert.ToInt32(ucFiscalPEP.propddlTipoFiscal);
            PEP.NroFiscalPEP = ucFiscalPEP.proptxtNroFiscal.Trim();
            PEP.RelacionadoPEP = rblRelacionadoPEP.SelectedValue;
            //PEP.RelacionPEP = txtRelacionPEP.Text.Trim();
            PEP.RelacionPEP = ucVinculoPEP.ToString();
            //PEP.RelacionPEP = ucVinculoPEP.VinculoTexto;
          

            //NUEVAS PROPIEDADES 2023
            if (ucNacionalidad.proptxtNacionalidad.Trim().Length > 0)
            {

                PEP.Nacionalidad = ucNacionalidad.proptxtNacionalidad.Trim();
                PEP.FechaNac = Convert.ToDateTime(ucFechaNac1.Fecha.Trim());
                PEP.Profesion = ucProfesion.proptxtProfesion.Trim();
                PEP.EstadoCivil = Convert.ToInt32(ucEstadoCivil.propddlEstadoCivil);
                PEP.Email = ucEmail.proptxtEmail.Trim();

            }
            
         

            if (PEP.PEPoF == true)
            {
                if (rblRelacionadoPEP.SelectedValue != Convert.ToString((int)EnumDJ.ETipoIncisos.NOINCLUIDO))
                {
                    //Sobrescribo el check y texbox de relacionado
                    PEP.RelacionadoPEP = rblRelacionadoPEP.SelectedValue;
                   // PEP.RelacionPEP = txtRelacionPEP.Text.Trim();

                    //Guardo en propiedades los datos de la Persona Politicamente Expuesta Relacionada
                    PEP.NombrePEPR = txtNombrePEPR.Text.Trim();
                    PEP.ApellidoPEPR = txtApellidoPEPR.Text.Trim();
                    PEP.TipoDocPEPRId = ucDocumentoPEPR.propddlTipoDoc;
                    PEP.NroDocPEPR = ucDocumentoPEPR.proptxtNroDoc.Trim();

                    //Agregado de categorias 02/05/2012-SATART
                    PEP.CategoriaPEP = -1;
                    PEP.SubCategoriaPEP = -1;
                    PEP.CategoriaPEPR = ucCategoriaPEPR.Categoria;
                    PEP.SubCategoriaPEPR = ucCategoriaPEPR.SubCategoria;
                    //Agregado de categorias 02/05/2012-END

                    //PEP.CuitPEPR = txtCuitPEPR.Text.Trim();
                    PEP.TipoFiscalPEPR = Convert.ToInt32(ucFiscalPEPR.propddlTipoFiscal);
                    PEP.NroFiscalPEPR = ucFiscalPEPR.proptxtNroFiscal.Trim();

                    //NUEVAS PROPIEDADES 2023
                    PEP.Nacionalidad = ucNacionalidad1.proptxtNacionalidad.Trim();
                    PEP.FechaNac = Convert.ToDateTime(ucFechaNac2.Fecha.Trim());
                    PEP.Profesion = ucProfesion1.proptxtProfesion.Trim();
                    PEP.Email = ucEmail1.proptxtEmail.Trim();
                }
                else
                {
                    PEP.CategoriaPEP = ucCategoriaPEP.Categoria;
                    PEP.SubCategoriaPEP = ucCategoriaPEP.SubCategoria;


                    PEP.CategoriaPEPR = -1;
                    PEP.SubCategoriaPEPR = -1;
                }
            }

            Session["PersonaEP"] = PEP;
        }


        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.Anterior();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            //Valido todos los controles de la pagina web
            Page.Validate();

            if (!Page.IsValid)
            {
                pnlvalidacion.Visible = true;
                return;
            }

            //if (ValidarCaptcha())
            //{   //Todo bien
            //TODO: Quite el ValidarCaptcha porque ya lo hace el Validation.
            CargarPropiedades();
            CargarCabeceraPPE();
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.Siguiente(); ;
            //}
        }

        /*-- Empieza Funciones del Captcha --*/

        //private bool ValidarCaptcha()
        //{
        //    try
        //    {
        //        if (this.ucCaptchaPersona.proptxtCaptcha.ToUpper() == (String)Session["CaptchaValue"])
        //        {
        //            Session.Remove("CaptchaValue");
        //            //imgAsterisco_Captcha.Visible = false;
        //            this.ucCaptchaPersona.proplblCaptchaErrorVisible = false;

        //            //lblCaptchaErrorvld.Visible = false;

        //            //Si el captcha estubo bien ingresado y no saltaron las validaciones cargo propiedades
        //            //E inserto en la bbdd
        //            CargarPropiedades();
        //            CargarCabeceraPPE();

        //            return true;
        //        }
        //        else
        //        {
        //            //devolver mensaje de error por captcha mal ingresado
        //            Session.Remove("CaptchaValue");
        //            //lblCaptchaError.Visible = true;
        //            this.ucCaptchaPersona.proplblCaptchaErrorVisible = true;

        //            //lblCaptchaErrorvld.Visible = true;
        //            return false;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //protected void btnRecargarCaptcha_Click(object sender, ImageClickEventArgs e)
        //{
        //    Captcha.CreateCaptcha();
        //    //TODO: Implementar un Captcha mas seguro para que no se muestre
        //    //System.Web.UI.Page p = new Page();

        //    imgCaptcha.ImageUrl = Session["captchaUrl"].ToString();
        //}

        /*-- Termina Funciones del Captcha --*/

        //Indique si usted es una Persona Expuesta Políticamente
        protected void rblPEPoF_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Soy Persona Expuesta Politicamente o Incluido en algun Inciso
            if (rblPEPoF.SelectedValue == "1")
            {
                LblTitulo_2.Text = "Datos de la Persona Declarante";

                //RelacionPEP.Visible = true;
                RelacionadoPEP.Visible = true;
                //lblRelacionPEP.CssClass = "lblNoTachado";
                //chkRelacionadoPEP_CheckedChanged(null, null);
                rblRelacionadoPEP.Enabled = true;
                rblRelacionadoPEP_SelectedIndexChanged(null, null);
                //chkRelacionadoPEP.Enabled = true;
                rblRelacionadoPEP.Enabled = true;
                ucCategoriaPEP.Visible = true;
                ucCategoriaPEPR.Visible = true;
                
             
            }
            //NO Soy Persona Expuesta Politicamente ni Incluido en algun Inciso
            else if (rblPEPoF.SelectedValue == "2")
            {
                LblTitulo_2.Text = "Datos de la Persona No Expuesta Pol&iacute;ticamente";

                //RelacionPEP.Visible = false;
                RelacionadoPEP.Visible = false;
                //lblRelacionPEP.CssClass = "lblTachado";
                //chkRelacionadoPEP.Checked = false;                
                rblRelacionadoPEP.SelectedValue = Convert.ToString((int)EnumDJ.ETipoIncisos.NOINCLUIDO);
                //chkRelacionadoPEP_CheckedChanged(null, null);
                rblRelacionadoPEP_SelectedIndexChanged(null, null);
                //chkRelacionadoPEP.Enabled = false;
                rblRelacionadoPEP.Enabled = false;
                ucCategoriaPEP.Visible = false;
                ucCategoriaPEPR.Visible = false;
                ucVinculoPEP.Visible = false;   
            }
        }

        protected void rblRelacionadoPEP_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Si "Indique si usted es una Persona Expuesta Políticamente" esta en "SI"
            if (rblPEPoF.SelectedValue == "1")
            {
                //Soy Persona Expuesta Politicamente, No Incluido, Inciso 'B' o Inciso 'I'
                switch (rblRelacionadoPEP.SelectedItem.Value)
                {
                    case "0": //"No Incluido"

                        pnlwfk_3.Visible = false;
                        pnlwfk_3.Enabled = false;
                        if (rblPEPoF.SelectedValue == "1")
                        {//Soy Persona Expuesta Politicamente o Incluido en algun Inciso
                            LblTitulo_2.Text = "Datos de la Persona Expuesta Pol&iacute;ticamente";
                            ucNacionalidad.Visible = true;
                            ucFechaNac1.Visible = true;
                            ucVinculoPEP.Visible = false; 
                        }
                        else
                        {//NO Soy Persona Expuesta Politicamente ni Incluido en algun Inciso
                            LblTitulo_2.Text = "Datos de la Persona No Expuesta Pol&iacute;ticamente";
                        }
                       // txtRelacionPEP.Enabled = false;
                        //lblRelacionPEP.CssClass = "lblTachado";
                        //cvRelacionPEP.Enabled = false;
                        //cvRelacionPEP.Visible = false;
                        BorrarDatosInciso();
                        pnlvalidacion.Visible = false;


                        ucNacionalidad.Visible = true;
                        ucFechaNac1.Visible = true;
                        ucEmail.Visible = true;
                        ucProfesion.Visible = true;
                        ucFechaNac2.Visible = true;
                        

                        ucCategoriaPEP.Visible = true;
                        break;
                    case "1": //"Inciso F"
                    case "2": //"Inciso B"
                    case "3": //"Inciso I"
                        ucCategoriaPEP.Visible = false;
                        pnlwfk_3.Visible = true;
                        pnlwfk_3.Enabled = true;
                        LblTitulo_2.Text = "Datos de la Persona Declarante";
                        ucVinculoPEP.Visible = true; 
                       // txtRelacionPEP.Enabled = true;
                        //lblRelacionPEP.CssClass = "lblNoTachado";
                        //cvRelacionPEP.Enabled = true;
                        //cvRelacionPEP.Visible = true;
                        BorrarDatosInciso();
                        
                        ucNacionalidad.Visible = false;
                        ucFechaNac1.Visible = false;
                        ucEmail.Visible = false;
                        ucProfesion.Visible = false;
                        //ucFechaNac2.Visible = false;

                        pnlvalidacion.Visible = false;
                        break;
                    default:
                        break;
                }
            }
            //NO Soy Persona Expuesta Politicamente, No Incluido, Inciso 'B' o Inciso 'I'
            else if (rblPEPoF.SelectedValue == "2")
            {
                pnlwfk_3.Visible = false;
                pnlwfk_3.Enabled = false;
                if (rblPEPoF.SelectedValue == "1")
                {//Soy Persona Expuesta Politicamente o Incluido en algun Inciso
                    LblTitulo_2.Text = "Datos de la Persona Expuesta Pol&iacute;ticamente";
                }
                else
                {//NO Soy Persona Expuesta Politicamente ni Incluido en algun Inciso
                    LblTitulo_2.Text = "Datos de la Persona No Expuesta Pol&iacute;ticamente";
                }
                //txtRelacionPEP.Enabled = false;
                //lblRelacionPEP.CssClass = "lblTachado";
                //cvRelacionPEP.Enabled = false;
                //cvRelacionPEP.Visible = false;
                BorrarDatosInciso();
                pnlvalidacion.Visible = false;
            }
        }

        private void BorrarDatosInciso()
        {
            //txtRelacionPEP.Text = "";
            txtNombrePEPR.Text = "";
            txtApellidoPEPR.Text = "";
            ucDocumentoPEPR.proptxtNroDoc = "";
            ucDocumentoPEPR.propddlTipoDoc = (int)EnumDJ.ETipoDoc.SELECCIONAROPCION;
            //txtCuitPEPR.Text = "";
            ucFiscalPEPR.proptxtNroFiscal = "";
            ucFiscalPEPR.propddlTipoFiscal = (int)EnumDJ.ETipoDoc.SELECCIONAROPCION;
        }

        protected void CustomValidator_Standar(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }

        protected void btnConfirmar_Click(object sender, ImageClickEventArgs e)
        {
            //Valido todos los controles de la pagina web
            Page.Validate();

            if (!Page.IsValid)
            {
                pnlvalidacion.Visible = true;
                return;
            }

            //TODO: Quite el ValidarCaptcha porque ya lo hace el Validation.
            CargarPropiedades();
            CargarCabeceraPPE();
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.Siguiente();
        }


    }
}
