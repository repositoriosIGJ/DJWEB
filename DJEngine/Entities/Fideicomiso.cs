using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJEngine.Business
{
    public class Fideicomiso
    {
        #region "Propiedades"

        private int? _NroCorrelativo;

        public int? NroCorrelativo
        {
            get { return _NroCorrelativo; }
            set { _NroCorrelativo = value; }
        }

        private string _RazonSocial;

        public string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }
        private string _Cuit;

        public string Cuit
        {
            get { return _Cuit; }
            set { _Cuit = value; }
        }
        private int _TipoSocId;

        public int TipoSocId
        {
            get { return _TipoSocId; }
            set { _TipoSocId = value; }
        }

        private bool _Constituida;

        public bool Constituida
        {
            get { return _Constituida; }
            set { _Constituida = value; }
        }

        #endregion "Propiedades"
    }
}
