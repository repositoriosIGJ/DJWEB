using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DJEngine.DataAccess.Tipos
{
    public class TiposFiscal: Tipos
    {
        private static DataSet ds;

        public TiposFiscal()
            : base(ds)
        {
            getTipoFiscal();
        }

        public TiposFiscal(int index)
            : base(ds)
        {
            getTipoFiscal();
            Load(index);
        }

        public DataSet getTipoFiscal()
        {
            _CodigoDefault = 1;

            if (ds == null)
            {
                LoadTablaFiscal();
            }
            return ds;
        }

        public void LoadTablaFiscal()
        {
            //WsDeclaracionJurada.ws_ddjj_web ws = new WsDeclaracionJurada.ws_ddjj_web();
            //WsConsultasEntidades.IGJ_Generic ws = new WsConsultasEntidades.IGJ_Generic();
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            _CodigoDefault = 1;

            //TODO: Arreglar WebService LstTiposClaveFiscal
            ds = ws.LstTiposClaveFiscal();
        }


    }
}
