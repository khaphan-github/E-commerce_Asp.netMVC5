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
        private ProductRepository productRepository = new ProductRepository();
        private ProductComponentRepository productComponent = new ProductComponentRepository();
        public ActionResult Index(string searchString)
        {
            // HIển thị danh mục kèm hình ảnh dưới phần banner
            ViewData["CategoryPicture"] = null;
            // Danh mục sản phẩm
            ViewData["Category"] = productComponent.GetCategories();
            // Hiển thị sản phẩm nổi bậc
            ViewBag.TopProduct = productRepository.GetProducts();
            ViewData["TopProduct"] = productRepository.GetProducts();
            // Hiển thị sản phẩm bán chạy
            ViewData["BestSellerPeoduct"] = productRepository.GetProducts();

            ViewBag.SlideBarCategory = productComponent.GetCategories();
            ViewData["TypeProduct"] = productComponent.GetProductTypes();

            ViewBag.Brands = productComponent.GetCompanies();
            if(searchString != null)
            {
                return RedirectToAction("Index", "Shop", new { searchString = searchString });

            }
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