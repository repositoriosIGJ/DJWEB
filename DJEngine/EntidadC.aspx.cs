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
    public partial class EntidadC : System.Web.UI.Page
    {
        private WSIGJGeneric.Entidad WsEnt = new DJEngine.WSIGJGeneric.Entidad();

        protected void Page_Load(object sender, EventArgs e)
        {
            //LoadCss();
            Page.MaintainScrollPositionOnPostBack = true;

            DJAbstract d = (DJAbstract)Session["DJ"];

            //Valida que la pagina fuera la correcta
            d.WorkFlow.WorkFlowValidate(Page);

            Session["captchaValidate"] = "1";

            if (Session["wsEntidad"] != null)
            {
                this.WsEnt = (DJEngine.WSIGJGeneric.Entidad)Session["wsEntidad"];
            }

            if (!IsPostBack)
            {
                try
                {
                    MostrarBusqueda(true);
                    //rblBusqueda.SelectedIndex = 0;
                    //rblBusqueda_SelectedIndexChanged(null, null);
                    

                    //Pregunto si se trata de la DJ11 para deshabilitar combo de tipo societario en SAS
                    if (d.TipoDJ_Id == (int)EnumDJ.EDDJJ.PRESENTACION_BALANCES_SAS)
                    {
                        CargarCombos(true, d.TipoDJ_Id);
                    }
                    else
                    {
                        CargarCombos(false, d.TipoDJ_Id);
                    }

                    Session["DatosEntidad"] = null;
                    Session["Entidad"] = null;
                    Session["captchaValue"] = null;
                    Session["captchaValidate"] = "1";

                    //Cambio Label Domicilio Real por Sede Social
                    ucDomicilioRealN.proplblDomicilio = "Sede Social";
                    ucDomicilioRealC.proplblDomicilio = "Sede Social";
                    ucCUITN.propCUITEnabled = false;

                    //Oculta Captcha para Desarrollo
                    if (Session["CaptchaHabilitado"] != null)
                    {
                        if ((bool)Session["CaptchaHabilitado"] == false)
                        {
                            this.ucCaptchaEntidad.Visible = false;
                            this.ucCaptchaEntidad_CUIT.Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("No pudo cargar el combo Tipo Societario:" + ex.Message);
                }
            }
        }

        private void CargarCombos(bool solosas, int tipodj)
        {
            if (solosas)
            {
                ddlTipoDeEntidadConstituida_CUIT.DataSource = new TiposSocietario().getTipoSocietarioFiltradoSinSel(tipodj);
                ddlTipoDeEntidadConstituida_CUIT.DataBind();
                ddlTipoDeEntidadConstituida_CUIT.Enabled = false;

                ddlTipoDeEntidadConstituida.DataSource = new TiposSocietario().getTipoSocietarioFiltradoSinSel(tipodj);
                ddlTipoDeEntidadConstituida.DataBind();
                ddlTipoDeEntidadConstituida.Enabled = false;
            }
            else
            {
                ddlTipoDeEntidadConstituida_CUIT.DataSource = new TiposSocietario().getTipoSocietarioFiltrado(tipodj);
                ddlTipoDeEntidadConstituida_CUIT.DataBind();
                ddlTipoDeEntidadConstituida_CUIT.Enabled = true;

                ddlTipoDeEntidadConstituida.DataSource = new TiposSocietario().getTipoSocietarioFiltrado(tipodj);
                ddlTipoDeEntidadConstituida.DataBind();
                ddlTipoDeEntidadConstituida.Enabled = true;
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

        protected void CargarPropiedades(WSIGJGeneric.Entidad WsEnt, string TipoBusqueda)
        {
            Business.Entidad Ent = new Business.Entidad();

            Ent.Constituida = true;
            Ent.RazonSocial = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.RazonSocial, 1);            
            Ent.NroCorrelativo = WsEnt.NroCorrelativo;
            Ent.TipoSocId = WsEnt.TipoSocId;
            Ent.TipoSocDesc = new TiposSocietario(Ent.TipoSocId).Descripcion;
            if (TipoBusqueda == "N")
            {
                Ent.SedeSocial = ucDomicilioRealN.proptxtDomicilio;
                //Pregunta si no trajo el cuit de la base
                if (WsEnt.Cuit == "")
                {
                    Ent.Cuit = ucCUITN.proptxtCUIT;
                }
                else
                {
                    Ent.Cuit = WsEnt.Cuit;
                }
            }
            else
            {
                Ent.SedeSocial = ucDomicilioRealC.proptxtDomicilio;
                Ent.Cuit = WsEnt.Cuit;
            }

            Session["Entidad"] = Ent;
        }

        //protected void CargarPropiedades()
        //{
        //    Business.Entidad Ent = new Business.Entidad();

        //    //Busqueda por Nro Correlativo
        //    if (Convert.ToInt32(rblBusqueda.SelectedValue) == 1)
        //    {
        //        Ent.Constituida = true;
        //        Ent.RazonSocial = CharacterTreat.ConvertirPrimeraLetraMayuscula(Convert.ToString(txtEntidadC.Text.Trim()), 1);
        //        Ent.Cuit = txtCUITref.Text.Trim();
        //        Ent.NroCorrelativo = Convert.ToInt32(txtNroCorrelativo.Text.Trim());
        //        Ent.TipoSocId = Convert.ToInt32(ddlTipoDeEntidadConstituida.SelectedValue);
        //        Ent.TipoSocDesc = new TiposSocietario(Ent.TipoSocId).Descripcion;
        //        Ent.SedeSocial = ucDomicilioRealN.proptxtDomicilio;

        //        Session["Entidad"] = Ent;
        //    }
        //    else //Busqueda por Nro de CUIT
        //    {
        //        Ent.Constituida = true;
        //        Ent.RazonSocial = CharacterTreat.ConvertirPrimeraLetraMayuscula(Convert.ToString(txtEntidadC.Text.Trim()), 1);
        //        Ent.Cuit = txtCUIT.Text.Trim();
        //        //De donde lo saco?
        //        Ent.NroCorrelativo = null;
        //        Ent.TipoSocId = Convert.ToInt32(ddlTipoDeEntidadConstituida_CUIT.SelectedValue);
        //        Ent.TipoSocDesc = new TiposSocietario(Ent.TipoSocId).Descripcion;
        //        Ent.SedeSocial = ucDomicilioRealC.proptxtDomicilio;

        //        Session["Entidad"] = Ent;
        //    }
        //}

        protected void btnBuscarNroCorrOtra_Click(object sender, EventArgs e)
        {
            ucCaptchaEntidad.propCaptchaEnabled = true;
            Session["captchaValue"] = null;
            Session["CaptchaValidate"] = null;

            MostrarBusqueda(true);
        }

        protected void btnBuscarNroCUITOtra_Click(object sender, EventArgs e)
        {
            ucCaptchaEntidad_CUIT.propCaptchaEnabled = true;
            Session["captchaValue"] = null;
            Session["CaptchaValidate"] = null;

            MostrarBusqueda(false);
        }

        protected void btnBuscarNroCorr_Click(object sender, EventArgs e)
        {
            //Entidad Ent = new Entidad();
            DJEngine.WSIGJGeneric.IGJ_Generic wsGeneric = new DJEngine.WSIGJGeneric.IGJ_Generic();

            Page.Validate();

            if (Page.IsValid)
            {
                WsEnt = wsGeneric.GetSociedadPOO(Convert.ToInt32(txtNroCorrelativo.Text.Trim()));

                Session["WsEntidad"] = WsEnt;

                //Pregunto si Existe una Entidad Constituida para ese Nro Correlativo
                if (WsEnt != null)
                {
                    //Pregunto si el Tipo Societario de la base es igual al que eligio el usuario en el combo
                    if (WsEnt.TipoSocId == Convert.ToInt32(ddlTipoDeEntidadConstituida.SelectedValue))
                    {
                        //Pregunta si no trajo el CUIT de la base
                        if (WsEnt.Cuit.Trim() == "")
                        {
                            if (ucCUITN.proptxtCUIT.Trim() == "")
                            {
                                divcuitentidad.Visible = true;
                                ucCUITN.propCUITEnabled = true;
                            }
                            else
                            {
                                WsEnt.Cuit = ucCUITN.proptxtCUIT.Trim();
                                divcuitentidad.Visible = false;
                                ucCUITN.propCUITEnabled = false;

                                //?
                                if (txtEntidadC.Text.Trim() != "" && txtTipoSocietario.Text.Trim() != "" && ucDomicilioRealN.proptxtDomicilio != "")
                                {
                                    ucCaptchaEntidad.btnRecargarCaptcha_Click(null, null);
                                }
                            }

                            //Cargo las propiedades en sesion cada vez que busco por numero correlativo para no perder todos los datos
                            //CargarPropiedades(WsEnt, "N");

                            cvNoExisteNroCorr.IsValid = true;
                            pnlvalidacion.Visible = false;
                            //Muestra los datos de la Entidad deshabilitados antes de continuar
                            MostrarDatosRefEntidad("N", true);
                            LoadDatosRef(WsEnt, "N");
                            
                        }
                        else
                        {
                            if (txtEntidadC.Text.Trim() != "" && txtTipoSocietario.Text.Trim() != "" && ucDomicilioRealN.proptxtDomicilio != "")
                            {
                                ucCaptchaEntidad.btnRecargarCaptcha_Click(null, null);
                            }
                            cvNoExisteNroCorr.IsValid = true;
                            pnlvalidacion.Visible = false;
                            MostrarDatosRefEntidad("N", true);
                            LoadDatosRef(WsEnt, "N");
                            //Cargo las propiedades en sesion cada vez que busco por numero correlativo para no perder todos los datos
                            //CargarPropiedades(WsEnt, "N");
                        }
                    }
                    else
                    {
                        cvTipoDeEntidadConstituida.IsValid = false;
                        pnlvalidacion.Visible = true;
                        string ErrorTipoDeEntidad = "El Tipo Societario no se corresponde al N&uacute;mero Correlativo ingresado";
                        cvTipoDeEntidadConstituida.ErrorMessage = "[" + "TIPO DE ENTIDAD" + "] " + ErrorTipoDeEntidad + "&nbsp;";
                        cvTipoDeEntidadConstituida.Text = "x";
                        MostrarDatosRefEntidad("N", false);
                        //Vuelve a ocultarse el div de pedido de CUIT
                        divcuitentidad.Visible = false;
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
                    MostrarDatosRefEntidad("N", false);
                }
            }
            else
            {
                cvNoExisteNroCorr.IsValid = true;
                //cvTipoDeEntidadConstituida.IsValid = true;
                pnlvalidacion.Visible = true;
                divdatosentidad.Visible = false;
                txtEntidadC.Text = "";
                txtTipoSocietario.Text = "";
                txtCUITref.Text = "";
            }
        }

        //Muestra los datos de la Entidad deshabilitados antes de continuar
        public void MostrarDatosRefEntidad(string busqueda, bool habilitado)
        {
            if (busqueda == "N")
            {
                //Muestra Sede Social arriba de los datos referenciales
                //ucDomicilioRealN.proptxtDomicilioEnabled = !habilitado; //false;
                divdatosextra.Visible = habilitado; //true

                txtNroCorrelativo.Enabled = !habilitado; //false;                
                ddlTipoDeEntidadConstituida.Enabled = !habilitado; //false;
                ddlTipoDeEntidadConstituida.Visible = !habilitado; //false;             
                //divcuitentidad.Visible = !habilitado; //false;
                divdatosentidad.Visible = habilitado; //true;                
                divTipoDeEntidadC.Visible = !habilitado; //false;
                divcaptchaentidad.Visible = !habilitado; //false;
                MostrarContinuar(habilitado); //true

                //Borra datos referenciales
                if (habilitado == false)
                {
                    txtEntidadC.Text = "";
                    txtTipoSocietario.Text = "";
                    ucCUITN.proptxtCUIT = "";
                    ucDomicilioRealN.proptxtDomicilio = "";
                }
            }
            else if (busqueda == "C")
            {
                //Muestra Sede Social arriba de los datos referenciales
                //ucDomicilioRealC.proptxtDomicilioEnabled = !habilitado; //false;
                divdatosextra_CUIT.Visible = habilitado; //true

                //Datos Referenciales
                txtCUIT.Enabled = !habilitado; //false;                
                ddlTipoDeEntidadConstituida_CUIT.Enabled = !habilitado; //false;
                ddlTipoDeEntidadConstituida_CUIT.Visible = !habilitado; //false;
                divdatosentidad_CUIT.Visible = habilitado; //true;
                divTipoDeEntidadC_CUIT.Visible = !habilitado; //false;
                divcaptchaentidad_CUIT.Visible = !habilitado; //false;
                MostrarContinuar(habilitado); //true
                //Borra datos referenciales
                if (habilitado == false)
                {
                    txtEntidadC_CUIT.Text = "";
                    txtTipoSocietario_CUIT.Text = "";
                    ucDomicilioRealC.proptxtDomicilio = "";
                }
            }
        }

        protected void btnBuscarNroCuit_Click(object sender, EventArgs e)
        {
            Entidad Ent = new Entidad();

            DJEngine.WSIGJGeneric.IGJ_Generic wsGeneric = new DJEngine.WSIGJGeneric.IGJ_Generic();

            Page.Validate();

            if (Page.IsValid)
            {
                WsEnt = wsGeneric.GetSociedadbyCUIT(Convert.ToInt64(txtCUIT.Text.Trim()));

                Session["WsEntidad"] = WsEnt;

                //Pregunto si Existe una Entidad Constituida para ese CUIT
                if (WsEnt != null)
                {
                    //Pregunto si el Tipo Societario de la base es igual al que eligio el usuario en el combo
                    if (WsEnt.TipoSocId == Convert.ToInt32(ddlTipoDeEntidadConstituida_CUIT.SelectedValue))
                    {
                        //Cargo las propiedades en sesion cada vez que busco por cuit para no perder todos los datos
                        //CargarPropiedades(WsEnt, "C");

                        if (txtEntidadC_CUIT.Text.Trim() != "" && txtTipoSocietario_CUIT.Text.Trim() != "" && ucDomicilioRealC.proptxtDomicilio != "")
                        {
                            ucCaptchaEntidad_CUIT.btnRecargarCaptcha_Click(null, null);
                        }

                        cvNoExisteCUIT.IsValid = true;
                        pnlvalidacion.Visible = false;
                        //Carga los datos referenciales de la entidad
                        MostrarDatosRefEntidad("C", true);
                        LoadDatosRef(WsEnt, "C");
                    }
                    else
                    {
                        cvTipoDeEntidadConstituida_CUIT.IsValid = false;
                        pnlvalidacion.Visible = true;
                        string ErrorTipoDeEntidad = "El Tipo Societario no se corresponde al N&uacute;mero de CUIT ingresado";
                        cvTipoDeEntidadConstituida_CUIT.ErrorMessage = "[" + "TIPO DE ENTIDAD" + "] " + ErrorTipoDeEntidad + "&nbsp;";
                        cvTipoDeEntidadConstituida_CUIT.Text = "x";
                        MostrarDatosRefEntidad("C", false);
                    }
                }
                else
                {
                    cvNoExisteCUIT.IsValid = false;
                    string ErrorCUIT = "El N&uacute;mero de CUIT no se corresponde a una Entidad existente";
                    cvNoExisteCUIT.ErrorMessage = "[" + "NUMERO DE CUIT" + "] " + ErrorCUIT + "&nbsp;";
                    cvNoExisteCUIT.Text = "x";
                    pnlvalidacion.Visible = true;
                }
            }
            else
            {
                cvNoExisteCUIT.IsValid = true;
                //cvTipoDeEntidadConstituida_CUIT.IsValid = true;
                pnlvalidacion.Visible = true;
                divdatosentidad_CUIT.Visible = false;
                txtEntidadC_CUIT.Text = "";
                txtTipoSocietario_CUIT.Text = "";
            }
        }

        //Carga los Datos Referenciales
        public void LoadDatosRef(WSIGJGeneric.Entidad WsEnt, string Busqueda)
        {
            if (Busqueda == "N")
            {
                //Ingreso la Razon Social de la Entidad Entera en el textbox
                txtEntidadC.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.RazonSocial, 1);

                //Pregunto si la Razon Social de la Entidad Entera tiene un largo mayor a 22 caracteres para recortarla
                if (txtEntidadC.Text.Length > 40)
                {
                    txtEntidadC.Text = txtEntidadC.Text.Substring(0, 40) + "...";
                }

                txtTipoSocietario_CUIT.Text = new TiposSocietario(WsEnt.TipoSocId).Descripcion;

                //Ingreso el tipo societario entero en el textbox
                //txtTipoSocietario.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.TipoSoc, 1);
                txtTipoSocietario.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(new TiposSocietario(WsEnt.TipoSocId).Descripcion, 1);

                //Muestra Cuit de la Entidad
                //Si no encontro cuit no se muestra como dato referencial
                if (WsEnt.Cuit != "")
                {
                    divCUITref.Visible = true;
                    txtCUITref.Text = WsEnt.Cuit;
                }
                else
                {
                    divCUITref.Visible = false;
                    txtCUITref.Text = "";
                }
            }
            else if (Busqueda == "C")
            {
                //Ingreso la Razon Social de la Entidad Entera en el textbox
                txtEntidadC_CUIT.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.RazonSocial, 1);

                //Pregunto si la Razon Social de la Entidad Entera tiene un largo mayor a 22 caracteres para recortarla
                if (txtEntidadC_CUIT.Text.Length > 40)
                {
                    txtEntidadC_CUIT.Text = txtEntidadC_CUIT.Text.Substring(0, 40) + "...";
                }

                //Ingreso el tipo societario entero en el textbox
                //txtTipoSocietario_CUIT.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(WsEnt.TipoSoc, 1);
                txtTipoSocietario_CUIT.Text = CharacterTreat.ConvertirPrimeraLetraMayuscula(new TiposSocietario(WsEnt.TipoSocId).Descripcion, 1);
            }
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

            DDJJ DJ = (DDJJ)Session["DatosEntidad"];
            Business.Entidad Ent = (Business.Entidad)Session["Entidad"];

            DJAbstract d = (DJAbstract)Session["DJ"];

            if (rblBusqueda.SelectedIndex == 0)
            {
                //Cargo las propiedades en sesion cada vez que busco por numero correlativo para no perder todos los datos
                CargarPropiedades(WsEnt, "N");

                //Busqueda por Numero Correlativo
                if (txtNroCorrelativo.Text != "" && txtEntidadC.Text != "" && txtTipoSocietario.Text != "" && ucDomicilioRealN.proptxtDomicilio != "")
                {
                    //CargarPropiedades();
                    d.WorkFlow.Siguiente();
                }
                else
                {
                    d.WorkFlow.Refrescar();
                }
            }
            else
            {
                //Cargo las propiedades en sesion cada vez que busco por CUIT para no perder todos los datos
                CargarPropiedades(WsEnt, "C");

                //Busqueda por CUIT
                if (txtCUIT.Text != "" && txtEntidadC_CUIT.Text != "" && txtTipoSocietario_CUIT.Text != "" && ucDomicilioRealC.proptxtDomicilio != "")
                {
                    //CargarPropiedades();
                    d.WorkFlow.Siguiente();
                }
                else
                {
                    d.WorkFlow.Refrescar();
                }
            }
        }

        protected void rblBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblBusqueda.SelectedIndex == 0)
            {//Busqueda por Nro Correlativo
                MostrarBusqueda(true);
            }
            else
            {//Busqueda por Nro CUIT
                MostrarBusqueda(false);
            }
        }

        public void MostrarBusqueda(bool porNroCorr)
        {
            bool solosas = false;
            DJAbstract d = (DJAbstract)Session["DJ"];
            //Pregunto si se trata de la DJ11 para deshabilitar combo de tipo societario en SAS
            if (d.TipoDJ_Id == (int)EnumDJ.EDDJJ.PRESENTACION_BALANCES_SAS)
            {
                solosas = true;
            }

            if (porNroCorr)
            {//Busqueda por Nro Correlativo
                pnlwfk_2.Visible = true;
                pnlwfk_3.Visible = false;

                pnlvalidacion.Visible = false;
                ucCaptchaEntidad.btnRecargarCaptcha_Click(null, null);
                txtNroCorrelativo.Text = "";
                txtNroCorrelativo.Enabled = true;

                //Pedido de Sede Social y/o nro de CUIT
                divdatosextra.Visible = false;
                ucDomicilioRealN.proptxtDomicilio = "";
                //ucDomicilioRealN.proptxtDomicilioEnabled = false;
                divcuitentidad.Visible = false;
                ucCUITN.proptxtCUIT = "";
                //ucCUITN.propCUITEnabled = false;

                //Si es dj11 deshabilita el combo
                if (solosas)
                {
                    ddlTipoDeEntidadConstituida.Enabled = false;
                }
                else
                {
                    ddlTipoDeEntidadConstituida.Enabled = true;
                }
                ddlTipoDeEntidadConstituida.Visible = true;
                ddlTipoDeEntidadConstituida.SelectedIndex = -1;
                divcuitentidad.Visible = false;
                divdatosentidad.Visible = false;
                divTipoDeEntidadC.Visible = true;
                divcaptchaentidad.Visible = true;
                txtEntidadC.Text = "";
                txtTipoSocietario.Text = "";
                txtCUITref.Text = "";
                MostrarContinuar(false);
            }
            else
            {//Busqueda por CUIT
                pnlwfk_2.Visible = false;
                pnlwfk_3.Visible = true;

                pnlvalidacion.Visible = false;
                ucCaptchaEntidad_CUIT.btnRecargarCaptcha_Click(null, null);
                txtCUIT.Text = "";
                txtCUIT.Enabled = true;

                //Pedido de Sede Social
                divdatosextra_CUIT.Visible = false;
                ucDomicilioRealC.proptxtDomicilio = "";

                //Si es dj11 deshabilita el combo
                if (solosas)
                {
                    ddlTipoDeEntidadConstituida_CUIT.Enabled = false;
                }
                else
                {
                    ddlTipoDeEntidadConstituida_CUIT.Enabled = true;
                }
                ddlTipoDeEntidadConstituida_CUIT.Visible = true;
                ddlTipoDeEntidadConstituida_CUIT.SelectedIndex = -1;
                divdatosentidad_CUIT.Visible = false;
                divTipoDeEntidadC_CUIT.Visible = true;
                divcaptchaentidad_CUIT.Visible = true;
                txtEntidadC_CUIT.Text = "";
                txtTipoSocietario_CUIT.Text = "";
                MostrarContinuar(false);
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
