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
    /// Clase Entity Reporte 03
    /// </summary>
    public class EntityDJ03
    {
        private string _DJPPEID;

        public string DJPPEID
        {
            get { return _DJPPEID; }
            set { _DJPPEID = value; }
        }
        private string _DJPNROCOR;//       VARCHAR2(255)  Y                  

        public string DJPNROCOR
        {
            get { return _DJPNROCOR; }
            set { _DJPNROCOR = value; }
        }
        private string _DJPTIPODDJJ;//     VARCHAR2(255)  Y                  

        public string DJPTIPODDJJ
        {
            get { return _DJPTIPODDJJ; }
            set { _DJPTIPODDJJ = value; }
        }
        private string _DJPFECHA;//        VARCHAR2(255)  Y                  

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
        
        private string _PEPAPELLIDO;//     VARCHAR2(255)  Y                  

        public string PEPAPELLIDO
        {
            get { return _PEPAPELLIDO; }
            set { _PEPAPELLIDO = value; }
        }
        private string _PEPNOMBRE;//       VARCHAR2(255)  Y                  

        public string PEPNOMBRE
        {
            get { return _PEPNOMBRE; }
            set { _PEPNOMBRE = value; }
        }
        private string _PEPTIPODOC;//     VARCHAR2(255)  Y                  

        public string PEPTIPODOC
        {
            get { return _PEPTIPODOC; }
            set { _PEPTIPODOC = value; }
        }
        private string _PEPNUMERO;//       VARCHAR2(255)  Y                  

        public string PEPNUMERO
        {
            get { return _PEPNUMERO; }
            set { _PEPNUMERO = value; }
        }

        private string _PEPCARGO;//     VARCHAR2(255)  Y                  

        public string PEPCARGO
        {
            get { return _PEPCARGO; }
            set { _PEPCARGO = value; }
        }

        // Indice del Cargo PEP en la tabla Tipo_Cargo - 23/02/13
        private string _PEPCARGOID;

        public string PEPCARGOID
        {
            get { return _PEPCARGOID; }
            set { _PEPCARGOID = value; }
        }

        // Domicilio Real Pep - 23/02/13
        private string _PEPDOMICILIOREAL;

        public string PEPDOMICILIOREAL
        {
            get { return _PEPDOMICILIOREAL; }
            set { _PEPDOMICILIOREAL = value; }
        }

        private string _PEPTIPOFISCAL;//        VARCHAR2(255)  Y  TIPO ID FISCAL PERSONA PEP

        public string PEPTIPOFISCAL
        {
            get { return _PEPTIPOFISCAL; }
            set { _PEPTIPOFISCAL = value; }
        }

        private string _PEPCUIT;//        VARCHAR2(255)  Y  NUMERO ID FISCAL PERSONA PEP

        public string PEPCUIT
        {
            get { return _PEPCUIT; }
            set { _PEPCUIT = value; }
        }

        private string _PEPCATEGORIA;//        VARCHAR2(255)  Y  NUMERO ID FISCAL PERSONA PEP

        public string PEPCATEGORIA
        {
            get { return _PEPCATEGORIA; }
            set { _PEPCATEGORIA = value; }
        }

        //PEP PROP 2023

        private string _PEPNACIONALIDAD;
        public string PEPNACIONALIDAD
        {
            get { return _PEPNACIONALIDAD; }
            set { _PEPNACIONALIDAD = value; }
        }

        private string _PEPEMAIL;
        
        public string PEPEMAIL
        {
            get { return _PEPEMAIL; }
            set { _PEPEMAIL = value; }
        }

        private string _PEPPROFESION;

        public string PEPPROFESION
        {
            get { return _PEPPROFESION; }
            set { _PEPPROFESION = value; }
        }

        private string _PEPFECHANACIMIENTO;

        public string PEPFECHANACIMIENTO
        {
            get { return _PEPFECHANACIMIENTO; }
            set { _PEPFECHANACIMIENTO = value; }
        }

        //FIN PROPIEDADES PEP 2023

        private string _DJPRAZONSOCIAL;//  VARCHAR2(255)  Y                  RAZON SOCIAL EMPRESA

        public string DJPRAZONSOCIAL
        {
            get { return _DJPRAZONSOCIAL; }
            set { _DJPRAZONSOCIAL = value; }
        }
        private string _PPRNOMBRE;//       VARCHAR2(255)  Y                  NOMBRE PERSONA RELACIONADA

        public string PPRNOMBRE
        {
            get { return _PPRNOMBRE; }
            set { _PPRNOMBRE = value; }
        }
        private string _PPRAPELLIDO;//     VARCHAR2(255)  Y                  APELLIDO PERSONA RELACIONADA

        public string PPRAPELLIDO
        {
            get { return _PPRAPELLIDO; }
            set { _PPRAPELLIDO = value; }
        }
        private string _PPRTIPODOC;//      INTEGER        Y                  TIPO DOC PERSONA RELACIONADA

        public string PPRTIPODOC
        {
            get { return _PPRTIPODOC; }
            set { _PPRTIPODOC = value; }
        }
        private string _PPRNRODOC;//       VARCHAR2(255)  Y                  NRODOCUMENTO DE PERSONA RELACIONADA

        public string PPRNRODOC
        {
            get { return _PPRNRODOC; }
            set { _PPRNRODOC = value; }
        }

        private string _PPRTIPOFISCAL;//        VARCHAR2(255)  Y  TIPO ID FISCAL PERSONA RELACIONADA

        public string PPRTIPOFISCAL
        {
            get { return _PPRTIPOFISCAL; }
            set { _PPRTIPOFISCAL = value; }
        }

        private string _PPRCUIT;//         VARCHAR2(255)  Y  NUMERO ID FISCAL PERSONA RELACIONADA

        public string PPRCUIT
        {
            get { return _PPRCUIT; }
            set { _PPRCUIT = value; }
        }

        private string _DJINCISO;//          VARCHAR2(1)    Y                  SI ESTA INCLUIDO EN ALGUN INCISO

        public string DJINCISO
        {
            get { return _DJINCISO; }
            set { _DJINCISO = value; }
        }
        private string _PEPRELACION;//     VARCHAR2(255)  Y                  RELACION CON LA PERSONA

        public string PEPRELACION
        {
            get { return _PEPRELACION; }
            set { _PEPRELACION = value; }
        }

        private string _DJPCUIT;

        public string DJPCUIT
        {
            get { return _DJPCUIT; }
            set { _DJPCUIT = value; }
        }

        private string _DJPCONST;

        public string DJPCONST
        {
            get { return _DJPCONST; }
            set { _DJPCONST = value; }
        }

        private string _DJPEP;

        public string DJPEP
        {
            get { return _DJPEP; }
            set { _DJPEP = value; }
        }

        private byte[] _CODIGODEBARRAS;

        public byte[] CODIGODEBARRAS
        {
            get { return _CODIGODEBARRAS; }
            set { _CODIGODEBARRAS = value; }
        }

        private byte[] _MINICODIGODEBARRAS;

        public byte[] MINICODIGODEBARRAS
        {
            get { return _MINICODIGODEBARRAS; }
            set { _MINICODIGODEBARRAS = value; }
        }

        private byte[] _CODIGOQR;

        public byte[] CODIGOQR
        {
            get { return _CODIGOQR; }
            set { _CODIGOQR = value; }
        }

        private string _HASH;

        public string HASH
        {
            get { return _HASH; }
            set { _HASH = value; }
        }

        public string TIPOSOC { get; set; }

        /*
        //HashDJFecha Hash Nro DJ y Fecha ejm: 03120522 
        public string HashPart0
        {
            get { return _HASH.Substring(0,8); }
        }
         */

        //Hash Completo sin los primeros 8 Digitos del HashDJFecha y sin el MiniHash Final
        public string HashPart1
        {
            get { return _HASH.Substring(8).Substring(0, _HASH.Substring(8).Length - 6); }
        }

        //MiniHash Final
        public string HashPart2
        {
            get { return _HASH.Substring(_HASH.Length - 6); }
        }

        public EntityDJ03()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }
    }
}
