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
/// Summary description for TipoDocumento
/// </summary>
/// 
namespace DJEngine.DataAccess.Tipos
{
    public class TiposDocumento : Tipos
    {
        private static DataSet ds;

        public TiposDocumento()
            : base(ds)
        {
            getTipoDocumento();
        }

        public TiposDocumento(int index)
            : base(ds)
        {
            getTipoDocumento();
            Load(index);
        }

        public DataSet getTipoDocumento()
        {
            _CodigoDefault = 1;

            if (ds == null)
            {
               LoadTablaDocumentos();
            }
            return ds;
        }

        public void LoadTablaDocumentos()
        {
            //WsDeclaracionJurada.ws_ddjj_web ws = new WsDeclaracionJurada.ws_ddjj_web();
            //WsConsultasEntidades.IGJ_Generic ws = new WsConsultasEntidades.IGJ_Generic();
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            _CodigoDefault = 1;

           ds = ws.LstTiposDocumentos();

 
        }


    }
}