using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce_Business_Logic.Session;
using E_Commerce_Repository.Models;

namespace E_Commerce.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
       protected override void OnActionExecuting(ActionExecutingContext filtercontext) {
            // Check session user
            bool noLogin = Session[SessionConstaint.USERSESION] as Account == null;

            bool noAuth = filtercontext.RouteData.Values["controller"].ToString() != "Login";

            System.Diagnostics.Debug.WriteLine(filtercontext.RouteData.Values["controller"].ToString());
            /* Nếu chưa login và controler không phải login -> Chuyển hướng đến trang login
               Nếu Chưa session và controller Login thì chuyển qua else
             */
            if (noLogin && noAuth) {
                filtercontext.Result = new RedirectResult("/Admin/Login/Index");
            }
            else {
            }
            base.OnActionExecuting(filtercontext);
        } 
    }
} 