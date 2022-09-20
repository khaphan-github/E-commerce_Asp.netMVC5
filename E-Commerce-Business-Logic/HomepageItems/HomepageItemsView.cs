using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Business_Logic.HomepageItems
{
    public class HomepageItemsView
    {
        public List<Category> CategoryView()
        {
           // Get data from data base;

            List<Category> categories = new List<Category>();
            Category category = new Category();
            category.Id = 1;
            category.Name = "Máy tính";
            categories.Add(category);
            categories.Add(category); 
            categories.Add(category); categories.Add(category); categories.Add(category);

            return categories;
        }

        // Return product in shopping card of Account
        public List<Product> ShoppingCardsView(AccountConsumer accountConsumer) {

            List<Product> products = new List<Product>();

            AccountAdmin account = new AccountAdmin();
            account.Id = 1;
            account.Username = "admin";
            account.Password = "123";
            //  products = accountConsumer.ShoppingCard.Products.ToList();
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

            return products;
        }
    }
}
