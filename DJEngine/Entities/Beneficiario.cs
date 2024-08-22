using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJEngine.Business
{
    public class Beneficiario
    {
        //////////////////////////////////////
        //PROPIEDADES DEL BENEFICIARIO FINAL//
        //////////////////////////////////////

        #region "Propiedades Beneficiario"

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Apellido;

        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        private int _TipoDocId;

        public int TipoDocId
        {
            get { return _TipoDocId; }
            set { _TipoDocId = value; }
        }

        private string _NroDoc;

        public string NroDoc
        {
            get { return _NroDoc; }
            set { _NroDoc = value; }
        }

        private int _TipoFiscal;

        public int TipoFiscal
        {
            get { return _TipoFiscal; }
            set { _TipoFiscal = value; }
        }

        private string _NroFiscal;

        public string NroFiscal
        {
            get { return _NroFiscal; }
            set { _NroFiscal = value; }
        }

        //private string _Cargo;

        //public string Cargo
        //{
        //    get { return _Cargo; }
        //    set { _Cargo = value; }
        //}

        //private int _CargoId;

        //public int CargoId
        //{
        //    get { return _CargoId; }
        //    set { _CargoId = value; }
        //}

        private string _DomicilioReal;

        public string DomicilioReal
        {
            get { return _DomicilioReal; }
            set { _DomicilioReal = value; }
        }

        private string _Nacionalidad;

        public string Nacionalidad
        {
            get { return _Nacionalidad; }
            set { _Nacionalidad = value; }
        }

        private DateTime _FechaNac;

        public DateTime FechaNac
        {
            get { return _FechaNac; }
            set { _FechaNac = value; }
        }

        private string _Profesion;

        public string Profesion
        {
            get { return _Profesion; }
            set { _Profesion = value; }
        }

        private Decimal _Porcentaje;

        public Decimal Porcentaje
        {
            get { return _Porcentaje; }
            set { _Porcentaje = value; }
        }

        //No se usa mas, 2021
        //private bool _BENoNO;

        //public bool BENoNO
        //{
        //    get { return _BENoNO; }
        //    set { _BENoNO = value; }
        //}

        //Empieza Nuevas Propiedades 2021

        private int _TipoBen;

        public int TipoBen
        {
            get { return _TipoBen; }
            set { _TipoBen = value; }
        }

        private int _EstadoCivil;

        public int EstadoCivil
        {
            get { return _EstadoCivil; }
            set { _EstadoCivil = value; }
        }

        private string _Caracter;

        public string Caracter
        {
            get { return _Caracter; }
            set { _Caracter = value; }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Observaciones;

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        //Termina Nuevas Propiedades 2021

        #endregion "Propiedades Beneficiario" 
    }
}
