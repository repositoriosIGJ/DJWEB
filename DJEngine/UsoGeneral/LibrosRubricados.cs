using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Reflection;
using DJEngine.Business;
using DJEngine.Reportes.EntityReport;

namespace DJEngine.UsoGeneral
{
    public static class LibrosRubricados
    {
        //Trae libros para probar
        //public static Libros GetLibrosPrueba()
        //{
        //    //Datos de Prueba en Json
        //    string jsonStrIni = @"{""libros"":[";
        //    string jsonStr1 = @"{""iddoc"":""1"",""doc"":""Memoria"",""den"":""ACTA DE DIRECTORIO NUMERO 1"",""nru"":""12345-01"",""fru"":""01/12/2020"",""fol"":""111-111""},";
        //    string jsonStr2 = @"{""iddoc"":""2"",""doc"":""Acta Organo de Administración"",""den"":""ACTA DE DIRECTORIO NUMERO 2"",""nru"":""12345-02"",""fru"":""02/12/2020"",""fol"":""111-222""},";
        //    string jsonStr3 = @"{""iddoc"":""3"",""doc"":""Acta de Asamblea"",""den"":""ACTA DE DIRECTORIO NUMERO 3"",""nru"":""12345-03"",""fru"":""03/12/2020"",""fol"":""111-333""},";
        //    string jsonStr4 = @"{""iddoc"":""4"",""doc"":""Registro Asistencia Asamblea"",""den"":""ACTA DE DIRECTORIO NUMERO 4"",""nru"":""12345-04"",""fru"":""04/12/2020"",""fol"":""111-444""},";
        //    string jsonStr5 = @"{""iddoc"":""5"",""doc"":""Estado de Situación Patrimonial"",""den"":""ACTA DE DIRECTORIO NUMERO 5"",""nru"":""12345-05"",""fru"":""05/12/2020"",""fol"":""111-555""},";
        //    string jsonStr6 = @"{""iddoc"":""6"",""doc"":""Estado de Resultados"",""den"":""ACTA DE DIRECTORIO NUMERO 6"",""nru"":""12345-06"",""fru"":""06/12/2020"",""fol"":""111-433""},";
        //    string jsonStr7 = @"{""iddoc"":""7"",""doc"":""Estado de Evolución de Patrimonio Neto"",""den"":""ACTA DE DIRECTORIO NUMERO 7"",""nru"":""12345-07"",""fru"":""07/12/2020"",""fol"":""111-777""},";
        //    string jsonStr8 = @"{""iddoc"":""8"",""doc"":""Estado de Flujo de Efectivo"",""den"":""ACTA DE DIRECTORIO NUMERO 8"",""nru"":""12345-08"",""fru"":""08/12/2020"",""fol"":""111-888""},";
        //    string jsonStr9 = @"{""iddoc"":""9"",""doc"":""Información Complementaria"",""den"":""ACTA DE DIRECTORIO NUMERO 9"",""nru"":""12345-09"",""fru"":""09/12/2020"",""fol"":""111-999""},";
        //    string jsonStr10 = @"{""iddoc"":""10"",""doc"":""Estado Contables Consolidados"",""den"":""ACTA DE DIRECTORIO NUMERO 10"",""nru"":""12345-10"",""fru"":""10/12/2020"",""fol"":""111-010""},";
        //    string jsonStr11 = @"{""iddoc"":""11"",""doc"":""Informe de Organo de Fiscalización"",""den"":""ACTA DE DIRECTORIO NUMERO 11"",""nru"":""12345-11"",""fru"":""11/12/2020"",""fol"":""111-011""},";
        //    string jsonStr12 = @"{""iddoc"":""12"",""doc"":""Informe del Auditor Externo"",""den"":""ACTA DE DIRECTORIO NUMERO 12"",""nru"":""12345-12"",""fru"":""12/12/2020"",""fol"":""111-012""}";
        //    string jsonStrFin = @"]}";

        //    //Meto todo el Json en un string
        //    string jsonstr = jsonStrIni + jsonStr1 + jsonStr2 + jsonStr3 + jsonStr4 + jsonStr5 + jsonStr6 + jsonStr7 + jsonStr8 + jsonStr9 + jsonStr10 + jsonStr11 + jsonStr12 + jsonStrFin;
        //    int cantjsonstr = jsonstr.Length;

        //    Libros libros = new Libros();

        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    libros = serializer.Deserialize<Libros>(jsonstr);

        //    return libros;
        //}

        //static IEnumerable<string> SplitStr(string str, int maxChunkSize)
        //{
        //    for (int i = 0; i < str.Length; i += maxChunkSize)
        //        yield return str.Substring(i, Math.Min(maxChunkSize, str.Length - i));
        //}

        // Convierte la lista de libros a json y lo comprime en un array de string
        //public static string[] ListToJsonAndCompress(Libros listLib)
        //{
        //    try
        //    {
        //        //Convierte la lista a json
        //        JavaScriptSerializer serializer = new JavaScriptSerializer();
        //        string jsonstr = serializer.Serialize(listLib);

        //        //Comprime el Json
        //        string jsonstrcomp = StringCompression.Zip(jsonstr);
        //        //int cantjsonstrcomp = jsonstrcomp.Length;

        //        //Descomprime el Json
        //        //string jsonstrdecomp = StringCompression.Unzip(jsonstrcomp);
        //        //int cantjsonstrdecomp = jsonstrdecomp.Length;

        //        //Lo pasa a un array de 255 caracteres maximo por registro
        //        IEnumerable<string> listjsonstrcomp = SplitStr(jsonstrcomp, 255);
        //        string[] arrjsonstrcomp = listjsonstrcomp.Cast<string>().ToArray();

        //        //Verifica que el json comprimido sea igual que el array
        //        string arrSingleString = String.Join("", arrjsonstrcomp);

        //        if (jsonstrcomp.Length == arrSingleString.Length)
        //        {
        //            if (jsonstrcomp == arrSingleString)
        //            {

        //            }
        //            else
        //            {
        //                throw new Exception("El Listado de Libros de Rubrica no se comprimio correctamente");
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception("El Listado de Libros de Rubrica no se comprimio correctamente");
        //        }

        //        return arrjsonstrcomp;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //Decomprime el String y lo convierte a Json
        //public static string StringCompToJson(string libroscomp)
        //{
        //    int cantlibroscomp = libroscomp.Length;

        //    //Descomprime el Json
        //    string jsonstrdecomp = StringCompression.Unzip(libroscomp);
        //    int cantjsonstrdecomp = jsonstrdecomp.Length;

        //    //Convierte el Json en un Listado de Objetos
        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    Libros libros = new Libros();
        //    libros = serializer.Deserialize<Libros>(jsonstrdecomp);

        //    return jsonstrdecomp;

        //    //Prueba
        //    //string libro01 = @"H4sIAAAAAAAEAO29B2AcSZYlJi9tynt/SvVK1+B0oQiAYBMk2JBAEOzBiM3mkuwdaUcjKasqgcplVmVdZhZAzO2dvPfee++999577733ujudTif33/8/XGZkAWz2zkrayZ4hgKrIHz9+fB8/In7xR2Uxqavmo0ff+8UfFbNZNf3o0Ue7H40+kt++yBdVXWT4O1/S38cnb47Tp6fp07NXpydvvnx19mX64qsvTl99meKdZb3G23v39u9v7+CDc/5";
        //    //string libro02 = @"gZ/fu7t7dvZ29HXxUlWizu7tN///ol4xcr3u21+Npm6Vf1hfZskpneXo8WxTLomnrbFr8o3/r8hbI7HWR2XPI7EWR2dvbC5C5FyIDLJpsMSnz29DiXrf7e677e9Hu7927F3S/b7t/lV9g6BX1Tz/z5bTI3geV/S4q+w6V/Sgq+/v7ASr3LSqnTZvNeEZeF+1aJiN9mbV1saiWRVbeAp37XXTuO3TuR9G5f/9+gM6nEXRe5c26xB/NLVD4tIvCpw";
        //    //string libro03 = @"6FT+MU6UzOgwgKp5dVuRaK0F+WKFX6Im+rW2D1oIvVA4fVgyhWDx48CLA6iGD1rFz/tKB3nk/b4vI2mBx0MTlwmBxEMTk4OAgweWgxOVueV/VCOeWkWqzKfJEv2+x2KuVhF5OHDpOHUUwePnwYYLK7Y1FRopxU1D3JToPfmqosZrdkGwblY8MfCDa7O1FsdqhJgI3Tq0KYHFPj9NyzoplmZfGDW6s5Bhjg5JTublzp7nSU7q7Tug6nMj1ez4q2q";
        //    //string libro04 = @"tPTd21eL2/DNrtdnbvrdO5uXOfuUJNf8v1f8v8A48Vmg4MGAAA=";
        //    //string json = UsoGeneral.LibrosRubricados.StringCompToJson(libro01 + libro02 + libro03 + libro04);
        //}

        //public static Libros JsonToList()
        //{
        //    //Datos de Prueba en Json
        //    string jsonStrIni = @"{""libros"":[";
        //    string jsonStr1 = @"{""iddoc"":""1"",""doc"":""Memoria"",""den"":""ACTA DE DIRECTORIO NUMERO 1"",""nru"":""12345-01"",""fru"":""01/12/2020"",""fol"":""111-111""},";
        //    string jsonStr2 = @"{""iddoc"":""2"",""doc"":""Acta Organ de Administración"",""den"":""ACTA DE DIRECTORIO NUMERO 2"",""nru"":""12345-02"",""fru"":""02/12/2020"",""fol"":""111-222""},";
        //    string jsonStr3 = @"{""iddoc"":""3"",""doc"":""Acta de Asamblea"",""den"":""ACTA DE DIRECTORIO NUMERO 3"",""nru"":""12345-03"",""fru"":""03/12/2020"",""fol"":""111-333""},";
        //    string jsonStr4 = @"{""iddoc"":""4"",""doc"":""Registro Asistencia Asamblea"",""den"":""ACTA DE DIRECTORIO NUMERO 4"",""nru"":""12345-04"",""fru"":""04/12/2020"",""fol"":""111-444""},";
        //    string jsonStr5 = @"{""iddoc"":""5"",""doc"":""Estado de Situación Patrimonial"",""den"":""ACTA DE DIRECTORIO NUMERO 5"",""nru"":""12345-05"",""fru"":""05/12/2020"",""fol"":""111-555""},";
        //    string jsonStr6 = @"{""iddoc"":""6"",""doc"":""Estado de Resultados"",""den"":""ACTA DE DIRECTORIO NUMERO 6"",""nru"":""12345-06"",""fru"":""06/12/2020"",""fol"":""111-433""},";
        //    string jsonStr7 = @"{""iddoc"":""7"",""doc"":""Estado de Evolución de Patrimonio Neto"",""den"":""ACTA DE DIRECTORIO NUMERO 7"",""nru"":""12345-07"",""fru"":""07/12/2020"",""fol"":""111-777""},";
        //    string jsonStr8 = @"{""iddoc"":""8"",""doc"":""Estado de Flujo de Efectivo"",""den"":""ACTA DE DIRECTORIO NUMERO 8"",""nru"":""12345-08"",""fru"":""08/12/2020"",""fol"":""111-888""},";
        //    string jsonStr9 = @"{""iddoc"":""9"",""doc"":""Información Complementaria"",""den"":""ACTA DE DIRECTORIO NUMERO 9"",""nru"":""12345-09"",""fru"":""09/12/2020"",""fol"":""111-999""},";
        //    string jsonStr10 = @"{""iddoc"":""10"",""doc"":""Estado Contables Consolidados"",""den"":""ACTA DE DIRECTORIO NUMERO 10"",""nru"":""12345-10"",""fru"":""10/12/2020"",""fol"":""111-010""},";
        //    string jsonStr11 = @"{""iddoc"":""11"",""doc"":""Informe de Organo de Fiscalización"",""den"":""ACTA DE DIRECTORIO NUMERO 11"",""nru"":""12345-11"",""fru"":""11/12/2020"",""fol"":""111-011""},";
        //    string jsonStr12 = @"{""iddoc"":""12"",""doc"":""Informe del Auditor Externo"",""den"":""ACTA DE DIRECTORIO NUMERO 12"",""nru"":""12345-12"",""fru"":""12/12/2020"",""fol"":""111-012""}";
        //    string jsonStrFin = @"]}";

        //    //Meto todo el Json en un string
        //    string jsonstr = jsonStrIni + jsonStr1 + jsonStr2 + jsonStr3 + jsonStr4 + jsonStr5 + jsonStr6 + jsonStr7 + jsonStr8 + jsonStr9 + jsonStr10 + jsonStr11 + jsonStr12 + jsonStrFin;
        //    int cantjsonstr = jsonstr.Length;

        //    //Comprime el Json
        //    string jsonstrcomp = StringCompression.Zip(jsonstr);
        //    int cantjsonstrcomp = jsonstrcomp.Length;

        //    //Descomprime el Json
        //    string jsonstrdecomp = StringCompression.Unzip(jsonstrcomp);
        //    int cantjsonstrdecomp = jsonstrdecomp.Length;


        //    JavaScriptSerializer serializer = new JavaScriptSerializer();

        //    //List<Libros> libros = new List<Libros>();
        //    //libros = serializer.Deserialize<List<Libros>>(jsonstrdecomp);

        //    //List<Libro> libros = new List<Libro>();
        //    //libros = serializer.Deserialize<List<Libro>>(jsonstrdecomp);

        //    Libros libros = new Libros();
        //    libros = serializer.Deserialize<Libros>(jsonstrdecomp);

        //    return libros;


        //    //EntityDJ11 dj = new EntityDJ11();

        //    //int i = 1;

        //    //foreach (Libro lib in libros.libros)
        //    //{
        //    //    if (i <= 12)
        //    //    {
        //    //        //Carga por Reflection las propiedades del Libro

        //    //        //LIBDOCUMENTO
        //    //        PropertyInfo propdoc = dj.GetType().GetProperty("LIBDOCUMENTO_" + i.ToString("00"), BindingFlags.Public | BindingFlags.Instance);
        //    //        if (null != propdoc && propdoc.CanWrite)
        //    //        {
        //    //            propdoc.SetValue(dj, lib.doc, null);
        //    //        }

        //    //        //LIBDENOMINACION
        //    //        PropertyInfo propden = dj.GetType().GetProperty("LIBDENOMINACION_" + i.ToString("00"), BindingFlags.Public | BindingFlags.Instance);
        //    //        if (null != propden && propden.CanWrite)
        //    //        {
        //    //            propden.SetValue(dj, lib.den, null);
        //    //        }

        //    //        //LIBRUBRICA
        //    //        PropertyInfo proprub = dj.GetType().GetProperty("LIBRUBRICA_" + i.ToString("00"), BindingFlags.Public | BindingFlags.Instance);
        //    //        if (null != proprub && proprub.CanWrite)
        //    //        {
        //    //            proprub.SetValue(dj, lib.nru + " ; " + lib.fru, null);
        //    //        }

        //    //        //LIBFOLIOS
        //    //        PropertyInfo propf = dj.GetType().GetProperty("LIBFOLIOS_" + i.ToString("00"), BindingFlags.Public | BindingFlags.Instance);
        //    //        if (null != propf && propf.CanWrite)
        //    //        {
        //    //            propf.SetValue(dj, lib.fol, null);
        //    //        }

        //    //        i++;
        //    //    }
        //    //    else
        //    //    {
        //    //        break;
        //    //    }                
        //    //}

        //}
    }
}
