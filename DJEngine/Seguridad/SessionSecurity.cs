using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// Summary description for SessionSecurity
/// </summary>
public class SessionSecurity
{
    public Boolean CheckSessionFixation()
    {
        // Checks de session cookies to avoid Session Fixation.            
        string SessionMacCookieValue;

        // Verifies that that the cookie "SessionMac" exists to assing "SessionMacCookieValue" a
        // null value, otherwise it assings the session value to that cookie.
        if (System.Web.HttpContext.Current.Request.Cookies["DJESessionMac"] == null)
        {
            SessionMacCookieValue = null;
        }
        else
        {
            //Pregunto si la SessionMac ya expiro
            if (System.Web.HttpContext.Current.Request.Cookies["DJESessionMac"].Expires < DateTime.Now)
            {
                //Le asigno null para volver a crearla
                SessionMacCookieValue = null;
            }
            else
            {
                //Le asigno el valor que tiene en la sesion
                SessionMacCookieValue = System.Web.HttpContext.Current.Request.Cookies["DJESessionMac"].Value;
            }
        }

        // If both are null then we create a hash code for the Session using a key in the current
        // webconfig file otherwise we compare the existing cookie with the current session.
        if (System.Web.HttpContext.Current.Session["key"] == null && SessionMacCookieValue == null)
        {
            System.Web.HttpContext.Current.Session["key"] = ConfigurationManager.AppSettings["SessionValidationKey"];

            // Creates the hash code.
            string hash = createHMASCHA1(Encoding.Unicode.GetBytes(System.Web.HttpContext.Current.Session.SessionID),
                                         Encoding.Unicode.GetBytes((string)System.Web.HttpContext.Current.Session["key"]));

            // Sets the hash code to the http cookie "SessionMac".
            HttpCookie SessionMac = new HttpCookie("DJESessionMac", hash);
            //SessionMac.Path = "/DJE/";
            //SessionMac.Path = HttpRequest.ApplicationPath;
            SessionMac.Expires = DateTime.Now.AddHours(5);
            // Adds the created cookie.
            System.Web.HttpContext.Current.Response.Cookies.Add(SessionMac);
            // Everything ok.
            return true;
        }
        else
        {
            //Cookie already exists.
            System.Web.HttpContext.Current.Session["key"] = ConfigurationManager.AppSettings["SessionValidationKey"];
            //Creates the hash code.
            string createdHash = createHMASCHA1(Encoding.Unicode.GetBytes(System.Web.HttpContext.Current.Session.SessionID),
                                                Encoding.Unicode.GetBytes((string)System.Web.HttpContext.Current.Session["key"]));

            //Checks if the cookie is different.
            if (createdHash != System.Web.HttpContext.Current.Request.Cookies["DJESessionMac"].Value)
                return false;
            else
                return true;
        }
    }

    private string createHMASCHA1(byte[] p1, byte[] key)
    {
        using (HMACSHA1 hmac = new HMACSHA1(key))
        {
            return Convert.ToBase64String(hmac.ComputeHash(p1));
        }
    }

    private bool CheckingClient()
    {
        //the two first octects of clients IP are taken
        //we try to assure that at least the request comes from
        //the same network even if its connected trough a proxy server.

        string[] userIpArray = System.Web.HttpContext.Current.Request.UserHostAddress.Split('.');
        string firstTwoOctets = userIpArray[0] + "." + userIpArray[1];

        if (System.Web.HttpContext.Current.Session["firstTwoOctets"] == null &&
            System.Web.HttpContext.Current.Session["userAgent"] == null)
        {
            System.Web.HttpContext.Current.Session["firstTwoOctets"] = firstTwoOctets;
            System.Web.HttpContext.Current.Session["userAgent"] = System.Web.HttpContext.Current.Request.UserAgent;
            return true;
        }
        else
        {
            if ((string)System.Web.HttpContext.Current.Session["firstTwoOctets"] != firstTwoOctets ||
                (string)System.Web.HttpContext.Current.Session["userAgent"] != System.Web.HttpContext.Current.Request.UserAgent)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
