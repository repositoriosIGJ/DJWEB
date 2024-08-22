using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DJEngine.DataAccess.Tipos;


namespace DJEngine.DataAccess.Entidades
{
    //public class DDJJ : global::TiposSocietario
    public class DDJJ

    //public class DeclaracionJurada 
    {
        #region "Propiedades"

        private long _ID;//long not null,

        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private long _NROCORR;//int not null,

        public long NROCORR
        {
            get { return _NROCORR; }
            set { _NROCORR = value; }
        }
                
        public TiposSocietario _TIPOSOC;

        public TiposSocietario TIPOSOC
        {
            get { return _TIPOSOC; }
            set { _TIPOSOC = value; }
        }

        public string TIPOSOC_DESCRIPCION
        {
            get { return _TIPOSOC.Descripcion; }
        }

        private string _RAZONSO;

        public string RAZONSO
        {
            get { return _RAZONSO; }
            set { _RAZONSO = value; }
        }

        private string _PRESNOMBRE;

        public string PRESNOMBRE
        {
            get { return _PRESNOMBRE; }
            set { _PRESNOMBRE = value; }
        }
        private string _PRESAPELLIDO;

        public string PRESAPELLIDO
        {
            get { return _PRESAPELLIDO; }
            set { _PRESAPELLIDO = value.ToUpper().Replace("&#209;", "Ñ"); }
        }
        private string _PRESCARACTER;

        public string PRESCARACTER
        {
            get { return _PRESCARACTER; }
            set { _PRESCARACTER = value; }
        }
        private string _PRESFECHA;

        public string PRESFECHA
        {
            get { return _PRESFECHA; }
            set { _PRESFECHA = value; }
        }
        private System.Byte[] _CodigoDeBarra;

        public System.Byte[] CodigoDeBarra
        {
            get { return _CodigoDeBarra; }
            set { _CodigoDeBarra = value; }
        }

        #endregion

        public DDJJ()
        {
            //
            // TODO: Add constructor logic here
            //
            
            TIPOSOC = new TiposSocietario();
        }

        /// <summary>
        /// Inserta los Datos Via WS
        /// </summary>
        public bool Alta(out string Mensaje)
        {           
           /*=========================================================*/
           /*   1 ) REGISTRO DE LO DATOS DEL DOMICILIO                */
           /*=========================================================*/
                       
            //try
            //{   
            //    Mensaje = "Dio el alta";
            //    return true;

            //}
            //catch (Exception e)
            //{               
               
            //   // return false;
            //}
            Mensaje="Dio de alta correctamente";
            return true;
        }
    }
}