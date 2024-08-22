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
    /// Clase Entity Reporte 10
    /// </summary>
    public class EntityDJ10
    {
        private string _DJFPJFIDID;

        public string DJFPJFIDID
        {
            get { return _DJFPJFIDID; }
            set { _DJFPJFIDID = value; }
        }

        private string _DJPTIPODDJJ;

        public string DJPTIPODDJJ
        {
            get { return _DJPTIPODDJJ; }
            set { _DJPTIPODDJJ = value; }
        }

        private string _DJPFECHA;

        public string DJPFECHA
        {
            get { return _DJPFECHA; }
            set { _DJPFECHA = value; }
        }

        private string _DJPMEMBRETE;

        public string DJPMEMBRETE
        {
            get { return _DJPMEMBRETE; }
            set { _DJPMEMBRETE = value; }
        }

        /*----------------------------------*/
        /*- DATOS DE LA ENTIDAD FIDUCIANTE -*/
        /*----------------------------------*/

        private string _DJPNROCORENT; //NUMBER(7) Y //NUMERO CORRELATIVO DE LA ENTIDAD

        public string DJPNROCORENT
        {
            get { return _DJPNROCORENT; }
            set { _DJPNROCORENT = value; }
        }

        private string _DJPRAZSOCENT; //VARCHAR2(255)	Y //RAZON SOCIAL DE LA ENTIDAD (ex DJPRAZONSOCIAL)

        public string DJPRAZSOCENT
        {
            get { return _DJPRAZSOCENT; }
            set { _DJPRAZSOCENT = value; }
        }

        private string _DJPCONSTENT; //VARCHAR2(5) Y //SI LA ENTIDAD ESTA CONSTITUIDA EN IGJ O ES DE OTRA JURISDICCION (False = 0 y True = 1)

        public string DJPCONSTENT
        {
            get { return _DJPCONSTENT; }
            set { _DJPCONSTENT = value; }
        }

        private int _DJPTIPOENTID; //NUMBER Y //TIPO SOCIETARIO DE LA ENTIDAD ID (INDICE DE TABLA TIPO_SOCIETARIO)

        public int DJPTIPOENTID
        {
            get { return _DJPTIPOENTID; }
            set { _DJPTIPOENTID = value; }
        }

        private string _DJPTIPOENT; //VARCHAR2(255) Y //TIPO SOCIETARIO DE LA ENTIDAD (DESCRIPCION)

        public string DJPTIPOENT
        {
            get { return _DJPTIPOENT; }
            set { _DJPTIPOENT = value; }
        }

        private string _DJPCUITENT; //VARCHAR2(13) Y //CUIT DE LA ENTIDAD

        public string DJPCUITENT
        {
            get { return _DJPCUITENT; }
            set { _DJPCUITENT = value; }
        }

        /*--------------------------------*/
        /*- DATOS DEL BENEFICIARIO FINAL -*/
        /*--------------------------------*/

        private string _BENNOMBRE; //VARCHAR2(60) Y                  

        public string BENNOMBRE
        {
            get { return _BENNOMBRE; }
            set { _BENNOMBRE = value; }
        }

        private string _BENAPELLIDO; //VARCHAR2(60) Y                  

        public string BENAPELLIDO
        {
            get { return _BENAPELLIDO; }
            set { _BENAPELLIDO = value; }
        }

        private string _BENTIPODOC; //VARCHAR2(255) Y                  

        public string BENTIPODOC
        {
            get { return _BENTIPODOC; }
            set { _BENTIPODOC = value; }
        }

        private string _BENNRODOC; //VARCHAR2(255) Y                  

        public string BENNRODOC
        {
            get { return _BENNRODOC; }
            set { _BENNRODOC = value; }
        }

        private string _BENTIPOFISCAL;

        public string BENTIPOFISCAL
        {
            get { return _BENTIPOFISCAL; }
            set { _BENTIPOFISCAL = value; }
        }

        private string _BENNROFISCAL;

        public string BENNROFISCAL
        {
            get { return _BENNROFISCAL; }
            set { _BENNROFISCAL = value; }
        }

        private string _BENDOMREAL;

        public string BENDOMREAL
        {
            get { return _BENDOMREAL; }
            set { _BENDOMREAL = value; }
        }

        private string _BENNACIONAL;

        public string BENNACIONAL
        {
            get { return _BENNACIONAL; }
            set { _BENNACIONAL = value; }
        }

        private string _BENFECHANAC;

        public string BENFECHANAC
        {
            get { return _BENFECHANAC; }
            set { _BENFECHANAC = value; }
        }

        private string _BENPROFESION;

        public string BENPROFESION
        {
            get { return _BENPROFESION; }
            set { _BENPROFESION = value; }
        }

        private string _BENPORCENTAJE;

        public string BENPORCENTAJE
        {
            get { return _BENPORCENTAJE; }
            set { _BENPORCENTAJE = value; }
        }

        private string _BENONODDESC;

        public string BENONODDESC
        {
            get { return _BENONODDESC; }
            set { _BENONODDESC = value; }
        }

        /*----------------------*/
        /*- NUEVOS CAMPOS 2021 -*/
        /*----------------------*/

        private string _BENTIPOBENID;

        public string BENTIPOBENID
        {
            get { return _BENTIPOBENID; }
            set { _BENTIPOBENID = value; }
        }

        private string _BENTIPOBEN;

        public string BENTIPOBEN
        {
            get { return _BENTIPOBEN; }
            set { _BENTIPOBEN = value; }
        }

        private string _BENESTADOCIVIL;

        public string BENESTADOCIVIL
        {
            get { return _BENESTADOCIVIL; }
            set { _BENESTADOCIVIL = value; }
        }

        private string _BENCARACTER;

        public string BENCARACTER
        {
            get { return _BENCARACTER; }
            set { _BENCARACTER = value; }
        }

        private string _BENPORCENCARACTER;

        public string BENPORCENCARACTER
        {
            get { return _BENPORCENCARACTER; }
            set { _BENPORCENCARACTER = value; }
        }

        private string _BENEMAIL;

        public string BENEMAIL
        {
            get { return _BENEMAIL; }
            set { _BENEMAIL = value; }
        }

        private string _BENOBSERV;

        public string BENOBSERV
        {
            get { return _BENOBSERV; }
            set { _BENOBSERV = value; }
        }

        /*------------------*/
        /*- DATOS DE LA DJ -*/
        /*------------------*/

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
            get{ return _HASH.Substring(0,_HASH.Length-6);}
        }

        public string HashPart2
        {
            get { return _HASH.Substring(_HASH.Length - 6); }
        }

        public EntityDJ10()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }
    }
}
