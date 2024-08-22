using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DJEngine.DataAccess.Tipos
{
    public class TiposInstrumento : Tipos
    {
        private static DataSet ds;

        public TiposInstrumento()
            : base(ds)
        {
            getTiposInstrumento();
        }

        public TiposInstrumento(int index)
            : base(ds)
        {
            getTiposInstrumento();
            Load(index);
        }

        public DataSet getTiposInstrumento()
        {
            _CodigoDefault = 1;

            if (ds == null)
            {
                LoadTablaInstrumento();
            }
            return ds;
        }

        //public DataSet getTiposInstrumentoFiltrado(int TipoBienId)
        //{
        //    WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

        //    _CodigoDefault = 1;

        //    DataSet ds1 = ws.LstTiposInstrumentoFiltrados(TipoBienId);

        //    return ds1;
        //}

        public void LoadTablaInstrumento()
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            _CodigoDefault = 1;

            ds = ws.LstTiposInstrumento();
        }
    }
}
