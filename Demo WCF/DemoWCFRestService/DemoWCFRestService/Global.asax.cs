﻿using System;
using System.ServiceModel.Activation;
using System.Web.Routing;

namespace DemoWCFRestService
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute("", new WebServiceHostFactory(), typeof(PersonsService)));
        }
    }
}