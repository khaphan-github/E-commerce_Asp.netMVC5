using E_Commerce_Business_Logic.CartHandler;
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
            
            base.OnActionExecuting(filtercontext);
        }
    }
}