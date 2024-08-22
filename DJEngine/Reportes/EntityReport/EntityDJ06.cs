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
    /// Clase Entity Reporte 06
    /// </summary>
    public class EntityDJ06
    {
        public EntityDJ06()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }

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

        private string _ENTNROCORRELATIVO;

        public string ENTNROCORRELATIVO
        {
            get { return _ENTNROCORRELATIVO; }
            set { _ENTNROCORRELATIVO = value; }
        }

        private string _ENTNROCUIT;

        public string ENTNROCUIT
        {
            get { return _ENTNROCUIT; }
            set { _ENTNROCUIT = value; }
        }

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

        private string _DJPFECHA;

        public string DJPFECHA
        {
            get { return _DJPFECHA; }
            set { _DJPFECHA = value; }
        }

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

        private string _APORAZONSOCIAL;

        public string APORAZONSOCIAL
        {
            get { return _APORAZONSOCIAL; }
            set { _APORAZONSOCIAL = value; }
        }

        private string _APOPERSONAFISICA;

        public string APOPERSONAFISICA
        {
            get { return _APOPERSONAFISICA; }
            set { _APOPERSONAFISICA = value; }
        }

        private string _FONCARACTERFONDO;

        public string FONCARACTERFONDO
        {
            get { return _FONCARACTERFONDO; }
            set { _FONCARACTERFONDO = value; }
        }

        private string _FONTIPOINGRESO;

        public string FONTIPOINGRESO
        {
            get { return _FONTIPOINGRESO; }
            set { _FONTIPOINGRESO = value; }
        }

        private string _FONOTROINSTRUMENTO;

        public string FONOTROINSTRUMENTO
        {
            get { return _FONOTROINSTRUMENTO; }
            set { _FONOTROINSTRUMENTO = value; }
        }

        private string _FONENTIDADBANCARIA;

        public string FONENTIDADBANCARIA
        {
            get { return _FONENTIDADBANCARIA; }
            set { _FONENTIDADBANCARIA = value; }
        }

        private string _FONNROCUENTA;

        public string FONNROCUENTA
        {
            get { return _FONNROCUENTA; }
            set { _FONNROCUENTA = value; }
        }

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

        private string _TIPODDJJ;

        public string TIPODDJJ
        {
            get { return _TIPODDJJ; }
            set { _TIPODDJJ = value; }
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

        private string _ESCAPELLIDO;//          VARCHAR2(1)    Y                  SI ESTA INCLUIDO EN ALGUN INCISO

        public string ESCAPELLIDO
        {
            get { return _ESCAPELLIDO; }
            set { _ESCAPELLIDO = value; }
        }

        private string _ESCNOMBRE;//          VARCHAR2(1)    Y                  SI ESTA INCLUIDO EN ALGUN INCISO

        public string ESCNOMBRE
        {
            get { return _ESCNOMBRE; }
            set { _ESCNOMBRE = value; }
        }
        private string _ESCMATRICULA;//          VARCHAR2(1)    Y                  SI ESTA INCLUIDO EN ALGUN INCISO

        public string ESCMATRICULA
        {
            get { return _ESCMATRICULA; }
            set { _ESCMATRICULA = value; }
        }
        private string _ESCTOMO;

        public string ESCTOMO
        {
            get { return _ESCTOMO; }
            set { _ESCTOMO = value; }
        }

        private string _ESCFOLIO;

        public string ESCFOLIO
        {
            get { return _ESCFOLIO; }
            set { _ESCFOLIO = value; }
        }

        private string _MATNUMERO;

        public string MATNUMERO
        {
            get { return _MATNUMERO; }
            set { _MATNUMERO = value; }
        }

        private string _MATFOLIO;

        public string MATFOLIO
        {
            get { return _MATFOLIO; }
            set { _MATFOLIO = value; }
        }

        private string _MATFECHA;

        public string MATFECHA
        {
            get { return _MATFECHA; }
            set { _MATFECHA = value; }
        }

    }
}
