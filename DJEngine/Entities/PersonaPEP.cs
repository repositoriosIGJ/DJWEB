using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJEngine.Business
{
    public class PersonaPEP
    {
        private bool _PEPoNO;

        public bool PEPoNO
        {
            get { return _PEPoNO; }
            set { _PEPoNO = value; }
        }

        private string _TipoInciso;

        public string TipoInciso
        {
            get { return _TipoInciso; }
            set { _TipoInciso = value; }
        }

        ///////////////////////
        //PROPIEDADES DEL PEP//
        ///////////////////////

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

        ///////////////////////
        //PROPIEDADES DEL PPR//
        ///////////////////////

        #region "Propiedades PEP Relacionado"

        private string _NombrePPR;

        public string NombrePPR
        {
            get { return _NombrePPR; }
            set { _NombrePPR = value; }
        }

        private string _ApellidoPPR;

        public string ApellidoPPR
        {
            get { return _ApellidoPPR; }
            set { _ApellidoPPR = value; }
        }

        private int _TipoDocPPRId;

        public int TipoDocPPRId
        {
            get { return _TipoDocPPRId; }
            set { _TipoDocPPRId = value; }
        }

        private string _NroDocPPR;

        public string NroDocPPR
        {
            get { return _NroDocPPR; }
            set { _NroDocPPR = value; }
        }

        private string _CargoPPR;

        public string CargoPPR
        {
            get { return _CargoPPR; }
            set { _CargoPPR = value; }
        }

        private int _CargoPPRId;

        public int CargoPPRId
        {
            get { return _CargoPPRId; }
            set { _CargoPPRId = value; }
        }

        private string _DomicilioRealPPR;

        public string DomicilioRealPPR
        {
            get { return _DomicilioRealPPR; }
            set { _DomicilioRealPPR = value; }
        }

        //Texto que indica la relacion entre el PPR y el PEP
       /* private string _VinculoPPR;

        public string VinculoPPR {

            get { return _VinculoPPR; }
            set{_VinculoPPR = value;}
        }*/

        //Creo que nunca la va a llenar el relacionado
        private int _CategoriaPPR;

        public int CategoriaPPR
        {
            get { return _CategoriaPPR; }
            set { _CategoriaPPR = value; }
        }

        //Creo que nunca la va a llenar el relacionado
        private int _SubCategoriaPPR;

        public int SubCategoriaPPR
        {
            get { return _SubCategoriaPPR; }
            set { _SubCategoriaPPR = value; }
        }

        private int _TipoFiscalPPR;

        public int TipoFiscalPPR
        {
            get { return _TipoFiscalPPR; }
            set { _TipoFiscalPPR = value; }
        }

        private string _NroFiscalPPR;

        public string NroFiscalPPR
        {
            get { return _NroFiscalPPR; }
            set { _NroFiscalPPR = value; }
        }

        //Texto que indica la relacion entre el PPR y el PEP
        private string _RelacionPPRPEP;

        public string RelacionPPRPEP
        {
            get { return _RelacionPPRPEP; }
            set { _RelacionPPRPEP = value; }
        }

        #endregion "Propiedades PEP Relacionado"
    }
}
