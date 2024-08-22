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
/// Summary description for TiposCuentaBanco
/// </summary>
/// 
namespace DJEngine.DataAccess.Tipos
{
    public class TiposCuentaBanco : Tipos
    {
        private static DataSet ds;

        public TiposCuentaBanco()
            : base(ds)
        {
            getTipoCuentaBanco();
        }

        public TiposCuentaBanco(int index)
            : base(ds)
        {
            getTipoCuentaBanco();
            Load(index);
        }

        public DataSet getTipoCuentaBanco()
        {
            _CodigoDefault = 1;

            if (ds == null)
            {
               LoadTablaCuentaBanco();
            }
            return ds;
        }

        public void LoadTablaCuentaBanco()
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            _CodigoDefault = 1;

           ds = ws.LstTiposCuentaBanco();
        }
    }
}