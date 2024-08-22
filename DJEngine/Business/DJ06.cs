using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using DJEngine.UsoGeneral;
using DJEngine.DataAccess.Tipos;
using DJEngine.Reportes;

namespace DJEngine.Business
{
    public class DJ06 : DJAbstract
    {
        private Entidad _Ent;

        public Entidad Ent
        {
            get { return _Ent; }
            set { _Ent = value; }
        }
        private Representante _Rep;

        public Representante Rep
        {
            get { return _Rep; }
            set { _Rep = value; }
        }

        private OrigenFondos _Ori;

        public OrigenFondos Ori
        {
            get { return _Ori; }
            set { _Ori = value; }
        }
        private Escribano _Esc;

        public Escribano Esc
        {
            get { return _Esc; }
            set { _Esc = value; }
        }

        public DJ06()
            : base(6)
        {
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Rep = (Representante)HttpContext.Current.Session["Representante"];//aca--Chequear que sea este el nombre de la variable de session
            Ori = (OrigenFondos)HttpContext.Current.Session["OrigenFondos"];//aca--Chequear que sea este el nombre de la variable de session
            Esc = (Escribano)HttpContext.Current.Session["Escribano"];

            LeyendaDJ = "DECLARACION JURADA (Res. Nro. 02/2012) - ORIGEN LICITO DE LOS FONDOS";
        }

        public override bool RegistrarDJ()//Avanzado
        {
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Rep = (Representante)HttpContext.Current.Session["Representante"];//aca--Chequear que sea este el nombre de la variable de session
            Ori = (OrigenFondos)HttpContext.Current.Session["OrigenFondos"];//aca--Chequear que sea este el nombre de la variable de session
            Esc = (Escribano)HttpContext.Current.Session["Escribano"];

            int status;
            string mensaje;

            WSMotorDDJJ.DDJJHeader Header = new WSMotorDDJJ.DDJJHeader();

            //Llenado de Campos            
            //Numero de Declaracion Jurada
            Header.TipoDDJJ = this.TipoDJ_Id.ToString();
            Header.Operacion = "OLFes"; //harcodeo OLF para origen licito de los fondos
            GenerarHash();
            Header.CodHash = base.DJHash;//TODO: Ojo no creo que se guarde en la DB(debería?)

            //Datos de Entidad
            Header.NroCorr = Convert.ToString(Ent.NroCorrelativo); //Nulleable
            Header.Campo01 = Convert.ToString(Convert.ToInt32(Ent.Constituida)); //False = 0 y True = 1
            Header.Campo02 = Convert.ToString(Ent.Cuit);
            
            //Datos del Representante
            Header.Campo03 = Convert.ToString(Rep.Nombre);
            Header.Campo04 = Convert.ToString(Rep.Apellido);
            Header.Campo05 = Convert.ToString(Rep.TipoDoc);
            Header.Campo06 = Convert.ToString(Rep.NroDoc);
            Header.Campo07 = Convert.ToString(Rep.TipoClaveFiscal);
            Header.Campo08 = Convert.ToString(Rep.NroClaveFiscal);

            //Datos del Origen de Fondos--Donante
            Header.Campo09 = Convert.ToString(Ori.Nombre);
            Header.Campo10 = Convert.ToString(Ori.Apellido);
            Header.Campo11 = Convert.ToString(Ori.TipoDoc);
            Header.Campo12 = Convert.ToString(Ori.NroDoc);
            Header.Campo13 = Convert.ToString(Ori.TipoClaveFiscal);
            Header.Campo14 = Convert.ToString(Ori.NroClaveFiscal);
            Header.Campo15 = Convert.ToString(Ori.RazonSocial);
            Header.Campo16 = Convert.ToString(Ori.PersonaFisica);
         
            //Datos del Origen de Fondos--Donacion

            //Caracter de los Fondos
            Header.Campo17 = Convert.ToString(Ori.CaracterFondo); //Caracter Fondo - 1 Donacion - 2 Aporte de Terceros
            
            //Modo de Ingreso de los Fondos
            Header.Campo18 = Convert.ToString(Ori.TipoIngreso); //Tipo de Ingreso
            
            //Modo de Ingreso de los Fondos - Otro Instrumento
            Header.Campo19 = Convert.ToString(Ori.OtroInstrumento);

            //Modo de Ingreso de los Fondos - Transferencia
            Header.Campo20 = Convert.ToString(Ori.EntidadBancaria);
            Header.Campo21 = Convert.ToString(Ori.NroCuenta);
            
            //Monto
            Header.Campo22 = Convert.ToString(Ori.MasDeDoscientosMil); //Mas de Doscientos mil
            Header.Campo23 = Convert.ToString(Ori.DocRespaldatoria); // Documentacion Respaldatoria 


            /*
                   Los datos sobre el escribano que declara, segun la dirigencia
               actual (14/05/2012), no se guardan en la base de datos
            */

            WSMotorDDJJ.WS_MOTOR_DDJJ Motor = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            long ddjjid = Motor.Insert_Header(Header, out status, out mensaje);

            if (status != 1)
            {
                //TODO: Manejar Fallo de Insert_Header
                return false;
            }

            DJId = ddjjid;

            /*Procesar la DDJJ*/
            //TODO: MUCHO OJO CON ESTO PORQUE ESTA COMENTADO Y TIENE QUE ESTAR ARREGLADO
            status = Motor.Proc_Ddjj(ddjjid, out mensaje);

            if (status != 1)
            {
                //TODO: Manejar Fallo de Proc_Ddjj
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombres">Enumerator como array de strings</param>
        /// <param name="indice">index del nombre a mostrar</param>
        /// <returns>nombre contenido en el enumerator que fue apuntado por el indice</returns>
        private string TraerValor(string[] nombres, int indice)
        {
            return Convert.ToString(nombres[indice]).Replace("_", " ");
        }

        public override void GenerarReporte(bool imprimir)
        {
            //Cambiar nro de Declaracion Jurada por cada nueva
            Reportes.EntityReport.EntityDJ06 dj = new Reportes.EntityReport.EntityDJ06();
            string DJId = "06";

            //Llenado de Campos

            //TODO: Cambio True/False por Si/No
            dj.ENTINSCRIPTA = Convert.ToString(Convert.ToInt32(Ent.Constituida));
            dj.ENTRAZONSOCIAL = Convert.ToString(Ent.RazonSocial);
            dj.ENTTIPOSOCIETARIO = Convert.ToString(Ent.TipoSocId);
            dj.ENTNROCORRELATIVO = Convert.ToString(Ent.NroCorrelativo);
            dj.ENTNROCUIT = Convert.ToString(Ent.Cuit);
            dj.TITNOMBRE = Convert.ToString(Rep.Nombre);
            dj.TITAPELLIDO = Convert.ToString(Rep.Apellido);
            

            dj.TITTIPODOC = new TiposDocumento(Rep.TipoDoc).Acronimo;
            dj.TITNRODOC = Convert.ToString(Rep.NroDoc);
            

            dj.TITTIPOCLAVEFISCAL = Convert.ToString(new TiposFiscal(Rep.TipoClaveFiscal).Codigo);
            dj.TITNROCLAVEFISCAL = Convert.ToString(Rep.NroClaveFiscal);
            dj.APONOMBRE = Convert.ToString(Ori.Nombre);
            dj.APOAPELLIDO = Convert.ToString(Ori.Apellido);
            

            dj.APOTIPODOC = new TiposDocumento(Ori.TipoDoc).Acronimo;
            dj.APONRODOC = Convert.ToString(Ori.NroDoc);
            

            dj.APOTIPOCLAVEFISCAL = Convert.ToString(new TiposFiscal(Ori.TipoClaveFiscal).Codigo);
            dj.APONROCLAVEFISCAL = Convert.ToString(Ori.NroClaveFiscal);
            dj.APORAZONSOCIAL = Convert.ToString(Ori.RazonSocial);
            dj.APOPERSONAFISICA = Convert.ToString(Ori.PersonaFisica);
            dj.FONCARACTERFONDO = Convert.ToString(Ori.CaracterFondo);
            dj.FONTIPOINGRESO = Convert.ToString(Ori.TipoIngreso);
            dj.FONOTROINSTRUMENTO = Convert.ToString(Ori.OtroInstrumento);
            dj.FONENTIDADBANCARIA = Convert.ToString(Ori.EntidadBancaria);
            dj.FONNROCUENTA = Convert.ToString(Ori.NroCuenta);
            dj.FONMASDEDOSCIENTOSMIL = Convert.ToString(Ori.MasDeDoscientosMil);
            dj.DOCRESPALDATORIA = Convert.ToString(Ori.DocRespaldatoria);

            dj.ESCFOLIO = Esc.FolioMat;
            dj.ESCMATRICULA = Esc.NumeroMat;
            dj.ESCTOMO = Esc.TomoMat;

            dj.MATFECHA = Esc.FechaES.ToString("dd/MM/yyyy");
            dj.MATFOLIO = Esc.FolioES;
            dj.MATNUMERO = Esc.NumeroES;
            dj.ESCNOMBRE = Esc.Nombres;
            dj.ESCAPELLIDO = Esc.Apellidos;

            //Fecha de la Declaracion Jurada
            dj.DJPFECHA = DateTime.Now.ToString("dd/MM/yyyy");


            dj.HASH = this.CodigoEscaner;

            oRpt.Load(HttpContext.Current.Server.MapPath("Reportes") + "/DDJJ06.rpt");

            CodigoBarra codigoBarras = new CodigoBarra();

            System.Drawing.Image imagen;
            MemoryStream ms = new MemoryStream();

            //NumeroSerie = dj.ID;

            imagen = codigoBarras.GenerarImagenCodigoBarra(this.DJHash);
            imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            dj.CODIGODEBARRAS = ms.ToArray();

            ms.Close();

            oRpt.SetDataSource(new[] { dj });

            if (imprimir)
            {
                //Imprimir Formulario
                oRpt.PrintToPrinter(1, false, 1, 1);
            }
            else
            {
                //Descargar Formulario
                MemoryStream oStream;

                oStream = (MemoryStream)oRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.AddHeader("Content-disposition", "attachment; filename=DDJJ" + DJId + "_" + base.CodigoEscaner + ".pdf");
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.BinaryWrite(oStream.ToArray());
                HttpContext.Current.Response.End();
            }   
        }

        public override void ReiniciarDeclaracion()
        {
            /*BORRO TODOS LOS ATRIBUTOS*/
            _Ent = null;
            _Rep = null;
            _Ori = null;
            _Esc = null;

            /*BORRO TODAS LAS VARIABLES DE SESSION*/
            //HttpContext.Current.Session["DatosEntidad"] = null;
            //HttpContext.Current.Session["Entidad"] = null;
            //HttpContext.Current.Session["PersonaEP"] = null;
            //HttpContext.Current.Session["captchaUrl"] = null;

            HttpContext.Current.Session.Clear();

            DJ06 dj06 = new DJ06();
            HttpContext.Current.Session["DJ"] = dj06;

            this.WorkFlow.Iniciar();
        }
    }
}
