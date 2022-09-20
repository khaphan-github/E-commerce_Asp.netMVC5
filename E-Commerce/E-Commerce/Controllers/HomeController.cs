using E_Commerce_Business_Logic.HomepageItems;
using E_Commerce_Repository.Models;
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
            // Show category in search bar
            HomepageItemsView homepageItemsView = new HomepageItemsView();
            ViewData["CategorySearch"] = homepageItemsView.CategoryView();

            // Show shopping card when account login 
            ViewData["ShoppingCard"] = homepageItemsView.ShoppingCardsView(new AccountConsumer());

            return View();
        }

        public ActionResult SignIn()
        {
            
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