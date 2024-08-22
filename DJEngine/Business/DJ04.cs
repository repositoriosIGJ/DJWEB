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
    public class DJ04 : DJAbstract
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


        public DJ04()
            : base(4)
        {
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Rep = (Representante)HttpContext.Current.Session["Representante"];//aca--Chequear que sea este el nombre de la variable de session
            Ori = (OrigenFondos)HttpContext.Current.Session["OrigenFondos"];//aca--Chequear que sea este el nombre de la variable de session
            LeyendaDJ = "DECLARACION JURADA (Res. Nro. 02/2012) - ORIGEN LICITO DE LOS FONDOS";
        }

        public override bool RegistrarDJ()//Avanzado
        {
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Rep = (Representante)HttpContext.Current.Session["Representante"];//aca--Chequear que sea este el nombre de la variable de session
            Ori = (OrigenFondos)HttpContext.Current.Session["OrigenFondos"];//aca--Chequear que sea este el nombre de la variable de session

            int status;
            string mensaje;

            WSMotorDDJJ.DDJJHeader Header = new WSMotorDDJJ.DDJJHeader();

            //Llenado de Campos            
            //Numero de Declaracion Jurada
            Header.TipoDDJJ = Convert.ToString((int)EnumDJ.EDDJJ.OLF);
            Header.Operacion = "OLF"; //harcodeo OLF para origen licito de los fondos
            GenerarHash();
            Header.CodHash = base.DJHash;

            //Datos de Entidad
            //DDJJ.NROCOR,  --djnrocorent, --NUMERO CORRELATIVO DE LA ENTIDAD (ex ENTNROCORRELATIVO)
            Header.NroCorr = Convert.ToString(Ent.NroCorrelativo);      
            //DDJJ.CAMPO01, --djrazsocent, --RAZON SOCIAL DE LA ENTIDAD (ex DJPRAZONSOCIAL)
            Header.Campo01 = Convert.ToString(Ent.RazonSocial); //ENTRAZONSOCIAL //Nuevo Campo 01/16
            //DDJJ.CAMPO02, --djconstent,  --SI LA ENTIDAD ESTA INSCRIPTA O NO (CONSTITUIDA O NO) (False = 0 y True = 1) (ex ENTINSCRIPTA)
            Header.Campo02 = Convert.ToString(Ent.Constituida);
            //DDJJ.CAMPO03, --djtipoentid, --TIPO SOCIETARIO DE LA ENTIDAD ID (INDICE DE TABLA TIPO_SOCIETARIO)
            Header.Campo03 = Convert.ToString(Ent.TipoSocId);   //ENTTIPOENTID //Nuevo Campo 01/16
            //DDJJ.CAMPO04, --djtipoent,   --TIPO SOCIETARIO DE LA ENTIDAD (DESCRIPCION)
            Header.Campo04 = Convert.ToString(Ent.TipoSocDesc); //ENTTIPOENT //Nuevo Campo 01/16
            //DDJJ.CAMPO05, --djcuitent,   --CUIT DE LA ENTIDAD (ex ENTNROCUIT)
            Header.Campo05 = Convert.ToString(Ent.Cuit);

            //DDJJ.TIPODDJJ,--djtipoddjj,  --TIPO DE DECLARACION JURADA (ORIGEN FONDOS es Nro. 04, etc) (ex TIPODDJJ)
            //Al principio Header.TipoDDJJ
            //DDJJ.FECHA,   --djfecha,     --FECHA DE ALTA DE LA DJ
            //Header.Fecha como default sysdate en la tabla

            //Datos del Representante (Presidente o Titular)
            //DDJJ.CAMPO06, --titnombre
            Header.Campo06 = Convert.ToString(Rep.Nombre);
            //DDJJ.CAMPO07, --titapellido,
            Header.Campo07 = Convert.ToString(Rep.Apellido);
            //DDJJ.CAMPO08, --tittipodoc, 
            Header.Campo08 = Convert.ToString(Rep.TipoDoc);
            //DDJJ.CAMPO09, --titnrodoc,
            Header.Campo09 = Convert.ToString(Rep.NroDoc);
            //DDJJ.CAMPO10, --tittipofiscal, 
            Header.Campo10 = Convert.ToString(Rep.TipoClaveFiscal);
            //DDJJ.CAMPO11, --titnrofiscal, 
            Header.Campo11 = Convert.ToString(Rep.NroClaveFiscal);

            //Datos del Donate/Aportante
            //DDJJ.CAMPO12, --apopersoneria, 
            Header.Campo12 = Convert.ToString(Ori.PersonaFisica);
            //DDJJ.CAMPO13, --aponombrepf,
            Header.Campo13 = Convert.ToString(Ori.Nombre);
            //DDJJ.CAMPO14, --apoapellidopf,
            Header.Campo14 = Convert.ToString(Ori.Apellido);
            //DDJJ.CAMPO15, --apotipodocpf, 
            Header.Campo15 = Convert.ToString(Ori.TipoDoc);
            //DDJJ.CAMPO16, --aponrodocpf,
            Header.Campo16 = Convert.ToString(Ori.NroDoc);
            //DDJJ.CAMPO17, --apotipofiscalpf, 
            Header.Campo17 = Convert.ToString(Ori.TipoClaveFiscal);
            //DDJJ.CAMPO18, --aponrofiscalpf,
            Header.Campo18 = Convert.ToString(Ori.NroClaveFiscal);
            //DDJJ.CAMPO19, --aporazsocpj,
            Header.Campo19 = Convert.ToString(Ori.RazonSocial);
            //DDJJ.CAMPO20, --aponrocuitpj
            Header.Campo20 = Convert.ToString(Ori.NroCuitPJ);
                        
            //Caracter de los Fondos
            //DDJJ.CAMPO21, --foncaracterfondo,
            Header.Campo21 = Convert.ToString(Ori.CaracterFondo); //Caracter Fondo - 1 Donacion - 2 Aporte de Terceros
            //DDJJ.CAMPO22, --fonorigen
            Header.Campo22 = Convert.ToString(Ori.Origen); //Nuevo 01/2016
            //DDJJ.CAMPO23, --fonfechacf
            Header.Campo23 = Convert.ToString(Ori.FechaCF.ToString("dd/MM/yyyy")); //Fecha de Aporte //Nuevo 12/2015

            //Modo de Ingreso de los Fondos
            //DDJJ.CAMPO24, --fontipoingreso
            Header.Campo24 = Convert.ToString(Ori.TipoIngreso); //Tipo de Ingreso

            //Fondos en Efectivo
            //DDJJ.CAMPO25, --fontipoinstrumento
            //Tipo de Instrumento en Efectivo: Deposito Bancario - Transferencia Bancaria - Otro Instrumento
            Header.Campo25 = Convert.ToString(Ori.TipoInstrumentoEfe); //Nuevo Campo 01/16            
            //Deposito Bancario
            //DDJJ.CAMPO26 --EFEENTBANDEPOSITO -- ENTIDAD BANCARIA DEPOSITO           
            Header.Campo26 = Convert.ToString(Ori.EntBanDeposito); //Nuevo 12/2015
            //DDJJ.CAMPO27 --EFETIPOCUENTAIDDEPOSITO
            Header.Campo27 = Convert.ToString(Ori.TipoCuentaIdDeposito);
            //DDJJ.CAMPO28 --EFENROCUENTADEPOSITO -- NUMERO DE CUENTA BANCARIA DEPOSITO
            Header.Campo28 = Convert.ToString(Ori.NroCuentaDeposito); //Nuevo 01/2016
            //Donante
            //DDJJ.CAMPO29 --EFEENTBANDONANTE -- ENTIDAD BANCARIA DONANTE
            Header.Campo29 = Convert.ToString(Ori.EntBanDonante); //Nuevo 01/2016
            //DDJJ.CAMPO30 --EFETIPOCUENTAIDDONANTE
            Header.Campo30 = Convert.ToString(Ori.TipoCuentaIdDonante);
            //DDJJ.CAMPO31 --EFENROCUENTADONANTE -- NUMERO DE CUENTA BANCARIA DONANTE
            Header.Campo31 = Convert.ToString(Ori.NroCuentaDonante); //Nuevo 01/2016
            //Donatario
            //DDJJ.CAMPO32 --efeentbancaria -- ENTIDAD BANCARIA DONATARIO (ex FONENTIDADBANCARIA)           
            Header.Campo32 = Convert.ToString(Ori.EntBanDonatario);
            //DDJJ.CAMPO33 --EFETIPOCUENTAIDDONATARIO
            Header.Campo33 = Convert.ToString(Ori.TipoCuentaIdDonatario);
            //DDJJ.CAMPO34 --EFENROCUENTADONATARIO -- NUMERO DE CUENTA BANCARIA DONATARIO (ex FONNROCUENTA)
            Header.Campo34 = Convert.ToString(Ori.NroCuentaDonatario);
            //Efectivo - Otro Instrumento
            //DDJJ.CAMPO35 --efeotroinstrumento -- DESCRIPCION DE OTRO INSTRUMENTO (ex FONOTROINSTRUMENTO)
            Header.Campo35 = Convert.ToString(Ori.OtroInstrumento);

            //Efectivo - Montos y Moneda
            //DDJJ.CAMPO36 --efemonto
            Header.Campo36 = Convert.ToString(Ori.MontoMoneda); //Nuevo 01/2016
            //DDJJ.CAMPO37 --efemonedaid
            Header.Campo37 = Convert.ToString(Ori.MonedaId); //Nuevo 01/2016
            //DDJJ.CAMPO38 --efemonedadesc
            Header.Campo38 = Convert.ToString(Ori.MonedaDesc); //Nuevo 01/2016
            //DDJJ.CAMPO39 --efemontopesos
            Header.Campo39 = Convert.ToString(Ori.MontoPesos); //Nuevo 01/2016

            //Especie
            //DDJJ.CAMPO40 --fontipobien
            Header.Campo40 = Convert.ToString(Ori.TipoBien); //Nuevo Campo 01/16
            //DDJJ.CAMPO41 --fontipovaluacion
            Header.Campo41 = Convert.ToString(Ori.Valuacion); //Nuevo Campo 01/16 //Valuacion
            //Cantidad
            //DDJJ.CAMPO42 --espcantidad            
            Header.Campo42 = Convert.ToString(Ori.Cantidad); //Nuevo Campo 01/16
            //Valor Corriente Unitario
            //DDJJ.CAMPO43 --espvalcorunit
            Header.Campo43 = Convert.ToString(Ori.ValCorUni); //Nuevo Campo 01/16 
            //Valor Corriente Total
            //DDJJ.CAMPO44 --espvalcortot
            Header.Campo44 = Convert.ToString(Ori.ValCorTot); //Nuevo Campo 01/16

            //Monto
            //DDJJ.CAMPO45 --fonmasdedoscientosmil 
            Header.Campo45 = Convert.ToString(Ori.MasDeDoscientosMil); //Mas de Doscientos mil
            //DDJJ.CAMPO46 --docrespaldatoria
            Header.Campo46 = Convert.ToString(Ori.DocRespaldatoria); // Documentacion Respaldatoria            
            
            //DDJJ.CODHASH, --djphash
            //Arriba como Header.CodHash = base.DJHash;
            //DDJJ.CAMPO47 --djprecibida
            //DDJJ.CAMPO48  --djprecibidafech    

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

            //quitar el Status != 0 despues de arreglarlo
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
            DJEngine.Reportes.EntityReport.EntityDJ04 dj = new DJEngine.Reportes.EntityReport.EntityDJ04();
            string DJId = "04";

            //Llenado de Campos

            //TODO: Cambio True/False por Si/No
            dj.ENTINSCRIPTA = Convert.ToString(Convert.ToInt32(Ent.Constituida));
            dj.ENTRAZONSOCIAL = Convert.ToString(Ent.RazonSocial);
            dj.ENTTIPOSOCIETARIO = Convert.ToString(Ent.TipoSocId);
            dj.ENTTIPOSOCDESC = Convert.ToString(Ent.TipoSocDesc);
            dj.ENTNROCORRELATIVO = Convert.ToString(Ent.NroCorrelativo);
            dj.ENTNROCUIT = Convert.ToString(Ent.Cuit);

            //TODO_MEMBRETE: Agrega Membrete
            //Agrega Membrete del Año Actual
            dj.DJPMEMBRETE = TraerMembrete(); //"2020 - AÑO DEL GENERAL MANUEL BELGRANO";

            //Pregunto si la Entidad no esta Inscripta
            if (dj.ENTINSCRIPTA == "0")
            {
                dj.ENTNROCORRELATIVO = "NO REGISTRADO";
                dj.ENTNROCUIT = "NO REGISTRADO";
            }
            dj.TITNOMBRE = Convert.ToString(Rep.Nombre);
            dj.TITAPELLIDO = Convert.ToString(Rep.Apellido);
            dj.TITTIPODOC = new TiposDocumento(Rep.TipoDoc).Acronimo;
            dj.TITNRODOC = Convert.ToString(Rep.NroDoc);
            dj.TITTIPOCLAVEFISCAL = Convert.ToString(new TiposFiscal(Rep.TipoClaveFiscal).Codigo);
            dj.TITNROCLAVEFISCAL = Convert.ToString(Rep.NroClaveFiscal);
            //Pregunto si el titular no ingreso cuit/cuil/cdi
            if (dj.TITTIPOCLAVEFISCAL == "0")
            {
                //dj.TITTIPOCLAVEFISCAL = "NO REGISTRADO";
                dj.TITNROCLAVEFISCAL = "NO REGISTRADO";
            }

            //Datos del Donante/Aportante
            dj.APOPERSONAFISICA = Convert.ToString(Ori.PersonaFisica);
            //Pregunto si es Persona Fisica o Juridica
            if (dj.APOPERSONAFISICA == "1")
            {
                //Persona Fisica
                dj.APONOMBRE = Convert.ToString(Ori.Nombre);
                dj.APOAPELLIDO = Convert.ToString(Ori.Apellido);
                dj.APOTIPODOC = new TiposDocumento(Ori.TipoDoc).Acronimo;
                dj.APONRODOC = Convert.ToString(Ori.NroDoc);
                dj.APOTIPOCLAVEFISCAL = Convert.ToString(new TiposFiscal(Ori.TipoClaveFiscal).Codigo);
                dj.APONROCLAVEFISCAL = Convert.ToString(Ori.NroClaveFiscal);
                //Pregunto si el Apoderado PF no ingreso cuit/cuil/cdi
                if (dj.APOTIPOCLAVEFISCAL == "0")
                {
                    dj.APONROCLAVEFISCAL = "NO REGISTRADO";
                }

                dj.APORAZONSOCIAL = " - - - ";
                dj.APONROCUITPJ = " - - - ";
            }
            else if (dj.APOPERSONAFISICA == "0")
            {
                //Persona Juridica
                dj.APONOMBRE = " - - - ";
                dj.APOAPELLIDO = " - - - ";
                dj.APOTIPODOC = " - - - ";
                dj.APONRODOC = " - - - ";
                dj.APOTIPOCLAVEFISCAL = " - - - ";
                dj.APONROCLAVEFISCAL = " - - - ";
                dj.APORAZONSOCIAL = Convert.ToString(Ori.RazonSocial);
                dj.APONROCUITPJ = Convert.ToString(Ori.NroCuitPJ);
                ////Pregunto si el Apoderado PJ no ingreso cuit/cuil/cdi
                //if (dj.APONROCUITPJ == "" || dj.APONROCUITPJ == null)
                //{
                //    dj.APONROCUITPJ = "NO REGISTRADO";
                //}
            }
            //Caracter de los Fondos
            dj.FONCARACTERFONDO = Convert.ToString(Ori.CaracterFondo);
            dj.FONORIGEN = Convert.ToString(Ori.Origen);
            dj.FONFECHACF = Ori.FechaCF.ToString("dd/MM/yyyy");
            //Modo de Ingreso de los Fondos
            dj.FONTIPOINGRESO = Convert.ToString(Ori.TipoIngreso);
            //Fondos en Efectivo:
            dj.FONTIPOINSTRUMENTOEFE = Convert.ToString(Ori.TipoInstrumentoEfe);

            //pregunto si el modo de ingreso es Efectivo
            if (Ori.TipoIngreso == 1)
            {
                //Montos y Monedas para Efectivo            
                dj.EFEMONEDAID = Ori.MonedaId;
                dj.EFEMONEDADESC = Ori.MonedaDesc;
                dj.EFEMONTO = Convert.ToString(Ori.MontoMoneda);
                dj.EFEMONTOPESOS = Convert.ToString(Ori.MontoPesos);
                //Pregunto por el tipo de Fondo en efectivo
                switch (dj.FONTIPOINSTRUMENTOEFE)
                {
                    //Deposito Bancario
                    case "1":
                        dj.EFEENTBANDEPOSITO = Convert.ToString(Ori.EntBanDeposito);
                        dj.EFETIPOCUENTADEPOSITO = Convert.ToString(Ori.TipoCuentaDeposito); //Descripcion
                        dj.EFENROCUENTADEPOSITO = Convert.ToString(Ori.NroCuentaDeposito);
                        dj.EFEENTBANDONANTE = " - - - ";
                        dj.EFETIPOCUENTADONANTE = " - - - ";
                        dj.EFENROCUENTADONANTE = " - - - ";
                        dj.EFEENTBANDONATARIO = " - - - ";
                        dj.EFETIPOCUENTADONATARIO = " - - - ";
                        dj.EFENROCUENTADONATARIO = " - - - ";
                        dj.FONOTROINSTRUMENTO = " - - - ";
                        break;
                    //Transferencia Bancaria
                    case "2":
                        dj.EFEENTBANDEPOSITO = " - - - ";
                        dj.EFETIPOCUENTADEPOSITO = " - - - ";
                        dj.EFENROCUENTADEPOSITO = " - - - ";
                        dj.EFEENTBANDONANTE = Convert.ToString(Ori.EntBanDonante);
                        dj.EFETIPOCUENTADONANTE = Convert.ToString(Ori.TipoCuentaDonante); //Descripcion
                        dj.EFENROCUENTADONANTE = Convert.ToString(Ori.NroCuentaDonante);
                        dj.EFEENTBANDONATARIO = Convert.ToString(Ori.EntBanDonatario);
                        dj.EFETIPOCUENTADONATARIO = Convert.ToString(Ori.TipoCuentaDonatario); //Descripcion
                        dj.EFENROCUENTADONATARIO = Convert.ToString(Ori.NroCuentaDonatario);
                        dj.FONOTROINSTRUMENTO = " - - - ";
                        break;
                    //Otro Instrumento
                    case "3":
                        dj.EFEENTBANDEPOSITO = " - - - ";
                        dj.EFETIPOCUENTADEPOSITO = " - - - ";
                        dj.EFENROCUENTADEPOSITO = " - - - ";
                        dj.EFEENTBANDONANTE = " - - - ";
                        dj.EFETIPOCUENTADONANTE = " - - - ";
                        dj.EFENROCUENTADONANTE = " - - - ";
                        dj.EFEENTBANDONATARIO = " - - - ";
                        dj.EFETIPOCUENTADONATARIO = " - - - ";
                        dj.EFENROCUENTADONATARIO = " - - - ";
                        dj.FONOTROINSTRUMENTO = Convert.ToString(Ori.OtroInstrumento);
                        break;
                }
            }
            else
            {
                //Montos y Monedas para Efectivo            
                dj.EFEMONEDAID = 0;
                dj.EFEMONEDADESC = "";
                dj.EFEMONTO = " - - - ";
                dj.EFEMONTOPESOS = "";
                dj.EFEENTBANDEPOSITO = " - - - ";
                dj.EFETIPOCUENTADEPOSITO = " - - - ";
                dj.EFENROCUENTADEPOSITO = " - - - ";
                dj.EFEENTBANDONANTE = " - - - ";
                dj.EFETIPOCUENTADONANTE = " - - - ";
                dj.EFENROCUENTADONANTE = " - - - ";
                dj.EFEENTBANDONATARIO = " - - - ";
                dj.EFETIPOCUENTADONATARIO = " - - - ";
                dj.EFENROCUENTADONATARIO = " - - - ";
                dj.FONOTROINSTRUMENTO = " - - - ";
            }

            //Fondos en Especie:            
            dj.FONTIPOBIEN = Convert.ToString(Ori.TipoBien);
            dj.ESPVALUACION = Convert.ToString(Ori.Valuacion);

            //pregunto si el modo de ingreso es especie
            if (Ori.TipoIngreso == 2)
            {
                dj.ESPDESCRIPCIONBIEN = Convert.ToString(Ori.DescripcionBien);
                dj.ESPCANTIDAD = Convert.ToString(Ori.Cantidad);
                dj.ESPVALCORUNI = Convert.ToString(Ori.ValCorUni);
                dj.ESPVALCORTOT = Convert.ToString(Ori.ValCorTot);
            }
            else
            {
                dj.ESPDESCRIPCIONBIEN = " - - - ";
                dj.ESPCANTIDAD = " - - - ";
                dj.ESPVALCORUNI = " - - - ";
                dj.ESPVALCORTOT = " - - - ";
            }

            dj.FONMASDEDOSCIENTOSMIL = Convert.ToString(Ori.MasDeDoscientosMil);
            dj.DOCRESPALDATORIA = Convert.ToString(Ori.DocRespaldatoria);

            //Fecha de la Declaracion Jurada
            dj.DJPFECHA = DateTime.Now.ToString("dd/MM/yyyy");
            
            dj.HASH = this.CodigoEscaner;

            oRpt.Load(HttpContext.Current.Server.MapPath("Reportes") + "/DDJJ04.rpt");

            CodigoBarra codigoBarras = new CodigoBarra();

            System.Drawing.Image imagen;
            MemoryStream ms = new MemoryStream();

            //NumeroSerie = DJ.ID;

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

            /*BORRO TODAS LAS VARIABLES DE SESSION*/
            //HttpContext.Current.Session["DatosEntidad"] = null;
            //HttpContext.Current.Session["Entidad"] = null;
            //HttpContext.Current.Session["PersonaEP"] = null;
            //HttpContext.Current.Session["captchaUrl"] = null;

            HttpContext.Current.Session.Clear();

            DJ04 dj04 = new DJ04();
            HttpContext.Current.Session["DJ"] = dj04;

            this.WorkFlow.Iniciar();
        }
    }
}
