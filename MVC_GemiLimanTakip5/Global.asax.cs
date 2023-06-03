using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC_GemiLimanTakip5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start(object sender,EventArgs e)
        {
            int onlineuyesayisi = Convert.ToInt32(Application["OnlineUyeSayisi"]);
            onlineuyesayisi = onlineuyesayisi + 1;
            Application["OnlineUyeSayisi"] = onlineuyesayisi;
        }
        protected void Session_End(object sender, EventArgs e)
        {
            int onlineuyesayisi = Convert.ToInt32(Application["OnlineUyeSayisi"]);
            onlineuyesayisi = onlineuyesayisi - 1;
            Application["OnlineUyeSayisi"] = onlineuyesayisi;
        }
    }
}
