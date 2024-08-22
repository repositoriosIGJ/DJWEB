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
    /// Clase Entity Reporte 11
    /// </summary>
    public class EntityDJ11
    {
        private string _DJBALID;

        public string DJBALID
        {
            get { return _DJBALID; }
            set { _DJBALID = value; }
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

        /*------------------------*/
        /*- DATOS DE LA ENTIDAD  -*/
        /*------------------------*/

        #region "Datos de la Entidad"

        private string _DJPNROCORENT; //NUMBER(7) Y //NUMERO CORRELATIVO DE LA ENTIDAD

        public string DJPNROCORENT
        {
            get { return _DJPNROCORENT; }
            set { _DJPNROCORENT = value; }
        }

        private string _DJPRAZSOCENT; //VARCHAR2(255)	Y //RAZON SOCIAL DE LA ENTIDAD (ex DJPRAZONSOCIAL)

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

        private int _DJPTIPOENTID; //NUMBER Y //TIPO SOCIETARIO DE LA ENTIDAD ID (INDICE DE TABLA TIPO_SOCIETARIO)

        public int DJPTIPOENTID
        {
            get { return _DJPTIPOENTID; }
            set { _DJPTIPOENTID = value; }
        }

        private string _DJPTIPOENT; //VARCHAR2(255) Y //TIPO SOCIETARIO DE LA ENTIDAD (DESCRIPCION)

        public string DJPTIPOENT
        {
            get { return _DJPTIPOENT; }
            set { _DJPTIPOENT = value; }
        }

        private string _DJPCUITENT; //VARCHAR2(13) Y //CUIT DE LA ENTIDAD

        public string DJPCUITENT
        {
            get { return _DJPCUITENT; }
            set { _DJPCUITENT = value; }
        }

        private string _DJPSEDESOC; //VARCHAR2(255) Y //SEDE SOCIAL DE LA ENTIDAD

        public string DJPSEDESOC
        {
            get { return _DJPSEDESOC; }
            set { _DJPSEDESOC = value; }
        }

        #endregion "Datos de la Entidad"

        /*---------------------*/
        /*- DATOS DEL BALANCE -*/
        /*---------------------*/

        #region "Datos del Balance"

        private string _BALANIO; //VARCHAR2(60) Y                  

        public string BALANIO
        {
            get { return _BALANIO; }
            set { _BALANIO = value; }
        }

        private string _BALFECHAINI; //DATE                 

        public string BALFECHAINI
        {
            get { return _BALFECHAINI; }
            set { _BALFECHAINI = value; }
        }

        private string _BALFECHAFIN; //DATE                 

        public string BALFECHAFIN
        {
            get { return _BALFECHAFIN; }
            set { _BALFECHAFIN = value; }
        }

        private string _BALFECHAREUNION; //DATE                 

        public string BALFECHAREUNION
        {
            get { return _BALFECHAREUNION; }
            set { _BALFECHAREUNION = value; }
        }

        private string _BALTIPOASAMBLEA;                 

        public string BALTIPOASAMBLEA
        {
            get { return _BALTIPOASAMBLEA; }
            set { _BALTIPOASAMBLEA = value; }
        }

        private string _BALFECHAASAMBLEA; //DATE                 

        public string BALFECHAASAMBLEA
        {
            get { return _BALFECHAASAMBLEA; }
            set { _BALFECHAASAMBLEA = value; }
        }

        private string _BALCAPITAL; //NUMBER(15,2)                 

        public string BALCAPITAL
        {
            get { return _BALCAPITAL; }
            set { _BALCAPITAL = value; }
        }

        private string _BALAJUSTE; //NUMBER(15,2)                 

        public string BALAJUSTE
        {
            get { return _BALAJUSTE; }
            set { _BALAJUSTE = value; }
        }

        #endregion "Datos del Balance"

        /*-----------------------------------*/
        /*- DATOS DEL CONTADOR CERTIFICANTE -*/
        /*-----------------------------------*/

        #region "Datos del Contador Certificante"

        private string _CONNOMBRE; //VARCHAR2(60) Y                  

        public string CONNOMBRE
        {
            get { return _CONNOMBRE; }
            set { _CONNOMBRE = value; }
        }

        private string _CONAPELLIDO; //VARCHAR2(60) Y                  

        public string CONAPELLIDO
        {
            get { return _CONAPELLIDO; }
            set { _CONAPELLIDO = value; }
        }

        private string _CONTIPODOC; //NUMBER Y                  

        public string CONTIPODOC
        {
            get { return _CONTIPODOC; }
            set { _CONTIPODOC = value; }
        }

        private string _CONNRODOC; //VARCHAR2(255) Y                  

        public string CONNRODOC
        {
            get { return _CONNRODOC; }
            set { _CONNRODOC = value; }
        }

        private string _CONTIPOFISCAL;

        public string CONTIPOFISCAL
        {
            get { return _CONTIPOFISCAL; }
            set { _CONTIPOFISCAL = value; }
        }

        private string _CONNROFISCAL;

        public string CONNROFISCAL
        {
            get { return _CONNROFISCAL; }
            set { _CONNROFISCAL = value; }
        }

        private string _CONTOMO;

        public string CONTOMO
        {
            get { return _CONTOMO; }
            set { _CONTOMO = value; }
        }

        private string _CONFOLIO;

        public string CONFOLIO
        {
            get { return _CONFOLIO; }
            set { _CONFOLIO = value; }
        }

        private string _AUDFECHA;

        public string AUDFECHA
        {
            get { return _AUDFECHA; }
            set { _AUDFECHA = value; }
        }

        private string _AUDNROLEG;

        public string AUDNROLEG
        {
            get { return _AUDNROLEG; }
            set { _AUDNROLEG = value; }
        }

        //private string _AUDDICTAMEN;

        //public string AUDDICTAMEN
        //{
        //    get { return _AUDDICTAMEN; }
        //    set { _AUDDICTAMEN = value; }
        //}

        #endregion "Datos del Contador Certificante"

        /*---------------------------------*/
        /*- DATOS DEL REPRESENTANTE LEGAL -*/
        /*---------------------------------*/

        #region "Datos del Representante Legal"

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

        private string _REPTIPODOC; //NUMBER Y                  

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

        private string _REPTIPOFISCAL;

        public string REPTIPOFISCAL
        {
            get { return _REPTIPOFISCAL; }
            set { _REPTIPOFISCAL = value; }
        }

        private string _REPNROFISCAL;

        public string REPNROFISCAL
        {
            get { return _REPNROFISCAL; }
            set { _REPNROFISCAL = value; }
        }

        #endregion "Datos del Representante Legal"

        /*------------------------*/
        /*- DATOS DE LOS LIBROS  -*/
        /*------------------------*/

        #region "Datos de los Libros"

        //LIBRO _01

        private string _LIBDOCUMENTO_01;

        public string LIBDOCUMENTO_01
        {
            get { return _LIBDOCUMENTO_01; }
            set { _LIBDOCUMENTO_01 = value; }
        }

        private string _LIBDENOMINACION_01;

        public string LIBDENOMINACION_01
        {
            get { return _LIBDENOMINACION_01; }
            set { _LIBDENOMINACION_01 = value; }
        }

        private string _LIBNRORL_01;

        public string LIBNRORL_01
        {
            get { return _LIBNRORL_01; }
            set { _LIBNRORL_01 = value; }
        }

        private string _LIBFEC_01;

        public string LIBFEC_01
        {
            get { return _LIBFEC_01; }
            set { _LIBFEC_01 = value; }
        }

        private string _LIBHASH_01;

        public string LIBHASH_01
        {
            get { return _LIBHASH_01; }
            set { _LIBHASH_01 = value; }
        }

        //LIBRO _02

        private string _LIBDOCUMENTO_02;

        public string LIBDOCUMENTO_02
        {
            get { return _LIBDOCUMENTO_02; }
            set { _LIBDOCUMENTO_02 = value; }
        }

        private string _LIBDENOMINACION_02;

        public string LIBDENOMINACION_02
        {
            get { return _LIBDENOMINACION_02; }
            set { _LIBDENOMINACION_02 = value; }
        }

        private string _LIBNRORL_02;

        public string LIBNRORL_02
        {
            get { return _LIBNRORL_02; }
            set { _LIBNRORL_02 = value; }
        }

        private string _LIBFEC_02;

        public string LIBFEC_02
        {
            get { return _LIBFEC_02; }
            set { _LIBFEC_02 = value; }
        }

        private string _LIBHASH_02;

        public string LIBHASH_02
        {
            get { return _LIBHASH_02; }
            set { _LIBHASH_02 = value; }
        }

        //LIBRO _03

        private string _LIBDOCUMENTO_03;

        public string LIBDOCUMENTO_03
        {
            get { return _LIBDOCUMENTO_03; }
            set { _LIBDOCUMENTO_03 = value; }
        }

        private string _LIBDENOMINACION_03;

        public string LIBDENOMINACION_03
        {
            get { return _LIBDENOMINACION_03; }
            set { _LIBDENOMINACION_03 = value; }
        }

        private string _LIBNRORL_03;

        public string LIBNRORL_03
        {
            get { return _LIBNRORL_03; }
            set { _LIBNRORL_03 = value; }
        }

        private string _LIBFEC_03;

        public string LIBFEC_03
        {
            get { return _LIBFEC_03; }
            set { _LIBFEC_03 = value; }
        }

        private string _LIBHASH_03;

        public string LIBHASH_03
        {
            get { return _LIBHASH_03; }
            set { _LIBHASH_03 = value; }
        }

        //LIBRO _04

        private string _LIBDOCUMENTO_04;

        public string LIBDOCUMENTO_04
        {
            get { return _LIBDOCUMENTO_04; }
            set { _LIBDOCUMENTO_04 = value; }
        }

        private string _LIBDENOMINACION_04;

        public string LIBDENOMINACION_04
        {
            get { return _LIBDENOMINACION_04; }
            set { _LIBDENOMINACION_04 = value; }
        }

        private string _LIBNRORL_04;

        public string LIBNRORL_04
        {
            get { return _LIBNRORL_04; }
            set { _LIBNRORL_04 = value; }
        }

        private string _LIBFEC_04;

        public string LIBFEC_04
        {
            get { return _LIBFEC_04; }
            set { _LIBFEC_04 = value; }
        }

        private string _LIBHASH_04;

        public string LIBHASH_04
        {
            get { return _LIBHASH_04; }
            set { _LIBHASH_04 = value; }
        }

        //LIBRO _05

        private string _LIBDOCUMENTO_05;

        public string LIBDOCUMENTO_05
        {
            get { return _LIBDOCUMENTO_05; }
            set { _LIBDOCUMENTO_05 = value; }
        }

        private string _LIBDENOMINACION_05;

        public string LIBDENOMINACION_05
        {
            get { return _LIBDENOMINACION_05; }
            set { _LIBDENOMINACION_05 = value; }
        }

        private string _LIBNRORL_05;

        public string LIBNRORL_05
        {
            get { return _LIBNRORL_05; }
            set { _LIBNRORL_05 = value; }
        }

        private string _LIBFEC_05;

        public string LIBFEC_05
        {
            get { return _LIBFEC_05; }
            set { _LIBFEC_05 = value; }
        }

        private string _LIBHASH_05;

        public string LIBHASH_05
        {
            get { return _LIBHASH_05; }
            set { _LIBHASH_05 = value; }
        }

        //LIBRO _06

        private string _LIBDOCUMENTO_06;

        public string LIBDOCUMENTO_06
        {
            get { return _LIBDOCUMENTO_06; }
            set { _LIBDOCUMENTO_06 = value; }
        }

        private string _LIBDENOMINACION_06;

        public string LIBDENOMINACION_06
        {
            get { return _LIBDENOMINACION_06; }
            set { _LIBDENOMINACION_06 = value; }
        }

        private string _LIBNRORL_06;

        public string LIBNRORL_06
        {
            get { return _LIBNRORL_06; }
            set { _LIBNRORL_06 = value; }
        }

        private string _LIBFEC_06;

        public string LIBFEC_06
        {
            get { return _LIBFEC_06; }
            set { _LIBFEC_06 = value; }
        }

        private string _LIBHASH_06;

        public string LIBHASH_06
        {
            get { return _LIBHASH_06; }
            set { _LIBHASH_06 = value; }
        }

        //LIBRO _07

        private string _LIBDOCUMENTO_07;

        public string LIBDOCUMENTO_07
        {
            get { return _LIBDOCUMENTO_07; }
            set { _LIBDOCUMENTO_07 = value; }
        }

        private string _LIBDENOMINACION_07;

        public string LIBDENOMINACION_07
        {
            get { return _LIBDENOMINACION_07; }
            set { _LIBDENOMINACION_07 = value; }
        }

        private string _LIBNRORL_07;

        public string LIBNRORL_07
        {
            get { return _LIBNRORL_07; }
            set { _LIBNRORL_07 = value; }
        }

        private string _LIBFEC_07;

        public string LIBFEC_07
        {
            get { return _LIBFEC_07; }
            set { _LIBFEC_07 = value; }
        }

        private string _LIBHASH_07;

        public string LIBHASH_07
        {
            get { return _LIBHASH_07; }
            set { _LIBHASH_07 = value; }
        }

        //LIBRO _08

        private string _LIBDOCUMENTO_08;

        public string LIBDOCUMENTO_08
        {
            get { return _LIBDOCUMENTO_08; }
            set { _LIBDOCUMENTO_08 = value; }
        }

        private string _LIBDENOMINACION_08;

        public string LIBDENOMINACION_08
        {
            get { return _LIBDENOMINACION_08; }
            set { _LIBDENOMINACION_08 = value; }
        }

        private string _LIBNRORL_08;

        public string LIBNRORL_08
        {
            get { return _LIBNRORL_08; }
            set { _LIBNRORL_08 = value; }
        }

        private string _LIBFEC_08;

        public string LIBFEC_08
        {
            get { return _LIBFEC_08; }
            set { _LIBFEC_08 = value; }
        }

        private string _LIBHASH_08;

        public string LIBHASH_08
        {
            get { return _LIBHASH_08; }
            set { _LIBHASH_08 = value; }
        }

        //LIBRO _09

        private string _LIBDOCUMENTO_09;

        public string LIBDOCUMENTO_09
        {
            get { return _LIBDOCUMENTO_09; }
            set { _LIBDOCUMENTO_09 = value; }
        }

        private string _LIBDENOMINACION_09;

        public string LIBDENOMINACION_09
        {
            get { return _LIBDENOMINACION_09; }
            set { _LIBDENOMINACION_09 = value; }
        }

        private string _LIBNRORL_09;

        public string LIBNRORL_09
        {
            get { return _LIBNRORL_09; }
            set { _LIBNRORL_09 = value; }
        }

        private string _LIBFEC_09;

        public string LIBFEC_09
        {
            get { return _LIBFEC_09; }
            set { _LIBFEC_09 = value; }
        }

        private string _LIBHASH_09;

        public string LIBHASH_09
        {
            get { return _LIBHASH_09; }
            set { _LIBHASH_09 = value; }
        }

        //LIBRO _10

        private string _LIBDOCUMENTO_10;

        public string LIBDOCUMENTO_10
        {
            get { return _LIBDOCUMENTO_10; }
            set { _LIBDOCUMENTO_10 = value; }
        }

        private string _LIBDENOMINACION_10;

        public string LIBDENOMINACION_10
        {
            get { return _LIBDENOMINACION_10; }
            set { _LIBDENOMINACION_10 = value; }
        }

        private string _LIBNRORL_10;

        public string LIBNRORL_10
        {
            get { return _LIBNRORL_10; }
            set { _LIBNRORL_10 = value; }
        }

        private string _LIBFEC_10;

        public string LIBFEC_10
        {
            get { return _LIBFEC_10; }
            set { _LIBFEC_10 = value; }
        }

        private string _LIBHASH_10;

        public string LIBHASH_10
        {
            get { return _LIBHASH_10; }
            set { _LIBHASH_10 = value; }
        }

        //LIBRO _11

        private string _LIBDOCUMENTO_11;

        public string LIBDOCUMENTO_11
        {
            get { return _LIBDOCUMENTO_11; }
            set { _LIBDOCUMENTO_11 = value; }
        }

        private string _LIBDENOMINACION_11;

        public string LIBDENOMINACION_11
        {
            get { return _LIBDENOMINACION_11; }
            set { _LIBDENOMINACION_11 = value; }
        }

        private string _LIBNRORL_11;

        public string LIBNRORL_11
        {
            get { return _LIBNRORL_11; }
            set { _LIBNRORL_11 = value; }
        }

        private string _LIBFEC_11;

        public string LIBFEC_11
        {
            get { return _LIBFEC_11; }
            set { _LIBFEC_11 = value; }
        }

        private string _LIBHASH_11;

        public string LIBHASH_11
        {
            get { return _LIBHASH_11; }
            set { _LIBHASH_11 = value; }
        }

        //LIBRO _12

        private string _LIBDOCUMENTO_12;

        public string LIBDOCUMENTO_12
        {
            get { return _LIBDOCUMENTO_12; }
            set { _LIBDOCUMENTO_12 = value; }
        }

        private string _LIBDENOMINACION_12;

        public string LIBDENOMINACION_12
        {
            get { return _LIBDENOMINACION_12; }
            set { _LIBDENOMINACION_12 = value; }
        }

        private string _LIBNRORL_12;

        public string LIBNRORL_12
        {
            get { return _LIBNRORL_12; }
            set { _LIBNRORL_12 = value; }
        }

        private string _LIBFEC_12;

        public string LIBFEC_12
        {
            get { return _LIBFEC_12; }
            set { _LIBFEC_12 = value; }
        }

        private string _LIBHASH_12;

        public string LIBHASH_12
        {
            get { return _LIBHASH_12; }
            set { _LIBHASH_12 = value; }
        }

        #endregion "Datos de los Libros"

        /*------------------*/
        /*- DATOS DE LA DJ -*/
        /*------------------*/

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

        public EntityDJ11()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }
    }
}
