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
    public class DJ11 : DJAbstract
    {
        private Entidad _Ent;

        public Entidad Ent
        {
            get { return _Ent; }
            set { _Ent = value; }
        }

        private Balance _Bal;

        public Balance Bal
        {
            get { return _Bal; }
            set { _Bal = value; }
        }

        private Auditor _Aud;

        public Auditor Aud
        {
            get { return _Aud; }
            set { _Aud = value; }
        }

        private RepLegalBal _Rep;

        public RepLegalBal Rep
        {
            get { return _Rep; }
            set { _Rep = value; }
        }

        public DJ11():base(11)
        { 
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Bal = (Balance)HttpContext.Current.Session["Balance"];
            Aud = (Auditor)HttpContext.Current.Session["Auditor"];
            Rep = (RepLegalBal)HttpContext.Current.Session["RepLegalBal"];

            LeyendaDJ = "DECLARACION JURADA - PRESENTACION DE BALANCES";
        }

        public override bool RegistrarDJ()
        {
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Bal = (Balance)HttpContext.Current.Session["Balance"];
            Aud = (Auditor)HttpContext.Current.Session["Auditor"];
            Rep = (RepLegalBal)HttpContext.Current.Session["RepLegalBal"];

            int status;
            string mensaje;

            WSMotorDDJJ.DDJJHeader Header = new WSMotorDDJJ.DDJJHeader();

            //Llenado de Campos
            //Numero de Declaracion Jurada
            Header.TipoDDJJ = Convert.ToString((int)EnumDJ.EDDJJ.PRESENTACION_BALANCES);
            Header.Operacion = "BAL"; //harcodeo BAL como BALANCES
            GenerarHash();
            Header.CodHash = base.DJHash;

            ////Datos de la Entidad
            Header.NroCorr = Convert.ToString(Ent.NroCorrelativo); //Nulleable
            Header.Campo01 = Ent.RazonSocial.ToString(); //Nulleable
            Header.Campo02 = Convert.ToString(Convert.ToInt32(Ent.Constituida)); //False = 0 y True = 1
            Header.Campo03 = Convert.ToString(Ent.TipoSocId); //Nulleable //Tipo Societario Entidad Id
            Header.Campo04 = Convert.ToString(Ent.TipoSocDesc); //Nulleable //Tipo Societario Entidad Descripcion            
            Header.Campo05 = Convert.ToString(Ent.Cuit); //Nulleable

            ////Datos del Balance
            //Estado Contable
            Header.Campo06 = Convert.ToString(Bal.Anio);
            Header.Campo07 = Convert.ToString(Bal.FechaIni.ToString("dd/MM/yyyy"));
            Header.Campo08 = Convert.ToString(Bal.FechaFin.ToString("dd/MM/yyyy"));
            //Aprobacion
            Header.Campo09 = Convert.ToString(Bal.FechaReunion.ToString("dd/MM/yyyy"));
            Header.Campo10 = Convert.ToString(Bal.TipoAsamblea);
            Header.Campo11 = Convert.ToString(Bal.FechaAsamblea.ToString("dd/MM/yyyy"));
            //Capital
            Header.Campo12 = Convert.ToString(Bal.MontoMonedaCapital);
            Header.Campo13 = Convert.ToString(Bal.MontoMonedaAjuste);

            ////Datos del Auditor Externo
            Header.Campo14 = Convert.ToString(Aud.Nombre);
            Header.Campo15 = Convert.ToString(Aud.Apellido);
            Header.Campo16 = Convert.ToString(Aud.TipoDoc);
            Header.Campo17 = Convert.ToString(Aud.NroDoc);
            Header.Campo18 = Convert.ToString(Aud.TipoClaveFiscal); //ID TIPO FISCAL
            Header.Campo19 = Convert.ToString(Aud.NroClaveFiscal);
            Header.Campo20 = Convert.ToString(Aud.Fecha.ToString("dd/MM/yyyy")); //Fecha del Informe
            Header.Campo21 = Convert.ToString(Aud.Tomo);
            Header.Campo22 = Convert.ToString(Aud.Folio);
            Header.Campo23 = Convert.ToString(Aud.TipoDictamen);

            ////Datos del Representante Legal
            Header.Campo24 = Convert.ToString(Rep.Nombre);
            Header.Campo25 = Convert.ToString(Rep.Apellido);
            Header.Campo26 = Convert.ToString(Rep.TipoDoc);
            Header.Campo27 = Convert.ToString(Rep.NroDoc);
            Header.Campo28 = Convert.ToString(Rep.TipoClaveFiscal); //ID TIPO FISCAL
            Header.Campo29 = Convert.ToString(Rep.NroClaveFiscal);

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

        //TODO_MEMBRETE: Agrega Membrete
        private string TraerMembrete()
        {
            DJEngine.Business.DJAbstract dj = (DJEngine.Business.DJAbstract)HttpContext.Current.Session["DJ"];
            return dj.Membrete.TextoMembrete;
        }

        //TODO: Generar Reporte para DJ11
        public override void GenerarReporte(bool imprimir)
        {
            //Cambiar nro de Declaracion Jurada por cada nueva
            EntityDJ11 dj = new EntityDJ11();
            string DJId = "11";

            //Llenado de Campos

            //Numero de Declaracion Jurada
            dj.DJPTIPODDJJ = Convert.ToString((int)EnumDJ.EDDJJ.PRESENTACION_BALANCES);
            dj.DJPFECHA = DateTime.Now.ToString("dd/MM/yyyy");
            //TODO_MEMBRETE: Agrega Membrete
            //Agrega Membrete del Año Actual
            dj.DJPMEMBRETE = TraerMembrete(); //"2020 - AÑO DEL GENERAL MANUEL BELGRANO";

            //Datos de la Entidad
            dj.DJPNROCORENT = Convert.ToString(Ent.NroCorrelativo);
            if (Ent.Constituida == false)
            {
                dj.DJPNROCORENT = "NO REGISTRADO";
            }

            dj.DJPRAZSOCENT = Ent.RazonSocial.ToUpper();
            dj.DJPCUITENT = Convert.ToString(Ent.Cuit);
            if (dj.DJPCUITENT == null)
            {
                dj.DJPCUITENT = "NO REGISTRADO";
            }

            //TODO: Cambio True/False por Si/No
            //dj.DJPCONST = Ent.Constituida.ToString();
            if (Ent.Constituida == true)
            {
                dj.DJPCONSTENT = "SI";
            }
            else
            {
                dj.DJPCONSTENT = "NO";
            }

            dj.DJPTIPOENT = Convert.ToString(Ent.TipoSocDesc);
            if (dj.DJPTIPOENT == null)
            {
                dj.DJPTIPOENT = "NO REGISTRADO";
            }

            //Datos del Balance
            dj.BALANIO = Convert.ToString(Bal.Anio);
            dj.BALFECHAINI = Convert.ToString(Bal.FechaIni.ToString("dd/MM/yyyy"));
            dj.BALFECHAFIN = Convert.ToString(Bal.FechaFin.ToString("dd/MM/yyyy"));
            dj.BALFECHAREUNION = Convert.ToString(Bal.FechaReunion.ToString("dd/MM/yyyy"));
            dj.BALTIPOASAMBLEA = new TiposAsamblea(Bal.TipoAsamblea).Descripcion;
            dj.BALFECHAASAMBLEA = Convert.ToString(Bal.FechaAsamblea.ToString("dd/MM/yyyy"));
            dj.BALCAPITAL = Convert.ToString(Bal.MontoMonedaCapital);
            dj.BALAJUSTE = Convert.ToString(Bal.MontoMonedaAjuste);

            //Datos del Auditor Externo
            dj.AUDNOMBRE = Convert.ToString(Aud.Nombre);
            dj.AUDAPELLIDO = Convert.ToString(Aud.Apellido);
            dj.AUDTIPODOC = new TiposDocumento(Aud.TipoDoc).Acronimo;
            dj.AUDNRODOC = Convert.ToString(Aud.NroDoc);
            dj.AUDFECHA = Convert.ToString(Aud.Fecha.ToString("dd/MM/yyyy"));
            dj.AUDTOMO = Convert.ToString(Aud.Tomo);
            dj.AUDFOLIO = Convert.ToString(Aud.Folio);
            dj.AUDDICTAMEN = new TiposDictamen (Aud.TipoDictamen).Descripcion;

            //Pregunto si No Posee Identificación Fiscal
            if (Aud.TipoClaveFiscal == -1)
            {
                dj.AUDTIPOFISCAL = "CUIT/CUIL/CDI";
                dj.AUDNROFISCAL = "NO POSEO IDENTIFICACION FISCAL";
            }
            else
            {
                dj.AUDTIPOFISCAL = new TiposFiscal(Aud.TipoClaveFiscal).Acronimo;
                dj.AUDNROFISCAL = Convert.ToString(Aud.NroClaveFiscal);
            }

            //Datos del Representante Legal
            dj.REPNOMBRE = Convert.ToString(Rep.Nombre);
            dj.REPAPELLIDO = Convert.ToString(Rep.Apellido);
            dj.REPTIPODOC = new TiposDocumento(Rep.TipoDoc).Acronimo;
            dj.REPNRODOC = Convert.ToString(Rep.NroDoc);

            //Pregunto si No Posee Identificación Fiscal
            if (Rep.TipoClaveFiscal == -1)
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
            _Bal = null;
            _Aud = null;
            _Rep = null;

            HttpContext.Current.Session.Clear();

            DJ11 dj11 = new DJ11();
            HttpContext.Current.Session["DJ"] = dj11;

            this.WorkFlow.Iniciar();
         }
    }
}
