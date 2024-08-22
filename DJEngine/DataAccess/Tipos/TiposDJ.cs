using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for TiposDJ
/// </summary>
/// 
namespace DJEngine.DataAccess.Tipos
{
    public class TiposDJ
    {
        public int TipoDJ_Id { get; set; }

        public string Descripcion { get; set; }

        public int Habilitado { get; set; }

        private static DataSet ds;

        private static List<TiposDJ> _TiposDDJJ;

        public static List<TiposDJ> TiposDDJJ
        {
            get
            {
                if (_TiposDDJJ == null)
                {
                    _TiposDDJJ = new List<TiposDJ>();
                    LoadTablaTiposDJ();
                }

                return TiposDJ._TiposDDJJ;
            }
        }

        public TiposDJ() //: base(ds)
        {
            getTiposDJ();
        } 

        public DataSet getTiposDJ()
        {
            //int _CodigoDefault = 1;

            if (ds == null)
            {
                LoadTablaTiposDJ();
            }
            return ds;
        }

        public static void LoadTablaTiposDJ()
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            ds = ws.LstTiposDJ();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TiposDJ tipodj = new TiposDJ();

                tipodj.TipoDJ_Id = Convert.ToInt32(dr["tipodj_id"]);
                tipodj.Descripcion = dr["Descripcion"].ToString();
                tipodj.Habilitado = Convert.ToInt32(dr["habilitado"]);

                TiposDDJJ.Add(tipodj);
            }
        }
    }
}