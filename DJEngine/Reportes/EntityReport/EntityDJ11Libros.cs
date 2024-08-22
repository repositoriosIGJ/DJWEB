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
    /// Clase Entity Reporte 11 Libros
    /// </summary>
    public class EntityDJ11Libros
    {
        /*------------------------*/
        /*- DATOS DE LOS LIBROS  -*/
        /*------------------------*/

        #region "Datos de los Libros"

        private int _IDLIBRO;

        public int IDLIBRO
        {
            get { return _IDLIBRO; }
            set { _IDLIBRO = value; }
        }

        private string _LIBDOCUMENTO;

        public string LIBDOCUMENTO
        {
            get { return _LIBDOCUMENTO; }
            set { _LIBDOCUMENTO = value; }
        }

        private string _LIBDENOMINACION;

        public string LIBDENOMINACION
        {
            get { return _LIBDENOMINACION; }
            set { _LIBDENOMINACION = value; }
        }

        private string _LIBRUBRICA;

        public string LIBRUBRICA
        {
            get { return _LIBRUBRICA; }
            set { _LIBRUBRICA = value; }
        }

        private string _LIBFOLIOS;

        public string LIBFOLIOS
        {
            get { return _LIBFOLIOS; }
            set { _LIBFOLIOS = value; }
        }

        #endregion "Datos de los Libros"

        public EntityDJ11Libros()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }
    }
}
