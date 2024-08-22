using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJEngine.Business
{
    public class DomicilioInfo
    {
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string CP { get; set; }

        public override string ToString()
        {
            return Calle + " " + Numero  + " " + CP;
        }
    }
}
