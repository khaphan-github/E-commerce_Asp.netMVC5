using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class ShopController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
    }
}