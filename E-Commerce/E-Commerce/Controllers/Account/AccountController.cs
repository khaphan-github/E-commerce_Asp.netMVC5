using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
   [RequireHttps]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Signin()
        {
            return View();
        }
        
        
    }
}