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
        ProductRepository productRepository = new ProductRepository();
        public ActionResult Index(string searchString) {
          
            ShopComponent shopComponent = new ShopComponent();
            
            // Hiển thị danh mục sản phẩm
            ViewData["Category"] = null;

            // Hiển thị Hảng sản suất;
            ViewData["Company"] = shopComponent.CompanyList;

            // Địa chỉ giao hàng 
            ViewData["SalePlance"] = null;

            System.Diagnostics.Debug.WriteLine("");
            ViewBag.Product = productRepository.GetProducts();
            if (searchString!=null)
            {
                ViewBag.Product = productRepository.SearchProducts(searchString);
                return View();
            }
            return View( );
        }


    }
}