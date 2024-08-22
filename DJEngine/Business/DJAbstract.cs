using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using CrystalDecisions.CrystalReports.Engine;

namespace DJEngine.Business
{
    public abstract class DJAbstract
    {
        protected ReportDocument oRpt = new ReportDocument();
        private long _DJId;

        public long DJId
        {
            get { return _DJId; }
            set { 
                _DJId = value; 
            
            }
        }

        private string _DJHash;

        public string DJHash
        {
            get { 
                return _DJHash; 
            
            }
        }

        private string _LeyendaDJ;

        public string LeyendaDJ
        {
            get { return _LeyendaDJ; }
            set { _LeyendaDJ = value; }
        }

        private string _CodigoEscaner;

        public string CodigoEscaner
        {
            get {
                return _TipoDJ_Id.ToString("00") + DateTime.Now.ToString("ddMMyy") + _DJHash; 
            
            }
        }

        private int _TipoDJ_Id;

        public int TipoDJ_Id
        {
            get { return _TipoDJ_Id; }
            set { _TipoDJ_Id = value; }
        }

        private Legal _MarcoLegal;

        public Legal MarcoLegal
        {
            get { return _MarcoLegal; }
            set { _MarcoLegal = value; }        
        }

        private Membrete _Membrete;

        public Membrete Membrete
        {
            get { return _Membrete; }
            set { _Membrete = value; }
        }

        private DJWorkFlow _WorkFlow;

        public DJWorkFlow WorkFlow
        {
            get { return _WorkFlow; }
            set { _WorkFlow = value; }
        }

        public DJAbstract(int tipodj)
        {
            _TipoDJ_Id = tipodj;
            this.MarcoLegal = new Legal(tipodj);
            //TODO_MEMBRETE: Agrega Membrete
            this.Membrete = new Membrete();
            this.WorkFlow = new DJWorkFlow(tipodj);

        }

        public string GenerarHash()
        {
            int longitud = 32;

            Random rnd = new Random((int)DateTime.Now.Ticks);

            StringBuilder s = new StringBuilder(longitud);

            //Obligo a que ingrese como primer caracter una letra 
            //Desde la letra A MAYUSCULA (65) hasta la letra Z MAYUSCULA (90)
            s.Append((char)(rnd.Next(65, 90)));
            //Obligo a que ingrese como primer caracter una letra
            //Desde el numero 0 (48) hasta el numero 9 (57)
            s.Append((char)(rnd.Next(48, 57)));
            // Un bucle para cada uno de los caracteres
            for (int i = 3; i <= longitud; i++)
            {
                char c;

                // El valor debe ser un carácter válido
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        //Desde el numero 0 (48) hasta el numero 9 (57)
                        c = (char)(rnd.Next(48, 57));
                        break;
                    case 2:
                        //Desde la letra A MAYUSCULA (65) hasta la letra Z MAYUSCULA (90)
                        c = (char)(rnd.Next(65, 90));
                        break;
                    default:
                        //Desde la letra a minuscula (97) hasta la letra z minuscula (122)
                        c = (char)(rnd.Next(97, 123));
                        break;
                }

                //Lo añadimos a la cadena
                s.Append(c);
            }

            //***************************************//
            //*****  CALCULO DE HASH DE LA CLAVE ****//
            //***************************************//

            // Devolvemos la cadena generada
            SHA1Managed algoritmoHash = new SHA1Managed();

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

            byte[] bhsh = algoritmoHash.ComputeHash(encoding.GetBytes(s.ToString()));
            string hsh = "";
            foreach (byte b in bhsh)
            {
                hsh += b.ToString("X2");
            }
            _DJHash = hsh;
            return hsh;
        }


        public abstract bool RegistrarDJ();

        public abstract void GenerarReporte(bool imprimir);

        public abstract void ReiniciarDeclaracion();
    }
}
