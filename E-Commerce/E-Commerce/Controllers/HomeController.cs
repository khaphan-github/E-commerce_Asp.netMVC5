using E_Commerce_Business_Logic.HomepageItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        // GET: Home Hiển thị trang chủ
        public ActionResult Index()
        {
            HomepageItemsView homepageItemsView = new HomepageItemsView();
            ViewData["Category"] = homepageItemsView.CategoryView();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult Contact()
        {
            return View();
        }

    }
}