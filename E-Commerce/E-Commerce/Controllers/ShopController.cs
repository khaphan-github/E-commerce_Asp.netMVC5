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
using E_Commerce_Business_Logic.RequestFilter;
using PagedList;

namespace E_Commerce.Controllers
{       
    public class ShopController : Controller
    {
        
        ProductRepository productRepository = new ProductRepository();
        ProductComponentRepository productComponentRepository = new ProductComponentRepository();
        ProductComponentRepository productRepository = new ProductComponentRepository();
    
        ProductRepository product = new ProductRepository();
        public ActionResult Index(int page,string searchString) {

            ViewData["Category"] = productRepository.GetCategories();
            ViewData["Company"] = productRepository.GetCompanies();

            ViewData["SalePlance"] = null;

            ViewBag.NumberOfPage = product.numberOfProductStoreIndb() / 40;

            if (page < 1 || page > ViewBag.NumberOfPage) page = 1;

            ViewBag.CurrentPage = page;
            
            ViewBag.Product = product.listProductInPage(page, 40);

            if (searchString!=null)
            {
                ViewBag.Product = product.SearchProducts(searchString);
                return View();
            }

            return View();
        }
    }
}