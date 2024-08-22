using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJEngine.Business
{
    public class Libros
    {
        public List<Libro> libros { get; set; }
    }

    public class Libro
    {
        public int iddoc { get; set; } //IdDocumento
        public string doc { get; set; } //Documento
        public string den { get; set; } //Denominacion
        public string nru { get; set; } //NroRubrica
        public string fru { get; set; } //FecRubrica
        public string fol { get; set; } //Folios
        public string has { get; set; } //Hash
    }
}
