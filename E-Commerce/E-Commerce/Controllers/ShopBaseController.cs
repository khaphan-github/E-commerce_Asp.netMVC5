using E_Commerce_Business_Logic.Session;
using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class ShopBaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filtercontext) {
            // Check session user
            bool noLogin = Session[SessionConstaint.USERSESION] as Account == null;

            bool noAuth = filtercontext.RouteData.Values["controller"].ToString() != "Login";

            System.Diagnostics.Debug.WriteLine(filtercontext.RouteData.Values["controller"].ToString());
            if (noLogin && noAuth) {
                filtercontext.Result = new RedirectResult("/Admin/Login/Index");
                System.Diagnostics.Debug.WriteLine("/Admin/Login/Index");
            }
            base.OnActionExecuting(filtercontext);
        }
    }
}