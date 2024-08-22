using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DJEngine.DataAccess.Tipos
{
    public class SubCategoriaPEP : Tipos
    {
        private static DataSet ds;

        public SubCategoriaPEP()
            : base(ds)
        {
        }

        public SubCategoriaPEP(int index)
            : base(ds)
        {
            Load(index);
        }

        public DataSet getSubCategoriaPEP(int catpepid)
        {
            _CodigoDefault = 1;

            if (ds == null)
            {
                LoadTablaSubCategoriaPEP(catpepid);
            }
            return ds;
        }

        public void LoadTablaSubCategoriaPEP(int catpepid)
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            _CodigoDefault = 1;

            ds = ws.LstSubCategoriasPEP(catpepid);

        }
    }
}
