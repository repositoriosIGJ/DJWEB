using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJEngine.Business
{
    public class OrigenFondos
    {
        ///////////////
        // Aportante //
        ///////////////
        ////////////////////
        // Persona Fisica //
        ////////////////////
        public int PersonaFisica { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDoc { get; set; }
        public string NroDoc { get; set; }
        public int TipoClaveFiscal { get; set; }
        public string NroClaveFiscal { get; set; }
        //////////////////////
        // Persona Juridica //
        //////////////////////
        public string RazonSocial { get; set; }
        public string NroCuitPJ { get; set; } //Nuevo Campo 01/16
        ////////////
        // Fondos //
        ////////////
        public int CaracterFondo { get; set; }
        public string Origen { get; set; } //Nuevo Campo 01/16       
        public DateTime FechaCF { get; set; } //Nuevo Campo 01/16
        /////////////////////
        // Modo de Ingreso //
        /////////////////////
        public int TipoIngreso { get; set; }
        //////////////
        // Efectivo //
        //////////////
        public int TipoInstrumentoEfe { get; set; } //Nuevo Campo 01/16
        //Deposito
        public string EntBanDeposito { get; set; } //Nuevo Campo 01/16
        public int TipoCuentaIdDeposito { get; set; }
        public string TipoCuentaDeposito { get; set; }
        public string NroCuentaDeposito { get; set; } //Nuevo Campo 01/16
        //Donante
        public string EntBanDonante { get; set; } //Nuevo Campo 12/15
        public int TipoCuentaIdDonante { get; set; }
        public string TipoCuentaDonante { get; set; }
        public string NroCuentaDonante { get; set; } //Nuevo Campo 12/15
        //Donatario
        public string EntBanDonatario { get; set; } //Nuevo Campo 12/15
        public int TipoCuentaIdDonatario { get; set; }
        public string TipoCuentaDonatario { get; set; }
        public string NroCuentaDonatario { get; set; } //Nuevo Campo 12/15
        //Otro Instrumento
        public string OtroInstrumento { get; set; }
        //Montos
        public decimal MontoMoneda { get; set; } //Nuevo Campo 01/16
        public int MonedaId { get; set; } //Nuevo Campo 01/16
        public string MonedaDesc { get; set; } //Nuevo Campo 01/16
        public decimal MontoPesos { get; set; } //Nuevo Campo 01/16
        //////////////
        // Especie //
        //////////////        
        public int TipoBien { get; set; } //Nuevo Campo 01/16
        public string DescripcionBien { get; set; } //Nuevo Campo 01/16
        public int Valuacion { get; set; } //Nuevo Campo 01/16
        //Cantidad
        public long Cantidad { get; set; } //Nuevo Campo 01/16
        //Valor Corriente Unitario
        public decimal ValCorUni { get; set; } //Nuevo Campo 01/16
        //Valor Corriente Total
        public decimal ValCorTot { get; set; } //Nuevo Campo 01/16
        ///////////
        // Monto //
        ///////////
        public int MasDeDoscientosMil { get; set; }
        public int DocRespaldatoria { get; set; }
    }
}
