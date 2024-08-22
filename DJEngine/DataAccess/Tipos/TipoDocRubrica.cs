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
    public class TiposDocRubrica : Tipos
    {
        private static DataSet ds;

        public TiposDocRubrica()
            : base(ds)
        {
            getTiposDocRubrica();
        }

        public TiposDocRubrica(int index)
            : base(ds)
        {
            getTiposDocRubrica();
            Load(index);
        }

        public DataSet getTiposDocRubrica()
        {
            _CodigoDefault = 1;

            if (ds == null)
            {
                LoadTablaDocRubrica();
            }
            return ds;
        }

        public void LoadTablaDocRubrica()
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            _CodigoDefault = 1;

            ds = ws.LstTiposDocRubrica();
        }
    }
}
