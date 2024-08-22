using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJEngine.Business
{
    public class Contador
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        //ID DEL TIPO DE DOCUMENTO (INDICE EN LA TABLA TIPO_DOCUMENTO)
        public int TipoDoc { get; set; }
        public string NroDoc { get; set; }
        //ID DEL TIPO FISCAL (INDICE EN LA TABLA TIPO_CLAVEFISCAL)
        public int TipoClaveFiscal { get; set; }
        public string NroClaveFiscal { get; set; }
        public string Tomo { get; set; }
        public string Folio { get; set; }
        public DateTime FechaAuditor { get; set; }
        public int NroAuditor { get; set; }
    }
}
