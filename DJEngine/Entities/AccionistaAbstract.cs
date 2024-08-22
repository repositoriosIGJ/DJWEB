using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJEngine.Business
{
    public abstract class AccionistaAbstract
    {
        public string Porcentaje { get; set; }
        public string TotalAcciones { get; set; }
        public string Votos { get; set; }
        public string CUIT { get; set; }
        public DomicilioInfo Domicilio { get; set; }

    }
}
