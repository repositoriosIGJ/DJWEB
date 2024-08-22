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
    public class DJ08 : DJAbstract
    {
        private Entidad _Fid;

        public Entidad Fid
        {
            get { return _Fid; }
            set { _Fid = value; }
        }

        private Business.PersonaPEP _Pep;

        public Business.PersonaPEP Pep
        {
            get { return _Pep; }
            set { _Pep = value; }
        }

        public DJ08():base(8)
        { 
            Fid = (Entidad)HttpContext.Current.Session["Fideicomiso"];
            Pep = (Business.PersonaPEP)HttpContext.Current.Session["PersonaPEP"];
            LeyendaDJ = "DECLARACION JURADA (Res. Nro. 07/2015) - PERSONAS EXPUESTAS POLITICAMENTE CONTRATO DE FIDEICOMISO - PERSONA FISICA";
        }

        public override bool RegistrarDJ()
        {
            Fid = (Entidad)HttpContext.Current.Session["Fideicomiso"];
            Pep = (Business.PersonaPEP)HttpContext.Current.Session["PersonaPEP"];

            int status;
            string mensaje;

            WSMotorDDJJ.DDJJHeader Header = new WSMotorDDJJ.DDJJHeader();

            //Llenado de Campos
            //Numero de Declaracion Jurada
            Header.TipoDDJJ = Convert.ToString((int)EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE_FIDEICOMISO_FISICA);
            Header.Operacion = "PPEff"; //harcodeo PPEff por Personas Expuestas Politicamente contrato de fideicomiso Persona Fisica
            GenerarHash();
            Header.CodHash = base.DJHash;

            //Datos del FideiComiso
            Header.NroCorr = Convert.ToString(Fid.NroCorrelativo); //Nulleable
            Header.Campo01 = Fid.RazonSocial.ToString(); //Nulleable
            Header.Campo02 = Convert.ToString(Convert.ToInt32(Fid.Constituida)); //False = 0 y True = 1
            Header.Campo03 = Convert.ToString(Fid.TipoSocId); //Nulleable //Tipo Societario Fideicomiso Id
            Header.Campo04 = Convert.ToString(Fid.TipoSocDesc); //Nulleable //Tipo Societario Fideicomiso Descripcion            
            Header.Campo05 = Convert.ToString(Fid.Cuit); //Nulleable

            //Indique si usted es una Persona Expuesta Politicamente //False = 0 y True = 1 //rblPEPoNO //DJPPEP
            Header.Campo06 = Convert.ToString(Convert.ToInt32(Pep.PEPoNO));

            //Persona Expuesta Politicamente incluida en el inciso "F", "B", "I" o Ninguno //rblIncisos //DJPINCISO
            Header.Campo07 = Convert.ToString(Convert.ToInt32(Pep.TipoInciso)); //TIPO DE INCISO - NO INCLUIDO=0 / F=1 / B=2 / I=3 

            //Datos de la Persona Expuesta Políticamente
            Header.Campo08 = Convert.ToString(Pep.NombrePEP);
            Header.Campo09 = Convert.ToString(Pep.ApellidoPEP);
            Header.Campo10 = Convert.ToString(Pep.TipoDocPEPId);
            Header.Campo11 = Convert.ToString(Pep.NroDocPEP);
            //PEP Tipo Fiscal
            Header.Campo12 = Convert.ToString(Pep.TipoFiscalPEP); //ID TIPO FISCAL DE LA PERSONA EXPUESTA POLITICAMENTE
            Header.Campo13 = Convert.ToString(Pep.NroFiscalPEP);
            //PEP Categoria
            Header.Campo14 = Convert.ToString(Pep.CategoriaPEP);
            Header.Campo15 = Convert.ToString(Pep.SubCategoriaPEP);
            //PEP Cargo
            Header.Campo16 = Convert.ToString(Pep.CargoPEPId); //ID Cargo en el Fideicomiso de la PEP (Default =  Fiduciario)
            Header.Campo17 = Convert.ToString(Pep.CargoPEP); //Cargo en el Fideicomiso Descripcion de la PEP (Default =  Fiduciario)
            Header.Campo18 = Convert.ToString(Pep.DomicilioRealPEP); //Domicilio Real PEP
            
            Header.Campo19 = Convert.ToString(Pep.RelacionPPRPEP); //Nulleable //TEXTO DE LA RELACION CON LA PERSONA EXPUESTA POLITICAMENTE

            //Datos de la Persona Expuesta Politicamente Relacionada por Inciso
            Header.Campo20 = Convert.ToString(Pep.NombrePPR);
            Header.Campo21 = Convert.ToString(Pep.ApellidoPPR);
            Header.Campo22 = Convert.ToString(Pep.TipoDocPPRId);
            Header.Campo23 = Convert.ToString(Pep.NroDocPPR);
            //PPR Tipo Fiscal
            Header.Campo24 = Convert.ToString(Pep.TipoFiscalPPR);
            Header.Campo25 = Convert.ToString(Pep.NroFiscalPPR);
            //PPR Categoria
            Header.Campo26 = Convert.ToString(Pep.CategoriaPPR);
            Header.Campo27 = Convert.ToString(Pep.SubCategoriaPPR);
            //PPR Cargo
            Header.Campo28 = Convert.ToString(Pep.CargoPPRId); //ID Cargo en el Fideicomiso de la PPR (Default =  Fiduciario)
            Header.Campo29 = Convert.ToString(Pep.CargoPPR); //Cargo en el Fideicomiso Descripcion de la PPR (Default =  Fiduciario)
            Header.Campo30 = Convert.ToString(Pep.DomicilioRealPPR); //Domicilio Real PPR

            //NUEVOS CAMPOS 2023 PEP Persona Politicamente Expuesta
            Header.Campo31 = Convert.ToString(Pep.Profesion);
            Header.Campo32 = Pep.FechaNac.ToString("dd/MM/yyyy");
            Header.Campo33 = Convert.ToString(Pep.EstadoCivil);
            Header.Campo34 = Convert.ToString(Pep.Email);
            Header.Campo35 = Convert.ToString(Pep.Nacionalidad);
        

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
            if(indice >0){
                indice = indice - 1;
            }
            
            return Convert.ToString(nombres[indice]).Replace("_", " ");
        }

        //TODO_MEMBRETE: Agrega Membrete
        private string TraerMembrete()
        {
            DJEngine.Business.DJAbstract dj = (DJEngine.Business.DJAbstract)HttpContext.Current.Session["DJ"];
            return dj.Membrete.TextoMembrete;
        }

                //TODO: Generar Reporte para DJ08
        public override void GenerarReporte(bool imprimir)
        {
            //Cambiar nro de Declaracion Jurada por cada nueva
            EntityDJ08 dj = new EntityDJ08();
            string DJId = "08";

            //Llenado de Campos

            //Cambio True/False por Si/No
            if (Pep.PEPoNO == true)
            {
                dj.DJPEP = "SI";
            }
            else
            {
                dj.DJPEP = "NO";
            }

            //Numero de Declaracion Jurada
            dj.DJPTIPODDJJ = Convert.ToString((int)EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE_FIDEICOMISO_FISICA);
            dj.DJPFECHA = DateTime.Now.ToString("dd/MM/yyyy");

            //TODO_MEMBRETE: Agrega Membrete
            //Agrega Membrete del Año Actual
            dj.DJPMEMBRETE = TraerMembrete(); //"2020 - AÑO DEL GENERAL MANUEL BELGRANO";

            //Datos del Fideicomiso
            dj.DJPNROCOR = Convert.ToString(Fid.NroCorrelativo);
            if (Fid.Constituida == false)
            {
                dj.DJPNROCOR = "NO REGISTRADO";
            }

            dj.DJPRAZONSOCIAL = Fid.RazonSocial.ToUpper();
            dj.DJCUIT = Convert.ToString(Fid.Cuit);
            if (dj.DJCUIT == "")
            {
                dj.DJCUIT = "NO REGISTRADO";
            }

            //TODO: Cambio True/False por Si/No
            //dj.DJPCONST = Ent.Constituida.ToString();
            if (Fid.Constituida == true)
            {
                dj.DJCONST = "SI";
            }
            else
            {
                dj.DJCONST = "NO";
            }

            dj.PPRPEPRELACION = Pep.RelacionPPRPEP;

            dj.DJINCISO = TraerValor(Enum.GetNames(typeof(EnumDJ.ETipoIncisos)), Convert.ToInt32(Pep.TipoInciso));

            //Si "Indique si usted es una Persona Expuesta Políticamente" esta en "SI"
            if (Pep.PEPoNO == true)
            {
                //Es una Persona Expuesta Politicamente, No Incluido, Inciso 'B' o Inciso 'I'
                switch (Pep.TipoInciso)
                {
                    case "0": //"No Incluido"
                        //Ingreso los Datos de Persona Expuesta Políticamente en sector PEP Arriba
                        llenarPEP(dj, "PEP", 1);
                        //Ingreso los Datos de Persona Relacionada en sector PPR Abajo
                        llenarPPR(dj, "PPR", 0); //0 = vaciar 
                        //Reinicio los 2 campos
                        dj.DJINCISO = "NO INCLUIDO";
                        dj.PPRCATEGORIA = "";
                        break;
                    case "1": //"Inciso F" //No se usa
                    case "2": //"Inciso B"
                    case "3": //"Inciso I" 
                        //Ingreso los Datos de Persona Relacionada en sector PEP Arriba
                        llenarPEP(dj, "PPR", 1);
                        //Ingreso los Datos de Persona Expuesta Políticamente en sector PPR Abajo
                        llenarPPR(dj, "PEP", 1);
                        break;
                }
            }
            //NO Soy Persona Expuesta Politicamente, No Incluido, Inciso 'B' o Inciso 'I'
            else //if (Pep.PEPoNO == false)
            {
                //Ingreso los Datos de Persona Expuesta Políticamente en sector PEP Arriba
                llenarPEP(dj, "PEP", 1);
                //Ingreso los Datos de Persona Relacionada en sector PPR Abajo
                llenarPPR(dj, "PPR", 0); //0 = vacio
                //Reinicio los 2 campos
                dj.DJINCISO = "B\" o \"I";
                //Como para las NOPEP no hay Combo de "Inciso Resolución 11/2011" harcodeo la catergoria
                dj.PPRCATEGORIA = "NINGUNO";
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

        public void llenarPEP(EntityDJ08 dj, string PEPoPPR, int vacio)
        {
            if (PEPoPPR == "PEP")
            {
                dj.PEPAPELLIDO = Convert.ToString(Pep.ApellidoPEP);
                dj.PEPNOMBRE = Convert.ToString(Pep.NombrePEP);
                dj.PEPTIPODOC = new TiposDocumento(Pep.TipoDocPEPId).Acronimo;
                dj.PEPNRODOC = Convert.ToString(Pep.NroDocPEP);
                dj.PEPCARGOID = Convert.ToString(Pep.CargoPEPId);
                dj.PEPCARGO = new TiposCargo(Pep.CargoPEPId).Acronimo;
                dj.PEPDOMREAL = Convert.ToString(Pep.DomicilioRealPEP);

                //PEP 2023
                dj.PEPNACIONALIDAD = Convert.ToString(Pep.Nacionalidad);
                dj.PEPEMAIL = Convert.ToString(Pep.Email);
                dj.PEPPROFESION = Convert.ToString(Pep.Profesion);
                dj.PEPFECHANACIMIENTO = Convert.ToString(Pep.FechaNac.ToShortDateString());

                //FIN PEP 2023

                //Pregunto si no posee identificación fiscal
                if (Pep.TipoFiscalPEP == 0)
                {
                    dj.PEPTIPOFISCAL = "CUIT/CUIL/CDI";
                    dj.PEPNROFISCAL = "NO POSEO IDENTIFICACION FISCAL";
                }
                else
                {
                    dj.PEPTIPOFISCAL = new TiposFiscal(Pep.TipoFiscalPEP).Acronimo;
                    dj.PEPNROFISCAL = Convert.ToString(Pep.NroFiscalPEP);
                }
                //Pregunto si existe subcategoria
                if (Pep.SubCategoriaPEP != -1)
                    //Si existe ingreso la categoria + la subcategoria
                    dj.PEPCATEGORIA = new CategoriaPEP(Pep.CategoriaPEP).GetDescripcionSubCategoria(Pep.SubCategoriaPEP);
                else
                //Si no existe ingreso solo la categoria
                 
                    dj.PEPCATEGORIA = new CategoriaPEP(Pep.CategoriaPEP).Descripcion; 
                
            }
            else if (PEPoPPR == "PPR")
            {
                dj.PEPAPELLIDO = Convert.ToString(Pep.ApellidoPPR);
                dj.PEPNOMBRE = Convert.ToString(Pep.NombrePPR);
                dj.PEPTIPODOC = new TiposDocumento(Pep.TipoDocPPRId).Acronimo;
                dj.PEPNRODOC = Convert.ToString(Pep.NroDocPPR);
                dj.PEPCARGOID = Convert.ToString(Pep.CargoPPRId);
                dj.PEPCARGO = new TiposCargo(Pep.CargoPPRId).Acronimo;
                dj.PEPDOMREAL = Convert.ToString(Pep.DomicilioRealPPR);

                //PEP 2023
                dj.PEPNACIONALIDAD = Convert.ToString(Pep.Nacionalidad);
                dj.PEPEMAIL = Convert.ToString(Pep.Email);
                dj.PEPPROFESION = Convert.ToString(Pep.Profesion);
                dj.PEPFECHANACIMIENTO = Convert.ToString(Pep.FechaNac.ToShortDateString());

                //FIN PEP 2023

                //Pregunto si no posee identificación fiscal
                if (Pep.TipoFiscalPPR == 0)
                {
                    dj.PEPTIPOFISCAL = "CUIT/CUIL/CDI";
                    dj.PEPNROFISCAL = "NO POSEO IDENTIFICACION FISCAL";
                }
                else
                {
                    dj.PEPTIPOFISCAL = new TiposFiscal(Pep.TipoFiscalPPR).Acronimo;
                    dj.PEPNROFISCAL = Convert.ToString(Pep.NroFiscalPPR);
                }
                //Pregunto si existe subcategoria
                if (Pep.SubCategoriaPPR != -1)
                    //Si existe ingreso la categoria + la subcategoria
                    dj.PEPCATEGORIA = new CategoriaPEP(Pep.CategoriaPEP).GetDescripcionSubCategoria(Pep.SubCategoriaPEP);
                else
                    //Si no existe ingreso solo la categoria
                    dj.PEPCATEGORIA = new CategoriaPEP(Pep.CategoriaPEP).Descripcion;
            }

            //Cambio los campos null por ----
            if (vacio == 0)
            {
                dj.PEPAPELLIDO = "- - - -";
                dj.PEPNOMBRE = "- - - -";
                dj.PEPTIPODOC = "- - - -";
                dj.PEPNRODOC = "- - - -";
                dj.PEPCARGOID = "- - - -";
                dj.PEPCARGO = "- - - -";
                dj.PEPDOMREAL = "- - - -";
                dj.PEPTIPOFISCAL = "CUIT/CUIL/CDI";
                dj.PEPNROFISCAL = "- - - -";
                dj.PEPCATEGORIA = "- - - -";

                dj.PPRPEPRELACION = "- - - -";
            }
        }

        public void llenarPPR(EntityDJ08 dj, string PEPoPPR, int vacio)
        {
            if (PEPoPPR == "PEP")
            {
                dj.PPRAPELLIDO = Convert.ToString(Pep.ApellidoPEP);
                dj.PPRNOMBRE = Convert.ToString(Pep.NombrePEP);
                dj.PPRTIPODOC = new TiposDocumento(Pep.TipoDocPEPId).Acronimo;
                dj.PPRNRODOC = Convert.ToString(Pep.NroDocPEP);
                dj.PPRCARGOID = Convert.ToString(Pep.CargoPEPId);
                dj.PPRCARGO = new TiposCargo(Pep.CargoPEPId).Acronimo;
                dj.PPRDOMREAL = Convert.ToString(Pep.DomicilioRealPEP);
                //Pregunto si no posee identificación fiscal
                if (Pep.TipoFiscalPEP == 0)
                {
                    dj.PPRTIPOFISCAL = "CUIT/CUIL/CDI";
                    dj.PPRNROFISCAL = "NO POSEO IDENTIFICACION FISCAL";
                }
                else
                {
                    dj.PPRTIPOFISCAL = new TiposFiscal(Pep.TipoFiscalPEP).Acronimo;
                    dj.PPRNROFISCAL = Convert.ToString(Pep.NroFiscalPEP);
                }
                //Pregunto si existe subcategoria
                if (Pep.SubCategoriaPEP != -1)
                    //Si existe ingreso la categoria + la subcategoria
                    dj.PPRCATEGORIA = new CategoriaPEP(Pep.CategoriaPEP).GetAcronimoSubcategoria(Pep.SubCategoriaPEP);
                else
                    //Si no existe ingreso solo la categoria
                    dj.PPRCATEGORIA = new CategoriaPEP(Pep.CategoriaPEP).Acronimo;
            }
            else if (PEPoPPR == "PPR")
            {
                dj.PPRAPELLIDO = Convert.ToString(Pep.ApellidoPPR);
                dj.PPRNOMBRE = Convert.ToString(Pep.NombrePPR);
                dj.PPRTIPODOC = new TiposDocumento(Pep.TipoDocPPRId).Acronimo;
                dj.PPRNRODOC = Convert.ToString(Pep.NroDocPPR);
                dj.PPRCARGOID = Convert.ToString(Pep.CargoPPRId);
                dj.PPRCARGO = new TiposCargo(Pep.CargoPPRId).Acronimo;
                dj.PPRDOMREAL = Convert.ToString(Pep.DomicilioRealPPR);
                //Pregunto si no posee identificación fiscal
                if (Pep.TipoFiscalPPR == 0)
                {
                    dj.PPRTIPOFISCAL = "CUIT/CUIL/CDI";
                    dj.PPRNROFISCAL = "NO POSEO IDENTIFICACION FISCAL";
                }
                else
                {
                    dj.PPRTIPOFISCAL = new TiposFiscal(Pep.TipoFiscalPPR).Acronimo;
                    dj.PPRNROFISCAL = Convert.ToString(Pep.NroFiscalPPR);
                }
                //Pregunto si existe subcategoria
                if (Pep.SubCategoriaPPR != -1)
                    //Si existe ingreso la categoria + la subcategoria
                    dj.PPRCATEGORIA = new CategoriaPEP(Pep.CategoriaPPR).GetAcronimoSubcategoria(Pep.SubCategoriaPPR);
                else
                    //Si no existe ingreso solo la categoria
                    dj.PPRCATEGORIA = new CategoriaPEP(Pep.CategoriaPPR).Acronimo;
            }

            //Cambio los campos null por - - - -
            if (vacio == 0)
            {
                dj.PPRAPELLIDO = "- - - -";
                dj.PPRNOMBRE = "- - - -";
                dj.PPRTIPODOC = "- - - -";
                dj.PPRNRODOC = "- - - -";
                dj.PPRCARGOID = "- - - -";
                dj.PPRCARGO = "- - - -";
                dj.PPRDOMREAL = "- - - -";
                dj.PPRTIPOFISCAL = "CUIT/CUIL/CDI";
                dj.PPRNROFISCAL = "- - - -";
                dj.PPRCATEGORIA = "- - - -";

                dj.PPRPEPRELACION = "- - - -";
            }
        }

        public override void ReiniciarDeclaracion()
        {
            /*BORRO TODOS LOS ATRIBUTOS*/
            _Fid = null;
            _Pep = null;

            /*BORRO TODAS LAS VARIABLES DE SESSION*/
            HttpContext.Current.Session.Clear();

            DJ08 dj08 = new DJ08();
            HttpContext.Current.Session["DJ"] = dj08;

            this.WorkFlow.Iniciar();
         }
    }
}
