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
    /// Clase Entity Reporte 08
    /// </summary>
    public class EntityDJ08
    {
        private string _DJPEPFIDID;

        public string DJPEPFIDID
        {
            get { return _DJPEPFIDID; }
            set { _DJPEPFIDID = value; }
        }
        private string _DJPNROCOR;

        public string DJPNROCOR
        {
            get { return _DJPNROCOR; }
            set { _DJPNROCOR = value; }
        }

        private string _DJPRAZONSOCIAL;

        public string DJPRAZONSOCIAL
        {
            get { return _DJPRAZONSOCIAL; }
            set { _DJPRAZONSOCIAL = value; }
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

        private string _DJINCISO;

        public string DJINCISO
        {
            get { return _DJINCISO; }
            set { _DJINCISO = value; }
        }

        private string _DJCUIT;

        public string DJCUIT
        {
            get { return _DJCUIT; }
            set { _DJCUIT = value; }
        }

        private string _DJCONST;

        public string DJCONST
        {
            get { return _DJCONST; }
            set { _DJCONST = value; }
        }

        private string _DJPEP;

        public string DJPEP
        {
            get { return _DJPEP; }
            set { _DJPEP = value; }
        }

        private string _PEPAPELLIDO;

        public string PEPAPELLIDO
        {
            get { return _PEPAPELLIDO; }
            set { _PEPAPELLIDO = value; }
        }
        private string _PEPNOMBRE;

        public string PEPNOMBRE
        {
            get { return _PEPNOMBRE; }
            set { _PEPNOMBRE = value; }
        }

        private string _PEPTIPODOC;

        public string PEPTIPODOC
        {
            get { return _PEPTIPODOC; }
            set { _PEPTIPODOC = value; }
        }

        private string _PEPNRODOC;

        public string PEPNRODOC
        {
            get { return _PEPNRODOC; }
            set { _PEPNRODOC = value; }
        }

        private string _PEPCARGOID;

        public string PEPCARGOID
        {
            get { return _PEPCARGOID; }
            set { _PEPCARGOID = value; }
        }

        private string _PEPCARGO;

        public string PEPCARGO
        {
            get { return _PEPCARGO; }
            set { _PEPCARGO = value; }
        }

        private string _PEPDOMREAL;

        public string PEPDOMREAL
        {
            get { return _PEPDOMREAL; }
            set { _PEPDOMREAL = value; }
        }

        private string _PEPTIPOFISCAL;

        public string PEPTIPOFISCAL
        {
            get { return _PEPTIPOFISCAL; }
            set { _PEPTIPOFISCAL = value; }
        }

        private string _PEPNROFISCAL;

        public string PEPNROFISCAL
        {
            get { return _PEPNROFISCAL; }
            set { _PEPNROFISCAL = value; }
        }

        private string _PEPCATEGORIA;

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

        private string _PPRNOMBRE;

        public string PPRNOMBRE
        {
            get { return _PPRNOMBRE; }
            set { _PPRNOMBRE = value; }
        }
        private string _PPRAPELLIDO;

        public string PPRAPELLIDO
        {
            get { return _PPRAPELLIDO; }
            set { _PPRAPELLIDO = value; }
        }
        private string _PPRTIPODOC;

        public string PPRTIPODOC
        {
            get { return _PPRTIPODOC; }
            set { _PPRTIPODOC = value; }
        }
        private string _PPRNRODOC;

        public string PPRNRODOC
        {
            get { return _PPRNRODOC; }
            set { _PPRNRODOC = value; }
        }

        private string _PPRTIPOFISCAL;

        public string PPRTIPOFISCAL
        {
            get { return _PPRTIPOFISCAL; }
            set { _PPRTIPOFISCAL = value; }
        }

        private string _PPRNROFISCAL;

        public string PPRNROFISCAL
        {
            get { return _PPRNROFISCAL; }
            set { _PPRNROFISCAL = value; }
        }

        private string _PPRCATEGORIA;

        public string PPRCATEGORIA
        {
            get { return _PPRCATEGORIA; }
            set { _PPRCATEGORIA = value; }
        }

        private string _PPRCARGOID;

        public string PPRCARGOID
        {
            get { return _PPRCARGOID; }
            set { _PPRCARGOID = value; }
        }

        private string _PPRCARGO;

        public string PPRCARGO
        {
            get { return _PPRCARGO; }
            set { _PPRCARGO = value; }
        }

        private string _PPRDOMREAL;

        public string PPRDOMREAL
        {
            get { return _PPRDOMREAL; }
            set { _PPRDOMREAL = value; }
        }

        private string _PPRPEPRELACION;

        public string PPRPEPRELACION
        {
            get { return _PPRPEPRELACION; }
            set { _PPRPEPRELACION = value; }
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

        public string TIPOSOC { get; set; }

        public string HashPart1
        { 
            get{ return _HASH.Substring(0,_HASH.Length-6);}
        }
        public string HashPart2
        {
            get { return _HASH.Substring(_HASH.Length - 6); }
        }
        public EntityDJ08()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }
    }
}
