using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HttpModules
{
    public class SecurityModule : IHttpModule
    {
        public void Dispose()
        {
            //intentionally do nothing
        }

        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += new EventHandler(context_PreSendRequestHeaders);
        }

        private void context_PreSendRequestHeaders(object sender, EventArgs e)
        {
            var context = ((HttpApplication)sender).Context;
            context.Response.Headers.Set("Server", "Apache 2.0");
        }
    }
}
