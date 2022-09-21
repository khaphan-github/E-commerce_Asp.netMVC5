using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using E_Commerce_Repository.Models;
using E_Commerce_Business_Logic.Shop;

namespace E_Commerce.Controllers
{
    public class ShopController : Controller
    {
        public ActionResult Index() {
            // LOAD SẢN PHẨM LÊN TRANG SHOP
            ShopComponent shopComponent = new ShopComponent();
            List<Product> products = new List<Product>();

            Product product = new Product();
            product.Id = 1;
            product.Name = "Iphone 14 ProMax";
            product.Price = 24000000;

            ProductImage productImage = new ProductImage();
            productImage.Id = 3;
            productImage.URL = "/assets/images/products/iphone14_promax.jpg";

            product.ProductImages.Add(productImage);

            products.Add(product);
            products.Add(product);
            ViewData["ShopProduct"] = products;

            return View();
        }
    }
}