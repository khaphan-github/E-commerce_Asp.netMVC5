using E_Commerce_Business_Logic.RequestFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Areas.Admin.Controllers
{
    [AuthorizationFilter(allowedRoles: new string[2] { Role.SystemAdmin, Role.Admin })]
    public class BrandController : Controller
    {
        // GET: Admin/Brand
        public ActionResult Index()
        {
            return View();
        }
    }
}