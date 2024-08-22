using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Tipos
/// </summary>
/// 

namespace DJEngine.DataAccess.Tipos
{
    public abstract class Tipos
    {
        protected int _Codigo;

        protected DataSet _DataSetGeneric;

        /// <summary>
        /// Codigo Por defecto
        /// </summary>
        protected int _CodigoDefault;

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        protected string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        //protected string _DESCRIPCIONCORTA;

        //public string DESCRIPCIONCORTA
        //{
        //    get { return _DESCRIPCIONCORTA; }
        //    set { _DESCRIPCIONCORTA = value; }
        //}

    

        private string _Acronimo;

        public string Acronimo
        {
            get { return _Acronimo; }
            set { _Acronimo = value; }
        }

        public string DescripcionCorta
        {
            get {
                string desc = "";

                if (Descripcion.Length > 50)
                    desc = Descripcion.Substring(0, 50) + "...";
                else
                    desc = Descripcion;
                
                return "(" + Acronimo + ") " + desc;             
            }
        }

        public Tipos(DataSet datasetobject)
        {
            _DataSetGeneric = datasetobject;
        }

        public DataSet getTablaTipos(string codigoTabla)
        {
            return null;
        }

        public override string ToString()
        {
            return _Descripcion;
        }

        public bool Load(int index)
        {
            foreach (DataRow dr in _DataSetGeneric.Tables[0].Rows)
            {
                if (Convert.ToInt32(dr[0].ToString()) == index)
                {
                    Codigo = index;
                    Acronimo = dr[1].ToString();
                    Descripcion = dr[2].ToString();
                    return true;
                }
            }
            return false;
        }
    }
}



