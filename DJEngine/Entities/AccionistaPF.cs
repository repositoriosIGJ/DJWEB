using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DJEngine.DataAccess.Tipos;

namespace DJEngine.Business
{
    public class AccionistaPF:AccionistaAbstract
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public TiposDocumento TipoDocumento { get; set; }
        public string NroDocumento { get; set; }

    }
}
