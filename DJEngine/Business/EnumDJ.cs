using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJEngine.Business
{
    public class EnumDJ
    {
        #region "DeclaracionesJuradas"

        //Numero de Declaracion Jurada
        public enum EDDJJ
        {
            DD = 1, //no esta activa
            DOMICILIO_DIGITAL = 2, //no esta activa
            PERSONAS_EXPUESTAS_POLITICAMENTE = 3,
            OLF = 4,
            PERSONAS_EXPUESTAS_POLITICAMENTE_ESCRIBANOS = 5,
            OLF_ESCRIBANOS = 6,
            PERSONAS_EXPUESTAS_POLITICAMENTE_REPRESENTANTE = 7,
            PERSONAS_EXPUESTAS_POLITICAMENTE_FIDEICOMISO_FISICA = 8,
            FIDEICOMISO_FIDUCIARIO_JURIDICA = 9,
            BENFICIARIO_FINAL = 10,
            PRESENTACION_BALANCES_SAS = 11
        }

        //Tipos de Incisos para PEP
        public enum ETipoIncisos
        {
             NOINCLUIDO = 0,
            //F = 1,
            PARENTESCO = 2,
            CERCANIA =3
            //B = 2,
            //I = 3
        }

        #endregion "DeclaracionesJuradas"

        #region VinculosPersonas

        //Vinculos entre Personas
        public enum ETipoVinculo
        {
            PRESIDENTE = 0,
            VICEPRESIDENTE = 1,
            SOCIO = 2,
            SOCIO_GERENTE = 3,
            SOCIO_ADMINISTRADOR = 4,
            SOCIO_COMANDITADO = 5,
            GERENTE = 6,
            DIRECTOR_TITULAR = 7,
            VOCAL_SUPLENTE = 8,
            SINDICO_TITULAR = 9,
            APODERADO = 10,
            LIQUIDADOR = 11,
            TESORERO = 12,
            ACCIONISTA = 13,
            CONSEJERO_DE_VIGILANCIA = 14,
            SOCIO_GERENTE_TITULAR = 15,
            SOCIO_GERENTE_SUPLENTE = 16,
            DIRECTOR_ALTERNO = 17,
            SOCIO_COLECTIVO = 18,
            TITULAR_COMISION_FISCALIZADORA = 19,
            SOCIO_Y_APODERADO = 20
        }

        #endregion

        #region "Usuario"

        #endregion "Usuario"

        #region "PersonaFisica"

        //Tipos de Personas Fisicas
        public enum ETipoPersona
        {
            COMERCIANTE = 0,
            MARTILLERO = 1,
            AGENTE_DE_BOLSA = 2,
            MARTILLERO_Y_CORREDOR = 3,
            CORREDOR = 4,
            DESPACHANTE_DE_ADUANA = 5
        }

        //Tipos de Documentos
        public enum ETipoDoc
        {
            SELECCIONAROPCION = -1,
            DNI = 1,
            CEDULA_DE_IDENTIDAD = 2,            
            LIBRETA_CIVICA = 3,
            LIBRETA_DE_ENRROLAMIENTO = 4,
            PASAPORTE = 5
         }

        //Relacion Declarante con la Persona Expuesta
        public enum ETipoRelacion
        { 
            SELECCIONAROPCION = -1,
            CONYUGE_CONVIVIENTE = 1,
            PADRE_HERMANO_HIJA_NIETO_SUEGRO_YERNO_CUÑADO = 2,
            OTRA_RELACION_VINCULO_RELEVANTE = 3
        }

        #endregion "PersonaFisica"

        #region "PersonaJuridica"

        //Tipos Societarios de Personas Juridicas
        public enum ETipoSocietario
        {
            SOCIEDAD_COLECTIVA = 0,
            SOCIEDAD_EN_COMANDITA_SIMPLE = 1,
            SOCIEDAD_DE_CAPITAL_E_INDUSTRIA = 2,
            SOCIEDAD_DE_RESPONSABILIDAD_LIMITADA = 3,
            SOCIEDAD_ANONIMA = 4,
            SOCIEDAD_DEL_ESTADO = 5,
            SOCIEDAD_EN_COMANDITA_POR_ACCIONES = 6,
            SOCIEDAD_DE_HECHO = 7,
            SOCIEDAD_EXTRANJERA = 8,
            SOCIEDAD_BINACIONAL_FUERA_DE_JURISDICCION = 9,
            ASOCIACION_CIVIL = 10,
            ENTIDAD_EXTRANJERA_SIN_FINES_DE_LUCRO = 11,
            FUNDACION = 12,
            SIMPLE_ASOCIACION = 13,
            FEDERACION = 14,
            CONFEDERACION = 15,
            CAMARA = 16,
            CONTRATO_DE_COLABORACION_EMPRESARIA = 17,
            CONSORCIO_DE_COOPERACION = 18,
            SOCIEDADES_NO_REGISTRADAS = 19,
            UNION_TRANSITORIA_DE_EMPRESAS = 20,
            SOCIEDAD_DE_GARANTIA_RECIPROCA = 21,
            SOCIEDAD_DE_CAPITALIZACION_Y_AHORRO_PROVINCIAL = 22,
            COMERCIANTE = 23,
            MARTILLERO = 24,
            AGENTE_DE_BOLSA = 25,
            MARTILLERO_Y_CORREDOR = 26,
            CORREDOR = 27,
            DESPACHANTE_DE_ADUANA = 28,
            PERSONA_FISICA_NO_REGISTRADA = 29
        }

        #endregion "PersonaJuridica"
    }
}
