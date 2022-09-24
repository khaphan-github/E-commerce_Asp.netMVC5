using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Business_Logic.Shop {
    public class ShopComponent 
    {
        public static ProductRepository productRepository = new ProductRepository();

        public List<Product> ProductList = productRepository.GetProducts();
    }
}
