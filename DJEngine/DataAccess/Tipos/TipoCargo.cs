using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace DJEngine.DataAccess.Tipos
{
    public class TiposCargo : Tipos
    {
        private static DataSet ds;

        public TiposCargo()
            : base(ds)
        {
            getTiposCargo();
        }

        public TiposCargo(int index)
            : base(ds)
        {
            getTiposCargo();
            Load(index);
        }

        public DataSet getTiposCargo()
        {
            _CodigoDefault = 1;

            if (ds == null)
            {
                LoadTablaCargo();
            }
            return ds;
        }

        public DataSet getTiposCargoFiltrado(int TipoSocId)
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            _CodigoDefault = 1;

            DataSet ds1 = ws.LstTiposCargoFiltrados(TipoSocId);

            //ds1.Tables[0].Columns["ACRONIMO"].MaxLength = 40;

            //DataRow row = ds1.Tables[0].NewRow();
            //row["CODIGO"] = "-1";
            //row["ACRONIMO"] = "<< SELECCIONAR OPCION >>";
            //row["DESCRIPCION"] = "<< SELECCIONAR OPCION >>";

            //ds1.Tables[0].Rows.InsertAt(row, 0);

            return ds1;
        }

        public void LoadTablaCargo()
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            _CodigoDefault = 1;

            ds = ws.LstTiposCargo();

            //DataRow row = null;

            //ds.Tables[0].Columns["ACRONIMO"].MaxLength = 40;

            //row = ds.Tables[0].NewRow();
            //row["CODIGO"] = "-1";
            //row["ACRONIMO"] = "<< SELECCIONAR OPCION >>";
            //row["DESCRIPCION"] = "<< SELECCIONAR OPCION >>";

            //ds.Tables[0].Rows.InsertAt(row, 0);
        }
    }
}
