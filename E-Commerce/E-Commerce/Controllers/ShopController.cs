using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Models;

namespace E_Commerce.Controllers
{
    public class ShopController : Controller
    {
        ECOMMERCEEntities db = new ECOMMERCEEntities();
        // GET: Product
        public ActionResult Index()
        {
            /*var items = db.Categories.Where(c => c.Parentid.ToString() == "be76f7ca-adcf-47b5-8556-72c794facca9").OrderBy(c => c.Name).ToList();
            var categories = items.Select(i => new List<string>
            {
                i.id.ToString(),
                i.Name,
                db.Product_Category.Where(p=>p.Categoryld == i.id).Count().ToString()
            }).ToList();
            ViewBag.Categories = categories;*/
            return View();
        }
        public ActionResult Products(List<Guid?> Categories, List<Guid?> Sizes, Guid? Color, List<Guid?> Brands,  decimal PriceFrom = 0, decimal PriceTo = 0, string OrderBy = "Date", int Page = 1)
        {
            int itemsPerPage = 6;
            var items = db.Products.ToList();
            if(Categories!= null)
            {
                items = items.Where(p => db.Product_Category.Where(c => Categories.Contains(c.Categoryld)).Select(c => c.Productld).ToList().Contains(p.id)).ToList();
            }

            if(Sizes != null)
            {
                items = items.Where(p => db.Product_Price.Where(c => Sizes.Contains(c.Sizeld)).Select(c => c.Productld).ToList().Contains(p.id)).ToList();
            }

            if (Color != null)
            {
                items = items.Where(p => db.Product_Price.Where(c =>c.Colorld == Color).Select(c=>c.Productld).Contains(p.id)).ToList();
            }

            if(Brands != null)
            {
                items = items.Where(p => Brands.Contains(p.Brandld)).ToList();
            }

            items = items.Where(p => db.Product_Price.Where(c => c.Price >= PriceFrom && c.Price <= PriceTo).Select(c => c.Productld).Contains(p.id)).ToList();
            switch (OrderBy)
            {
                case "Date":
                    items = items.OrderByDescending(p => p.CreatedDate).ToList();   
                    break;
                case "Rated":
                    break;
            }
            items = items.Skip((Page - 1)*itemsPerPage).Take(itemsPerPage).ToList();
            var products = items.Select(i => new List<string>
            {
                i.id.ToString(),
                i.Picture,
                String.Join(", ",db.Categories.Where( c=> db.Product_Category.Where ( d=>d.Productld == i.id).Select(d=>d.Categoryld).Contains(c.id)).Select(c=>c.Name).ToArray()),
                i.Name,
                i.Decription,
                String.Join(", ", db.Product_Price.Where(p=>p.Productld==i.id).Select(p=>p.Picture).ToArray()),
                db.Product_Price.Where(p=>p.Productld==i.id).Min(p=>p.Price).ToString(),
                db.Product_Voting.Where(p=>p.Productld==i.id).Count().ToString(),
                db.Product_Voting.Where(p=>p.Productld==i.id).Average(p=>p.Star).ToString(),
            });
            return new JsonResult() { Data = products, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
       
    }
}