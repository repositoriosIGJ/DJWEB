using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace DJEngine.UsoGeneral
{
    public static class CharacterTreat
    {
        //Verifica si la cadena es solo Alfanumerica sin caracteres especiales
        public static bool ValidarCadena(string cadena)
        {
            Regex RxAlpha = new Regex("^((([A-Za-z]|[0-9]+)|([0-9]|[A-Za-z]+))*)$");
            if (!RxAlpha.IsMatch(cadena))
            {
                return false;
            }

            return true;
        }

        //Convierte un string en Primera Letra a Mayuscula y despues todo miniscula
        public static string ConvertirPrimeraLetraMayuscula(string strWord, int Limpiar)
        {
            try
            {

                //Limpiar = 1 -- True  -- Limpia Caracteres Especiales
                //Limpiar = 0 -- False -- NO Limpia Caracteres Especiales
                if (Limpiar == 1)
                {
                    strWord = LimpiarCaracteres(strWord.Trim());
                }

                string[] arrWords = strWord.Split(' ');
                string strTemp2 = string.Empty;

                if (arrWords.Length > 1) //Existe mas de una palabra, Ej ANA MARIA
                {
                    int i = 0;

                    foreach (string strTemp in arrWords)
                    {
                        //Si es "DE" que lo deje en minuscula 
                        if (i > 0 && (strTemp == "DE" || strTemp == "LA" || strTemp == "LOS" || strTemp == "DEL" || strTemp == "EL"))
                        {
                            strTemp2 += strTemp.ToLower() + " ";
                        }
                        else
                        {
                            strTemp2 += strTemp.Substring(0, 1).ToUpper() + strTemp.Substring(1).ToLower() + " ";
                        }
                        i++;
                    }
                }
                else
                    strTemp2 = arrWords[0].Substring(0, 1).ToUpper() + arrWords[0].Substring(1).ToLower() + " ";

                return strTemp2.Substring(0, strTemp2.Length - 1);
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
                return strWord;
            }
        }

        //Limpia los caracteres especiales de una cadena
        public static string LimpiarCaracteres(string cadena)
        {
            string pattern = "([!@#$%^&*()?]|\"|\'|\\|(?:[.](?![a-zA-Z0-9]+$)))";
            Regex RxAlpha = new Regex(pattern);

            //Deja la cadena solo Alfanumerica sin caracteres especiales
            string cadenalimpia = RxAlpha.Replace(cadena, "");

            return cadenalimpia.Trim();
        }
    }
}
