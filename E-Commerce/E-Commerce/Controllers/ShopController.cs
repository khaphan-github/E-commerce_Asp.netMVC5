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
        // Shop
        private readonly EcommerIntializationDB ecommerIntialization;
        public ShopController() {
            ecommerIntialization = new EcommerIntializationDB();
        }
        public ActionResult Index() {
          
            ShopComponent shopComponent = new ShopComponent();
            
            // Hiển thị danh mục sản phẩm
            ViewData["Category"] = null;

            // Hiển thị Hảng sản suất;
            ViewData["Company"] = shopComponent.CompanyList;

            // Địa chỉ giao hàng 
            ViewData["SalePlance"] = null;
            System.Diagnostics.Debug.WriteLine("");


            ProductRepository productRepository = new ProductRepository();
            ViewBag.Product = productRepository.GetProducts();


            return View();
        }
    }
}