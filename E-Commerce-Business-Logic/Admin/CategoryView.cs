using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Business_Logic.Admin
{
    public class CategoryView
    {
        public List<Product> CategorysView()
        {
            // Get data from data base;

            List<Product> products = new List<Product>();
            Product product = new Product();
            product.Id = 1;
            product.Name = "Laptop";
            products.Add(product);
            products.Add(product);
            products.Add(product); products.Add(product); products.Add(product);

            return products;
        }

    }
}
