using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Business_Logic.Shop {
    public class ShopComponent {
        public static ProductRepository productRepository = new ProductRepository();

        public static ProductComponentRepository productComponentRepository = new ProductComponentRepository();

        // Lấy toàn bộ sản phẩm
        public IEnumerable<Product> ProductList = productRepository.GetProducts();

        // Lấy danh mục sản phẩm;
        public List<Category> CategoryList = productComponentRepository.GetCategories();

        // Lấy hảng sản suất;
        public List<Company> CompanyList = productComponentRepository.GetCompanies();

        // Hiển thị địa chỉ giao hàng Khi login
        public Address AddressDelivery = null;


    }
}
