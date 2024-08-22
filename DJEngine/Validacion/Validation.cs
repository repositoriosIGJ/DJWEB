using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.OleDb;
using System.Globalization;
using System.Configuration;

/// <summary>
/// Summary description for Validation
/// </summary>
public class Validation
{
    private static DataSet Validaciones;

    public Validation()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void Iniciar()
    {
        Validaciones = new DataSet("Validaciones");

        DJEngine.WSIGJGeneric.IGJ_Generic wsGeneric = new DJEngine.WSIGJGeneric.IGJ_Generic();

        DataTable dt = new DataTable();

        Validaciones = wsGeneric.GetEsquemaValidacionSistema(3);
    }

    public static bool ValidarCaptcha(string strCaptcha, out string mensaje)
    {
        string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
        string sRet = oInfo.Name;

        //Pregunto si el valor del captcha en session es distinto de null para descartar
        //salteo del captcha mediante plugins del browser
        if ((String)HttpContext.Current.Session["CaptchaValue"] != null)
        {
            if (strCaptcha.ToUpper() == (String)HttpContext.Current.Session["CaptchaValue"])
            {
                mensaje = "";
                //Borro el Captcha despues de compararlo para evitar salteos solo para "Entidad.aspx"
                if (sRet == "Entidad.aspx")
                {
                    HttpContext.Current.Session["CaptchaValue"] = null;
                    HttpContext.Current.Session["CaptchaValidate"] = null;
                }
                return true;
            }
            else
            {
                mensaje = " El texto ingresado es incorrecto";
                //Borro el Captcha despues de compararlo para evitar salteos solo para "Entidad.aspx"
                if (sRet == "Entidad.aspx")
                    HttpContext.Current.Session["CaptchaValue"] = null;
                return false;
            }
        }
        else
        {
            mensaje = " El valor ingresado es invalido";
            return false;
        }
    }

    public static bool ValidarEmailsDD(CustomValidator cv, string EmailA, string EmailB)
    {
        //Creo un custom validator auxiliar
        //CustomValidator cvAux = new CustomValidator();
        //cvAux.Page = cv.Page;
        cv.Text = "x";
        //cvAux.Text = "x";
        //cvAux.EnableClientScript = true;

        bool rlt = false;

        //Pregunto si el campo "Domicilio Digital Nuevo" y "Confirmar Domicilio Digital" son identicos
        if (EmailA != EmailB)
        {
            cv.ErrorMessage = "[CONFIRMAR DOMICILIO DIGITAL] El domicilio digital ingresado no se corresponde con su confirmación";
            cv.IsValid = false;
        }
        else
        {
            cv.IsValid = true;
            rlt = true;
        }

        return rlt;
    }

    public static bool ValidarCodValDD(CustomValidator cv, string strCodVal, string strCodValEnviado)
    {
        cv.Text = "x";

        bool rlt = false;

        //Pregunto si el campo "Código de Validación" y el codigo enviado por email (session) son identicos en Mayusculas
        if (strCodVal != strCodValEnviado)
        {
            cv.ErrorMessage = "[CODIGO DE VALIDACION DOMICILIO DIG] El Código de Validación ingresado no se corresponde al enviado por email";
            cv.IsValid = false;
        }
        else
        {
            cv.IsValid = true;
            rlt = true;
        }

        return rlt;
    }

    public static bool ValidarNroDoc(CustomValidator cv, string TipoDoc, string NroDoc)
    {
        //Creo un custom validator auxiliar
        CustomValidator cvAux = new CustomValidator();
        cvAux.Page = cv.Page;
        cv.Text = "x";
        cvAux.Text = "x";
        cvAux.EnableClientScript = true;

        bool rlt = false;

        //Segun el Tipo de Documento valido el Numero de Documento 
        switch (TipoDoc)
        {
            case "-1": //"<< SELECCIONAR OPCION >>"
                //No Validar
                //TODO: Revisar que hacer con esta opcion
                //No debo validar el campo txtNroDoc si no se selecciono una opcion en ddlTipoDoc
                cv.ErrorMessage = "[" + "NUMERO DE DOCUMENTO" + "] Debe Seleccionar algun Tipo de Documento.";
                //cv.IsValid = false;
                return false;
            case "1": //"DOCUMENTO NACIONAL DE IDENTIDAD"
            case "2": //"CEDULA DE IDENTIDAD"
            case "3": //"LIBRETA CIVICA"
            case "4": //"LIBRETA DE ENROLAMIENTO"
                //Validar como txtNroDoc_1 para Numerico Obligatorio
                cvAux.ControlToValidate = cv.ControlToValidate + "_1";
                rlt = Validar(cvAux, NroDoc);
                break;
            case "5": //"PASAPORTE"
                //Validar como txtNroDoc_2 para Alfanumerico Obligatorio
                cvAux.ControlToValidate = cv.ControlToValidate + "_2";
                rlt = Validar(cvAux, NroDoc);
                break;
        }
        cv.ErrorMessage = cvAux.ErrorMessage;
        //cv.IsValid = cvAux.IsValid;

        return rlt;
    }

    public static bool ValidarEmail(CustomValidator cv, string email)
    {
        //Creo un custom validator auxiliar
        CustomValidator cvAux = new CustomValidator();
        cvAux.Page = cv.Page;
        cv.Text = "x";
        cvAux.Text = "x";
        cvAux.ControlToValidate = cv.ControlToValidate;
        cvAux.EnableClientScript = true;

        bool rlt = false;

        //Valida Campo Obligatorio
        if (email.Trim() == "")
        {
            rlt = Validar(cvAux, email.Trim());
        }
        else
        {
            //Permite alfanumericos con varios espacios, ñÑ, acentos minusculas, Parentesis, punto y coma
            //Regex rgx = new Regex(@"^[a-zA-Z0-9Ññáéíóú\\(\\)\\.\\,][a-zA-Z0-9 Ññáéíóú\\(\\)\\.\\,]+$");

            //Formato Email
            Regex rgx = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

            //Valido el formato
            Match _Match = rgx.Match(email);

            if (!_Match.Success)
            {
                cvAux.ErrorMessage = "[" + "CORREO ELECTRONICO" + "] Caracteres Invalidos en el Correo Electrónico ingresado.";
                rlt = false;
            }
            else
            {
                //Si esta bien escrito el domicilio valido rango
                rlt = Validar(cvAux, email);
            }
        }

        cv.ErrorMessage = cvAux.ErrorMessage;

        return rlt;
    }

    public static bool ValidarDomicilio(CustomValidator cv, string domicilio)
    {
        //Creo un custom validator auxiliar
        CustomValidator cvAux = new CustomValidator();
        cvAux.Page = cv.Page;
        cv.Text = "x";
        cvAux.Text = "x";
        cvAux.ControlToValidate = cv.ControlToValidate;
        cvAux.EnableClientScript = true;

        bool rlt = false;

        //Valida Campo Obligatorio
        if (domicilio.Trim() == "")
        {
            rlt = Validar(cvAux, domicilio.Trim());
        }
        else
        {
            //Permite alfanumericos con varios espacios, ñÑ, acentos minusculas, Parentesis, punto y coma
            Regex rgx = new Regex(@"^[a-zA-Z0-9Ññáéíóú\\(\\)\\.\\,][a-zA-Z0-9 Ññáéíóú\\(\\)\\.\\,]+$");

            //Valido el formato
            Match _Match = rgx.Match(domicilio);

            if (!_Match.Success)
            {
                cvAux.ErrorMessage = "[" + "DOMICILIO" + "] Caracteres Invalidos en el Domicilio ingresado.";
                rlt = false;
            }
            else
            {
                //Si esta bien escrito el domicilio valido rango
                rlt = Validar(cvAux, domicilio);
            }            
        }

        cv.ErrorMessage = cvAux.ErrorMessage;

        return rlt;
    }

    public static bool ValidarCUIT(CustomValidator cv, string numerocuit)
    {
        //Creo un custom validator auxiliar
        CustomValidator cvAux = new CustomValidator();
        cvAux.Page = cv.Page;
        cv.Text = "x";
        cvAux.Text = "x";
        cvAux.ControlToValidate = cv.ControlToValidate;
        cvAux.EnableClientScript = true;

        bool rlt = false;

        //Valida Campo Obligatorio
        if (numerocuit.Trim() == "")
        {
            rlt = Validar(cvAux, numerocuit.Trim());
        }
        else
        {
            //mensaje = "";
            int suma, longitud, valor1, valor2;

            suma = 0;

            string final;

            longitud = numerocuit.Length;

            string patron = "5432765432";

            if (longitud == 11)
            {
                if (numerocuit.Substring(0, 2).CompareTo("20") == 0 || numerocuit.Substring(0, 2).CompareTo("23") == 0 || numerocuit.Substring(0, 2).CompareTo("24") == 0 || numerocuit.Substring(0, 2).CompareTo("27") == 0 || numerocuit.Substring(0, 2).CompareTo("30") == 0 || numerocuit.Substring(0, 2).CompareTo("33") == 0 || numerocuit.Substring(0, 2).CompareTo("34") == 0)
                {
                    final = numerocuit[10].ToString();

                    for (int i = 0; i <= 9; i++)
                    {
                        try
                        {
                            suma += int.Parse(patron[i].ToString()) * int.Parse(numerocuit[i].ToString());
                        }
                        catch
                        {
                            cvAux.ErrorMessage = "[CUIT] El numero tiene caracteres";
                            rlt = false;
                        }
                    }

                    valor1 = suma % 11;
                    valor2 = 11 - valor1;

                    if (valor2 == 11)
                    {
                        valor2 = 0;
                    }

                    else if (valor2 == 10)
                    {
                        valor2 = 9;
                    }

                    if (String.Equals(Convert.ToString(valor2), final))
                    {
                        rlt = true;
                    }
                    else
                    {
                        cvAux.ErrorMessage = "[CUIT] Fin del Cuit erroneo";
                        rlt = false;
                    }
                }
                else
                {
                    cvAux.ErrorMessage = "[CUIT] Comienzo del Cuit erroneo";
                    rlt = false;
                }
            }
            else
            {
                cvAux.ErrorMessage = "[CUIT] Longitud del Cuit erronea";
                rlt = false;
            }
        }

        cv.ErrorMessage = cvAux.ErrorMessage;

        return rlt;
    }

    //public static bool ValidarNroCorr(CustomValidator cv, string NroCorr)
    //{
    //    //Creo un custom validator auxiliar
    //    CustomValidator cvAux = new CustomValidator();
    //    cvAux.Page = cv.Page;
    //    cv.Text = "x";
    //    cvAux.Text = "x";
    //    cvAux.EnableClientScript = true;

    //    bool rlt = false;

    //    if (NroCorr)
    //    {
    //        cvAux.ControlToValidate = cv.ControlToValidate;
    //        rlt = Validar(cvAux, NroCorr);
    //        cv.ErrorMessage = "[" + "NUMERO DE DOCUMENTO" + "] El N&uacute;mero Correlativo no se corresponde a una Entidad existe&nbsp;";
    //    }

    //    //switch (txtNroCorrelativo)
    //    //{
    //    //    case "-1": //"<< SELECCIONAR OPCION >>"
    //    //        //No Validar
    //    //        //TODO: Revisar que hacer con esta opcion
    //    //        //No debo validar el campo txtNroDoc si no se selecciono una opcion en ddlTipoDoc
    //    //        cv.ErrorMessage = "[" + "NUMERO DE DOCUMENTO" + "] Debe Seleccionar algun Tipo de Documento.";
    //    //        //cv.IsValid = false;
    //    //        return false;
    //    //    case "1": //"DOCUMENTO NACIONAL DE IDENTIDAD"
    //    //    case "2": //"CEDULA DE IDENTIDAD"
    //    //    case "3": //"LIBRETA CIVICA"
    //    //    case "4": //"LIBRETA DE ENROLAMIENTO"
    //    //        //Validar como txtNroDoc_1 para Numerico Obligatorio
    //    //        cvAux.ControlToValidate = cv.ControlToValidate + "_1";
    //    //        rlt = Validar(cvAux, NroDoc);
    //    //        break;
    //    //    case "5": //"PASAPORTE"
    //    //        //Validar como txtNroDoc_2 para Alfanumerico Obligatorio
    //    //        cvAux.ControlToValidate = cv.ControlToValidate + "_2";
    //    //        rlt = Validar(cvAux, NroDoc);
    //    //        break;
    //    //}

    //    cv.ErrorMessage = cvAux.ErrorMessage;
    //    //cv.IsValid = cvAux.IsValid;

    //    return rlt;
    //}

    public static bool Validar(CustomValidator cv, string valor)
    {
        //Iniciar();

        //cv.Text = "*";
        cv.Text = "x";
        //cv.Text = "~/App_Theme/Imagenes/imgAsterisco.png";

        string Pagina = cv.Page.ToString();

        ServerValidateEventArgs rtn;
        //ASP.Nombre_aspx

        ParametrosValidacion pv = GetParametros(cv.ControlToValidate, Pagina.Substring(4, Pagina.Length - 9).ToUpper());

        if (pv.TipoCampo == null)
            throw new Exception(cv.ControlToValidate + " no tiene validacion");


        /*======================================*/
        /*    CARACTERES INVALIDOS              */
        /*======================================*/

        if (StringValueValidation(valor, pv.TipoCampo) == false)
        {
            cv.ErrorMessage = "[" + pv.Campo + "] Valores Inválidos.";
            return false;
        }



        /*======================================*/
        /*    VALIDACION SI ES REQUERIDO        */
        /*======================================*/

        if (pv.Requerido == "N")
        {
            if (valor == "")
                return true;
        }
        else
        {
            /*SI SE TRATA DE VACIO O NULO*/
            if (NullValueValidation(valor))
            {
                cv.ErrorMessage = "[" + pv.Campo + "] Campo Obligatorio. Debe Cargar algún Valor.";
                return false;
            }
        }

        /*======================================*/
        /*  BUSCO TIPOS COMBINADOS              */
        /*======================================*/
        switch (pv.TipoCampo)
        {
            case "NR":
                int aux;
                if (int.TryParse(valor, out aux))
                {
                    pv.TipoCampo = "N";
                }
                else
                {
                    pv.TipoCampo = "R";
                }
                break;
        }


        /*======================================*/
        /*  BUSCO TIPOS SIMPLES                 */
        /*======================================*/
        // si es solo Texto
        switch (pv.TipoCampo)
        {

            case "R":
                string msj;
                if (ValidarNumerosRomanos(valor, out msj) == false)
                {
                    cv.ErrorMessage = "[" + pv.Campo + "]" + msj;
                    return false;
                }

                break;
            //MBenso-24/05/2012-End
            //MBenso-23/02/2012-Start

            //break;

            case "C":
                string msj1;
                if (ValidarCuit(valor, out msj1) == false)
                {
                    cv.ErrorMessage = "[" + pv.Campo + "]" + msj1;
                    return false;
                }
                break;
            //MBenso-23/02/2012-End

            //Valida Captcha
            case "P":
                string msjcaptcha;
                if (ValidarCaptcha(valor, out msjcaptcha) == false)
                {
                    cv.ErrorMessage = "[" + pv.Campo + "]" + msjcaptcha;
                    return false;
                }
                break;
            case "T":

                if (ValidarSoloTexto(valor) == false)
                {
                    cv.ErrorMessage = "[" + pv.Campo + "] Caracteres Inválidos. Solo Letras.";
                    return false;
                }
                break;

            case "N":
            case "I":
            case "L":
                double r;

                try
                {
                    r = double.Parse(valor);
                }
                catch
                {
                    cv.ErrorMessage = "[" + pv.Campo + "] Datos Númericos Inválidos.";
                    return false;
                }
                break;

            case "F":
                //Valido el formato de la fecha
                DateTime aux;
                //DateTime.TryParse(valor, out aux);
                DateTime.TryParseExact(valor, "dd'/'MM'/'yyyy", CultureInfo.CreateSpecificCulture("es-AR"), DateTimeStyles.None, out aux);

                /*si no pudo convertirlo a fecha, asigna a aux el MinValue*/
                if (aux == DateTime.MinValue)
                {
                    cv.ErrorMessage = "[" + pv.Campo + "] Formato de Fecha inválido.";
                    return false;
                }

                break;
            case "Y":
                //Valida que el Año sea numerico
                double y;

                try
                {
                    y = double.Parse(valor);
                }
                catch
                {
                    cv.ErrorMessage = "[" + pv.Campo + "] Formato de Año inválido.";
                    return false;
                }
                break;

            case "E":
                //si es del tipo  Email
                if (EMailValueValidator(valor) == false)
                {
                    cv.ErrorMessage = "[" + pv.Campo + "] Formato de Email inválido.";
                    return false;
                }
                break;
            case "PO":
                //Si es del tipo Porcentaje
                if (PorcentajeValidator(valor) == false)
                {
                    cv.ErrorMessage = "[" + pv.Campo + "] Formato de Porcentaje inválido.";
                    return false;
                }
                break;
            case "DI":
                //Si es del tipo Dinero
                if (DineroValidator(valor) == false)
                {
                    cv.ErrorMessage = "[" + pv.Campo + "] Formato de Dinero inválido (ingresar miles sin punto)";
                    return false;
                }
                break;
            //Valido Domicilio Real 03/11/2015
            //case "D":
            //    string msjdom;
            //    if (ValidarDomicilio(CustomValidator cv, valor, out msjdom) == false)
            //    {
            //        cv.ErrorMessage = "[" + pv.Campo + "]" + msjdom;
            //        return false;
            //    }

            //    break;

            default:
                break;
        }


        /*======================================*/
        /*  VALIDO RANGOS                      */
        /*======================================*/
        double val;
        switch (pv.TipoCampo)
        {
            case "N":
                val = Convert.ToDouble(valor);

                if (val < Convert.ToDouble(pv.ValorInicio) || val > Convert.ToDouble(pv.ValorFin))
                {
                    if ((pv.Control.Substring(0, 3).ToUpper() == "DDL") || (pv.Control.Substring(0, 3).ToUpper() == "CBO"))
                        cv.ErrorMessage = "[" + pv.Campo + "] Debe Seleccionar una Opción";
                    else
                        cv.ErrorMessage = "[" + pv.Campo + "] Valor Numérico fuera de Rango válido";

                    return false;
                }
                break;
            case "I":
                val = Convert.ToDouble(valor);

                if (val < int.MinValue || val > int.MaxValue)
                {
                    if ((pv.Control.Substring(0, 3).ToUpper() == "DDL") || (pv.Control.Substring(0, 3).ToUpper() == "CBO"))
                        cv.ErrorMessage = "[" + pv.Campo + "] Debe Seleccionar una Opción";
                    else
                        cv.ErrorMessage = "[" + pv.Campo + "] Valor Numérico fuera de Rango válido";

                    return false;
                }
                break;

            case "L":
                val = Convert.ToDouble(valor);

                if (val < long.MinValue || val > long.MaxValue)
                {
                    if ((pv.Control.Substring(0, 3).ToUpper() == "DDL") || (pv.Control.Substring(0, 3).ToUpper() == "CBO"))
                        cv.ErrorMessage = "[" + pv.Campo + "] Debe Seleccionar una Opción";
                    else
                        cv.ErrorMessage = "[" + pv.Campo + "] Valor Numérico fuera de Rango válido";

                    return false;
                }
                break;

            case "T":
            case "A":
            case "AC":
            case "AE":

                if (valor.Length < Convert.ToInt32(pv.ValorInicio) || valor.Length > Convert.ToInt32(pv.ValorFin))
                {
                    //Entra si el valor minimo o de inicio es menor al configurado
                    if (valor.Length < Convert.ToInt32(pv.ValorInicio))
                    {
                        cv.ErrorMessage = "[" + pv.Campo + "] Tamaño del Texto esta afuera su rangos válidos, minimo " + pv.ValorInicio + " caracteres";
                    }

                    //Entra si el valor maximo o de final es mayor al configurado
                    if (valor.Length > Convert.ToInt32(pv.ValorFin))
                    {
                        cv.ErrorMessage = "[" + pv.Campo + "] Tamaño del Texto esta afuera su rangos válidos, maximo " + pv.ValorFin + " caracteres";
                    }

                    return false;
                }
                break;
            case "F":

                if (valor.Length != 10)
                {
                    cv.ErrorMessage = "[" + pv.Campo + "] Fecha Inválida el Formato debe ser dd/mm/aaaa. Ej. 01/03/2011";
                    return false;
                }
                DateTime date = Convert.ToDateTime(valor);

                if (date < Convert.ToDateTime(pv.ValorInicio) || date > Convert.ToDateTime(pv.ValorFin))
                {
                    cv.ErrorMessage = "[" + pv.Campo + "] Fecha Inválida. Fuera del Rango de Fechas válidas";
                    return false;
                }
                break;
            case "Y":
                //Valida el rango del año
                val = Convert.ToDouble(valor);
                int YearNow = DateTime.Now.Year;

                //if (val < Convert.ToDouble(pv.ValorInicio) || val > Convert.ToDouble(pv.ValorFin))
                if (val < Convert.ToDouble(pv.ValorInicio) || val > Convert.ToDouble(YearNow))
                {
                    cv.ErrorMessage = "[" + pv.Campo + "] Valor del Año fuera de Rango válido";

                    return false;
                }
                break;
            case "PO":
                val = Convert.ToDouble(valor);

                if (val < Convert.ToInt32(pv.ValorInicio) || val > Convert.ToInt32(pv.ValorFin))
                {
                    cv.ErrorMessage = "[" + pv.Campo + "] Tamaño del Porcentaje fuera de su rangos válidos";
                    return false;
                }
                break;
            case "DI":
                val = Convert.ToDouble(valor);

                if (val < Convert.ToInt64(pv.ValorInicio) || val > Convert.ToInt64(pv.ValorFin))
                {
                    cv.ErrorMessage = "[" + pv.Campo + "] Tamaño del Dinero fuera de su rangos válidos";
                    return false;
                }
                break;
            case "D":

                if (valor.Length < Convert.ToInt32(pv.ValorInicio) || valor.Length > Convert.ToInt32(pv.ValorFin))
                {
                    //Entra si el valor minimo o de inicio es menor al configurado
                    if (valor.Length < Convert.ToInt32(pv.ValorInicio))
                    {
                        cv.ErrorMessage = "[" + pv.Campo + "] Tamaño del Texto Domicilio fuera de su rangos válidos, minimo " + pv.ValorInicio + " caracteres";
                    }

                    //Entra si el valor maximo o de final es mayor al configurado
                    if (valor.Length > Convert.ToInt32(pv.ValorFin))
                    {
                        cv.ErrorMessage = "[" + pv.Campo + "] Tamaño del Texto Domicilio fuera de su rangos válidos, maximo " + pv.ValorFin + " caracteres";
                    }

                    return false;
                }
                break;
            default:
                break;
        }

        return true;
    }

    public static bool ValidarSoloTexto(string Valor)
    {

        foreach (char c in Valor)
        {
            if ((Char.IsLetter(c) == false) && (Char.IsWhiteSpace(c) == false))
            {
                return false;
            }
        }
        return true;
    }

    public static bool ValidarCheckListRequired(CustomValidator cv, CheckBoxList cbl)
    {
        cv.Text = "(*)";

        string Pagina = cv.Page.ToString();

        ParametrosValidacion pv = GetParametros(cbl.ID, Pagina.Substring(4, Pagina.Length - 9).ToUpper());

        bool flg = false;

        foreach (ListItem item in cbl.Items)
        {
            if (item.Selected == true)
            {
                flg = true;
                cv.ErrorMessage = "";
                break;
            }

            cv.ErrorMessage = "[" + pv.Campo + "] Debe seleccionar por lo menos uno.";
        }

        return flg;
    }

    public static ParametrosValidacion GetParametros(string Campo, string Pagina)
    {
        ParametrosValidacion pv = new ParametrosValidacion();

        foreach (DataRow dr in Validaciones.Tables[Pagina].Rows)
        {
            if (dr["VAFCONTROL"].ToString() == Campo)
            {
                pv.Control = dr["VAFCONTROL"].ToString();
                pv.Campo = dr["VAFCAMPO"].ToString();
                pv.Requerido = dr["VAFOBLIGATORIO"].ToString();
                pv.TipoCampo = dr["VAFTIPO_DATO_ID"].ToString();
                pv.ValorInicio = dr["VAFVALOR_DESDE"].ToString();
                pv.ValorFin = dr["VAFVALOR_HASTA"].ToString();

                break;
            }
        }
        return pv;
    }

    public static bool NullValueValidation(string valor)
    {
        return string.IsNullOrEmpty(valor);
    }

    ///<summary>
    ///Sobrecargado con msj de descripcion
    ///<param name="args">Parametro args del CustomValidator</param>
    ///<param name="msj">Parametro de salida que retorna el mensaje: "Dato obligatorio", que devuelve para asignar al ErrorMessage del CustomValidator</param>
    ///</summary>
    public static ServerValidateEventArgs NullValueValidation(ServerValidateEventArgs args, out string msj)
    {
        args.IsValid = !string.IsNullOrEmpty(args.Value);
        if (!args.IsValid)
        {
            msj = "Dato obligatorio";
            return args;
        }// else { msj = ""; };
        msj = "";
        return args;
    }

    public static bool StringValueValidation(string valor, string TipoCampo)
    {

        char[] charValidos;
        switch (TipoCampo)
        {
            case "E":
                char[] charEmail = { '@', '&', '.', '-', '_' };
                charValidos = charEmail;
                break;
            case "F":
                char[] charFechas = { '/', '-' };
                charValidos = charFechas;
                break;
            case "N":
            case "I":
            case "L":
                char[] charNumericos = { '-', '.', ',' };
                charValidos = charNumericos;
                break;
            case "PO":
                char[] charPorcentajes = { ',' };
                charValidos = charPorcentajes;
                break;
            case "DI":
                char[] charDinero = { ',' };
                charValidos = charDinero;
                break;
            case "D":
                //Para domicilio lo hago salir porque valida la expresion regular
                return true;
            case "AC":
                //Para Alfanumericos con Caracteres Especiales (como Libros de Rubrica)
                char[] charAlfanumerico = { '-', '#' };
                charValidos = charAlfanumerico;
                break;
            case "AE":
                //Para Alfanumericos con Caracteres Especiales Extra (como Observaciones)
                char[] charAlfanumericoExtra = { '-', '#', '¿', '?', '_', '.', ';', ',', '(', ')', '°', '\'', '\"' };
                charValidos = charAlfanumericoExtra;
                break;
            default:
                char[] charDefecto = { '&' };
                charValidos = charDefecto;
                break;
        }

        bool FlagValido;

        foreach (char ch in valor)
        {
            FlagValido = false;

            foreach (char c in charValidos)
            {
                if (c == ch)
                {
                    FlagValido = true;
                    break;
                }
            }

            if ((FlagValido == false) && (char.IsSymbol(ch) || char.IsPunctuation(ch)))
            {
                return false;
            }
        }
        return true;
    }

    /* public static ServerValidateEventArgs NumericValueValidation(ServerValidateEventArgs args)
     {
         int p;
         args.IsValid = int.TryParse(args.Value, out p);
         return 0.args;
     }*/
    ///<summary>
    ///Sobrecargado con msj de descripcion
    ///<param name="args">Parametro args del CustomValidator</param>
    ///<param name="msj">Parametro de salida que retorna el mensaje: "E-Mail no valido", que devuelve para asignar al ErrorMessage del CustomValidator</param>
    ///</summary>
    public static bool EMailValueValidator(string valor)
    {
        Regex _isNumber = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        Match ok = _isNumber.Match(valor);
        return ok.Success;
    }

    public static bool PorcentajeValidator(string valor)
    {
        Regex _isNumber = new Regex(@"^(\d+|\d{0,3}[,]\d{0,2})%?$");
        Match ok = _isNumber.Match(valor);
        return ok.Success;
    }

    public static bool DineroValidator(string valor)
    {
        //Maximo 13 digitos y 2 decimales
        Regex _isNumber = new Regex(@"^(\d+|\d{0,13}[,]\d{0,2})%?$");
        Match ok = _isNumber.Match(valor);
        return ok.Success;
    }

    public static ServerValidateEventArgs StringNumericValidation(ServerValidateEventArgs args)
    {
        foreach (char ch in args.Value)
        {
            if (char.IsPunctuation(ch) || char.IsSymbol(ch))
            {
                args.IsValid = false;
                return args;
            }
        }
        return args;
    }

    public static bool ValidarCuit(string numerocuit, out string mensaje)
    {

        mensaje = "";
        int suma, longitud, valor1, valor2;

        suma = 0;

        string final;

        longitud = numerocuit.Length;

        string patron = "5432765432";



        if (longitud == 11)
        {
            if (numerocuit.Substring(0, 2).CompareTo("20") == 0 || numerocuit.Substring(0, 2).CompareTo("23") == 0 || numerocuit.Substring(0, 2).CompareTo("24") == 0 || numerocuit.Substring(0, 2).CompareTo("27") == 0 || numerocuit.Substring(0, 2).CompareTo("30") == 0 || numerocuit.Substring(0, 2).CompareTo("33") == 0 || numerocuit.Substring(0, 2).CompareTo("34") == 0)
            {

                final = numerocuit[10].ToString();

                for (int i = 0; i <= 9; i++)
                {

                    try
                    {
                        suma += int.Parse(patron[i].ToString()) * int.Parse(numerocuit[i].ToString());
                    }
                    catch
                    {
                        mensaje = "El numero tiene caracteres";
                        return false;
                    }
                }

                valor1 = suma % 11;
                valor2 = 11 - valor1;


                if (valor2 == 11)
                {
                    valor2 = 0;
                }

                else if (valor2 == 10)
                {
                    valor2 = 9;
                }


                if (String.Equals(Convert.ToString(valor2), final))
                    return true;
                else
                    mensaje = " Fin del Cuit erroneo";
                return false;
            }

            else
            {
                mensaje = " Comienzo del Cuit erroneo";
                return false;
            }
        }
        else
        {
            mensaje = " Longitud del Cuit erronea";
            return false;

        }
    }

    public static bool ValidarNumerosRomanos(string numero, out string mensaje)
    {
        mensaje = "";

        Regex rgx = new Regex(@"^(?i:(?=[MDCLXVI])((M{0,3})((C[DM])|(D?C{0,3}))?((X[LC])|(L?XX{0,2})|L)?((I[VX])|(V?(II{0,2}))|V)?))$");

        //Valido de que se trate de una sola palabra
        string[] aux = numero.Split(' ');
        if ((aux.Count() > 1) || (aux.Count() < 0))
        {
            mensaje = "No se permiten espacios";
            return false;
        }

        //Valido el formato
        Match _Match = rgx.Match(numero);

        if (!_Match.Success)
        {
            mensaje = "Formato de Numeros Romanos Invalido";
            return false;
        }

        return true; ;
    }
}

