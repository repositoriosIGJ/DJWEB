using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJEngine.Business
{
    public class AccionistaPJ:AccionistaAbstract
    {
        public string DenominacionSocial { get; set; }
        public string Jurisdiccion { get; set; }
        public string Pais { get; set; }
        public bool EsNacional { get; set; }

    }
}
