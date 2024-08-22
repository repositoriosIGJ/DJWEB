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
    public class TiposDictamen : Tipos
    {
        private static DataSet ds;

        public TiposDictamen()
            : base(ds)
        {
            getTiposDictamen();
        }

        public TiposDictamen(int index)
            : base(ds)
        {
            getTiposDictamen();
            Load(index);
        }

        public DataSet getTiposDictamen()
        {
            _CodigoDefault = 1;

            if (ds == null)
            {
                LoadTablaDictamen();
            }
            return ds;
        }

        public void LoadTablaDictamen()
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            _CodigoDefault = 1;

            ds = ws.LstTiposDictamen();
        }
    }
}
