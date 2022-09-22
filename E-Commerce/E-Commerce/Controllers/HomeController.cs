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
            // HIển thị danh mục kèm hình ảnh dưới phần banner
            ViewData["CategoryPicture"] = null;

            // Hiển thị sản phẩm nổi bậc
            ViewData["TopProduct"] = null;

            // Hiển thị sản phẩm bán chạy
            ViewData["BestSellerPeoduct"] = null;

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