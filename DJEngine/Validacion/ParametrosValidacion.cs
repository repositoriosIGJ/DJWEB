using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//namespace DDSAE.Validacion
//{
    /// <summary>
    /// Summary description for ParametrosValidacion
    /// </summary>
    public class ParametrosValidacion
    {
        private string _Control;

        public string Control
        {
            get { return _Control; }
            set { _Control = value; }
        }

        private string _Campo;

        public string Campo
        {
            get { return HttpContext.Current.Server.HtmlEncode(_Campo); }
            set { _Campo = value; }
        }

        private string _TipoCampo;

        public string TipoCampo
        {
            get { return _TipoCampo; }
            set { _TipoCampo = value; }
        }

        private string _Requerido;

        public string Requerido
        {
            get { return _Requerido; }
            set { _Requerido = value; }
        }

        private string _ValorInicio;

        public string ValorInicio
        {
            get { return _ValorInicio; }
            set { _ValorInicio = value; }
        }

        private string _ValorFin;

        public string ValorFin
        {
            get { return _ValorFin; }
            set { _ValorFin = value; }
        }

        public ParametrosValidacion()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
//}
