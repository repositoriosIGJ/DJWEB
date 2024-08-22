using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using DJEngine.UsoGeneral;
using DJEngine.DataAccess.Tipos;
using DJEngine.Reportes.EntityReport;

namespace DJEngine.Business
{
    public class DJ09 : DJAbstract
    {
        private Entidad _Fid;

        public Entidad Fid
        {
            get { return _Fid; }
            set { _Fid = value; }
        }

        private Entidad _Ent;

        public Entidad Ent
        {
            get { return _Ent; }
            set { _Ent = value; }
        }

        private RepLegal _Rep;

        public RepLegal Rep
        {
            get { return _Rep; }
            set { _Rep = value; }
        }

        public DJ09():base(9)
        { 
            Fid = (Entidad)HttpContext.Current.Session["Fideicomiso"];
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Rep = (RepLegal)HttpContext.Current.Session["RepLegal"];
            LeyendaDJ = "DECLARACION JURADA (Res. Nro. 07/2015) - FIDEICOMISO - FIDUCIARIO PERSONA JURIDICA";
        }

        public override bool RegistrarDJ()
        {
            Fid = (Entidad)HttpContext.Current.Session["Fideicomiso"];
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Rep = (RepLegal)HttpContext.Current.Session["RepLegal"];

            int status;
            string mensaje;

            WSMotorDDJJ.DDJJHeader Header = new WSMotorDDJJ.DDJJHeader();

            //Llenado de Campos            
            //Numero de Declaracion Jurada
            Header.TipoDDJJ = Convert.ToString((int)EnumDJ.EDDJJ.FIDEICOMISO_FIDUCIARIO_JURIDICA);
            Header.Operacion = "FFpj"; //harcodeo FFpj por FIDEICOMISO FIDUCIARIO PERSONA JURIDICA
            GenerarHash();
            Header.CodHash = base.DJHash;

            //Datos del FideiComiso
            Header.NroCorr = Convert.ToString(Fid.NroCorrelativo); //Nulleable
            Header.Campo01 = Fid.RazonSocial.ToString(); //Nulleable
            Header.Campo02 = Convert.ToString(Convert.ToInt32(Fid.Constituida)); //Inscripto //False = 0 y True = 1
            Header.Campo03 = Convert.ToString(Fid.TipoSocId); //Nulleable //Tipo Societario Fideicomiso Id
            Header.Campo04 = Convert.ToString(Fid.TipoSocDesc); //Nulleable //Tipo Societario Fideicomiso Descripcion            
            Header.Campo05 = Convert.ToString(Fid.Cuit); //Nulleable            
            
            //Datos de Entidad
            Header.Campo06 = Convert.ToString(Ent.NroCorrelativo); //Nulleable
            Header.Campo07 = Ent.RazonSocial.ToString(); //Nulleable
            Header.Campo08 = Convert.ToString(Convert.ToInt32(Ent.Constituida)); //False = 0 y True = 1
            Header.Campo09 = Convert.ToString(Ent.TipoSocId); //Nulleable //Tipo Societario Entidad Id
            Header.Campo10 = Convert.ToString(Ent.TipoSocDesc); //Nulleable //Tipo Societario Entidad Descripcion            
            Header.Campo11 = Convert.ToString(Ent.Cuit); //Nulleable
            //Sede Social (Dato Extra) - Nuevo Dato 23/10/2015
            Header.Campo12 = Convert.ToString(Ent.SedeSocial); //Nulleable
            
            //Datos del Representante
            Header.Campo13 = Convert.ToString(Rep.Nombre);
            Header.Campo14 = Convert.ToString(Rep.Apellido);
            Header.Campo15 = Convert.ToString(Rep.TipoDoc);
            Header.Campo16 = Convert.ToString(Rep.NroDoc);
            Header.Campo17 = Convert.ToString(Rep.TipoClaveFiscal);
            Header.Campo18 = Convert.ToString(Rep.NroClaveFiscal);
            //Domicilio Real (Dato Extra) - Nuevo Dato 23/10/2015
            Header.Campo19 = Convert.ToString(Rep.DomicilioReal); 

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
            indice = indice - 1;
            return Convert.ToString(nombres[indice]).Replace("_", " ");
        }

        //TODO_MEMBRETE: Agrega Membrete
        private string TraerMembrete()
        {
            DJEngine.Business.DJAbstract dj = (DJEngine.Business.DJAbstract)HttpContext.Current.Session["DJ"];
            return dj.Membrete.TextoMembrete;
        }

        //TODO: Generar Reporte para DJ09
        public override void GenerarReporte(bool imprimir)
        {
            //Cambiar nro de Declaracion Jurada por cada nueva
            EntityDJ09 dj = new EntityDJ09();
            string DJId = "09";

            //Llenado de Campos

            //Numero de Declaracion Jurada
            dj.DJPTIPODDJJ = Convert.ToString((int)EnumDJ.EDDJJ.FIDEICOMISO_FIDUCIARIO_JURIDICA);
            dj.DJPFECHA = DateTime.Now.ToString("dd/MM/yyyy");

            //TODO_MEMBRETE: Agrega Membrete
            //Agrega Membrete del Año Actual
            dj.DJPMEMBRETE = TraerMembrete(); //"2020 - AÑO DEL GENERAL MANUEL BELGRANO";

            /*-------------------------*/
            /*- DATOS DEL FIDEICOMISO -*/
            /*-------------------------*/

            //Datos del Fideicomiso
            dj.DJPNROCORFID = Convert.ToString(Fid.NroCorrelativo);
            if (Fid.Constituida == false)
            {
                dj.DJPNROCORFID = "NO REGISTRADO";
            }

            dj.DJPRAZSOCFID = Fid.RazonSocial.ToUpper();

            dj.DJPCUITFID = Convert.ToString(Fid.Cuit);
            if (dj.DJPCUITFID == null || dj.DJPCUITFID == "")
            {
                dj.DJPCUITFID = "NO REGISTRADO";
            }

            //Cambio True/False por Si/No
            if (Fid.Constituida == true)
            {
                dj.DJPCONSTFID = "SI";
            }
            else
            {
                dj.DJPCONSTFID = "NO";
            }

            //Tipo Societario del Fideicomiso
            dj.DJPTIPOENTIDFID = Fid.TipoSocId;
            dj.DJPTIPOENTFID = new TiposSocietario(Fid.TipoSocId).Descripcion;

            ////CUIT del Fideicomiso
            //dj.DJPCUITFID = Convert.ToString(Fid.Cuit);
            //if (dj.DJPCUITFID == null)
            //{
            //    dj.DJPCUITFID = "NO REGISTRADO";
            //}

            /*----------------------------------*/
            /*- DATOS DE LA ENTIDAD FIDUCIARIA -*/
            /*----------------------------------*/

            //Datos del Fideicomiso
            dj.DJPNROCORENT = Convert.ToString(Ent.NroCorrelativo);
            if (Ent.Constituida == false)
            {
                dj.DJPNROCORENT = "NO REGISTRADO";
            }

            dj.DJPRAZSOCENT = Ent.RazonSocial.ToUpper();

            //dj.DJPCUITENT = Convert.ToString(Ent.Cuit);
            //if (dj.DJPCUITENT == null)
            //{
            //    dj.DJPCUITENT = "NO REGISTRADO";
            //}


            //Cambio True/False por Si/No
            if (Ent.Constituida == true)
            {
                dj.DJPCONSTENT = "SI";
            }
            else
            {
                dj.DJPCONSTENT = "NO";
            }

            //Entidad Fiduciaria Constituida en otra jurisdicción: SI ó NO
            if (Ent.Constituida == true)
            {
                dj.DJPOTRAJURISENT = "NO";
            }
            else
            {
                dj.DJPOTRAJURISENT = "SI";
            }

            //Tipo Societario de la Entidad Fiduciaria
            dj.DJPTIPOENTIDENT = Ent.TipoSocId;
            dj.DJPTIPOENTENT = new TiposSocietario(Ent.TipoSocId).Descripcion;
            dj.DJPSEDESOCENT = Ent.SedeSocial;

            //CUIT de la Entidad Fiduciaria
            dj.DJPCUITENT = Convert.ToString(Ent.Cuit);
            if (dj.DJPCUITENT == null || dj.DJPCUITENT == "")
            {
                dj.DJPCUITENT = "NO REGISTRADO";
            }

            /*---------------------------------*/
            /*- DATOS DEL REPRESENTANTE LEGAL -*/
            /*---------------------------------*/

            dj.REPNOMBRE = Convert.ToString(Rep.Nombre);
            dj.REPAPELLIDO = Convert.ToString(Rep.Apellido);
            dj.REPTIPODOC = new TiposDocumento(Rep.TipoDoc).Acronimo;
            dj.REPNRODOC = Convert.ToString(Rep.NroDoc);            
            dj.REPDOMREAL = Convert.ToString(Rep.DomicilioReal);

            //Pregunto si No Posee Identificación Fiscal
            if (Rep.TipoClaveFiscal == 0)
            {
                dj.REPTIPOFISCAL = "CUIT/CUIL/CDI";
                dj.REPNROFISCAL = "NO POSEO IDENTIFICACION FISCAL";
            }
            else
            {
                dj.REPTIPOFISCAL = new TiposFiscal(Rep.TipoClaveFiscal).Acronimo;
                dj.REPNROFISCAL = Convert.ToString(Rep.NroClaveFiscal);
            }

            dj.HASH = this.CodigoEscaner;

            string NomReporte = "/DDJJ" + DJId + ".rpt";

            oRpt.Load(HttpContext.Current.Server.MapPath("Reportes") + NomReporte);

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
                //Open the PrintDialog

                //.Document = printDocument1;
                //DialogResult dr = this.printDialog1.ShowDialog();
                //if (dr == DialogResult.OK)
                //{
                //    //Get the Copy times
                //    int nCopy = this.printDocument1.PrinterSettings.Copies;
                //    //Get the number of Start Page
                //    int sPage = this.printDocument1.PrinterSettings.FromPage;
                //    //Get the number of End Page
                //    int ePage = this.printDocument1.PrinterSettings.ToPage;
                //    //Get the printer name
                //    string PrinterName = this.printDocument1.PrinterSettings.PrinterName;
                //    //Imprimir Formulario                    
                //}

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
            _Fid = null;
            _Ent = null;

            /*BORRO TODAS LAS VARIABLES DE SESSION*/
            
            //HttpContext.Current.Session["DatosEntidad"] = null;
            //HttpContext.Current.Session["Entidad"] = null;
            //HttpContext.Current.Session["PersonaEP"] = null;
            //HttpContext.Current.Session["captchaUrl"] = null;

            HttpContext.Current.Session.Clear();

            DJ09 dj09 = new DJ09();
            HttpContext.Current.Session["DJ"] = dj09;

            this.WorkFlow.Iniciar();
         }
    }
}
