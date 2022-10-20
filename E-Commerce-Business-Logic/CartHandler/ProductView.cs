using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Business_Logic.CartHandler {
    public class ProductView {
        public int productId { get; set; }
        public string productName { get; set; }
        public List<ProductImage> productImages { get; set; }
        public float TotalPrice { get; set; }
        public float perItemsPrice { get; set; }
        public int numberItems { get; set; }
        public string Company { get; set; }
        public string typeProduct { get; set; }

        public ProductView(ShoppingCardDetail detail) {
            productId = detail.Product.Id;
            productName = detail.Product.Name;
            TotalPrice = detail.price;
            perItemsPrice = detail.Product.Price;
            typeProduct = detail.Product.TypeProduct.Name;
            Company = detail.Product.Company.Name;
            productImages = detail.Product.ProductImages.ToList();
            numberItems = detail.Number;
        }
    }
}