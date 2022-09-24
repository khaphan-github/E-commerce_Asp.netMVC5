using E_Commerce_Repository.InitializationDB;
using E_Commerce_Repository.Models;
using E_Commerce_Repository.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Repository
{
    public class ProductRepository : ProductService
    {
        // Tạo kết nối và đối tượng đến db
        public EcommerIntializationDB repository = new EcommerIntializationDB();

        public void AddProductToCard(int productId, int cardId) {
            throw new NotImplementedException();
        }

        // Thêm mới sản phẩm
        public void CreateProduct(Product product)
        {
            repository.Products.Add(product);
            repository.SaveChanges();
        }
        // Xóa sản phẩm theo Id;
        public void DeleteProduct(int Id)
        {
            Product p = new Product();
            p.Id = Id;
            repository.Products.Remove(repository.Products.Find(p));
            repository.SaveChanges();
        }
        // Xóa hàng hoạt sản phẩm theo id;
        public void DeteteProduct(List<int> productId)
        {
            for (int i = 0; i < productId.Count; i++)
            {
                DeleteProduct(productId[i]);
            }
        }
        // Lọc sản phẩm có giá từ under đến above
        public List<Product> FilterProduct(float under, float above)
        {
            var products = new List<Product>();
            var result = from product in products
                         where under < product.Price && product.Price < above
                         select product;
            foreach (var product in result)
                Console.WriteLine(product.ToString());
            return (List<Product>)result;
        }
        // lọc sản phẩm theo ngôi sao
        public List<Product> FilterProduct(int rank)
        {
            /*           var products = new List<Product>();
                       var feedbacks = new List<Feedback>();
                       var result = from product in products
                                    from feedback in feedbacks
                                    where feedback.Ranking == rank && feedback.Product == product.Feedbacks
                                    select product;
                       foreach (var product in result)
                           Console.WriteLine(product.ToString());
                       return (List<Product>)result;
            */
            throw new NotImplementedException();
        }
        // Lấy sản phẩm theo Id
        public Product getProductById(int id)
        {
            var products = new List<Product>();
            var result = from product in products
                         where product.Id==id
                         select product;
            foreach (var product in result)
                Console.WriteLine(product.ToString());
            return (Product)result;
        }
        /*  Lấy danh sách sản phẩm của giõ hàng khách hàng
         *  Trả về sản phẩm (Product) và số lượng (int) */
        public Dictionary<Product, int> getProductInShoppingCard(AccountConsumer accountConsumer)
        {
            var products = new List<Product>();
            var shoppingcarddetails = new List<ShoppingCardDetail>();
            var shoppingcards = new List<ShoppingCard>();
            var result = from product in products
                         from shoppingcarddetail in shoppingcarddetails
                         from shoppingcard in shoppingcards
                         let number= shoppingcard.Number
                         where shoppingcard.Id==shoppingcarddetail.ShoppingCard.Id && shoppingcarddetail.Product.Id==product.Id
                         select new {
                               product,
                               Number=number
                         };
            foreach (var product in result)
            {
                Console.WriteLine(product.ToString());
                Console.WriteLine("{Number}");/*------------------??????????????*/
            }
            return (Dictionary<Product, int>)result;
        }
        // Lấy toàn bộ sản phẩm từ database á
        public List<Product> GetProducts()
        {
           /* var Product = (from Products in repository.Products
                          join TypeProducts in repository.TypeProducts
                          on Products.Id equals TypeProducts.Id
                          where Products.Id == TypeProducts.Id
                          select Products);
            List<Product> products = new List<Product>();
           */
          //  int item = repository.Products.Count();
         //   System.Diagnostics.Debug.WriteLine("");
            return repository.Products.ToList();
           // return repository.Products.Where(p=>p.Id==1).ToList();

        }

        public void RemoveProductFromCard(int productId, int cardId) {
            throw new NotImplementedException();
        }

        // Lấy sản phẩm có tên hoặc danh mục hoặc mô tả gần giống với searchString
        public List<Product> SearchProducts(string searchString)
        {
            var products = new List<Product>();
            var categotys = new List<Category>();
            var describes = new List<Describe>();
            var typeproducts = new List<TypeProduct>();
            var result = from product in products
                         from categoty in categotys
                         from typeproduct in typeproducts
                         from describe in describes
                         let search = searchString
                         where (product.Name == @"search") || (categoty.Name == @"search" && categoty.Products==typeproduct.Category && typeproduct.Products==product.TypeProduct)
                         || (describe.Description == @"search" && describe.Product==product.Describe.Product)
                         select product;
            return (List<Product>)result;
        }

        public void UpdateProduct(Product product)
        {
            repository.Entry(product).State = System.Data.Entity.EntityState.Modified;
            repository.Products.Attach(product);/*----------------------------------------??????????????*/
            repository.Categorys.Count();

        }

 
    }
}
