using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DJEngine.DataAccess.Tipos
{
    public class TiposMonedas : Tipos
    {
        private static DataSet ds;

        public TiposMonedas()
            : base(ds)
        {
            getTiposMonedas();
        }

        public TiposMonedas(int index)
            : base(ds)
        {
            getTiposMonedas();
            Load(index);
        }

        public DataSet getTiposMonedas()
        {
            _CodigoDefault = 1;

            if (ds == null)
            {
                LoadTablaMonedas();
            }
            return ds;
        }

        public void LoadTablaMonedas()
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            _CodigoDefault = 1;

            ds = ws.LstTiposMonedas();
        }
    }
}
