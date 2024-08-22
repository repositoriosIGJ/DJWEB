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
/// Summary description for TipoSocietario
/// </summary>
/// 
namespace DJEngine.DataAccess.Tipos
{
    public class TiposSocietario : Tipos
    {
        private static DataSet ds;
        private static int lastindex;

        public TiposSocietario()
            : base(ds)
        {
            getTipoSocietario();
        }

        public TiposSocietario(int index)
            : base(ds)
        {
            if (lastindex != index)
            {
                lastindex = index;
                ds = null;
            }

            getTipoSocietario();
            
            Load(index);
        }

        public DataSet getTipoSocietario()
        {
            _CodigoDefault = 50;

            if (ds == null)
            {
                LoadTablaSocietarios();
            }
            return ds;
        }

        public DataSet getTipoSocietarioFiltrado(int TipoDDJJ)
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            DataSet ds1 = ws.LstTiposSocietariosFiltrados(TipoDDJJ);

            ds1.Tables[0].Columns["ACRONIMO"].MaxLength = 40;

            DataRow row = ds1.Tables[0].NewRow();
            row["CODIGO"] = "-1";
            row["ACRONIMO"] = "<< SELECCIONAR OPCION >>";
            row["DESCRIPCION"] = "<< SELECCIONAR OPCION >>";

            ds1.Tables[0].Rows.InsertAt(row, 0);

            return ds1;
        }

        //Sin << SELECCIONAR OPCION >>
        public DataSet getTipoSocietarioFiltradoSinSel(int TipoDDJJ)
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            DataSet ds1 = ws.LstTiposSocietariosFiltrados(TipoDDJJ);

            ds1.Tables[0].Columns["ACRONIMO"].MaxLength = 40;

            //DataRow row = ds1.Tables[0].NewRow();
            //row["CODIGO"] = "-1";
            //row["ACRONIMO"] = "<< SELECCIONAR OPCION >>";
            //row["DESCRIPCION"] = "<< SELECCIONAR OPCION >>";

            //ds1.Tables[0].Rows.InsertAt(row, 0);

            return ds1;
        }

        private void LoadTablaSocietarios()
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            _CodigoDefault = 1;

            ds = ws.LstTiposSocietarios();

            DataRow row = null;

            ds.Tables[0].Columns["ACRONIMO"].MaxLength = 40;

            row = ds.Tables[0].NewRow();
            row["CODIGO"] = "-1";
            row["ACRONIMO"] = "<< SELECCIONAR OPCION >>";
            row["DESCRIPCION"] = "<< SELECCIONAR OPCION >>";
            
            ds.Tables[0].Rows.InsertAt(row, 0);
        }
    }
}