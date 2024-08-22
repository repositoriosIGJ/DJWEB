using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;

namespace DJEngine.Business
{
    public class Escribano
    {
        /*DATOS DE LA MATRICULA DEL ESCRIBANO*/
         
        /// <summary>
        /// NUMERO DE MATRICULA DEL ESCRIBANO
        /// </summary>
        public string NumeroMat { get; set; }
        /// <summary>
        /// TOMO DE LA MATRICULA DEL ESCRIBANO
        /// </summary>
        public string TomoMat { get; set; }
        /// <summary>
        /// FOLIO DE MATRICULA DEL ESCRIBANO
        /// </summary>
        public string FolioMat { get; set; }

        /*DATOS DE LA ESCRITURA*/
        /// <summary>
        /// NUMERO DE ESCRITURA
        /// </summary>
        public string NumeroES { get; set; }

        /// <summary>
        /// FOLIO DE LA ESCRITURA
        /// </summary>
        public string FolioES { get; set; }

        /// <summary>
        /// FECHA DE ESCRITURA
        /// </summary>
        public DateTime FechaES { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }

    }
}