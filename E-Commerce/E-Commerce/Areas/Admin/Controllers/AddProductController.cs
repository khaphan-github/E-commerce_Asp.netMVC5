using E_Commerce_Business_Logic.RequestFilter;
using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Areas.Admin.Controllers
{
    [AuthorizationFilter(allowedRoles: new string[2] { Role.SystemAdmin, Role.Admin })]
    public class AddProductController : Controller {
        // GET: Admin/AddProduct
        public ActionResult Index()
        {
            return View();
        }

    }
}