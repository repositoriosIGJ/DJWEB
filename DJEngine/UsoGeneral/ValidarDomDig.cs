using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;

namespace DJEngine.UsoGeneral
{
    public class ValidarDomDig
    {
        #region Propiedades

        //Codigo de Validacion del DD
        private string _Codigo;

        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        //private WizardEngine _oWzd;
        //public WizardEngine oWzd
        //{
        //    get { return _oWzd; }
        //    set { _oWzd = value; }
        //}        

        //private Usuario _oUsuario;
        //public Usuario oUsuario
        //{
        //    get 
        //    {
        //        _oUsuario = (Usuario) HttpContext.Current.Session["BRUsuario"];                
        //        return _oUsuario; 
        //    }
        //    set 
        //    { 
        //        _oUsuario = value;
        //        HttpContext.Current.Session["usuario"] = _oUsuario;
        //    }
        //}

        //private DomDig _oDomDig;
        //public DomDig oDomDig
        //{
        //    get { return _oDomDig; }
        //    set { _oDomDig = value; }
        //}

       
        //private BussinesRules.Entities.PersonaFisica _oPersonaF;
        //public BussinesRules.Entities.PersonaFisica oPersonaF
        //{
        //    get { return _oPersonaF; }
        //    set { _oPersonaF = value; }
        //}

        //public string Cargo { get; set; }

        //public int EnvioEmail { get; set; }

        #endregion
              
        //public ValidarDomDig() : base((int)EnumBR.ETipoOperacion.CAMBIODOMDIG)
        //{
        //}

        public bool Load(long __OperacionId)
        {
            return true;

            //base.Load(__OperacionId);

            //Conn.AddParameter("p_OperacionId", __OperacionId);
            //DataSet ds = Conn.ExecuteSP("PKG_SAEBR.Get_Operacion_DD");

            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //   DataRow dr = ds.Tables[0].Rows[0];
            //    if (dr["ddnuevo"] != DBNull.Value)
            //    {
            //        this.oDomDig = new DomDig();
            //        this.oDomDig.NuevoDomDig = dr["ddnuevo"].ToString();
            //        this.oDomDig.CodVal = dr["CodVal"].ToString(); 
            //    }

            //    if (dr["nombre"] != DBNull.Value)
            //    {
            //        this.oPersonaF = new PersonaFisica();
            //        this.oPersonaF.Nombre = dr["nombre"].ToString();
            //        this.oPersonaF.Apellido = dr["apellido"].ToString();
                    
            //        if (dr["tipodocid"] != DBNull.Value)
            //            this.oPersonaF.TipoDocId = Convert.ToInt32(dr["tipodocid"].ToString());
                    
            //        this.oPersonaF.NroDoc = dr["nrodoc"].ToString();
            //        this.Cargo = dr["cargo"].ToString();
            //    }

            //    this.EnvioEmail = Convert.ToInt32(dr["EnvioEmail"]);

                
            //    return true;
            //}

            //return false;
        }

        public bool RegistrarEmailEnviado()
        {
            return true;

            //Conn.AddParameter("p_operacionid", OperacionId);
            //Conn.AddParameter("p_EnvioEmail", 1);
            //Conn.AddParameter("p_CodVal", oDomDig.CodVal);
            //Conn.AddParamOutNumber("p_status");
            //Conn.AddParamOutVarchar("p_mensaje", 255);

            //bool rlt = Conn.ExecuteSPNoQuery("PKG_SAEBR.Reg_Operacion_DD");

            //if (rlt == true)
            //    EnvioEmail = 1;
            //return rlt;
        }

        //public bool Guardar()
        //{
        //    /* REGISTRAR OPERACION */
        //    if (base.Guardar())
        //        if (this.RegistrarDatos())
        //            return true;
        //    return false;
                
        //}

        //public override void GenerarReporte(bool imprimir)
        //{
        //    SAE.Report.Entities.RO01Data d01 = new SAE.Report.Entities.RO01Data();

        //    d01.EntApodo = oUsuario.oSUsuario.Apodo;

        //    d01.TipoOperacion = this.oTipoOperacion.TipoOperacionID;
        //    d01.UsuarioID = this.oUsuario.oSUsuario.UsuarioId;
        //    d01.EntNombre = oUsuario.oPersonaJ.RazonSocial;
        //    d01.EntTipo = new TiposSocietario(oUsuario.oPersonaJ.TipoSocId).Acronimo;

        //    d01.RepNombre = oPersonaF.Nombre;
        //    d01.RepApellido = oPersonaF.Apellido;
        //    d01.RepNroDocumento = oPersonaF.NroDoc;
        //    d01.RepTipoDocumento = new TiposDocumento(oPersonaF.TipoDocId).Acronimo;
            
        //    d01.RepCargo = Cargo;

        //    d01.DDNuevo = oDomDig.NuevoDomDig;
        //    d01.DDActual = oUsuario.oSUsuario.Email;

        //    d01.NroOperacion = this.OperacionId;
            

        //    if (DocumentoBinario.Binario == null)
        //    {

        //        d01.GenerarBinario();

        //        DocumentoBinario.Nombre = this.OperacionId.ToString("0000000000");
        //        DocumentoBinario.Extension = "pdf";
        //        DocumentoBinario.Binario = d01.Binario;
        //        /*DocumentoBinario.Guardar();
        //        Guardar();*/
        //    }
        //    DocumentoBinario.Download();
        //}

        public bool ValidarCodigo(string codigo)
        {
            return true;

            //string msg;
            //bool rlt = this.oDomDig.CompararCodVal(codigo, out msg);

            //MsgOperacion = msg;
            
            //// SI ES VALIDO
            //if (rlt == true)
            //{
            //    oDomDig.CodVal = codigo;
            //}
            //return rlt;
        }

        public bool RegistrarDatos()
        {
            return true;

            //try
            //{
            //    /*OBTENGO EL DOMICILIO ACTUAL*/
            //    string ddActual = ((Usuario)HttpContext.Current.Session["BRUsuario"]).oSUsuario.Email;
            //    // si es primera vez
            //    if (OperacionId != 0)
            //    {
            //        Conn.AddParameter("p_operacionid", OperacionId);
            //        Conn.AddParameter("p_DDActual", ddActual);

                    
            //            /*fue cargado el nuevo domicilio*/

            //            if (this.oDomDig != null)
            //            {
            //                Conn.AddParameter("p_DDNuevo", oDomDig.NuevoDomDig);
            //                Conn.AddParameter("p_CodVal", oDomDig.CodVal);
            //            }

            //            if (this.oPersonaF != null)
            //            {
            //                Conn.AddParameter("p_Nombre", oPersonaF.Nombre);
            //                Conn.AddParameter("p_Apellido", oPersonaF.Apellido);
            //                Conn.AddParameter("p_TipoDocID", oPersonaF.TipoDocId);
            //                Conn.AddParameter("p_NroDoc", oPersonaF.NroDoc);
            //                Conn.AddParameter("p_Cargo", Cargo);
            //            }
                    
            //        Conn.AddParamOutNumber("p_status");
            //        Conn.AddParamOutVarchar("p_mensaje", 255);

            //        if (Conn.ExecuteSPNoQuery("PKG_SAEBR.Reg_Operacion_DD") == false)
            //            throw new Exception();

            //        return true;
            //    }

            //    return false;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}           
        }

        public bool EnviarAviso()
        {
            return true;

            //// TODO: VER COMO ENVIAR MSG A CAPA DE VALIDACION
            //string msg;
            
            //bool rt = oDomDig.InsertarNuevoDomDig(out msg);
            //MsgOperacion = msg;

            //bool rlt = EnviarAvisoCambioDomDig();

            //bool rlt1 = EnviarCambioDomDig();

            //bool rltR = RegistrarEmailEnviado();

            //return (rt && rlt && rlt1 && rltR);
        }

        //public override ListItemCollection Resumen()
        //{
        //    ListItemCollection res = new ListItemCollection();
            
        //    //res.Add(new ListItem("DOMICILIO DIGITAL ACTIVO:",this.oUsuario.oSUsuario.Email));
        //    //res.Add(new ListItem("DOMICLIO DIGITAL NUEVO:",this.oDomDig.NuevoDomDig));
        //    //res.Add(new ListItem("REPRESENTANTE NOMBRE:",this.oPersonaF.Nombre));
        //    //res.Add(new ListItem("APELLIDO:",this.oPersonaF.Apellido));
        //    //res.Add(new ListItem("TIPO DOC:",new TiposDocumento(this.oPersonaF.TipoDocId).Acronimo));
        //    //res.Add(new ListItem("NRO DOC:",this.oPersonaF.NroDoc));
        //    //res.Add(new ListItem("CARGO:",this.Cargo));

        //    return res;
        //}

        //private bool EnviarAvisoCambioDomDig()
        //{
        //    try
        //    {
        //        Postino postino = new Postino();
        //        /////////////////////////////////////////////////////////////////////////////////////////////////////
        //        ///// Envio al Email Actual para Aviso de Pedido de Cambio de Nuevo Dominio Digital via Postino /////
        //        /////////////////////////////////////////////////////////////////////////////////////////////////////

        //        postino.AddParametro("[@Fecha]", DateTime.Now.ToString("dd 'de' MMMM 'del' yyyy"));
        //        //Pregunto el tipo de personeria
        //        if (this.oUsuario.oSUsuario.oTipoUsuario.TipoPersoneriaId == (int)EnumSL.ETipoPersoneria.JURIDICA)
        //        {
        //            //si es persona Juridica meto la razon social como nombre
        //            postino.AddParametro("[@Nombre]", this.oUsuario.oPersonaJ.RazonSocial.ToUpper());
        //        }
        //        else
        //        {
        //            //si es persona Fisica meto el nombre y apellido como nombre
        //            postino.AddParametro("[@Nombre]", this.oUsuario.oPersonaF.Apellido.ToUpper() + ", " + this.oUsuario.oPersonaF.Nombre.ToUpper());
        //        }
        //        //postino.AddParametro("[@Nombre]", this.oUsuario.oSUsuario.Apodo);//Propenso a cambio - Propuesta de clase base persona
        //        postino.AddParametro("[@Apodo]", this.oUsuario.oSUsuario.Apodo);
        //        postino.AddParametro("[@DDActual]", this.oUsuario.oSUsuario.Email.ToLower());
        //        postino.AddParametro("[@DDNuevo]", this.oDomDig.NuevoDomDig.ToLower().Trim());
        //        return postino.EnviarCorreo(DateTime.Now, "SAE", "Solicitud para Cambio de Domicilio Digital", this.oUsuario.oSUsuario.Email.ToLower(), Postino.ETipoPlantilla.AVISONUEVODD);
        //    }
        //    catch (Exception ex)
        //    {//Pendiente-Manejo de error                
        //        throw ex;
        //    }
        //}

        //private bool EnviarCambioDomDig()
        //{
        //    try
        //    {
        //        Postino postino = new Postino();

        //        //////////////////////////////////////////////////////////////////////////////////////////
        //        ///// Envio al Email Nuevo Codigo de Validacion de Nuevo Dominio Digital via Postino /////
        //        //////////////////////////////////////////////////////////////////////////////////////////             

        //        postino.AddParametro("[@Fecha]", DateTime.Now.ToString("dd 'de' MMMM 'del' yyyy"));
        //        //Pregunto el tipo de personeria
        //        if (this.oUsuario.oSUsuario.oTipoUsuario.TipoPersoneriaId == (int)EnumSL.ETipoPersoneria.JURIDICA)
        //        {
        //            //si es persona Juridica meto la razon social como nombre
        //            postino.AddParametro("[@Nombre]", this.oUsuario.oPersonaJ.RazonSocial.ToUpper());
        //        }
        //        else
        //        {
        //            //si es persona Fisica meto el nombre y apellido como nombre
        //            postino.AddParametro("[@Nombre]", this.oUsuario.oPersonaF.Apellido.ToUpper() + ", " + this.oUsuario.oPersonaF.Nombre.ToUpper());
        //        }
        //        //postino.AddParametro("[@Nombre]", this.oUsuario.oSUsuario.Apodo);//TODO: Propenso a cambio - Propuesta de clase base persona
        //        postino.AddParametro("[@Apodo]", this.oUsuario.oSUsuario.Apodo);
        //        postino.AddParametro("[@Codval]", this.oDomDig.CodVal.ToString());
        //        postino.AddParametro("[@DDNuevo]", this.oDomDig.NuevoDomDig.ToLower().Trim());

        //        //Esta vez no lo envio al email actual del usuario sino al nuevo email ingresado en el formulario
        //        return postino.EnviarCorreo(DateTime.Now, "SAE", "Validación de Nuevo Domicilio Digital", this.oDomDig.NuevoDomDig.ToLower().Trim(), Postino.ETipoPlantilla.VALNUEVODD);
        //    }
        //    catch (Exception ex)
        //    {//Pendiente-Manejo de error                
        //        throw ex;
        //    }
        //}

        //Genera el Codigo de Validacion para el Domicilio Digital
        public string GenerarCodVal()
        {
            int longitud = 8;

            Random rnd = new Random((int)DateTime.Now.Ticks);

            StringBuilder s = new StringBuilder(longitud);

            //Obligo a que ingrese como primer caracter una letra 
            //Desde la letra A MAYUSCULA (65) hasta la letra Z MAYUSCULA (90)
            s.Append((char)(rnd.Next(65, 90)));
            //Obligo a que ingrese como primer caracter un numero
            //Desde el numero 0 (48) hasta el numero 9 (57)
            s.Append((char)(rnd.Next(48, 57)));
            // Un bucle para cada uno de los caracteres
            for (int i = 3; i <= longitud; i++)
            {
                char c;

                // El valor debe ser un carácter válido
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        //Desde el numero 0 (48) hasta el numero 9 (57)
                        c = (char)(rnd.Next(48, 57));
                        break;
                    case 2:
                        //Desde la letra A MAYUSCULA (65) hasta la letra Z MAYUSCULA (90)
                        c = (char)(rnd.Next(65, 90));
                        break;
                    default:
                        //Desde la letra a minuscula (97) hasta la letra z minuscula (122)
                        c = (char)(rnd.Next(97, 123));
                        break;
                }

                //Lo añadimos a la cadena
                s.Append(c);
            }

            //***************************************//
            //*****  CALCULO DE HASH DE LA CLAVE ****//
            //***************************************//

            // Devolvemos la cadena generada
            SHA1Managed algoritmoHash = new SHA1Managed();

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

            byte[] bhsh = algoritmoHash.ComputeHash(encoding.GetBytes(s.ToString()));
            string hsh = "";

            foreach (byte b in bhsh)
            {
                hsh += b.ToString("X2");
            }

            Codigo = hsh;
            return hsh;
        }

    }
}

