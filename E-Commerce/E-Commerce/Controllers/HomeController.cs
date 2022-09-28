using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
   
    public class HomeController : Controller
    {
        // GET: Home Hiển thị trang chủ
        private ProductComponentRepository productComponent = new ProductComponentRepository();

        public ActionResult Index()
        {
            
            // HIển thị danh mục kèm hình ảnh dưới phần banner
            ViewData["CategoryPicture"] = null;
            // Danh mục sản phẩm
            ViewData["Category"] = productComponent.GetCategories();
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