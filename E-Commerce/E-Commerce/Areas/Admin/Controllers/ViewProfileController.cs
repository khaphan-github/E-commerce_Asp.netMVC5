using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Areas.Admin.Controllers
{
    public class ViewProfileController : Controller
    {
        // GET: Admin/ViewProfile
        public ActionResult Index()
        {
            return View();
        }
    }
}