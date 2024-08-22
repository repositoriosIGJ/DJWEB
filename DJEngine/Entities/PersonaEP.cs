using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJEngine.Business
{
    public class PersonaEP
    {
        #region "Propiedades PEP"

        private string _NombrePEP;

        public string NombrePEP
        {
            get { return _NombrePEP; }
            set { _NombrePEP = value; }
        }

        private string _ApellidoPEP;

        public string ApellidoPEP
        {
            get { return _ApellidoPEP; }
            set { _ApellidoPEP = value; }
        }

        private int _TipoDocPEPId;

        public int TipoDocPEPId
        {
            get { return _TipoDocPEPId; }
            set { _TipoDocPEPId = value; }
        }

        private string _NroDocPEP;

        public string NroDocPEP
        {
            get { return _NroDocPEP; }
            set { _NroDocPEP = value; }
        }

        private string _CargoPEP;

        public string CargoPEP
        {
            get { return _CargoPEP; }
            set { _CargoPEP = value; }
        }

        private int _CargoPEPId;

        public int CargoPEPId
        {
            get { return _CargoPEPId; }
            set { _CargoPEPId = value; }
        }

        private string _DomicilioRealPEP;

        public string DomicilioRealPEP
        {
            get { return _DomicilioRealPEP; }
            set { _DomicilioRealPEP = value; }
        }

        private int _TipoFiscalPEP;

        public int TipoFiscalPEP
        {
            get { return _TipoFiscalPEP; }
            set { _TipoFiscalPEP = value; }
        }

        private string _NroFiscalPEP;

        public string NroFiscalPEP
        {
            get { return _NroFiscalPEP; }
            set { _NroFiscalPEP = value; }
        }

        private string _RelacionadoPEP;

        public string RelacionadoPEP
        {
            get { return _RelacionadoPEP; }
            set { _RelacionadoPEP = value; }
        }

        private string _RelacionPEP;

        public string RelacionPEP
        {
            get { return _RelacionPEP; }
            set { _RelacionPEP = value; }
        }

        private bool _PEPoF;

        public bool PEPoF
        {
            get { return _PEPoF; }
            set { _PEPoF = value; }
        }

        private int _CategoriaPEP;

        public int CategoriaPEP
        {
            get { return _CategoriaPEP; }
            set { _CategoriaPEP = value; }
        }

        private int _SubCategoriaPEP;

        public int SubCategoriaPEP
        {
            get { return _SubCategoriaPEP; }
            set { _SubCategoriaPEP = value; }
        }

        //NUEVA PROPIEDADES 2023

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

        private int _EstadoCivil;

        public int EstadoCivil
        {
            get { return _EstadoCivil; }
            set { _EstadoCivil = value; }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        #endregion "Propiedades PEP"

        #region "Propiedades PEP Relacionado"

        private string _NombrePEPR;

        public string NombrePEPR
        {
            get { return _NombrePEPR; }
            set { _NombrePEPR = value; }
        }

        private string _ApellidoPEPR;

        public string ApellidoPEPR
        {
            get { return _ApellidoPEPR; }
            set { _ApellidoPEPR = value; }
        }

        private int _TipoDocPEPRId;

        public int TipoDocPEPRId
        {
            get { return _TipoDocPEPRId; }
            set { _TipoDocPEPRId = value; }
        }

        private string _NroDocPEPR;

        public string NroDocPEPR
        {
            get { return _NroDocPEPR; }
            set { _NroDocPEPR = value; }
        }

        private int _CategoriaPEPR;

        public int CategoriaPEPR
        {
            get { return _CategoriaPEPR; }
            set { _CategoriaPEPR = value; }
        }

        private int _SubCategoriaPEPR;

        public int SubCategoriaPEPR
        {
            get { return _SubCategoriaPEPR; }
            set { _SubCategoriaPEPR = value; }
        }

        private int _TipoFiscalPEPR;

        public int TipoFiscalPEPR
        {
            get { return _TipoFiscalPEPR; }
            set { _TipoFiscalPEPR = value; }
        }

        private string _NroFiscalPEPR;

        public string NroFiscalPEPR
        {
            get { return _NroFiscalPEPR; }
            set { _NroFiscalPEPR = value; }
        }

        #endregion "Propiedades PEP Relacionado"
    }
}
