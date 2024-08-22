using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace DJEngine
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Validation.Iniciar();
            HttpContext.Current.Session["WorkFlow"] = 0;
            
            //HttpCookie cookie = (HttpCookie)HttpContext.Current.Response.Cookies["ASP.NET_SessionId"];
            //if (cookie.Path != "/DJE")
            //{
            //    //HttpCookie cookie = (HttpCookie)HttpContext.Current.Request.Cookies["ASP.NET_SessionId"];
            //    //cookie = (HttpCookie)HttpContext.Current.Request.Cookies("ASP.NET_SessionId");            
            //    cookie.Path = "/DJE";
            //    Response.Cookies.Remove("ASP.NET_SessionId");
            //    HttpContext.Current.Response.Cookies.Add(cookie);
            //}

            //Response.Cookies["ASP.NET_SessionId"].Path = "/DJE/";
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            //var app = (HttpApplication)sender;
            //var mapPath = Server.MapPath("/").Replace("\\", "/");

            ////var cookiePath = app.Request.ApplicationPath;
            //var cookiePath = mapPath;
            ////if (cookiePath.Length > 1) cookiePath += "/";
            ////if (cookiePath.Length == 1) cookiePath += "DJE/";
            //if (cookiePath.Length > 1) cookiePath += "";

            //foreach (string name in app.Response.Cookies.AllKeys)
            //{
            //    var cookie = app.Response.Cookies[name];
            //    cookie.Path = cookiePath;
            //}
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}