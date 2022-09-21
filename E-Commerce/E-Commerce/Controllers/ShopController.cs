﻿using System;
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

            ProductImage productImage1 = new ProductImage();
            productImage1.Id = 3;
            productImage1.URL = "/assets/images/products/iphone14_promax.jpg";
            product.ProductImages.Add(productImage1);
            ProductImage productImage2 = new ProductImage();

            productImage2.Id = 4;
            productImage2.URL = "/assets/images/products/iphone14_promaxblack.png";
            product.ProductImages.Add(productImage2);

            products.Add(product);
            products.Add(product);
            products.Add(product);
            products.Add(product); products.Add(product);
            products.Add(product); products.Add(product);
            products.Add(product);
            ViewData["ShopProduct"] = products;

            return View();
        }
    }
}