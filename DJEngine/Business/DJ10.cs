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
    public class DJ10 : DJAbstract
    {
        private Entidad _Ent;

        public Entidad Ent
        {
            get { return _Ent; }
            set { _Ent = value; }
        }

        private Beneficiario _Ben;

        public Beneficiario Ben
        {
            get { return _Ben; }
            set { _Ben = value; }
        }

        public DJ10():base(10)
        { 
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Ben = (Beneficiario)HttpContext.Current.Session["Beneficiario"];
            LeyendaDJ = "DECLARACION JURADA (Res. Nro. 07/2015) - BENEFICIARIO FINAL";
        }

        public override bool RegistrarDJ()
        {
            Ent = (Entidad)HttpContext.Current.Session["Entidad"];
            Ben = (Beneficiario)HttpContext.Current.Session["Beneficiario"];

            int status;
            string mensaje;

            WSMotorDDJJ.DDJJHeader Header = new WSMotorDDJJ.DDJJHeader();

            //Llenado de Campos            
            //Numero de Declaracion Jurada
            Header.TipoDDJJ = Convert.ToString((int)EnumDJ.EDDJJ.BENFICIARIO_FINAL);
            Header.Operacion = "BFpf"; //harcodeo BFpf por FIDEICOMISO BENEFICIARIO FINAL (Persona Fisica)
            GenerarHash();
            Header.CodHash = base.DJHash;

            //Datos de la Entidad
            Header.NroCorr = Convert.ToString(Ent.NroCorrelativo); //Nulleable
            Header.Campo01 = Ent.RazonSocial.ToString(); //Nulleable
            Header.Campo02 = Convert.ToString(Convert.ToInt32(Ent.Constituida)); //False = 0 y True = 1
            Header.Campo03 = Convert.ToString(Ent.TipoSocId); //Nulleable //Tipo Societario Entidad Id
            Header.Campo04 = Convert.ToString(Ent.TipoSocDesc); //Nulleable //Tipo Societario Entidad Descripcion            
            Header.Campo05 = Convert.ToString(Ent.Cuit); //Nulleable

            //Datos del Beneficiario Final
            Header.Campo06 = Convert.ToString(Ben.Nombre);
            Header.Campo07 = Convert.ToString(Ben.Apellido);
            Header.Campo08 = Convert.ToString(Ben.TipoDocId);
            Header.Campo09 = Convert.ToString(Ben.NroDoc);
            Header.Campo10 = Convert.ToString(Ben.TipoFiscal); //ID TIPO FISCAL
            Header.Campo11 = Convert.ToString(Ben.NroFiscal);
            Header.Campo12 = Convert.ToString(Ben.DomicilioReal);
            Header.Campo13 = Convert.ToString(Ben.Nacionalidad);
            Header.Campo14 = Convert.ToString(Ben.FechaNac.ToString("dd/MM/yyyy"));
            Header.Campo15 = Convert.ToString(Ben.Profesion);
            Header.Campo16 = Convert.ToString(Ben.Porcentaje).Replace(",", "."); //Convierto la coma en un punto porque al oracle no le gustan las comas
            Header.Campo17 = Convert.ToString(Ben.EstadoCivil); //Nuevo //ESTADO CIVIL DEL BENEFICIARIO FINAL (INDICE EN LA TABLA TIPO_ESTADOCIVIL)
            Header.Campo18 = Convert.ToString(Ben.Caracter); //Nuevo //CARACTER DEL BENEFICIARIO
            Header.Campo19 = Convert.ToString(Ben.TipoBen); //Nuevo //TIPO DE BENEFICIARIO - "Participación Directa"=1 / "Participación Indirecta"=2 / "Persona Humana que Ejerce el Control Final"=3
            Header.Campo20 = Convert.ToString(Ben.Email); //Nuevo //CORREO ELECTRONICO DEL BENEFICIARIO FINAL
            Header.Campo50 = Convert.ToString(Ben.Observaciones); //Nuevo //OBSERVACIONES DEL BENEFICIARIO FINAL

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

        //TODO: Generar Reporte para DJ10
        public override void GenerarReporte(bool imprimir)
        {
            //Cambiar nro de Declaracion Jurada por cada nueva
            EntityDJ10 dj = new EntityDJ10();
            string DJId = "10";

            //Llenado de Campos

            //Numero de Declaracion Jurada
            dj.DJPTIPODDJJ = Convert.ToString((int)EnumDJ.EDDJJ.BENFICIARIO_FINAL);
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
            //if (dj.DJPTIPOENT == null)
            //{
            //    dj.DJPTIPOENT = "NO REGISTRADO";
            //}

            //Datos de Persona Expuesta Políticamente
            dj.BENNOMBRE = Convert.ToString(Ben.Nombre);
            dj.BENAPELLIDO = Convert.ToString(Ben.Apellido);
            dj.BENTIPODOC = new TiposDocumento(Ben.TipoDocId).Acronimo;
            dj.BENNRODOC = Convert.ToString(Ben.NroDoc);            
            dj.BENDOMREAL = Convert.ToString(Ben.DomicilioReal);
            

            //Pregunto si No Posee Identificación Fiscal para PEP
            if (Ben.TipoFiscal == 0)
            {
                dj.BENTIPOFISCAL = "CUIT/CUIL/CDI";
                dj.BENNROFISCAL = "NO POSEO IDENTIFICACION FISCAL";
            }
            else
            {
                dj.BENTIPOFISCAL = new TiposFiscal(Ben.TipoFiscal).Acronimo;
                dj.BENNROFISCAL = Convert.ToString(Ben.NroFiscal);
            }

            dj.BENNACIONAL = Convert.ToString(Ben.Nacionalidad);
            dj.BENFECHANAC = Convert.ToString(Ben.FechaNac.ToString("dd/MM/yyyy"));
            dj.BENESTADOCIVIL = new TiposEstadoCivil(Ben.EstadoCivil).Descripcion; //Nuevo
            dj.BENPROFESION = Convert.ToString(Ben.Profesion);
            dj.BENPORCENTAJE = Convert.ToString(Ben.Porcentaje);
            dj.BENCARACTER = Convert.ToString(Ben.Caracter); //Nuevo
            dj.BENEMAIL = Convert.ToString(Ben.Email); //Nuevo

            if (Ben.Observaciones != "")
            {
                dj.BENOBSERV = "Observaciones: " + Ben.Observaciones; //Nuevo
            }

            //dj.BENONODDESC = ".............................................................. reviste/o ";

            dj.BENTIPOBENID = Convert.ToString(Ben.TipoBen); //Nuevo
            //Segun el Tipo de Beneficiario //Nuevo 
            switch (Ben.TipoBen)
            {
                case 1: //Porcentaje de Participación en la Entidad (Directo)
                    dj.BENTIPOBEN = "Participación Directa";
                    dj.BENPORCENCARACTER = "Porcentaje de participación en la entidad que directamente le otorga tal calidad: " + Ben.Porcentaje + "%";
                    break;
                case 2: //Porcentaje de Participación en la Entidad (Indirecto)
                    dj.BENTIPOBEN = "Participación Indirecta";
                    dj.BENPORCENCARACTER = "Porcentaje de participación en la entidad que indirectamente le otorga tal calidad: " + Ben.Porcentaje + "%";
                    break;
                case 3: //Caracter del Beneficiario
                    dj.BENTIPOBEN = "Persona Humana que Ejerce el Control Final";
                    dj.BENPORCENCARACTER = "Calidad de la persona humana que frente a la entidad ejerce el control final (Dirección/Administración/Representación): " + Ben.Caracter;
                    break;
            }

            dj.BENTIPOBEN = dj.BENTIPOBEN.ToString().ToUpper();

            //Pregunto si no es Beneficiario // Ya no se usa
            /*
            if (Ben.BENoNO == true)
            {
                dj.BENAPELLIDO = "- - - -";
                dj.BENNOMBRE = "- - - -";
                dj.BENTIPODOC = "- - - -";
                dj.BENNRODOC = "- - - -";
                dj.BENDOMREAL = "- - - -";
                dj.BENTIPOFISCAL = "CUIT/CUIL/CDI";
                dj.BENNROFISCAL = "- - - -";
                dj.BENNACIONAL = "- - - -";
                dj.BENFECHANAC = "- - - -";
                dj.BENPROFESION = "- - - -";
                dj.BENPORCENTAJE = "- -";
                dj.BENONODDESC = "no hay persona humana que posea";
            }
            */

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
            _Ben = null;

            HttpContext.Current.Session.Clear();

            DJ10 dj10 = new DJ10();
            HttpContext.Current.Session["DJ"] = dj10;

            this.WorkFlow.Iniciar();
         }
    }
}
