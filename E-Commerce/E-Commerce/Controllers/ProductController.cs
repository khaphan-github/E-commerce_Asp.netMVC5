using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
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
        private ProductRepository productRepository = new ProductRepository();
        private ProductComponentRepository productComponent = new ProductComponentRepository();
        public ActionResult Index(int id)
        {
            Product product = productRepository.getProductById(id);
            ViewData["Product"] = product;
            ViewData["RelatedProduct"] = product;
            ViewData["ProductList"] = productRepository.SearchProducts(product.TypeProduct.Name);
            ViewData["Describes"] = productComponent.GetDescribes(product.Id);
            return View();
        }

        
    }
}