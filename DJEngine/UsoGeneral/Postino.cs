using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DJEngine.PostinoWS;

 public class Postino
{
    List<Parametro> _Parametros;

    public Postino()
    {
        _Parametros = new List<Parametro>();
    }

    public void AddParametro(string Nombre, string Valor)
    {

        Parametro p = new Parametro();
        p.Nombre = Nombre;
        p.Valor = Valor;
        _Parametros.Add(p);
    }

    public enum ETipoPlantilla
    {
        REINICIOPASS = 1,
        USUARIOBLOQUEADO = 2,
        CAMBIOPASSEXITOSO = 3,
        VALNUEVODD = 4,
        AVISONUEVODD = 5
    }

    public bool EnviarCorreo(DateTime FechaProgramada, string Remitente, string Asunto, string Destinatario, ETipoPlantilla Tipo)
    {
        try
        {
            //contrato que te devuelve el cliente
            PostinoWS aux = new PostinoWS();

            aux.EnviarCorreo(1, FechaProgramada.ToString("dd/MM/yyyy"), Remitente, Asunto, Destinatario, Convert.ToInt32(Tipo), _Parametros.ToArray());

            _Parametros.Clear();
            return true;
        }
        catch (InvalidOperationException ex)
        {
            throw ex;
            //TODO_EXCEPCIONES: Manejo de excepcion                
        }
    }
}
