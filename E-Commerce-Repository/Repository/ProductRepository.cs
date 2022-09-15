using E_Commerce_Repository.InitializationDB;
using E_Commerce_Repository.Models;
using E_Commerce_Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Repository
{
    public class ProductRepository : ProductService
    {
        public EcommerIntializationDB repository = new EcommerIntializationDB();

        public int GetProducts()
        {
            return repository.Products.Count();
        }
    }
}
