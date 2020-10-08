using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ApiWebClientes
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //Acordarse: cambiar por el del davinci
            AppDomain.CurrentDomain.SetData("DataDirectory", @"C:\Users\Jano\Desktop\Customer_Management\WEB\App_Data\");
        }
    }
}
