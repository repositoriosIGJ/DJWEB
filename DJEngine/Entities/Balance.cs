using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJEngine.Business
{
    public class Balance
    {
        public int Anio { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin{ get; set; }
        public DateTime FechaReunion { get; set; }
        public int TipoAsamblea { get; set; }
        public DateTime FechaAsamblea { get; set; }
        public decimal MontoMonedaCapital { get; set; }
        //public int MonedaIdCapital { get; set; }
        //public string MonedaDescCapital { get; set; }
        //public decimal MontoPesosCapital { get; set; }
        public decimal MontoMonedaAjuste { get; set; }
        //public int MonedaIdAjuste { get; set; }
        //public string MonedaDescAjuste { get; set; }
        //public decimal MontoPesosAjuste { get; set; }
    }
}
