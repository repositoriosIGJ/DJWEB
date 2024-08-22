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
    /// Clase Entity Reporte 09
    /// </summary>
    public class EntityDJ09
    {
        private string _DJFPJFIDID;

        public string DJFPJFIDID
        {
            get { return _DJFPJFIDID; }
            set { _DJFPJFIDID = value; }
        }

        /*-------------------------*/
        /*- DATOS DEL FIDEICOMISO -*/
        /*-------------------------*/

        private string _DJPNROCORFID; //VARCHAR2(255) Y                  

        public string DJPNROCORFID
        {
            get { return _DJPNROCORFID; }
            set { _DJPNROCORFID = value; }
        }

        private string _DJPRAZSOCFID; //VARCHAR2(255) Y //RAZON SOCIAL FIDEICOMISO

        public string DJPRAZSOCFID
        {
            get { return _DJPRAZSOCFID; }
            set { _DJPRAZSOCFID = value; }
        }

        private string _DJPCONSTFID; //VARCHAR2(5) Y //SI EL FIDEICOMISO ESTA INSCRIPTO O NO (False = 0 y True = 1)

        public string DJPCONSTFID
        {
            get { return _DJPCONSTFID; }
            set { _DJPCONSTFID = value; }
        }

        private int _DJPTIPOENTIDFID; //NUMBER Y //TIPO SOCIETARIO DEL FIDEICOMISO ID (INDICE DE TABLA TIPO_SOCIETARIO)
        
        public int DJPTIPOENTIDFID
        {
            get { return _DJPTIPOENTIDFID; }
            set { _DJPTIPOENTIDFID = value; }
        }

        private string _DJPTIPOENTFID;  //VARCHAR2(255) Y //TIPO SOCIETARIO DEL FIDEICOMISO (DESCRIPCION)

        public string DJPTIPOENTFID
        {
            get { return _DJPTIPOENTFID; }
            set { _DJPTIPOENTFID = value; }
        }

        private string _DJPCUITFID; //VARCHAR2(13) Y //CUIT DEL FIDEICOMISO

        public string DJPCUITFID
        {
            get { return _DJPCUITFID; }
            set { _DJPCUITFID = value; }
        }

        private string _DJPTIPODDJJ; //NUMBER(7) Y	//TIPO DE DECLARACION JURADA (Nro. 09)

        public string DJPTIPODDJJ
        {
            get { return _DJPTIPODDJJ; }
            set { _DJPTIPODDJJ = value; }
        }

        //private string _DJPTIPODDJJ;//     VARCHAR2(255)  Y                  

        //public string DJPTIPODDJJ
        //{
        //    get { return _DJPTIPODDJJ; }
        //    set { _DJPTIPODDJJ = value; }
        //}

        private string _DJPFECHA; //DATE Y //FECHA DE ALTA DE LA DJ

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

        private string _DJPRAZSOCENT;	//VARCHAR2(255)	Y //RAZON SOCIAL DE LA ENTIDAD (ex DJPRAZONSOCIAL)

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

        private int _DJPTIPOENTIDENT; //NUMBER Y //TIPO SOCIETARIO DE LA ENTIDAD ID (INDICE DE TABLA TIPO_SOCIETARIO)

        public int DJPTIPOENTIDENT
        {
            get { return _DJPTIPOENTIDENT; }
            set { _DJPTIPOENTIDENT = value; }
        }

        private string _DJPTIPOENTENT; //VARCHAR2(255) Y //TIPO SOCIETARIO DE LA ENTIDAD (DESCRIPCION)

        public string DJPTIPOENTENT
        {
            get { return _DJPTIPOENTENT; }
            set { _DJPTIPOENTENT = value; }
        }

        private string _DJPCUITENT; //VARCHAR2(13) Y //CUIT DE LA ENTIDAD

        public string DJPCUITENT
        {
            get { return _DJPCUITENT; }
            set { _DJPCUITENT = value; }
        }

        private string _DJPSEDESOCENT; //VARCHAR2(255) Y //SEDE SOCIAL DE LA ENTIDAD FIDUCIARIA

        public string DJPSEDESOCENT
        {
            get { return _DJPSEDESOCENT; }
            set { _DJPSEDESOCENT = value; }
        }

        private string _DJPOTRAJURISENT; //VARCHAR2(5) Y //SI LA ENTIDAD ESTA CONSTITUIDA EN IGJ O ES DE OTRA JURISDICCION (SI o NO)

        public string DJPOTRAJURISENT
        {
            get { return _DJPOTRAJURISENT; }
            set { _DJPOTRAJURISENT = value; }
        }

        /*---------------------------------*/
        /*- DATOS DEL REPRESENTANTE LEGAL -*/
        /*---------------------------------*/

        private string _REPNOMBRE; //VARCHAR2(60) Y                  

        public string REPNOMBRE
        {
            get { return _REPNOMBRE; }
            set { _REPNOMBRE = value; }
        }

        private string _REPAPELLIDO; //VARCHAR2(60) Y                  

        public string REPAPELLIDO
        {
            get { return _REPAPELLIDO; }
            set { _REPAPELLIDO = value; }
        }

        private string _REPTIPODOC; //VARCHAR2(255) Y                  

        public string REPTIPODOC
        {
            get { return _REPTIPODOC; }
            set { _REPTIPODOC = value; }
        }

        private string _REPNRODOC; //VARCHAR2(255) Y                  

        public string REPNRODOC
        {
            get { return _REPNRODOC; }
            set { _REPNRODOC = value; }
        }

        private string _REPTIPOFISCAL; //PEPTIPOFISCAL NUMBER Y //TIPO FISCAL DEL REPRESENTANTE LEGAL (INDICE EN LA TABLA TIPO_CLAVEFISCAL)

        public string REPTIPOFISCAL
        {
            get { return _REPTIPOFISCAL; }
            set { _REPTIPOFISCAL = value; }
        }

        private string _REPNROFISCAL; //VARCHAR2(255) Y //NUMERO FISCAL DEL REPRESENTANTE LEGAL

        public string REPNROFISCAL
        {
            get { return _REPNROFISCAL; }
            set { _REPNROFISCAL = value; }
        }

        private string _REPDOMREAL; //PEPDOMREAL VARCHAR2(60) Y //DOMICILIO REAL DEL REPRESENTANTE LEGAL

        public string REPDOMREAL
        {
            get { return _REPDOMREAL; }
            set { _REPDOMREAL = value; }
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
            get{ return _HASH.Substring(0,_HASH.Length-6);}
        }

        public string HashPart2
        {
            get { return _HASH.Substring(_HASH.Length - 6); }
        }

        public EntityDJ09()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }
    }
}
