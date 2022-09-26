using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce_Business_Logic.Session;

namespace E_Commerce.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
       protected override void OnActionExecuting(ActionExecutingContext filtercontext) {
            // Check session user
            bool noLogin = Session[SessionConstaint.USERSESION] == null;
            bool noAuth = filtercontext.RouteData.Values["controller"].ToString() != "Login";

            if (noLogin && noAuth) {
                filtercontext.Result = new RedirectResult("/Admin/Login/Index");
            }
            
            base.OnActionExecuting(filtercontext);
        } 
    }
} 