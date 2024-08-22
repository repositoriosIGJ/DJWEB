using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace DJEngine.Reportes.EntityReport
{
    /// <summary>
    /// Clase Entity Reporte 04
    /// </summary>
    public class EntityDJ04
    {
        public EntityDJ04()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }

        ///////////////////////////////////
        /// EMPIEZA DATOS DE LA ENTIDAD ///
        ///////////////////////////////////

        #region "Datos de la Entidad"

        private string _ENTINSCRIPTA;

        public string ENTINSCRIPTA
        {
            get { return _ENTINSCRIPTA; }
            set { _ENTINSCRIPTA = value; }
        }

        private string _ENTRAZONSOCIAL;

        public string ENTRAZONSOCIAL
        {
            get { return _ENTRAZONSOCIAL; }
            set { _ENTRAZONSOCIAL = value; }
        }

        private string _ENTTIPOSOCIETARIO;

        public string ENTTIPOSOCIETARIO
        {
            get { return _ENTTIPOSOCIETARIO; }
            set { _ENTTIPOSOCIETARIO = value; }
        }

        private string _ENTTIPOSOCDESC;

        public string ENTTIPOSOCDESC
        {
            get { return _ENTTIPOSOCDESC; }
            set { _ENTTIPOSOCDESC = value; }
        }
        
        private string _ENTNROCORRELATIVO;

        public string ENTNROCORRELATIVO
        {
            get { return _ENTNROCORRELATIVO; }
            set { _ENTNROCORRELATIVO = value; }
        }

        private string _DJPMEMBRETE;

        public string DJPMEMBRETE
        {
            get { return _DJPMEMBRETE; }
            set { _DJPMEMBRETE = value; }
        }

        private string _ENTNROCUIT;

        public string ENTNROCUIT
        {
            get { return _ENTNROCUIT; }
            set { _ENTNROCUIT = value; }
        }

        #endregion "Datos de la Entidad"

        ///////////////////////////////////
        /// TERMINA DATOS DE LA ENTIDAD ///
        ///////////////////////////////////        

        //////////////////////////////////////////////
        /// EMPIEZA DATOS DEL PRESIDENTE O TITULAR ///
        //////////////////////////////////////////////

        #region "Datos del Presidente o Titular"

        private string _TITNOMBRE;

        public string TITNOMBRE
        {
            get { return _TITNOMBRE; }
            set { _TITNOMBRE = value; }
        }

        private string _TITAPELLIDO;

        public string TITAPELLIDO
        {
            get { return _TITAPELLIDO; }
            set { _TITAPELLIDO = value; }
        }

        private string _TITTIPODOC;


        public string TITTIPODOC
        {
            get { return _TITTIPODOC; }
            set { _TITTIPODOC = value; }
        }

        private string _TITNRODOC;

        public string TITNRODOC
        {
            get { return _TITNRODOC; }
            set { _TITNRODOC = value; }
        }

        private string _TITTIPOCLAVEFISCAL;

        public string TITTIPOCLAVEFISCAL
        {
            get { return _TITTIPOCLAVEFISCAL; }
            set { _TITTIPOCLAVEFISCAL = value; }
        }

        private string _TITNROCLAVEFISCAL;

        public string TITNROCLAVEFISCAL
        {
            get { return _TITNROCLAVEFISCAL; }
            set { _TITNROCLAVEFISCAL = value; }
        }

        #endregion "Datos del Presidente o Titular"

        //////////////////////////////////////////////
        /// TERMINA DATOS DEL PRESIDENTE O TITULAR ///
        //////////////////////////////////////////////

        //SI ES PERSONA FISICA (1) o JURIDICA (0)
        private string _APOPERSONAFISICA;

        public string APOPERSONAFISICA
        {
            get { return _APOPERSONAFISICA; }
            set { _APOPERSONAFISICA = value; }
        }

        ///////////////////////////////////////////////////////
        /// EMPIEZA DATOS DE LA PERSONA APORTANTE O DONANTE ///
        ///////////////////////////////////////////////////////

        #region "Datos de la Persona Fisica Aportante"

        private string _APONOMBRE;

        public string APONOMBRE
        {
            get { return _APONOMBRE; }
            set { _APONOMBRE = value; }
        }

        private string _APOAPELLIDO;

        public string APOAPELLIDO
        {
            get { return _APOAPELLIDO; }
            set { _APOAPELLIDO = value; }
        }

        private string _APOTIPODOC;

        public string APOTIPODOC
        {
            get { return _APOTIPODOC; }
            set { _APOTIPODOC = value; }
        }

        private string _APONRODOC;

        public string APONRODOC
        {
            get { return _APONRODOC; }
            set { _APONRODOC = value; }
        }

        private string _APOTIPOCLAVEFISCAL;

        public string APOTIPOCLAVEFISCAL
        {
            get { return _APOTIPOCLAVEFISCAL; }
            set { _APOTIPOCLAVEFISCAL = value; }
        }

        private string _APONROCLAVEFISCAL;

        public string APONROCLAVEFISCAL
        {
            get { return _APONROCLAVEFISCAL; }
            set { _APONROCLAVEFISCAL = value; }
        }

        #endregion "Datos de la Persona Fisica Aportante"

        #region "Datos de la Persona Juridica Aportante"

        private string _APORAZONSOCIAL;

        public string APORAZONSOCIAL
        {
            get { return _APORAZONSOCIAL; }
            set { _APORAZONSOCIAL = value; }
        }

        private string _APONROCUITPJ;

        public string APONROCUITPJ
        {
            get { return _APONROCUITPJ; }
            set { _APONROCUITPJ = value; }
        }

        #endregion "Datos de la Persona Juridica Aportante"

        ///////////////////////////////////////////////////////
        /// TERMINA DATOS DE LA PERSONA APORTANTE O DONANTE ///
        ///////////////////////////////////////////////////////        

        //////////////////////////////////////
        /// EMPIEZA CARACTER DE LOS FONDOS ///
        //////////////////////////////////////

        #region "Caracter de los Fondos"

        //TIPO DE CARACTER DE LOS FONDOS: DONACION (1) O APORTE DE TERCEROS (2)
        private string _FONCARACTERFONDO;

        public string FONCARACTERFONDO
        {
            get { return _FONCARACTERFONDO; }
            set { _FONCARACTERFONDO = value; }
        }

        //FONORIGEN //FONDOS - ORIGEN DE LOS APORTES - DESCRIPCION
        private string _FONORIGEN;

        public string FONORIGEN
        {
            get { return _FONORIGEN; }
            set { _FONORIGEN = value; }
        }

        //FONFECHACF //FONDOS - FECHA DE LOS APORTES
        private string _FONFECHACF;

        public string FONFECHACF
        {
            get { return _FONFECHACF; }
            set { _FONFECHACF = value; }
        }

        #endregion "Caracter de los Fondos"

        //////////////////////////////////////
        /// TERMINA CARACTER DE LOS FONDOS ///
        //////////////////////////////////////        

        //TIPO DE APORTE O DONACION: EFECTIVO (1) - ESPECIES (2)
        private string _FONTIPOINGRESO;

        public string FONTIPOINGRESO
        {
            get { return _FONTIPOINGRESO; }
            set { _FONTIPOINGRESO = value; }
        }

        ////////////////////////////////////////
        /// EMPIEZA INSTRUMENTOS EN EFECTIVO ///
        ////////////////////////////////////////

        #region "Instrumentos en Efectivo"

        //FONTIPOINSTRUMENTOEFE //exFONTIPOEFECTIVO
        private string _FONTIPOINSTRUMENTOEFE;

        public string FONTIPOINSTRUMENTOEFE
        {
            get { return _FONTIPOINSTRUMENTOEFE; }
            set { _FONTIPOINSTRUMENTOEFE = value; }
        }

        //DEPOSITO BANCARIO
        //EFEENTBANDEPOSITO //ex EFEENTBANCARIADEP
        private string _EFEENTBANDEPOSITO;

        public string EFEENTBANDEPOSITO
        {
            get { return _EFEENTBANDEPOSITO; }
            set { _EFEENTBANDEPOSITO = value; }
        }

        //EFETIPOCUENTADEPOSITO //Descripcion //NUEVO!!
        private string _EFETIPOCUENTADEPOSITO;

        public string EFETIPOCUENTADEPOSITO
        {
            get { return _EFETIPOCUENTADEPOSITO; }
            set { _EFETIPOCUENTADEPOSITO = value; }
        }

        //EFENROCUENTADEPOSITO //ex EFENROCUENTADEP
        private string _EFENROCUENTADEPOSITO;

        public string EFENROCUENTADEPOSITO
        {
            get { return _EFENROCUENTADEPOSITO; }
            set { _EFENROCUENTADEPOSITO = value; }
        }

        //TRANSFERENCIA BANCARIA
        //DONANTE
        //EFEENTBANDONANTE //ex EFEENTBANCARIADON
        private string _EFEENTBANDONANTE;

        public string EFEENTBANDONANTE
        {
            get { return _EFEENTBANDONANTE; }
            set { _EFEENTBANDONANTE = value; }
        }

        //EFETIPOCUENTADONANTE //Descripcion //NUEVO!!
        private string _EFETIPOCUENTADONANTE;

        public string EFETIPOCUENTADONANTE
        {
            get { return _EFETIPOCUENTADONANTE; }
            set { _EFETIPOCUENTADONANTE = value; }
        }

        //EFENROCUENTADONANTE //ex EFENROCUENTADON
        private string _EFENROCUENTADONANTE;

        public string EFENROCUENTADONANTE
        {
            get { return _EFENROCUENTADONANTE; }
            set { _EFENROCUENTADONANTE = value; }
        }

        //DONATARIO
        //EFEENTBANDONATARIO//ex EFEENTIDADBANCARIA
        private string _EFEENTBANDONATARIO;

        public string EFEENTBANDONATARIO
        {
            get { return _EFEENTBANDONATARIO; }
            set { _EFEENTBANDONATARIO = value; }
        }

        //EFETIPOCUENTADONATARIO //Descripcion //NUEVO!!
        private string _EFETIPOCUENTADONATARIO;

        public string EFETIPOCUENTADONATARIO
        {
            get { return _EFETIPOCUENTADONATARIO; }
            set { _EFETIPOCUENTADONATARIO = value; }
        }

        //EFENROCUENTADONATARIO//ex EFENROCUENTA
        private string _EFENROCUENTADONATARIO;

        public string EFENROCUENTADONATARIO
        {
            get { return _EFENROCUENTADONATARIO; }
            set { _EFENROCUENTADONATARIO = value; }
        }

        //OTRO INSTRUMENTO
        private string _FONOTROINSTRUMENTO; //Descripcion

        public string FONOTROINSTRUMENTO
        {
            get { return _FONOTROINSTRUMENTO; }
            set { _FONOTROINSTRUMENTO = value; }
        }

        //EFEMONTO
        private string _EFEMONTO;

        public string EFEMONTO
        {
            get { return _EFEMONTO; }
            set { _EFEMONTO = value; }
        }

        //EFEMONTOPESOS
        private string _EFEMONTOPESOS;

        public string EFEMONTOPESOS
        {
            get { return _EFEMONTOPESOS; }
            set { _EFEMONTOPESOS = value; }
        }

        //EFEMONEDAID
        private int _EFEMONEDAID;

        public int EFEMONEDAID
        {
            get { return _EFEMONEDAID; }
            set { _EFEMONEDAID = value; }
        }

        //EFEMONEDADESC
        private string _EFEMONEDADESC;

        public string EFEMONEDADESC
        {
            get { return _EFEMONEDADESC; }
            set { _EFEMONEDADESC = value; }
        }

        #endregion "Instrumentos en Efectivo"

        ////////////////////////////////////////
        /// TERMINA INSTRUMENTOS EN EFECTIVO ///
        ////////////////////////////////////////

        /////////////////////////////////
        /// EMPIEZA BIENES EN ESPECIE ///
        /////////////////////////////////

        #region "Bienes en Especie"

        //FONTIPOBIEN
        private string _FONTIPOBIEN;

        public string FONTIPOBIEN
        {
            get { return _FONTIPOBIEN; }
            set { _FONTIPOBIEN = value; }
        }

        //ESPDESCRIPCIONBIEN
        private string _ESPDESCRIPCIONBIEN;

        public string ESPDESCRIPCIONBIEN
        {
            get { return _ESPDESCRIPCIONBIEN; }
            set { _ESPDESCRIPCIONBIEN = value; }
        }

        //ESPVALUACION //exFONTIPOESPECIE
        private string _ESPVALUACION;

        public string ESPVALUACION
        {
            get { return _ESPVALUACION; }
            set { _ESPVALUACION = value; }
        }

        //ESPCANTIDAD
        private string _ESPCANTIDAD;

        public string ESPCANTIDAD
        {
            get { return _ESPCANTIDAD; }
            set { _ESPCANTIDAD = value; }
        }

        //ESPVALCORUNI
        private string _ESPVALCORUNI;

        public string ESPVALCORUNI
        {
            get { return _ESPVALCORUNI; }
            set { _ESPVALCORUNI = value; }
        }

        //ESPVALCORTOT
        private string _ESPVALCORTOT;

        public string ESPVALCORTOT
        {
            get { return _ESPVALCORTOT; }
            set { _ESPVALCORTOT = value; }
        }
        
        #endregion "Bienes en Especie"

        /////////////////////////////////
        /// TERMINA BIENES EN ESPECIE ///
        /////////////////////////////////

        /////////////////////
        /// EMPIEZA MONTO ///
        /////////////////////

        #region "Monto"

        private string _FONMASDEDOSCIENTOSMIL;

        public string FONMASDEDOSCIENTOSMIL
        {
            get { return _FONMASDEDOSCIENTOSMIL; }
            set { _FONMASDEDOSCIENTOSMIL = value; }
        }

        private string _DOCRESPALDATORIA;

        public string DOCRESPALDATORIA
        {
            get { return _DOCRESPALDATORIA; }
            set { _DOCRESPALDATORIA = value; }
        }

        #endregion "Monto"

        /////////////////////
        /// TERMINA MONTO ///
        /////////////////////        

        //////////////////////////////////////////////////
        /// EMPIEZA PROPIEDADES COMUNES A TODAS LAS DJ ///
        //////////////////////////////////////////////////

        #region "Propiedades Comunes a todas las DJ"

        private string _TIPODDJJ;

        public string TIPODDJJ
        {
            get { return _TIPODDJJ; }
            set { _TIPODDJJ = value; }
        }

        private string _DJPFECHA;

        public string DJPFECHA
        {
            get { return _DJPFECHA; }
            set { _DJPFECHA = value; }
        }

        private string _OPERACION;

        public string OPERACION
        {
            get { return _OPERACION; }
            set { _OPERACION = value; }
        }
        private byte[] _CODIGODEBARRAS;

        public byte[] CODIGODEBARRAS
        {
            get { return _CODIGODEBARRAS; }
            set { _CODIGODEBARRAS = value; }
        }

        private string _HASH;

        public string HASH
        {
            get { return _HASH; }
            set { _HASH = value; }
        }

        public string HashPart1
        {
            get { return _HASH.Substring(0, _HASH.Length - 6); }
        }

        public string HashPart2
        {
            get { return _HASH.Substring(_HASH.Length - 6); }
        }

        #endregion "Propiedades Comunes a todas las DJ"

        //////////////////////////////////////////////////
        /// TERMINA PROPIEDADES COMUNES A TODAS LAS DJ ///
        //////////////////////////////////////////////////

        
    }
}
