using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using DJEngine.UsoGeneral;
using DJEngine.DataAccess.Tipos;

namespace DJEngine.Business
{
    public class DJ07 : DJAbstract
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

        private Representante _Rep;

        public Representante Rep
        {
            get { return _Rep; }
            set { _Rep = value; }
        }

        public DJ07()
            : base(7)
        {
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Pep = (PersonaEP)HttpContext.Current.Session["PersonaEP"];
            Rep = (Representante)HttpContext.Current.Session["Representante"];
            LeyendaDJ = "DECLARACION JURADA (Res. Nro. 16/2012) - PERSONAS EXPUESTAS POLITICAMENTE PARA REPRESENTANTES LEGALES";
        }

        public override bool RegistrarDJ()
        {
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Pep = (PersonaEP)HttpContext.Current.Session["PersonaEP"];
            Rep = (Representante)HttpContext.Current.Session["Representante"];

            int status;
            string mensaje;

            WSMotorDDJJ.DDJJHeader Header = new WSMotorDDJJ.DDJJHeader();

            //Llenado de Campos            
            //Numero de Declaracion Jurada
            Header.TipoDDJJ = Convert.ToString((int)EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE_REPRESENTANTE);
            Header.Operacion = "PPErl"; //harcodeo PPErl por Personas Expuestas Politicamente Representante Legal
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
            Header.Campo10 = Convert.ToString(Convert.ToInt32(Pep.RelacionadoPEP)); //False = 0 y True = 1
            Header.Campo11 = Convert.ToString(Pep.RelacionPEP); //Nulleable

            //Datos de Persona Expuesta Politicamente Relacionada Inciso
            Header.Campo12 = Convert.ToString(Pep.NombrePEPR); //Nulleable
            Header.Campo13 = Convert.ToString(Pep.ApellidoPEPR); //Nulleable
            Header.Campo14 = Convert.ToString(Pep.TipoDocPEPRId); //Nulleable
            Header.Campo15 = Convert.ToString(Pep.NroDocPEPR); //Nulleable
            Header.Campo16 = Convert.ToString(Pep.NroFiscalPEPR); //Nulleable

            //Persona Expuesta Politicamente o incluida en el inciso "F"
            //Persona Expuesta Politicamente o incluida en el inciso "B" o "I"
            //No Incluido en ninguno = 0
            //Inciso "F" = 1
            //Inciso 'B' = 2
            //Inciso 'I' = 3
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

            //TODO: Importante: Los datos sobre el escribano que declara, segun la dirigencia actual (14/05/2012), no se guardan en la base de datos

            //Indice de Cargo PEP - 23/02/13
            Header.Campo22 = Convert.ToString(Pep.CargoPEPId); //Nulleable
            //Domicilio Real PEP - 23/02/13
            Header.Campo23 = Convert.ToString(Pep.DomicilioRealPEP); //Nulleable

            //TODO: Agregar datos del Representante Legal en la Base

            //Datos del Representante Legal - 28/02/13
            Header.Campo24 = Convert.ToString(Rep.Nombre);
            Header.Campo25 = Convert.ToString(Rep.Apellido);
            Header.Campo26 = Convert.ToString(Rep.TipoDoc);
            Header.Campo27 = Convert.ToString(Rep.NroDoc);
            Header.Campo28 = Convert.ToString(Rep.TipoClaveFiscal);
            Header.Campo29 = Convert.ToString(Rep.NroClaveFiscal);

            //NUEVOS CAMPOS 2023 PEP Persona politicamente expuesta
            Header.Campo30 = Convert.ToString(Pep.Profesion);
            Header.Campo31 = Pep.FechaNac.ToString("dd/MM/yyyy");
            Header.Campo32 = Convert.ToString(Pep.EstadoCivil);
            Header.Campo33 = Convert.ToString(Pep.Email);
            Header.Campo34 = Convert.ToString(Pep.Nacionalidad);
        

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
            Reportes.EntityReport.EntityDJ07 dj = new Reportes.EntityReport.EntityDJ07();
            string DJId = "07";

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
            dj.DJPTIPODDJJ = Convert.ToString((int)EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE_REPRESENTANTE);
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

            //Datos del Representante Legal
            dj.REPNOMBRE = Convert.ToString(Rep.Nombre);
            dj.REPAPELLIDO = Convert.ToString(Rep.Apellido);
            dj.REPTIPODOC = new TiposDocumento(Rep.TipoDoc).Acronimo;
            dj.REPNRODOC = Convert.ToString(Rep.NroDoc);
            //Pregunto si No Posee Identificación Fiscal
            if (Rep.TipoClaveFiscal == 0)
            {
                dj.REPTIPOFISCAL = "CUIT/CUIL/CDI";
                dj.REPNROFISCAL = "NO POSEE IDENTIFICACION FISCAL";
            }
            else
            {
                dj.REPTIPOFISCAL = new TiposFiscal(Rep.TipoClaveFiscal).Acronimo;
                dj.REPNROFISCAL = Convert.ToString(Rep.NroClaveFiscal);
            }

            //Datos de Persona Expuesta Políticamente
            dj.PEPNOMBRE = Convert.ToString(Pep.NombrePEP);
            dj.PEPAPELLIDO = Convert.ToString(Pep.ApellidoPEP);
            dj.PEPTIPODOC = new TiposDocumento(Pep.TipoDocPEPId).Acronimo;

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

            //Pregunto si No Posee Identificación Fiscal para PEP
            if (Pep.TipoFiscalPEP == 0)
            {
                dj.PEPTIPOFISCAL = "CUIT/CUIL/CDI";
                dj.PEPCUIT = "NO POSEE IDENTIFICACION FISCAL";
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
                    dj.PEPRELACION = "- - -";
                    //Datos de Persona Expuesta Politicamente Relacionada Inciso F (Vacio)
                    dj.PPRNOMBRE = "- - - -";
                    dj.PPRAPELLIDO = "- - - -";
                    //TODO: Fijarse si se necesita el Id o el valor del tipo de documento.
                    //TODO: Cargar Tipo de Documento
                    dj.PPRTIPODOC = "- - - -";
                    dj.PPRNRODOC = "- - - -";
                    dj.PPRTIPOFISCAL = "CUIT/CUIL/CDI";
                    dj.PPRCUIT = "- - - -";
                    break;
                case "1": //"INCISO F" //No se usa mas
                case "2": //"INCISO B"
                case "3": //"INCISO I"
                    dj.DJINCISO = TraerValor(Enum.GetNames(typeof(EnumDJ.ETipoIncisos)), Convert.ToInt32(Pep.RelacionadoPEP));//Pep.RelacionadoPEP;
                    dj.PEPRELACION = Convert.ToString(Pep.RelacionPEP);
                    //Datos de Persona Expuesta Politicamente Relacionada
                    dj.PPRNOMBRE = Convert.ToString(Pep.NombrePEPR);
                    dj.PPRAPELLIDO = Convert.ToString(Pep.ApellidoPEPR);
                    dj.PPRTIPODOC = new TiposDocumento(Pep.TipoDocPEPRId).Acronimo;
                    dj.PPRNRODOC = Convert.ToString(Pep.NroDocPEPR);

                    //Pregunto si No Posee Identificación Fiscal para PEP Inciso
                    if (Pep.TipoFiscalPEPR == 0)
                    {
                        dj.PPRTIPOFISCAL = "CUIT/CUIL/CDI";
                        dj.PPRCUIT = "NO POSEE IDENTIFICACIÓN FISCAL";
                    }
                    else
                    {
                        dj.PPRTIPOFISCAL = new TiposFiscal(Pep.TipoFiscalPEPR).Acronimo;
                        dj.PPRCUIT = Convert.ToString(Pep.NroFiscalPEPR);
                    }
                    break;
            }

            dj.HASH = this.CodigoEscaner;


            dj.PEPCATEGORIA = " - - - - ";

            if (Pep.RelacionadoPEP == "0")
            {
                if (Pep.PEPoF == true)
                {
                    if (Pep.SubCategoriaPEP != -1)
                        dj.PEPCATEGORIA = new CategoriaPEP(Pep.CategoriaPEP).GetDescripcionSubCategoria(Pep.SubCategoriaPEP);
                    else
                        dj.PEPCATEGORIA = new CategoriaPEP(Pep.CategoriaPEP).Descripcion;
                }
            }
            else
            {
                if (Pep.SubCategoriaPEPR != -1)
                    dj.PEPCATEGORIA = new CategoriaPEP(Pep.CategoriaPEPR).GetDescripcionSubCategoria(Pep.SubCategoriaPEPR);
                else
                    dj.PEPCATEGORIA = new CategoriaPEP(Pep.CategoriaPEPR).Descripcion;
            }
            ///************************************************/

            #region "Impresion de Reporte"
            //** Empieza Impresión de Reporte comun a todos **//

            oRpt.Load(HttpContext.Current.Server.MapPath("Reportes") + "/DDJJ07.rpt");

            CodigoBarra codigoBarras = new CodigoBarra();

            System.Drawing.Image imagen;
            MemoryStream ms = new MemoryStream();

            imagen = codigoBarras.GenerarImagenCodigoBarra(this.DJHash);
            imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            dj.CODIGODEBARRAS = ms.ToArray();

            ms.Close();

            oRpt.SetDataSource(new[] { dj });

            if (imprimir)
            {
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

            #endregion
            //** Termina Impresión de Reporte comun a todos **//
        }

        public override void ReiniciarDeclaracion()
        {
            /*BORRO TODOS LOS ATRIBUTOS*/
            _Ent = null;
            _Pep = null;
            _Rep = null;

            /*BORRO TODAS LAS VARIABLES DE SESSION*/


            HttpContext.Current.Session.Clear();

            DJ07 dj07 = new DJ07();
            HttpContext.Current.Session["DJ"] = dj07;

            this.WorkFlow.Iniciar();
        }
    }
}

