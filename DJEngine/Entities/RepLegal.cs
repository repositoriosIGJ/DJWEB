using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJEngine.Business
{
    public class RepLegal
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDoc { get; set; }
        //public int TipoDocId { get; set; }
        public string NroDoc { get; set; }
        public int TipoClaveFiscal { get; set; }
        //public int TipoClaveFiscalId { get; set; }
        public string NroClaveFiscal { get; set; }
        public string DomicilioReal { get; set; }
    }
}
