using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using E_Commerce_Business_Logic.Session;

namespace E_Commerce
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start() {
            // Khởi tạo session user khi web khởi động
            Session[SessionConstaint.USERSESION] = "";
        }

       
        
        
    }
}
