using E_Commerce_Business_Logic.Logic;
using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce_Business_Logic.Session;

namespace E_Commerce.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            // Hiển thị được tài dăng nhập vô 
            return View();
        }

       
    }
}