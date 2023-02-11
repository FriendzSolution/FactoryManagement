using FactoryManagement.WebUI.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FactoryManagement.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //GlobalFilters.Filters.Add(new AuthorizationFilter());
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }
    }
}
