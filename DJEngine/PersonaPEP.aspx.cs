using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DJEngine.DataAccess.Tipos;
using System.Web.UI.HtmlControls;
using DJEngine.Business;
using System.Text.RegularExpressions;
using DJEngine.UsoGeneral;

namespace DJEngine.WebEntities
{
    public partial class PersonaPEP : System.Web.UI.Page
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
                //Cambio los titulos segun el tipo de DJ
                if (d.TipoDJ_Id == Convert.ToInt32(EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE_ESCRIBANOS))
                {
                    lblHeader_1.Text = "Indique si el declarante es una Persona Expuesta Políticamente";
                    lblHeader_1b.Text = "Indique si está incluido en los Incisos \"B\" o \"I\"";
                }
                else if (d.TipoDJ_Id == Convert.ToInt32(EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE_REPRESENTANTE))
                {
                    lblHeader_1.Text = "Indique si el interesado es una Persona Expuesta Políticamente";
                    lblHeader_1b.Text = "Indique si el interesado está incluido en los Incisos \"B\" o \"I\"";
                }
                //else if (d.TipoDJ_Id == Convert.ToInt32(EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE_FIDEICOMISO_FISICA))
                //{
                //    lblHeader_1.Text = "Indique si usted es una Persona Expuesta Políticamente";
                //    lblHeader_1b.Text = "Indique si usted está incluido en los Incisos \"B\" o \"I\"";
                //    //Deshabilito el combo de cargo para Fideicomiso, para que solo se pueda seleccionar Fiduciario
                //    //ddlCargoPEP.SelectedValue = "24";
                //    //ddlCargoPEP.Items.RemoveAt(0);
                //    //ddlCargoPEP.Enabled = false;
                //}
                else
                {
                    lblHeader_1.Text = "Indique si usted es una Persona Expuesta Políticamente";
                    lblHeader_1b.Text = "Indique si usted está incluido en los Incisos \"B\" o \"I\"";
                }
                   
                pnlvalidacion.Visible = false;

                Session["PersonaPEP"] = null;

                //Oculto mensaje de error del captcha
                this.ucCaptchaPersona.proplblCaptchaErrorVisible = false;

                //Cargo los combos de Cargo para el tipo societario de la entidad
                this.ucCargoPEP.propTipoSocId = Ent.TipoSocId;
                this.ucCargoPEP.propTipoDJId = d.TipoDJ_Id;
                this.ucCargoPPR.propTipoSocId = Ent.TipoSocId;
                this.ucCargoPPR.propTipoDJId = d.TipoDJ_Id;

                lblRelacionPPRPEP.CssClass = "lblTachado";

                //Muestro datos referenciales de la Entidad
                MostrarDatosEntidad();
            }
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
            //Oculto Labels y Textbox de Datos Referenciales
            lblEntidad.Visible = false;
            lblTipoSocietario.Visible = false;
            lblNroCorrelativo.Visible = false;
            txtEntidad.Visible = false;
            txtTipoSocietario.Visible = false;
            txtNroCorrelativo.Visible = false;

            if (Ent.Constituida == true)
            {
                //Si esta constituida muestro de la entidad
                //Denominacion, TipoSocietario y NroCorrelativo
                lblEntidad.Visible = true;
                lblTipoSocietario.Visible = true;
                lblNroCorrelativo.Visible = true;
                txtEntidad.Visible = true;
                txtTipoSocietario.Visible = true;
                txtNroCorrelativo.Visible = true;

                txtEntidad.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(Convert.ToString(Ent.RazonSocial), 1);
                if (txtEntidad.Text.Length >= 40)
                txtEntidad.Text = txtEntidad.Text.Substring(0, 40) + "...";

                //Lo estoy llenando pero no lo muestro ni lo uso
                //txtCuitEnt.Text = Ent.Cuit.ToString();
                txtTipoSocietario.Text = new TiposSocietario(Ent.TipoSocId).Descripcion ;                
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

        protected void CargarPropiedades()
        {
            //Guardo en propiedades los datos de la Persona Politicamente Expuesta
            DJEngine.Business.PersonaPEP PEP = new DJEngine.Business.PersonaPEP();
            
            if (Convert.ToInt32(rblPEPoNO.SelectedValue) == 1)
            {//Es una Persona Expuesta Politicamente o Incluido en algun Inciso
                PEP.PEPoNO = true;
            }
            else
            {//No es una Persona Expuesta Politicamente ni Incluido en algun Inciso
                PEP.PEPoNO = false; 
            }

            PEP.TipoInciso = rblIncisos.SelectedValue;

            //Guardo en propiedades los datos de la Persona Politicamente Expuesta
            PEP.NombrePEP = txtNombrePEP.Text.Trim();
            PEP.ApellidoPEP = txtApellidoPEP.Text.Trim();
            PEP.TipoDocPEPId = ucDocumentoPEP.propddlTipoDoc;
            PEP.NroDocPEP = ucDocumentoPEP.proptxtNroDoc.Trim();
            PEP.TipoFiscalPEP = Convert.ToInt32(ucFiscalPEP.propddlTipoFiscal);
            PEP.NroFiscalPEP = ucFiscalPEP.proptxtNroFiscal.Trim();
            PEP.CategoriaPEP = ucCategoriaPEP.Categoria;
            PEP.SubCategoriaPEP = ucCategoriaPEP.SubCategoria; 
            PEP.CargoPEP = new TiposCargo(ucCargoPEP.Cargo).Acronimo.ToUpper();
            PEP.CargoPEPId = ucCargoPEP.Cargo;
            PEP.DomicilioRealPEP = ucDomicilioRealPEP.proptxtDomicilio.Trim();



            //NUEVAS PROPIEDADES 2023
            PEP.Nacionalidad = ucNacionalidad.proptxtNacionalidad.Trim();
            PEP.FechaNac = Convert.ToDateTime(ucFechaNac1.Fecha.Trim());
            PEP.Profesion = ucProfesion.proptxtProfesion.Trim();
            PEP.EstadoCivil = Convert.ToInt32(ucEstadoCivil.propddlEstadoCivil);
            PEP.Email = ucEmail.proptxtEmail.Trim();


            //PEP.RelacionadoPEP = rblIncisos.SelectedValue;            
            //PEP.RelacionPPRPEP = null;
            PEP.RelacionPPRPEP = ucVinculoPEP.ToString();
            //PEP.RelacionPPRPEP = txtRelacionPPRPEP.Text.Trim();
            
            

            //Guardo en propiedades los datos de la Persona Politicamente Expuesta Relacionada
            PEP.NombrePPR = txtNombrePPR.Text.Trim();
            PEP.ApellidoPPR = txtApellidoPPR.Text.Trim();
            PEP.TipoDocPPRId = ucDocumentoPPR.propddlTipoDoc;
            PEP.NroDocPPR = ucDocumentoPPR.proptxtNroDoc.Trim();
            PEP.TipoFiscalPPR = Convert.ToInt32(ucFiscalPPR.propddlTipoFiscal);
            PEP.NroFiscalPPR = ucFiscalPPR.proptxtNroFiscal.Trim();
            PEP.CategoriaPPR = ucCategoriaPPR.Categoria;
            PEP.SubCategoriaPPR = ucCategoriaPPR.SubCategoria;
            PEP.CargoPPR = new TiposCargo(ucCargoPPR.Cargo).Acronimo; ;
            PEP.CargoPPRId = ucCargoPEP.Cargo;
            PEP.DomicilioRealPPR = ucDomicilioRealPPR.proptxtDomicilio.Trim();


            //NUEVAS PROPIEDADES 2023
            if (ucNacionalidad.proptxtNacionalidad.Trim().Length > 0)
            //{

            //    PEP.Nacionalidad = ucNacionalidad.proptxtNacionalidad.Trim();
            //    PEP.FechaNac = Convert.ToDateTime(ucFechaNac1.Fecha.Trim());
            //    PEP.Profesion = ucProfesion.proptxtProfesion.Trim();
            //    PEP.EstadoCivil = Convert.ToInt32(ucEstadoCivil.propddlEstadoCivil);
            //    PEP.Email = ucEmail.proptxtEmail.Trim();

            //}

            
            Session["PersonaPEP"] = PEP;
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

            CargarPropiedades();
            CargarCabecera();
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.Siguiente();
        }

        //Indique si usted es una Persona Expuesta Políticamente
        protected void rblPEPoNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Si es una Persona Expuesta Politicamente o Incluido en algun Inciso
            if (rblPEPoNO.SelectedValue == "1")
            {
                //Muestro el Div donde se seleccionan los Incisos
                divIncisos.Visible = true;

                //Muestro el TR de la Relacion con el PEP y destacho el label
                trRelacionPPRPEP.Visible = true;
                lblRelacionPPRPEP.CssClass = "lblNoTachado";

                //Habilito Radio List Button de Incisos como No Incluido y lo recargo
                rblIncisos.Enabled = true;
                rblIncisos_SelectedIndexChanged(null, null);
                rblIncisos.Enabled = true;

                //ucCategoriaPEP.Visible = true;
                //ucCategoriaPPR.Visible = true;
            }
            //NO es una Persona Expuesta Politicamente ni Incluido en algun Inciso
            else if (rblPEPoNO.SelectedValue == "2") 
            {
                //Cambio el titulo del pnlwfk_PEP si NO es PEP
                LblTitulo_PEP.Text = "Datos de la Persona No Expuesta Pol&iacute;ticamente";

                //Oculto el Div donde se seleccionan los Incisos
                divIncisos.Visible = false;

                //Oculto el TR de la Relacion con el PEP y tacho el label
                trRelacionPPRPEP.Visible = false;                
                lblRelacionPPRPEP.CssClass = "lblTachado";

                //Harcodeo el valor del Radio List Button de Incisos como No Incluido, lo recargo y lo deshabilito
                rblIncisos.SelectedValue = Convert.ToString((int)EnumDJ.ETipoIncisos.NOINCLUIDO);
                rblIncisos_SelectedIndexChanged(null, null);
                rblIncisos.Enabled = false;

                //ucCategoriaPEP.Visible = false;
                //ucCategoriaPPR.Visible = false;
            }
        }

        //Indique si usted esta incluido en los Incisos B o I
        protected void rblIncisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Si "Indique si usted es una Persona Expuesta Políticamente" esta en "SI"
            if (rblPEPoNO.SelectedValue == "1")
            {
                //Soy Persona Expuesta Politicamente, No Incluido, Inciso 'B' o Inciso 'I'
                switch (rblIncisos.SelectedItem.Value)
                {
                    case "0": //"No Incluido"
                        //Oculto y deshabilito el Panel de Formulario PPR
                        pnlwfk_PPR.Visible = false;
                        pnlwfk_PPR.Enabled = false;
                        //Cambio el titulo porque es una Persona Expuesta Politicamente
                        LblTitulo_PEP.Text = "Datos de la Persona Expuesta Pol&iacute;ticamente";
                        //Muestro el Combo "Inciso Resolución 11/2011" para PEP
                        ucCategoriaPEP.Visible = true;
                        ucCategoriaPEP.ReiniciarCombos();
                        //Muestro el Combo "Cargo en la Entidad" para PEP
                        ucCargoPEP.Visible = true;
                        //Muestro el Combo "Domicilio Real" para PEP
                        ucDomicilioRealPEP.Visible = true;
                        //Tacho y deshabilito la relacion porque es PEP
                        ucVinculoPEP.Visible = false;
                       
                        //txtRelacionPPRPEP.Enabled = false;
                        //lblRelacionPPRPEP.CssClass = "lblTachado";
                        //cvRelacionPPRPEP.Enabled = false;
                        //cvRelacionPPRPEP.Visible = false;
                        BorrarDatosPPR();
                        pnlvalidacion.Visible = false;
                        break;
                    case "1": //"Inciso F" //No se usa
                    case "2": //"Inciso B"
                    case "3": //"Inciso I"
                        //No Muestro el Combo "Inciso Resolución 11/2011"
                        //ucCategoriaPEP.Visible = false;
                        //Muestro y Habilito el Panel de Formulario PEP Incisos
                        pnlwfk_PPR.Visible = true;
                        pnlwfk_PPR.Enabled = true;
                        ////Cambio el titulo
                        //LblTitulo_PEP.Text = "Datos de la Persona Declarante";
                        //Muestro el Combo "Inciso Resolución 11/2011" para PEP y lo oculto para PPR
                        ucCategoriaPEP.Visible = true;
                        ucCategoriaPEP.ReiniciarCombos();
                        ucCategoriaPPR.Visible = false;
                        //Muestro el Combo "Cargo en la Entidad" para PPR y lo oculto para PEP
                        ucCargoPEP.Visible = false;
                        ucCargoPPR.Visible = true;
                        //Muestro el Combo "Domicilio Real" para PPR y lo oculto para PEP
                        ucDomicilioRealPEP.Visible = false;
                        ucDomicilioRealPPR.Visible = true;
                        //Destacho y habilito la relacion porque no es PEP o NoPEP
                        ucVinculoPEP.Visible = true;
                     
                        //txtRelacionPPRPEP.Enabled = true;
                        //lblRelacionPPRPEP.CssClass = "lblNoTachado";
                        //cvRelacionPPRPEP.Enabled = true;
                        //cvRelacionPPRPEP.Visible = true;
                        //Reinicio y Borro los Datos de la Persona Relacionada
                        BorrarDatosPPR();
                        pnlvalidacion.Visible = false;
                        break;
                }
            }
            //NO Soy Persona Expuesta Politicamente, No Incluido, Inciso 'B' o Inciso 'I'
            else if (rblPEPoNO.SelectedValue == "2")
            {
                //Oculto y deshabilito el Panel de Formulario PPR
                pnlwfk_PPR.Visible = false;
                pnlwfk_PPR.Enabled = false;
                //Cambio el titulo porque NO es una Persona Expuesta Politicamente ni Incluido en algun Inciso
                LblTitulo_PEP.Text = "Datos de la Persona No Expuesta Pol&iacute;ticamente";
                //Oculto el Combo "Inciso Resolución 11/2011" para PEP
                ucCategoriaPEP.ReiniciarCombos();
                ucCategoriaPEP.Visible = false;                
                //Muestro el Combo "Cargo en la Entidad" para PEP
                ucCargoPEP.Visible = true;
                //Tacho y deshabilito la relacion porque es NoPEP
               
               
                ucVinculoPEP.Visible = false;    
                //txtRelacionPPRPEP.Enabled = false;
                //lblRelacionPPRPEP.CssClass = "lblTachado";
                //cvRelacionPPRPEP.Enabled = false;
                //cvRelacionPPRPEP.Visible = false;
                //Reinicio y Borro los Datos de la Persona Relacionada
                BorrarDatosPPR();
                pnlvalidacion.Visible = false;
            }
        }

        //Reinicio y Borro los Datos de la Persona Relacionada
        private void BorrarDatosPPR()
        {            
            txtNombrePPR.Text = "";
            txtApellidoPPR.Text = "";
            ucDocumentoPPR.proptxtNroDoc = "";
            ucDocumentoPPR.propddlTipoDoc = (int)EnumDJ.ETipoDoc.SELECCIONAROPCION;
            ucFiscalPPR.proptxtNroFiscal = "";
            ucFiscalPPR.propddlTipoFiscal = (int)EnumDJ.ETipoDoc.SELECCIONAROPCION;
            ucCategoriaPPR.ReiniciarCombos();
            ucCargoPPR.propddlCargo = (int)EnumDJ.ETipoDoc.SELECCIONAROPCION;
            //txtRelacionPPRPEP.Text = "";
            ucVinculoPEP.Vinculo= (int)EnumDJ.ETipoDoc.SELECCIONAROPCION;;
           
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

            CargarPropiedades();
            CargarCabecera();
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.Siguiente();
        }


    }
}
