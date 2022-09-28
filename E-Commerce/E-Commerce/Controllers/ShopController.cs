using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using E_Commerce_Repository.Models;
using E_Commerce_Business_Logic.Shop;
using E_Commerce_Repository.Repository;
using E_Commerce_Repository.InitializationDB;

namespace E_Commerce.Controllers
{
    public class ShopController : Controller
    {
        private ProductRepository productRep = new ProductRepository();

        private ProductComponentRepository productRepository = new ProductComponentRepository();
        public ActionResult Index() {

            
            // Hiển thị danh mục sản phẩm
            ViewData["Category"] = productRepository.GetCategories();

            // Hiển thị Hảng sản suất;
            ViewData["Company"] = productRepository.GetCompanies();

            // Địa chỉ giao hàng 
            ViewData["SalePlance"] = null;

            System.Diagnostics.Debug.WriteLine("");

            ViewBag.Product = productRep.GetProducts();

            return View();
        }
    }
}