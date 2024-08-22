using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using DJEngine.UsoGeneral;
using DJEngine.DataAccess.Tipos;
using DJEngine.Reportes.EntityReport;
using System.Reflection;

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

        private Contador _Con;

        public Contador Con
        {
            get { return _Con; }
            set { _Con = value; }
        }

        private RepLegalBal _Rep;

        public RepLegalBal Rep
        {
            get { return _Rep; }
            set { _Rep = value; }
        }

        private Libros _Lib;

        public Libros Lib
        {
            get { return _Lib; }
            set { _Lib = value; }
        }

        public DJ11()
            : base(11)
        {
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Bal = (Balance)HttpContext.Current.Session["Balance"];
            Con = (Contador)HttpContext.Current.Session["Contador"];
            Rep = (RepLegalBal)HttpContext.Current.Session["RepLegalBal"];
            //TODO: Cambiar cuando haya datos en sesion
            Lib = (Libros)HttpContext.Current.Session["Libros"];
            //Datos de Prueba
            //Lib = LibrosRubricados.GetLibrosPrueba();

            LeyendaDJ = "DECLARACION JURADA - PRESENTACION DE BALANCES (SAS)";
        }

        public override bool RegistrarDJ()
        {
            try
            {
                Ent = (Entidad)HttpContext.Current.Session["Entidad"];
                Bal = (Balance)HttpContext.Current.Session["Balance"];
                Con = (Contador)HttpContext.Current.Session["Contador"];
                Rep = (RepLegalBal)HttpContext.Current.Session["RepLegalBal"];
                Lib = (Libros)HttpContext.Current.Session["Libros"];
                //Datos de Prueba
                //Lib = LibrosRubricados.GetLibrosPrueba();

                int status;
                string mensaje;
                int djid;

                WSMotorDDJJ.DDJJHeader Header = new WSMotorDDJJ.DDJJHeader();

                //Llenado de Campos
                //Numero de Declaracion Jurada
                Header.TipoDDJJ = Convert.ToString((int)EnumDJ.EDDJJ.PRESENTACION_BALANCES_SAS);
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
                Header.Campo06 = Convert.ToString(Ent.SedeSocial); //Nulleable

                ////Datos del Balance
                //Estado Contable
                Header.Campo07 = Convert.ToString(Bal.Anio);
                Header.Campo08 = Convert.ToString(Bal.FechaIni.ToString("dd/MM/yyyy"));
                Header.Campo09 = Convert.ToString(Bal.FechaFin.ToString("dd/MM/yyyy"));
                //Aprobacion
                Header.Campo10 = Convert.ToString(Bal.FechaReunion.ToString("dd/MM/yyyy"));
                Header.Campo11 = Convert.ToString(Bal.TipoAsamblea);
                Header.Campo12 = Convert.ToString(Bal.FechaAsamblea.ToString("dd/MM/yyyy"));
                //Capital
                Header.Campo13 = Convert.ToString(Bal.MontoMonedaCapital);
                Header.Campo14 = Convert.ToString(Bal.MontoMonedaAjuste);

                ////Datos del Contador Certificante
                Header.Campo15 = Convert.ToString(Con.Nombre);
                Header.Campo16 = Convert.ToString(Con.Apellido);
                Header.Campo17 = Convert.ToString(Con.TipoDoc);
                Header.Campo18 = Convert.ToString(Con.NroDoc);
                Header.Campo19 = Convert.ToString(Con.TipoClaveFiscal); //ID TIPO FISCAL
                Header.Campo20 = Convert.ToString(Con.NroClaveFiscal);                
                Header.Campo21 = Convert.ToString(Con.Tomo);
                Header.Campo22 = Convert.ToString(Con.Folio);
                Header.Campo23 = Convert.ToString(Con.FechaAuditor.ToString("dd/MM/yyyy")); //Fecha del Informe
                Header.Campo24 = Convert.ToString(Con.NroAuditor);
                //Header.Campo24 = Convert.ToString(Aud.TipoDictamen);

                ////Datos del Representante Legal
                Header.Campo25 = Convert.ToString(Rep.Nombre);
                Header.Campo26 = Convert.ToString(Rep.Apellido);
                Header.Campo27 = Convert.ToString(Rep.TipoDoc);
                Header.Campo28 = Convert.ToString(Rep.NroDoc);
                Header.Campo29 = Convert.ToString(Rep.TipoClaveFiscal); //ID TIPO FISCAL
                Header.Campo30 = Convert.ToString(Rep.NroClaveFiscal);

                //Datos de los Libros de Rubrica
                //TODO: Se persistio directamente en la tabla DDJJ_LIBROS
                //Convierte a Json y lo Comprime en un Array
                //string[] arrstrcomp = UsoGeneral.LibrosRubricados.ListToJsonAndCompress(Lib);
                //Header.Campo30 = arrstrcomp.Count() > 0 ? arrstrcomp[0] : "";
                //Header.Campo31 = arrstrcomp.Count() > 1 ? arrstrcomp[1] : "";
                //Header.Campo32 = arrstrcomp.Count() > 2 ? arrstrcomp[2] : "";
                //Header.Campo33 = arrstrcomp.Count() > 3 ? arrstrcomp[3] : "";

                WSMotorDDJJ.WS_MOTOR_DDJJ Motor = new WSMotorDDJJ.WS_MOTOR_DDJJ();

                long ddjjid = Motor.Insert_Header(Header, out status, out mensaje);

                if (status != 1)
                {
                    //Maneja Fallo de Insert_Header
                    return false;
                }

                //DJId = ddjjid;

                /*Procesar la DDJJ*/
                status = Motor.Proc_Ddjj_Id(ddjjid, out mensaje, out djid);

                if (status == 1)
                {
                    //Inserta Libros Rubricados en Nueva Tabla
                    foreach (var libro in Lib.libros)
                    {
                        /*Procesa cada Libro*/
                        status = Motor.Proc_Libro(djid, libro.iddoc, libro.doc, libro.den, libro.nru, libro.fru, (libro.fol == null ? "" : libro.fol), (libro.has == null ? "" : libro.has), out mensaje);

                        if (status != 1)
                        {
                            //Maneja Fallo de Proc_Libro
                            return false;
                        }
                    }
                }
                else
                {
                    //Maneja Fallo de Proc_Ddjj
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }
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

        //TODO: Generar Reporte para DJ11
        public override void GenerarReporte(bool imprimir)
        {
            //Cambiar nro de Declaracion Jurada por cada nueva
            EntityDJ11 dj = new EntityDJ11();
            string DJId = "11";

            //Llenado de Campos

            //Numero de Declaracion Jurada
            dj.DJPTIPODDJJ = Convert.ToString((int)EnumDJ.EDDJJ.PRESENTACION_BALANCES_SAS);
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

            dj.DJPSEDESOC = Ent.SedeSocial.Trim();

            //Datos del Balance
            dj.BALANIO = Convert.ToString(Bal.Anio);
            dj.BALFECHAINI = Convert.ToString(Bal.FechaIni.ToString("dd/MM/yyyy"));
            dj.BALFECHAFIN = Convert.ToString(Bal.FechaFin.ToString("dd/MM/yyyy"));
            dj.BALFECHAREUNION = Convert.ToString(Bal.FechaReunion.ToString("dd/MM/yyyy"));
            dj.BALTIPOASAMBLEA = new TiposAsamblea(Bal.TipoAsamblea).Descripcion;
            dj.BALFECHAASAMBLEA = Convert.ToString(Bal.FechaAsamblea.ToString("dd/MM/yyyy"));
            dj.BALCAPITAL = Convert.ToString(Bal.MontoMonedaCapital);
            dj.BALAJUSTE = Convert.ToString(Bal.MontoMonedaAjuste);

            //Datos del Contador Certificante
            dj.CONNOMBRE = Convert.ToString(Con.Nombre);
            dj.CONAPELLIDO = Convert.ToString(Con.Apellido);
            dj.CONTIPODOC = new TiposDocumento(Con.TipoDoc).Acronimo;
            dj.CONNRODOC = Convert.ToString(Con.NroDoc);            
            dj.CONTOMO = Convert.ToString(Con.Tomo);
            dj.CONFOLIO = Convert.ToString(Con.Folio);
            dj.AUDFECHA = Convert.ToString(Con.FechaAuditor.ToString("dd/MM/yyyy"));
            dj.AUDNROLEG = Convert.ToString(Con.NroAuditor);
            //dj.AUDDICTAMEN = new TiposDictamen(Aud.TipoDictamen).Descripcion;

            //Pregunto si No Posee Identificación Fiscal
            if (Con.TipoClaveFiscal == -1)
            {
                dj.CONTIPOFISCAL = "CUIT/CUIL/CDI";
                dj.CONNROFISCAL = "NO POSEO IDENTIFICACION FISCAL";
            }
            else
            {
                dj.CONTIPOFISCAL = new TiposFiscal(Con.TipoClaveFiscal).Acronimo;
                dj.CONNROFISCAL = Convert.ToString(Con.NroClaveFiscal);
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

            #region "Datos de los Libros Rubricados"

            //Datos de los Libros Rubricados
            //Datos de Prueba
            Libros listlib = Lib;

            int i = 1;

            foreach (Libro lib in listlib.libros)
            {
                //TODO: Cambiar por el lenght de DocumentoId
                if (i <= listlib.libros.Count)
                {
                    //Carga por Reflection las propiedades del Libro

                    string Doc = new TiposDocRubrica(lib.iddoc).Descripcion;

                    //LIBDOCUMENTO
                    PropertyInfo propdoc = dj.GetType().GetProperty("LIBDOCUMENTO_" + i.ToString("00"), BindingFlags.Public | BindingFlags.Instance);
                    if (null != propdoc && propdoc.CanWrite)
                    {
                        propdoc.SetValue(dj, Convert.ToString(Doc), null);
                    }

                    //LIBDENOMINACION
                    PropertyInfo propden = dj.GetType().GetProperty("LIBDENOMINACION_" + i.ToString("00"), BindingFlags.Public | BindingFlags.Instance);
                    if (null != propden && propden.CanWrite)
                    {
                        propden.SetValue(dj, Convert.ToString(lib.den), null);
                    }

                    ////LIBRUBRICA
                    //PropertyInfo proprub = dj.GetType().GetProperty("LIBRUBRICA_" + i.ToString("00"), BindingFlags.Public | BindingFlags.Instance);
                    //if (null != proprub && proprub.CanWrite)
                    //{
                    //    proprub.SetValue(dj, Convert.ToString(lib.nru) + " ; " + Convert.ToString(lib.fru), null);
                    //}

                    //LIBNRORL
                    PropertyInfo propnrorl = dj.GetType().GetProperty("LIBNRORL_" + i.ToString("00"), BindingFlags.Public | BindingFlags.Instance);
                    if (null != propnrorl && propnrorl.CanWrite)
                    {
                        propnrorl.SetValue(dj, Convert.ToString(lib.nru), null);
                    }

                    //LIBFEC
                    PropertyInfo propfec = dj.GetType().GetProperty("LIBFEC_" + i.ToString("00"), BindingFlags.Public | BindingFlags.Instance);
                    if (null != propfec && propfec.CanWrite)
                    {
                        propfec.SetValue(dj, Convert.ToString(lib.fru), null);
                    }

                    //LIBFOLIOS
                    //PropertyInfo propf = dj.GetType().GetProperty("LIBFOLIOS_" + i.ToString("00"), BindingFlags.Public | BindingFlags.Instance);
                    //if (null != propf && propf.CanWrite)
                    //{
                    //    propf.SetValue(dj, Convert.ToString(lib.fol), null);
                    //}

                    //LIBHASH
                    PropertyInfo prophas = dj.GetType().GetProperty("LIBHASH_" + i.ToString("00"), BindingFlags.Public | BindingFlags.Instance);
                    if (null != prophas && prophas.CanWrite)
                    {
                        prophas.SetValue(dj, Convert.ToString(lib.has), null);
                    }

                    i++;
                }
                else
                {
                    break;
                }
            }

            #endregion "Datos de los Libros Rubricados"


            //Datos de la DJ
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
            _Con = null;
            _Rep = null;
            _Lib = null;

            HttpContext.Current.Session.Clear();

            DJ11 dj11 = new DJ11();
            HttpContext.Current.Session["DJ"] = dj11;

            this.WorkFlow.Iniciar();
        }
    }
}
