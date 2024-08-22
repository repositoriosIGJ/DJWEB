using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DJEngine.DataAccess.Tipos
{
    public class TiposValuacion : Tipos
    {
        private static DataSet ds;

        public TiposValuacion()
            : base(ds)
        {
            getTiposValuacion();
        }

        public TiposValuacion(int index)
            : base(ds)
        {
            getTiposValuacion();
            Load(index);
        }

        public DataSet getTiposValuacion()
        {
            _CodigoDefault = 1;

            if (ds == null)
            {
                LoadTablaValuacion();
            }
            return ds;
        }

        //TODO: revisar bien
        public DataSet getTiposValuacionFiltrado(int TipoBienId)
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            _CodigoDefault = 1;

            DataSet ds1 = ws.LstTiposValuacionFiltrados(TipoBienId);

            return ds1;
        }

        public void LoadTablaValuacion()
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            _CodigoDefault = 1;

            ds = ws.LstTiposValuacion();
        }
    }
}
