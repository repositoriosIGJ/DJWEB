using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using DJEngine.UsoGeneral;
using DJEngine.DataAccess.Tipos;
using DJEngine.Reportes.EntityReport;
using System.Text;
using System.Security.Cryptography;

namespace DJEngine.Business
{
    public class DJ02 : DJAbstract
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

        private DomDig _DD;

        public DomDig DD
        {
            get { return _DD; }
            set { _DD = value; }
        }

        public DJ02()
            : base(2)
        {
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Rep = (Representante)HttpContext.Current.Session["Representante"];
            DD = (DomDig)HttpContext.Current.Session["DomDig"];
            //TODO: Completar Resolucion y Numero de la DJ02
            LeyendaDJ = "DECLARACION JURADA (Res. Nro. ??/????) - DOMICILIO DIGITAL";
        }

        public override bool RegistrarDJ()
        {
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Rep = (Representante)HttpContext.Current.Session["Representante"];
            DD = (DomDig)HttpContext.Current.Session["DomDig"];

            int status;
            string mensaje;

            WSMotorDDJJ.DDJJHeader Header = new WSMotorDDJJ.DDJJHeader();

            //Llenado de Campos            
            //Numero de Declaracion Jurada
            Header.TipoDDJJ = Convert.ToString((int)EnumDJ.EDDJJ.DOMICILIO_DIGITAL);
            Header.Operacion = "DD"; //harcodeo DD por Domicilio Digital
            GenerarHash();
            Header.CodHash = base.DJHash;

            //Datos de Entidad
            Header.NroCorr = Convert.ToString(Ent.NroCorrelativo); //Nulleable
            Header.Campo01 = Ent.RazonSocial.ToString();
            Header.Campo02 = Convert.ToString(Ent.Cuit); //Nulleable
            Header.Campo03 = Convert.ToString(Convert.ToInt32(Ent.Constituida)); //False = 0 y True = 1

            //Datos del Representante
            Header.Campo04 = Convert.ToString(Rep.Nombre);
            Header.Campo05 = Convert.ToString(Rep.Apellido);
            Header.Campo06 = Convert.ToString(Rep.TipoDoc);
            Header.Campo07 = Convert.ToString(Rep.NroDoc);
            Header.Campo08 = Convert.ToString(Rep.TipoClaveFiscal);
            Header.Campo09 = Convert.ToString(Rep.NroClaveFiscal);

            //Datos del Domicilio Digital
            Header.Campo10 = Convert.ToString(DD.Email);
            Header.Campo11 = Convert.ToString(DD.CodVal);

            WSMotorDDJJ.WS_MOTOR_DDJJ Motor = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            long ddjjid = Motor.Insert_Header(Header, out status, out mensaje);

            if (status != 1)
            {
                //TODO: Manejar Fallo de Insert_Header
                return false;
            }

            DJId = ddjjid;

            /*Procesar la DDJJ*/
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
            EntityDJ02 dj = new EntityDJ02();
            string DJId = "02";

            //Numero de Declaracion Jurada
            dj.TIPODDJJ = Convert.ToString((int)EnumDJ.EDDJJ.DOMICILIO_DIGITAL);
            dj.DJPFECHA = DateTime.Now.ToString("dd/MM/yyyy");

            //Datos de Entidad
            

            //TODO: Cambio True/False por Si/No
            // Deberia ser siempre inscripta para la DJ02
            if (Ent.Constituida == true)
            {
                dj.ENTINSCRIPTA = "SI";
            }
            else
            {
                dj.ENTINSCRIPTA = "NO";
            }

            dj.ENTNROCORRELATIVO = Convert.ToString(Ent.NroCorrelativo);

            if (Ent.Constituida == false)
            {
                dj.ENTNROCORRELATIVO = "NO REGISTRADO";
            }

            dj.ENTRAZONSOCIAL = Ent.RazonSocial.ToUpper();
            dj.ENTTIPOSOCIETARIO = new TiposSocietario(Ent.TipoSocId).Descripcion;
            //dj.ENTNROCUIT = Convert.ToString(Ent.Cuit);
            //if (dj.DJPCUIT == null)
            //{
            //    dj.DJPCUIT = "NO REGISTRADO";
            //}

            dj.EMAILDOMDIG = DD.Email;
            
            dj.TITNOMBRE = Rep.Nombre;
            dj.TITAPELLIDO = Rep.Apellido;
            //dj.TITTIPODOC = new TiposDocumento(Rep.TipoDoc).Acronimo;
            dj.TITTIPODOC = Convert.ToString(Rep.TipoDoc);
            dj.TITNRODOC = Convert.ToString(Rep.NroDoc);

            if (Rep.NroClaveFiscal != "")
            {
                dj.TITTIPOCLAVEFISCAL = Convert.ToString(new TiposFiscal(Rep.TipoClaveFiscal).Codigo);
                dj.TITNROCLAVEFISCAL = Convert.ToString(Rep.NroClaveFiscal);
            }
            else
            {
                dj.TITTIPOCLAVEFISCAL = "";
                dj.TITNROCLAVEFISCAL = "";
            }

            dj.HASH = this.CodigoEscaner;

            oRpt.Load(HttpContext.Current.Server.MapPath("Reportes") + "/DDJJ02.rpt");

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
                oRpt.PrintToPrinter(1, false, 1, 1);

                /*mensage de alerta*/
                //Response.Write("<script language=javascript>alert('Se ha impreso su Declaración Jurada');</script>");
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
            _DD = null;

            /*BORRO TODAS LAS VARIABLES DE SESSION*/
            HttpContext.Current.Session.Clear();

            DJ02 dj02 = new DJ02();
            HttpContext.Current.Session["DJ"] = dj02;

            this.WorkFlow.Iniciar();
        }
    }
}
