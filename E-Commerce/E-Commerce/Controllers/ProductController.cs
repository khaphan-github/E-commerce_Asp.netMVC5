using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product/Id
        public ActionResult Index(int id)
        {
            // Get prodcut by id
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
            product.ProductImages.Add(productImage2); 
            product.ProductImages.Add(productImage2);

            // Sản phẩm ID
            ViewData["Product"] = product;


            List<Product> products = new List<Product>();
          
            products.Add(product);
            products.Add(product); products.Add(product);
            products.Add(product); products.Add(product);
            products.Add(product);


            // Hiển thị sản phẩm liên quan;
            ViewData["RelatedProduct"] = products;
            return View();
        }
    }
}