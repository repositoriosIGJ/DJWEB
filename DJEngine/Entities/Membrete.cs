using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;

namespace DJEngine.Business
{
    public class Membrete
    {
        private int _TipoMem;

        public int TipoMem
        {
            get { return _TipoMem; }
            set { _TipoMem = value; }
        }

        private string _Anio;

        public string Anio
        {
            get { return _Anio; }
            set { _Anio = value; }
        }

        private string _TextoMembrete;

        public string TextoMembrete
        {
            get { return _TextoMembrete; }
            set { _TextoMembrete = value; }
        }

        public Membrete()
        {
            DJEngine.WSMotorDDJJ.WS_MOTOR_DDJJ Motor = new DJEngine.WSMotorDDJJ.WS_MOTOR_DDJJ();

            DataSet ds = Motor.GetMembrete();

            int ultimo = ds.Tables[0].Rows.Count;
            int indice = 0;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ++indice;
                if (ultimo == indice)
                {
                    this.TipoMem = Convert.ToInt32(dr["TIPO_MEMBRETE_ID"]);
                    this.Anio = dr["Anio"].ToString();
                    this.TextoMembrete = dr["Texto"].ToString();
                }
            }                            
        }
    }
}
