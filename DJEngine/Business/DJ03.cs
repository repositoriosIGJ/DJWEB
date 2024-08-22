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
    public class DJ03 : DJAbstract
    {
        private Entidad _Ent;

        public Entidad Ent
        {
            get { return _Ent; }
            set { _Ent = value; }
        }
        private PersonaEP _Pep;

        public PersonaEP Pep
        {
            get { return _Pep; }
            set { _Pep = value; }
        }

        public DJ03()
            : base(3)
        {
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Pep = (PersonaEP)HttpContext.Current.Session["PersonaEP"];
            LeyendaDJ = "DECLARACION JURADA (Res. Nro. 16/2012) - PERSONAS EXPUESTAS POLITICAMENTE";
        }

        public override bool RegistrarDJ()
        {
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Pep = (PersonaEP)HttpContext.Current.Session["PersonaEP"];

            int status;
            string mensaje;

            WSMotorDDJJ.DDJJHeader Header = new WSMotorDDJJ.DDJJHeader();

            //Llenado de Campos            
            //Numero de Declaracion Jurada
            Header.TipoDDJJ = Convert.ToString((int)EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE);
            Header.Operacion = "PPE"; //harcodeo PPE por Personas Expuestas Politicamente
            //TODO: Deberia agregregar el tipo de dj (id) al hash
            GenerarHash();
            Header.CodHash = base.DJHash;

            //Datos de Entidad
            Header.NroCorr = Convert.ToString(Ent.NroCorrelativo); //Nulleable
            Header.Campo01 = Ent.RazonSocial.ToString();
            Header.Campo02 = Convert.ToString(Ent.Cuit); //Nulleable
            Header.Campo03 = Convert.ToString(Convert.ToInt32(Ent.Constituida)); //False = 0 y True = 1

            //Datos de Persona Expuesta Políticamente
            Header.Campo04 = Convert.ToString(Pep.NombrePEP);
            Header.Campo05 = Convert.ToString(Pep.ApellidoPEP);
            Header.Campo06 = Convert.ToString(Pep.TipoDocPEPId);
            Header.Campo07 = Convert.ToString(Pep.NroDocPEP);
            Header.Campo08 = Convert.ToString(Pep.CargoPEP);
            Header.Campo09 = Convert.ToString(Pep.NroFiscalPEP);
            //Persona Expuesta Politicamente o incluida en el inciso "F"
            //Persona Expuesta Politicamente o incluida en el inciso "B" o "I"
            //No Incluido en ninguno = 0
            //Inciso "F" = 1
            //Inciso 'B' = 2
            //Inciso 'I' = 3
            Header.Campo10 = Convert.ToString(Convert.ToInt32(Pep.RelacionadoPEP));
            Header.Campo11 = Convert.ToString(Pep.RelacionPEP); //Nulleable

            //Datos de Persona Expuesta Politicamente Relacionada Inciso
            Header.Campo12 = Convert.ToString(Pep.NombrePEPR); //Nulleable
            Header.Campo13 = Convert.ToString(Pep.ApellidoPEPR); //Nulleable
            Header.Campo14 = Convert.ToString(Pep.TipoDocPEPRId); //Nulleable
            Header.Campo15 = Convert.ToString(Pep.NroDocPEPR); //Nulleable
            Header.Campo16 = Convert.ToString(Pep.NroFiscalPEPR); //Nulleable

            //rblPEPoF //False = 0 y True = 1
            Header.Campo17 = Convert.ToString(Convert.ToInt32(Pep.PEPoF));

            //Tipo Fiscal
            Header.Campo18 = Convert.ToString(Pep.TipoFiscalPEP);
            Header.Campo19 = Convert.ToString(Pep.TipoFiscalPEPR); //Nulleable

            //Cambio para que registre CategoriaPEP
            if (Pep.SubCategoriaPEP != -1)
            {
                //Categoria PEP
                Header.Campo20 = Convert.ToString(Pep.CategoriaPEP); //Nulleable
                Header.Campo21 = Convert.ToString(Pep.SubCategoriaPEP); //Nulleable
            }
            else
            {
                //Categoria PEPR
                Header.Campo20 = Convert.ToString(Pep.CategoriaPEPR); //Nulleable
                Header.Campo21 = Convert.ToString(Pep.SubCategoriaPEPR); //Nulleable
            }

            //Indice de Cargo PEP - 23/02/13
            Header.Campo22 = Convert.ToString(Pep.CargoPEPId); //Nulleable
            //Domicilio Real PEP - 23/02/13
            Header.Campo23 = Convert.ToString(Pep.DomicilioRealPEP); //Nulleable
            
            //NUEVOS CAMPOS 2023
            Header.Campo24 = Convert.ToString(Pep.Profesion);
            Header.Campo25 = Pep.FechaNac.ToString("dd/MM/yyyy");
            Header.Campo26 = Convert.ToString(Pep.EstadoCivil);
            Header.Campo27 = Convert.ToString(Pep.Email);
            Header.Campo28 = Convert.ToString(Pep.Nacionalidad);
        

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

        public override void GenerarReporte(bool imprimir)
        {
            //Cambiar nro de Declaracion Jurada por cada nueva
            EntityDJ03 dj = new EntityDJ03();
            string DJId = "03";

            //Llenado de Campos

            //TODO: Cambio True/False por Si/No
            if (Pep.PEPoF == true)
            {
                dj.DJPEP = "SI";
            }
            else
            {
                dj.DJPEP = "NO";
            }

            //Numero de Declaracion Jurada
            dj.DJPTIPODDJJ = Convert.ToString((int)EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE);
            dj.DJPFECHA = DateTime.Now.ToString("dd/MM/yyyy");

            //TODO_MEMBRETE: Agrega Membrete
            //Agrega Membrete del Año Actual
            dj.DJPMEMBRETE = TraerMembrete(); //"2020 - AÑO DEL GENERAL MANUEL BELGRANO";

            //Datos de Entidad
            dj.DJPNROCOR = Convert.ToString(Ent.NroCorrelativo);
            if (Ent.Constituida == false)
            {
                dj.DJPNROCOR = "NO REGISTRADO";
            }

            dj.DJPRAZONSOCIAL = Ent.RazonSocial.ToUpper();
            dj.DJPCUIT = Convert.ToString(Ent.Cuit);
            if (dj.DJPCUIT == null)
            {
                dj.DJPCUIT = "NO REGISTRADO";
            }

            //TODO: Cambio True/False por Si/No
            //dj.DJPCONST = Ent.Constituida.ToString();
            if (Ent.Constituida == true)
            {
                dj.DJPCONST = "SI";
            }
            else
            {
                dj.DJPCONST = "NO";
            }

            //Datos de Persona Expuesta Políticamente
            dj.PEPNOMBRE = Convert.ToString(Pep.NombrePEP);
            dj.PEPAPELLIDO = Convert.ToString(Pep.ApellidoPEP);
            dj.PEPTIPODOC = new TiposDocumento(Pep.TipoDocPEPId).Acronimo;
            //dj.PEPTIPODOC = TraerValor(Enum.GetNames(typeof(EnumDJ.ETipoDoc)), Pep.TipoDocPEPId);
            dj.PEPNUMERO = Convert.ToString(Pep.NroDocPEP);
            //dj.PEPCARGO = Convert.ToString(Pep.CargoPEP);
            dj.PEPCARGOID = Convert.ToString(Pep.CargoPEPId);
            dj.PEPCARGO = new TiposCargo(Pep.CargoPEPId).Acronimo;
            dj.PEPDOMICILIOREAL = Convert.ToString(Pep.DomicilioRealPEP);

            //PEP 2023
            dj.PEPNACIONALIDAD = Convert.ToString(Pep.Nacionalidad);
            dj.PEPEMAIL = Convert.ToString(Pep.Email);
            dj.PEPPROFESION = Convert.ToString(Pep.Profesion);
            dj.PEPFECHANACIMIENTO = Convert.ToString(Pep.FechaNac.ToShortDateString());

            //FIN PEP 2023
       

            dj.PEPCATEGORIA = " - - - ";
            if (Pep.RelacionadoPEP == "0")
            {
                if (Pep.PEPoF == true)
                {
                    if (Pep.SubCategoriaPEP != -1)
                        dj.PEPCATEGORIA = new CategoriaPEP(Pep.CategoriaPEP).GetDescripcionSubCategoria(Pep.SubCategoriaPEP);
                    else
                        dj.PEPCATEGORIA = new CategoriaPEP(Pep.CategoriaPEP).Descripcion;
                }
                else
                    dj.PEPCATEGORIA = " - - - ";
            }
            else
            {
                if (Pep.SubCategoriaPEPR != -1)
                    dj.PEPCATEGORIA = new CategoriaPEP(Pep.CategoriaPEPR).GetDescripcionSubCategoria(Pep.SubCategoriaPEPR);
                else
                    dj.PEPCATEGORIA = new CategoriaPEP(Pep.CategoriaPEPR).Descripcion;
            }

            //Pregunto si No Posee Identificación Fiscal para PEP
            if (Pep.TipoFiscalPEP == 0)
            {
                dj.PEPTIPOFISCAL = "CUIT/CUIL/CDI";
                dj.PEPCUIT = "NO POSEO IDENTIFICACION FISCAL";
            }
            else
            {
                dj.PEPTIPOFISCAL = new TiposFiscal(Pep.TipoFiscalPEP).Acronimo;
                dj.PEPCUIT = Convert.ToString(Pep.NroFiscalPEP);
            }

            //Pregunto si esta incluido en algun Inciso o en ninguno
            //NOINCLUIDO = 0, INCISOF = 1, INCISOB = 2, INCISOI = 3
            switch (Pep.RelacionadoPEP)
            {
                case "0": //"No Incluido"
                    dj.DJINCISO = "NO INCLUIDO";
                    //Datos de Persona Expuesta Politicamente Relacionada Inciso F (Vacio)
                    dj.PPRNOMBRE = "- - - -";
                    dj.PPRAPELLIDO = "- - - -";
                    //TODO: Fijarse si se necesita el Id o el valor del tipo de documento.
                    //TODO: Cargar Tipo de Documento
                    dj.PPRTIPODOC = "- - - -";
                    dj.PPRNRODOC = "- - - -";
                    dj.PPRTIPOFISCAL = "CUIT/CUIL/CDI";
                    dj.PPRCUIT = "- - - -";
                    dj.PEPRELACION = " - - -";


                
                    break;
                case "1": //"INCISO F" //No se usa mas
                case "2": //
                case "3":
                    //dj.DJINCISO = "CERCANIA";
                    dj.DJINCISO = TraerValor(Enum.GetNames(typeof(EnumDJ.ETipoIncisos)), Convert.ToInt32(Pep.RelacionadoPEP));//Pep.RelacionadoPEP;
                    dj.PEPRELACION = Convert.ToString(Pep.RelacionPEP);
                    //Datos de Persona Expuesta Politicamente Relacionada
                    dj.PPRNOMBRE = Convert.ToString(Pep.NombrePEPR);
                    dj.PPRAPELLIDO = Convert.ToString(Pep.ApellidoPEPR);
                    dj.PPRTIPODOC = new TiposDocumento(Pep.TipoDocPEPRId).Acronimo;
                    dj.PPRNRODOC = Convert.ToString(Pep.NroDocPEPR);

                    //PEP 2023
                    //dj.PEPNACIONALIDAD = Convert.ToString(Pep.Nacionalidad);
                    //dj.PEPEMAIL = Convert.ToString(Pep.Email);
                    //dj.PEPPROFESION = Convert.ToString(Pep.Profesion);
                    //dj.PEPFECHANACIMIENTO = Convert.ToString(Pep.FechaNac.ToShortDateString());

                    //FIN PEP 2023

                
                    //Pregunto si No Posee Identificación Fiscal para PEP Inciso
                    if (Pep.TipoFiscalPEPR == 0)
                    {
                        dj.PPRTIPOFISCAL = "CUIT/CUIL/CDI";
                        dj.PPRCUIT = "NO POSEE IDENTIFICACION FISCAL";
                    }
                    else
                    {
                        dj.PPRTIPOFISCAL = new TiposFiscal(Pep.TipoFiscalPEPR).Acronimo;
                        dj.PPRCUIT = Convert.ToString(Pep.NroFiscalPEPR);
                    }
                    break;
            }

            //CodigoEscaner: Hash completo con los primeros 8 Digitos del HashDJFecha (ejm: 03120522)
            dj.HASH = this.CodigoEscaner;

            oRpt.Load(HttpContext.Current.Server.MapPath("Reportes") + "/DDJJ03.rpt");

            //Genera Codigo de Barras y QR
            #region "Genera Codigo de Barras y QR"

            //Genera Codigo de Barras
            #region "Codigo de Barras"
            CodigoBarra oCodBar = new CodigoBarra();
            MemoryStream msCodBar = new MemoryStream();

            System.Drawing.Image imagen = oCodBar.GenerarImagenCodigoBarra(this.DJHash);
            imagen.Save(msCodBar, System.Drawing.Imaging.ImageFormat.Bmp);

            dj.CODIGODEBARRAS = msCodBar.ToArray();

            msCodBar.Close();
            #endregion "Codigo de Barras"

            //Genera Mini Codigo de Barras
            #region "Mini Codigo de Barras"
            MemoryStream msMiniCodBar = new MemoryStream();
            string MiniHash = this.DJHash.Substring(this.DJHash.Length - 6);
            System.Drawing.Image imagenMiniCodBar = oCodBar.GenerarImagenCodigoBarra(MiniHash);
            imagenMiniCodBar.Save(msMiniCodBar, System.Drawing.Imaging.ImageFormat.Bmp);

            dj.MINICODIGODEBARRAS = msMiniCodBar.ToArray();

            msMiniCodBar.Close();
            #endregion "MiniCodigo de Barras"

            //Genera Codigo QR
            #region "Codigo QR"
            MemoryStream msQR = new MemoryStream();

            System.Drawing.Image imagenQR = oCodBar.GenerarImagenQR(this.DJHash);
            imagenQR.Save(msQR, System.Drawing.Imaging.ImageFormat.Bmp);

            dj.CODIGOQR = msQR.ToArray();

            msQR.Close();
            #endregion "Codigo QR"

            #endregion "Genera Codigo de Barras y QR"

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
            _Ent = null;
            _Pep = null;

            /*BORRO TODAS LAS VARIABLES DE SESSION*/

            //HttpContext.Current.Session["DatosEntidad"] = null;
            //HttpContext.Current.Session["Entidad"] = null;
            //HttpContext.Current.Session["PersonaEP"] = null;
            //HttpContext.Current.Session["captchaUrl"] = null;

            HttpContext.Current.Session.Clear();

            DJ03 dj03 = new DJ03();
            HttpContext.Current.Session["DJ"] = dj03;

            this.WorkFlow.Iniciar();
        }
    }
}
