using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Mvc;

namespace Company.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        //when application starts it comes here to configure and register
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //register all areas to help page in web api
            AreaRegistration.RegisterAllAreas();
        }

        protected void Application_BeginRequest()
        {
            //PreFlight Request
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                Response.Flush();
            }
        }
        //authenticate
        //authorize
        //handler
        //endrequest
    }
}
