using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DJEngine.Business;
using DJEngine.UsoGeneral;
using DJEngine.DataAccess.Tipos;
using System.Text.RegularExpressions;

namespace DJEngine.WebEntities
{
    public partial class OrigenFondos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;

            //Arreglado por Fer
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.WorkFlowValidate(Page);

            LoadCss();

            if (!IsPostBack)
            {
                pnlvalidacion.Visible = false;
                pnlwfk_2.Visible = true;
                pnlwfk_2.Enabled = true;
                pnlwfk_3.Visible = false;
                pnlwfk_3.Enabled = false;
                pnlwfk_5efe.Visible = true;
                pnlwfk_5esp.Visible = false;

                rblModoIngreso.SelectedValue = "1";

                //Cargo el Combo de Tipo de Instrumento en Efectivo                
                CargarComboInstrumento();
                ddlTipoInstrumentoEfe.SelectedValue = "-1";

                //Reinicio todos los campos de los Fondos en Efectivo
                MostrarCamposEfectivo(-1);

                //Reinicio todos los campos de los Fondos en Especie
                ddlTipoBien.SelectedValue = "-1";
                ddlValuacion.SelectedValue = "-1";
                MostrarCamposEspecie(false);

                //Reinicio todos los cambos de Monto
                lblDocResp200.Visible = false;
                rblDocResp.Enabled = true;
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

        protected void rblPFPJ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblPFPJ.SelectedIndex == 0)
            {
                //Persona Fisica

                //LblTitulo_2.Text = "Datos de la Persona Declarante";
                pnlwfk_2.Visible = true;
                pnlwfk_2.Enabled = true;
                pnlwfk_3.Visible = false;
                pnlwfk_3.Enabled = false;
            }
            else
            {
                //Persona Juridica

                //LblTitulo_2.Text = "Datos de la Persona No Expuesta Pol&iacute;ticamente";
                pnlwfk_2.Visible = false;
                pnlwfk_2.Enabled = false;
                pnlwfk_3.Visible = true;
                pnlwfk_3.Enabled = true;
            }
        }

        protected void chkCuitPJEXT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCuitPJEXT.Checked == true)
            {
                txtCuitPJ.Text = "";
                txtCuitPJ.Visible = false;
                txtCuitPJ.Enabled = false;
                cvCuitPJ.Visible = false;
                cvCuitPJ.Enabled = false;
                txtCuitPJEXT.Text = "";
                txtCuitPJEXT.Visible = true;
                txtCuitPJEXT.Enabled = true;
                cvCuitPJEXT.Visible = true;
                cvCuitPJEXT.Enabled = true;
            }
            else
            {
                txtCuitPJ.Text = "";
                txtCuitPJ.Visible = true;
                txtCuitPJ.Enabled = true;
                cvCuitPJ.Visible = true;
                cvCuitPJ.Enabled = true;
                txtCuitPJEXT.Text = "";
                txtCuitPJEXT.Visible = false;
                txtCuitPJEXT.Enabled = false;
                cvCuitPJEXT.Visible = false;
                cvCuitPJEXT.Enabled = false;
            }
        }

        //////////////////////////////////////////////////////////////////////////
        // INDIQUE EL MODO DE INGRESO DE LOS FONDOS o TIPO DE APORTE / DONACION //
        //////////////////////////////////////////////////////////////////////////

        protected void rblModoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Reinicio los Combos de Modo de Ingreso
            ddlTipoInstrumentoEfe.SelectedValue = "-1";
            ddlTipoBien.SelectedValue = "-1";
            ddlValuacion.SelectedValue = "-1";

            switch (rblModoIngreso.SelectedValue)
            {
                case "1": //"EFECTIVO"
                    pnlwfk_5efe.Visible = true;
                    pnlwfk_5esp.Visible = false;
                    divDeposito.Visible = false;
                    divTransferencia.Visible = false; //Oculto las opciones de Transferencia hasta que elija el tipo de ingreso en Efectivo
                    divOtroInstrumento.Visible = false;
                    divMontos.Visible = false;

                    break;
                case "2": //"ESPECIES"
                    pnlwfk_5efe.Visible = false;
                    pnlwfk_5esp.Visible = true;
                    divValuacion.Visible = false; //Oculto las opciones de Bienes hasta que elija el tipo de ingreso en Especies
                    break;
                //case "3": //"AMBOS"
                //    pnlwfk_5efe.Visible = true;
                //    pnlwfk_5esp.Visible = true;
                //    divTransferencia.Visible = false; //Oculto las opciones de Transferencia hasta que elija el tipo de ingreso en Efectivo
                //    divOtroInstrumento.Visible = false;
                //    divValuacion.Visible = false; //Oculto las opciones de Bienes hasta que elija el tipo de ingreso en Especies
                //    break;
            }
        }

        /////////////////////////////////////
        // TIPO DE INSTRUMENTO EN EFECTIVO //
        /////////////////////////////////////

        #region "Tipo de Ingreso en Efectivo"

        public void CargarComboInstrumento()
        {
            ddlTipoInstrumentoEfe.DataSource = new TiposInstrumento().getTiposInstrumento();
            ddlTipoInstrumentoEfe.DataBind();
            Combo.CargarLeyenda(ddlTipoInstrumentoEfe);
            ddlTipoInstrumentoEfe.SelectedIndex = -1;
        }

        public void MostrarCamposEfectivo(int TipoInstrumentoEfe)
        {
            //////////
            //LABELS//
            //////////
            ucCuentaBancoDeposito.labelEntBancaria = "Entidad Bancaria del Deposito";
            ucCuentaBancoDeposito.labelTipoCuenta = "Tipo de Cuenta del Deposito";
            ucCuentaBancoDeposito.labelNroCuenta = "Numero de Cuenta del Deposito";

            ucCuentaBancoDonante.labelEntBancaria = "Entidad Bancaria del Donante";
            ucCuentaBancoDonante.labelTipoCuenta = "Tipo de Cuenta del Donante";
            ucCuentaBancoDonante.labelNroCuenta = "Numero de Cuenta del Donante";

            ucCuentaBancoDonatario.labelEntBancaria = "Entidad Bancaria del Donatario";
            ucCuentaBancoDonatario.labelTipoCuenta = "Tipo de Cuenta del Donatario";
            ucCuentaBancoDonatario.labelNroCuenta = "Numero de Cuenta del Donatario";
            

            bool Mostrar = true;
            ////////////
            //DEPOSITO//
            ////////////
            divDeposito.Visible = !Mostrar;

            //Entidad Deposito
            ucCuentaBancoDeposito.Visible = !Mostrar;
            //TODO: Se necesita habilitar o deshabilitar el User Control?
            //ucCuentaBancoDeposito.Enabled = !Mostrar;

            //txtEntBancariaDep.Visible = !Mostrar;
            //txtEntBancariaDep.Enabled = !Mostrar;
            //txtNroCuentaDep.Visible = !Mostrar;
            //txtNroCuentaDep.Enabled = !Mostrar;

            /////////////////
            //TRANSFERENCIA//
            /////////////////
            divTransferencia.Visible = !Mostrar;

            //Entidad Donante
            ucCuentaBancoDonante.Visible = !Mostrar;
            //TODO: Se necesita habilitar o deshabilitar el User Control?
            //ucCuentaBancoDonante.Enabled = !Mostrar;

            //lblEntBancariaDon.Visible = !Mostrar;
            //lblEntBancariaDon.Enabled = !Mostrar;
            //txtEntBancariaDon.Visible = !Mostrar;
            //txtEntBancariaDon.Enabled = !Mostrar;

            //lblNroCuentaDon.Visible = !Mostrar;
            //lblNroCuentaDon.Enabled = !Mostrar;
            //txtNroCuentaDon.Visible = !Mostrar;
            //txtNroCuentaDon.Enabled = !Mostrar;

            //Entidad Donatario
            ucCuentaBancoDonatario.Visible = !Mostrar;
            //TODO: Se necesita habilitar o deshabilitar el User Control?
            //ucCuentaBancoDonatario.Enabled = !Mostrar;

            //lblEntBancaria.Visible = !Mostrar;
            //lblEntBancaria.Enabled = !Mostrar;
            //txtEntBancaria.Visible = !Mostrar;
            //txtEntBancaria.Enabled = !Mostrar;

            //lblNroCuenta.Visible = !Mostrar;
            //lblNroCuenta.Enabled = !Mostrar;
            //txtNroCuenta.Visible = !Mostrar;
            //txtNroCuenta.Enabled = !Mostrar;

            ////////////////////
            //OTRO INSTRUMENTO//
            ////////////////////
            //Otro Instrumento
            divOtroInstrumento.Visible = !Mostrar;

            lblOtroInst.Visible = !Mostrar;
            lblOtroInst.Enabled = !Mostrar;
            txtOtroInst.Visible = !Mostrar;
            txtOtroInst.Enabled = !Mostrar;

            //Montos
            divMontos.Visible = !Mostrar;
            ucMontosEfe.Visible = !Mostrar;

            switch (TipoInstrumentoEfe)
            {
                case -1: //"SELECCIONAR OPCION"
                    break;
                case 1: //"DEPOSITO BANCARIO"
                    ////////////
                    //DEPOSITO//
                    ////////////
                    divDeposito.Visible = Mostrar;

                    //Entidad Deposito
                    ucCuentaBancoDeposito.Visible = Mostrar;
                    //txtEntBancariaDep.Visible = Mostrar;
                    //txtEntBancariaDep.Enabled = Mostrar;
                    //txtNroCuentaDep.Visible = Mostrar;
                    //txtNroCuentaDep.Enabled = Mostrar;

                    //Montos
                    divMontos.Visible = Mostrar;
                    ucMontosEfe.Visible = Mostrar;
                    break;
                case 2: //"TRANSFERENCIA BANCARIA"
                    /////////////////
                    //TRANSFERENCIA//
                    /////////////////
                    divTransferencia.Visible = Mostrar;

                    //Entidad Donante
                    ucCuentaBancoDonante.Visible = Mostrar;
                    //lblEntBancariaDon.Visible = Mostrar;
                    //lblEntBancariaDon.Enabled = Mostrar;
                    //txtEntBancariaDon.Visible = Mostrar;
                    //txtEntBancariaDon.Enabled = Mostrar;

                    //lblNroCuentaDon.Visible = Mostrar;
                    //lblNroCuentaDon.Enabled = Mostrar;
                    //txtNroCuentaDon.Visible = Mostrar;
                    //txtNroCuentaDon.Enabled = Mostrar;

                    ////Entidad Donatario
                    ucCuentaBancoDonatario.Visible = Mostrar;
                    //lblEntBancaria.Visible = Mostrar;
                    //lblEntBancaria.Enabled = Mostrar;
                    //txtEntBancaria.Visible = Mostrar;
                    //txtEntBancaria.Enabled = Mostrar;

                    //lblNroCuenta.Visible = Mostrar;
                    //lblNroCuenta.Enabled = Mostrar;
                    //txtNroCuenta.Visible = Mostrar;
                    //txtNroCuenta.Enabled = Mostrar;

                    //Montos
                    divMontos.Visible = Mostrar;
                    ucMontosEfe.Visible = Mostrar;
                    break;
                case 3: //"OTRO INSTRUMENTO"
                    ////////////////////
                    //OTRO INSTRUMENTO//
                    ////////////////////
                    //Otro Instrumento
                    divOtroInstrumento.Visible = Mostrar;

                    lblOtroInst.Visible = Mostrar;
                    lblOtroInst.Enabled = Mostrar;
                    txtOtroInst.Visible = Mostrar;
                    txtOtroInst.Enabled = Mostrar;

                    //Montos
                    divMontos.Visible = Mostrar;
                    ucMontosEfe.Visible = Mostrar;
                    break;
                default:
                    break;
            }
        }

        protected void ddlTipoInstrumentoEfe_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlTipoInstrumentoEfe.SelectedItem.Value)
            {
                case "-1": //"SELECCIONAR OPCION"
                    MostrarCamposEfectivo(-1);
                    break;
                case "1": //"DEPOSITO BANCARIO"
                    MostrarCamposEfectivo(1);
                    break;
                case "2": //"TRANSFERENCIA BANCARIA"
                    MostrarCamposEfectivo(2);
                    break;
                case "3": //"OTRO INSTRUMENTO"
                    MostrarCamposEfectivo(3);
                    break;
            }
        }

        #endregion "Tipo de Ingreso en Efectivo"

        ////////////////////////////////
        // TIPO DE INGRESO EN ESPECIE //
        ////////////////////////////////

        #region "Tipo de Ingreso en Especie"

        public void CargarComboValuacion(int TipoBienId)
        {
            ddlValuacion.DataSource = new TiposValuacion().getTiposValuacionFiltrado(TipoBienId);
            ddlValuacion.DataBind();
            Combo.CargarLeyenda(ddlValuacion);
            ddlValuacion.SelectedIndex = -1;
        }

        public void MostrarCamposEspecie(bool Mostrar)
        {
            //divValuacion
            divValuacion.Visible = Mostrar;
            //Descripcion
            txtDescripcionBien.Visible = Mostrar;
            txtDescripcionBien.Enabled = Mostrar;
            txtDescripcionBien.Text = "";
            //Tipo de Bien
            ddlValuacion.Visible = Mostrar;
            ddlValuacion.Enabled = Mostrar;
            ddlValuacion.SelectedValue = "-1";
            //Cantidad//Valor Corriente Unitario//Valor Corriente Total
            ucValores.MostrarCamposValores(Mostrar);
            ////Cantidad
            //txtCantidad.Visible = Mostrar;
            //txtCantidad.Enabled = Mostrar;
            //txtCantidad.Text = "";
            ////Valor Corriente Unitario
            //txtValCorUni.Visible = Mostrar;
            //txtValCorUni.Enabled = Mostrar;
            //txtValCorUni.Text = "";
            ////Valor Corriente Total
            //txtValCorTot.Visible = Mostrar;
            //txtValCorTot.Enabled = Mostrar;
            //txtValCorTot.Text = "";

        }

        protected void ddlTipoBien_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cargo combo Valuacion segun tipo de bien
            switch (ddlTipoBien.SelectedItem.Value)
            {
                case "-1": //"SELECCIONAR OPCION"
                    CargarComboValuacion(0);
                    break;
                case "1": //"REGISTRABLE" (1)
                    //Dejar solo en el combo "1": //"VALORACION FISCAL" y "2": //"TASACION PERICIAL"
                    CargarComboValuacion(1);
                    break;
                case "2": //"NO REGISTRABLE" (2)
                    //Dejar solo en el combo "2": //"TASACION PERICIAL" y "3": //"VALOR DE PLAZA"
                    CargarComboValuacion(2);
                    break;
            }

            //Muestro o no los campos segun tipo de bien
            if (ddlTipoBien.SelectedItem.Value == "-1")
            {
                MostrarCamposEspecie(false);
            }
            else
            {
                MostrarCamposEspecie(true);
            }
        }

        #endregion "Tipo de Ingreso en Especie"

        ///////////
        // MONTO //
        ///////////

        #region "Monto"

        //protected void txtValCorUni_TextChanged(object sender, EventArgs e)
        //protected void btnCalcular_Click(object sender, ImageClickEventArgs e)
        //{
        //    //Pregunto si ambos campos son distintos de vacio
        //    if (txtCantidad.Text != "" && txtValCorUni.Text != "")
        //    {
        //        Regex isNumber = new Regex(@"^\+?([1-9]\d*)$");
        //        Regex isDecimal = new Regex(@"^(\d+|\d{0,13}[,]\d{0,2})%?$");

        //        //Verifico que sea un numero entero positivo (mayor a 0)
        //        Match okCantidad = isNumber.Match(txtCantidad.Text.Trim());
        //        //Verifico que sea un numero con un maximo 13 digitos y 2 decimales
        //        Match okValCorUni = isDecimal.Match(txtValCorUni.Text.Trim());

        //        //Reviso que ambos campos sean numericos
        //        if (okValCorUni.Success && okCantidad.Success)
        //        {
        //            //Multiplico la Cantidad x el Valor Corriente Unitario y lo asigno al campo del Valor Corriente Total
        //            txtValCorTot.Text = Convert.ToString(Convert.ToInt64(txtCantidad.Text.Trim()) * Convert.ToDecimal(txtValCorUni.Text.Trim()));
        //        }
        //    }
        //}

        protected void ddlMonto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Pregunto si es mayor a 200k para Harcodear en si y mostrar "Documentacion Respaldatoria Obligatoria (Art. 517) "
            if (ddlMonto.SelectedItem.Value == "2")
            { //DOSCIENTOS MIL
                rblDocResp.SelectedValue = "1";
                rblDocResp.Enabled = false;
                //lblDocResp200.Text = "Documentación Respaldatoria Obligatoria (Art. 517)";
                lblDocResp200.Visible = true;
            }
            else
            { //CIEN MIL o SELECCIONAR OPCION
                rblDocResp.Enabled = true;
                lblDocResp200.Visible = false;
            }
        }

        #endregion "Monto"

        protected void CargarPropiedades()
        {
            //Guardo en propiedades los datos de la Persona Politicamente Expuesta
            DJEngine.Business.OrigenFondos ORI = new DJEngine.Business.OrigenFondos();

            #region "Datos del Donante o Aportante"
            ///////////////////////////////////////////
            // Empieza Datos del Donante o Aportante //
            ///////////////////////////////////////////

            if (Convert.ToInt32(rblPFPJ.SelectedValue) == 1)
            {//Persona Fisica
                ORI.PersonaFisica = 1;
                ORI.TipoClaveFiscal = Convert.ToInt32(ucFiscalPF.propddlTipoFiscal);
                ORI.NroClaveFiscal = ucFiscalPF.proptxtNroFiscal.Trim();
            }
            else
            {//Persona Juridica
                ORI.PersonaFisica = 0;
                //ORI.TipoClaveFiscal = 1; //Harcodeo tipo "CUIT" esta bien igual porque es juridica
                if (chkCuitPJEXT.Checked == true)
                    ORI.NroCuitPJ = txtCuitPJEXT.Text.Trim();
                else
                    ORI.NroCuitPJ = txtCuitPJ.Text.Trim();
            }

            //Persona Fisica
            ORI.Nombre = txtNombrePF.Text.Trim();
            ORI.Apellido = txtApellidoPF.Text.Trim();
            //ORI.TipoDoc = ddlTipoDocPF.SelectedIndex;
            ORI.TipoDoc = ucDocumentoPF.propddlTipoDoc;
            //ORI.NroDoc = txtNroDocPF.Text.Trim();
            ORI.NroDoc = ucDocumentoPF.proptxtNroDoc.Trim();

            //Persona Juridica
            ORI.RazonSocial = CharacterTreat.ConvertirPrimeraLetraMayuscula(Convert.ToString(txtRazonSocPJ.Text.Trim()), 1);

            ///////////////////////////////////////////
            // Termina Datos del Donante o Aportante //
            ///////////////////////////////////////////
            #endregion "Datos del Donante o Aportante"

            #region "Caracter de los Fondos"
            ////////////////////////////////////
            // Empieza Caracter de los Fondos //
            ////////////////////////////////////
            ORI.CaracterFondo = Convert.ToInt32(ddlCaracter.SelectedItem.Value);
            //Nuevo 12/2015
            ORI.Origen = txtOrigen.Text.Trim();
            ORI.FechaCF = Convert.ToDateTime(ucFechaCF.proptxtFecha.Trim());
            ////////////////////////////////////
            // Termina Caracter de los Fondos //
            ////////////////////////////////////
            #endregion "Caracter de los Fondos"

            #region "Modo de Ingreso de los Fondos"
            ///////////////////////////////////////////
            // Empieza Modo de Ingreso de los Fondos //
            ///////////////////////////////////////////

            //ORI.TipoIngreso = Convert.ToInt32(ddlTipoInstrumentoEfe.SelectedItem.Value); //Viejo
            ORI.TipoIngreso = Convert.ToInt32(rblModoIngreso.SelectedValue);

            #region "Tipo de Ingreso en Efectivo"
            /////////////////////////////////////////
            // Empieza Tipo de Ingreso en Efectivo //
            /////////////////////////////////////////
            ORI.TipoInstrumentoEfe = Convert.ToInt32(ddlTipoInstrumentoEfe.SelectedValue);

            //Monto
            //Pregunto si los montos no estan vacios porque se eligio especie
            if (ucMontosEfe.MontoMoneda != "")
            {
                ORI.MontoMoneda = Convert.ToDecimal(ucMontosEfe.MontoMoneda);
                ORI.MonedaId = ucMontosEfe.MonedaId;
                ORI.MonedaDesc = new TiposMonedas(ORI.MonedaId).Descripcion;
                if (ORI.MonedaId > 1)
                    ORI.MontoPesos = Convert.ToDecimal(ucMontosEfe.MontoPesos);
            }
            else
            {//Borro todo en el caso de que sea en Especie
                ORI.MontoMoneda = 0;
                ORI.MonedaId = 0;
                ORI.MonedaDesc = "";
                ORI.MontoPesos = 0;
            }

            switch (ddlTipoInstrumentoEfe.SelectedValue)
            {
                case "1": //DEPOSITO BANCARIO
                    ORI.EntBanDeposito = ucCuentaBancoDeposito.EntBancaria;
                    ORI.TipoCuentaIdDeposito = ucCuentaBancoDeposito.TipoCuenta;
                    ORI.TipoCuentaDeposito = new TiposCuentaBanco(ORI.TipoCuentaIdDeposito).Descripcion;
                    ORI.NroCuentaDeposito = ucCuentaBancoDeposito.NroCuenta;
                    ORI.EntBanDonante = "";
                    ORI.TipoCuentaIdDonante = -1;
                    ORI.TipoCuentaDonante = "";
                    ORI.NroCuentaDonante = "";
                    ORI.EntBanDonatario = "";
                    ORI.TipoCuentaIdDonatario = -1;
                    ORI.TipoCuentaDonatario = "";
                    ORI.NroCuentaDonatario = "";
                    ORI.OtroInstrumento = "";
                    break;
                case "2": //TRANSFERENCIA BANCARIA
                    ORI.EntBanDeposito = "";
                    ORI.TipoCuentaIdDeposito = -1;
                    ORI.NroCuentaDeposito = "";
                    ORI.EntBanDonante = ucCuentaBancoDonante.EntBancaria;
                    ORI.TipoCuentaIdDonante = ucCuentaBancoDonante.TipoCuenta;
                    ORI.TipoCuentaDonante = new TiposCuentaBanco(ORI.TipoCuentaIdDonante).Descripcion;
                    ORI.NroCuentaDonante = ucCuentaBancoDonante.NroCuenta;
                    ORI.EntBanDonatario = ucCuentaBancoDonatario.EntBancaria;
                    ORI.TipoCuentaIdDonatario = ucCuentaBancoDonatario.TipoCuenta;
                    ORI.TipoCuentaDonatario = new TiposCuentaBanco(ORI.TipoCuentaIdDonatario).Descripcion;
                    ORI.NroCuentaDonatario = ucCuentaBancoDonatario.NroCuenta;
                    ORI.OtroInstrumento = "";
                    break;
                case "3": //OTRO INSTRUMENTO
                    ORI.EntBanDeposito = "";
                    ORI.TipoCuentaIdDeposito = -1;
                    ORI.TipoCuentaDeposito = "";
                    ORI.NroCuentaDeposito = "";
                    ORI.EntBanDonante = "";
                    ORI.TipoCuentaIdDonante = -1;
                    ORI.TipoCuentaDonante = "";
                    ORI.NroCuentaDonante = "";
                    ORI.EntBanDonatario = "";
                    ORI.TipoCuentaIdDonatario = -1;
                    ORI.TipoCuentaDonatario = "";
                    ORI.NroCuentaDonatario = "";
                    ORI.OtroInstrumento = txtOtroInst.Text.Trim();
                    break;
            }

            /////////////////////////////////////////
            // Termina Tipo de Ingreso en Efectivo //
            /////////////////////////////////////////
            #endregion "Tipo de Ingreso en Efectivo"

            #region "Tipo de Ingreso en Especies"
            /////////////////////////////////////////
            // Empieza Tipo de Ingreso en Especies //
            /////////////////////////////////////////

            ORI.TipoBien = Convert.ToInt32(ddlTipoBien.SelectedValue);
            ORI.DescripcionBien = txtDescripcionBien.Text.Trim();

            if (ddlValuacion.SelectedValue != "")
            {
                ORI.Valuacion = Convert.ToInt32(ddlValuacion.SelectedValue);
                switch (ddlValuacion.SelectedValue)
                {
                    case "1": //VALORACION FISCAL
                    case "2": //TASACION PERICIAL
                    case "3": //VALOR DE PLAZA
                        //Cantidad
                        ORI.Cantidad = Convert.ToInt64(ucValores.Cantidad);
                        //Valor Corriente Unitario
                        ORI.ValCorUni = Convert.ToDecimal(ucValores.ValCorUni);
                        //Valor Corriente Total
                        ORI.ValCorTot = ORI.Cantidad * ORI.ValCorUni;
                        break;
                }
            }
            /////////////////////////////////////////
            // Termina Tipo de Ingreso en Especies //
            /////////////////////////////////////////
            #endregion "Tipo de Ingreso en Especies"

            #region "Monto"
            ///////////////////
            // Empieza Monto //
            ///////////////////

            if (Convert.ToInt32(ddlMonto.SelectedValue) == 1)
            {//PESOS CIEN MIL
                ORI.MasDeDoscientosMil = 0;
            }
            else
            {//PESOS DOSCIENTOS MIL
                ORI.MasDeDoscientosMil = 1;
            }


            if (Convert.ToInt32(rblDocResp.SelectedValue) == 1)
            {//SI
                ORI.DocRespaldatoria = 1;
            }
            else
            {//NO
                ORI.DocRespaldatoria = 0;
            }

            ///////////////////
            // Termina Monto //
            ///////////////////
            #endregion "Monto"

            ///////////////////////////////////////////
            // Termina Modo de Ingreso de los Fondos //
            ///////////////////////////////////////////
            #endregion "Modo de Ingreso de los Fondos"

            Session["OrigenFondos"] = ORI;
        }

        protected bool CargarCabeceraOLF()
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

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.Anterior();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            //Valido todos los controles de la pagina web
            //txtValCorTot.Attributes.Remove("disabled='disabled'");
            Page.Validate();

            if (!Page.IsValid)
            {
                //txtValCorTot.Attributes.Add("disabled","disabled");
                pnlvalidacion.Visible = true;
                return;
            }

            //TODO: Quite el ValidarCaptcha porque ya lo hace el Validation.
            CargarPropiedades();
            CargarCabeceraOLF();
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.Siguiente();
        }

        protected void CustomValidator_Standar(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }

    }
}