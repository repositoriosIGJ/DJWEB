using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;

namespace DJEngine.Business
{
    public class Legal
    {
        private int _TipoDJ;

        public int TipoDJ
        {
            get { return _TipoDJ; }
            set { _TipoDJ = value; }
        }

        private string _TextoLegal;

        public string TextoLegal
        {
            get { return _TextoLegal; }
            set { _TextoLegal = value; }
        }

        public Legal(int __tipoDJ)
        {
            //WSMotorDDJJ.WS_MOTOR_DDJJ Motor = new WSMotorDDJJ.WS_MOTOR_DDJJ();
            //DataSet ds = Motor.GetLegales(__tipoDJ);
            StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~\\App_Data\\MarcoLegal\\MarcoLegal" + __tipoDJ.ToString("00")+ ".htm"));

            if (sr.EndOfStream == false)
            {
                this.TextoLegal = sr.ReadToEnd();
                this.TipoDJ = __tipoDJ;
            }
            sr.Close();
        }
    }
}
