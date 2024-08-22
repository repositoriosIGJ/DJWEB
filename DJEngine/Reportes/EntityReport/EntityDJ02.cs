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
    /// Clase Entity Reporte 02
    /// </summary>
    public class EntityDJ02
    {
        public EntityDJ02()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region "Propiedades"

        //private string _Codigo;

        //public string Codigo
        //{
        //    get { return _Codigo; }
        //    set { _Codigo = value; }
        //}        

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

        private string _EMAILDOMDIG;

        public string EMAILDOMDIG
        {
            get { return _EMAILDOMDIG; }
            set { _EMAILDOMDIG = value; }
        }

        private string _DJPFECHA;

        public string DJPFECHA
        {
            get { return _DJPFECHA; }
            set { _DJPFECHA = value; }
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

        #endregion

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
    }
}
