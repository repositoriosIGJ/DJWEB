using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DJEngine.UsoGeneral;

namespace DJEngine.DataAccess.Tipos
{
    public class CategoriaPEP : Tipos
    {
        private static DataSet ds;

        private static List<CategoriaPEP> _Categorias;

        public static List<CategoriaPEP> Categorias
        {
            get 
            {
                if (_Categorias == null)
                {
                    _Categorias = new List<CategoriaPEP>();
                    LoadTablaCategoriaPEP();
                }

                return CategoriaPEP._Categorias;
            }
            set { _Categorias = value; }
        }

        private List<SubCategoriaPEP> _SubCategorias;

        public List<SubCategoriaPEP> SubCategorias
        {
            get { return _SubCategorias; }
            set { _SubCategorias = value; }
        }

        public CategoriaPEP(): base(ds)
        {
            getCategoriaPEP();

            SubCategorias = new List<SubCategoriaPEP>();
        }

        public CategoriaPEP(int index)
            : base(ds)
        {
            getCategoriaPEP();
            Load(index);
            LoadSubCategorias();
        }

        public string GetAcronimoSubcategoria(int SubcategoriaId)
        {
            foreach (SubCategoriaPEP sc in SubCategorias)
            {
                if (sc.Codigo == SubcategoriaId)
                {
                    return sc.Acronimo;
                }
            }
            return "";
        }

        public string GetDescripcionSubCategoria(int SubcategoriaId)
        {
            foreach (SubCategoriaPEP sc in SubCategorias)
            {
                if (sc.Codigo == SubcategoriaId)
                {
                    return sc.Descripcion;
                }
            }
            return "";
        }

        public DataSet getCategoriaPEP()
        {
            _CodigoDefault = 1;

            if (ds == null)
            {
                LoadTablaCategoriaPEP();
            }
            return ds;
        }

        public static void LoadTablaCategoriaPEP()
        {
            //WsDeclaracionJurada.ws_ddjj_web ws = new WsDeclaracionJurada.ws_ddjj_web();
            //WsConsultasEntidades.IGJ_Generic ws = new WsConsultasEntidades.IGJ_Generic();
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            //_CodigoDefault = 1;

            //TODO: Arreglar WebService LstTiposClaveFiscal
            ds = ws.LstCategoriaPEP();
           
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                CategoriaPEP cat = new CategoriaPEP();

                cat.Codigo = Convert.ToInt32(dr["CODIGO"]);
                cat.Acronimo = dr["ACRONIMO"].ToString();
                cat.Descripcion = dr["DESCRIPCION"].ToString();

                cat.LoadSubCategorias();

                Categorias.Add(cat);
            }

            //Ordena la lista por Acronimo
            //Categorias = Categorias.OrderBy(x => x.Acronimo).ToList();
        }

        public void LoadSubCategorias()
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            DataSet ds = ws.LstSubCategoriasPEP(Codigo);

            if (SubCategorias == null)
                SubCategorias = new List<SubCategoriaPEP>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                SubCategoriaPEP sucat = new SubCategoriaPEP();

                sucat.Codigo = Convert.ToInt32(dr["CODIGO"]);
                sucat.Acronimo = dr["ACRONIMO"].ToString();
                sucat.Descripcion= dr["DESCRIPCION"].ToString();
               
              
                SubCategorias.Add(sucat);
            }

            //Ordena la lista por Acronimo
            SubCategorias = SubCategorias.OrderBy(x => x.Acronimo).ToList();
        }

        public static CategoriaPEP GetCategoria(int codigo)
        {
            foreach (CategoriaPEP c in Categorias)
            {
                if (c.Codigo == codigo)
                    return c;
            }

            return null;
        }

    }
}
