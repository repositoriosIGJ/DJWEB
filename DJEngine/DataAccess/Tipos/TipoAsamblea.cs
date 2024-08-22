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
    public class TiposAsamblea : Tipos
    {
        private static DataSet ds;

        public TiposAsamblea()
            : base(ds)
        {
            getTiposAsamblea();
        }

        public TiposAsamblea(int index)
            : base(ds)
        {
            getTiposAsamblea();
            Load(index);
        }

        public DataSet getTiposAsamblea()
        {
            _CodigoDefault = 1;

            if (ds == null)
            {
                LoadTablaAsamblea();
            }
            return ds;
        }

        public void LoadTablaAsamblea()
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            _CodigoDefault = 1;

            ds = ws.LstTiposAsamblea();
        }
    }
}
