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

        // Thêm sản phẩm vào giỏ hàng
        public void AddProductToCard(int productId, int cardId) 
        {
            var pc = from shoppingcards in repository.ShoppingCards
                     from products in repository.Products
                         //from shoppingcarddetail in repository.ShoppingCardsDetail
                     where products.Id == productId && products.ShoppingCardDetails == shoppingcards.ShoppingCardDetails
                           && shoppingcards.Id == cardId
                     select new { products, shoppingcards };
            repository.ShoppingCards.Add((ShoppingCard)pc);
            repository.SaveChanges();
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
            var p = repository.Products.Find(Id);
            repository.Products.Remove(p);
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
            var result = from product in repository.Products
                         where under < product.Price && product.Price < above
                         select product;
            /*foreach (var product in result)
                Console.WriteLine(product.ToString());*/
            return result.ToList();
        }
        // lọc sản phẩm theo ngôi sao
        public List<Product> FilterProduct(int rank)
        {
            var result = from product in repository.Products
                         from feedback in repository.Feedbacks
                         where feedback.Ranking == rank && feedback.Product == product.Feedbacks
                         select product;
            /*foreach (var product in result)
                Console.WriteLine(product.ToString());*/
            return result.ToList();
        }
        // Lấy sản phẩm theo Id
        public Product getProductById(int id)
        {
            /*var result = from product in repository.Products
                         where product.Id==id
                         select product;*/
            return (from product in repository.Products
                    where product.Id == id
                    select product).FirstOrDefault();
        }
        /*  Lấy danh sách sản phẩm của giõ hàng khách hàng
         *  Trả về sản phẩm (Product) và số lượng (int) */
        public Dictionary<Product, int> getProductInShoppingCard(AccountConsumer accountConsumer)
        {
            var shoppingcarddetails = new List<ShoppingCardDetail>();
            var result = from product in repository.Products
                         from shoppingcarddetail in shoppingcarddetails    /*?????????????*/
                         from shoppingcard in repository.ShoppingCards
                         let number= shoppingcard.Number
                         where shoppingcard.Id==shoppingcarddetail.ShoppingCard.Id && shoppingcarddetail.Product.Id==product.Id
                         select new {
                               product,
                               Number=number
                         };
            return (Dictionary<Product, int>)result;

        }

        // Lấy toàn bộ sản phẩm
        public List<Product> GetProducts() 
        {
            return repository.Products.OrderBy(p=>p.Id).ToList();
        }

        // Xóa sản phẩm khỏi giỏ hàng
        public void RemoveProductFromCard(int productId, int cardId) 
        {
            var pc = from shoppingcards in repository.ShoppingCards
                     from products in repository.Products
                     where shoppingcards.Id == cardId && shoppingcards.ShoppingCardDetails == products.ShoppingCardDetails
                           && products.Id == productId
                     select shoppingcards;
            repository.ShoppingCards.Remove((ShoppingCard)pc);
            repository.SaveChanges();
        }

        // Lấy sản phẩm có tên hoặc danh mục hoặc mô tả gần giống với searchString
        public List<Product> SearchProducts(string searchString)
        {
            var result = from product in repository.Products
                      //   from categoty in repository.Categorys
                         from typeproduct in repository.TypeProducts
                    //     from describe in repository.Describes
                         where 
                            (product.Name.Contains(searchString) || typeproduct.Name.Contains(searchString)) 
                            && typeproduct.Id==product.Id
                         //     || (categoty.Name.Contains(searchString) )
                         //     && categoty.TypeProducts==typeproduct.Category 
                         //      && typeproduct.Products==product.TypeProduct)
                         //      || (describe.Description.Contains(searchString) && describe.Product==product.Describe.Product)

                         select product;
            return result.ToList();
        }

        public void UpdateProduct(Product product)
        {
            repository.Products.Attach(product);
            repository.Entry(product).State = System.Data.Entity.EntityState.Modified;

            repository.SaveChanges();

        }

 
    }
}
