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
            var product = repository.Products.FirstOrDefault(prop => prop.Id == productId);

            var cart = repository.ShoppingCards.FirstOrDefault(prop => prop.Id == cardId);

            var productInDetail = repository.ShoppingCardDetails.FirstOrDefault(prop => prop.ProductID == productId);

            bool isExistProduct = productInDetail != null; 
            // nếu giỏ đã có sản phẩm thì thêm 1
            // nếu giỏ chưa có mới tạo
            if (isExistProduct) {
                productInDetail.price = (productInDetail.Number + 1) * product.Price;
                productInDetail.Number += 1;
            }
            else {
                System.Diagnostics.Debug.WriteLine("Found Product and cart -> Add Product to cart");
                repository.ShoppingCardDetails.Add(new ShoppingCardDetail {
                    ShoppingCard = cart,
                    Product = product,
                    ProductID = productId,
                    ShoppingCardID = cardId,
                    Number = 1,
                    price = product.Price
                });
            }
            System.Diagnostics.Debug.WriteLine("Add product to cart success");
            repository.SaveChanges();
        }

        // Xóa sản phẩm khỏi giỏ hàng
        public void RemoveProductFromCard(int productId, int cardId) {
            var Detail = repository.ShoppingCardDetails
                                               .FirstOrDefault(prop => prop.ShoppingCardID == cardId && prop.ProductID == productId);
            var product = repository.Products.FirstOrDefault(prop => prop.Id == productId);
            if (Detail != null) {
                if (Detail.Number > 1) {
                    Detail.Number -= 1;
                    Detail.price = product.Price + Detail.Number;
                }
                else {
                    repository.ShoppingCardDetails.Remove(Detail);
                }
            }
            repository.SaveChanges();
            System.Diagnostics.Debug.WriteLine("REMOVE PRODUCT SUCCESSFULL");
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
        public List<ShoppingCardDetail> getProductInShoppingCard(AccountConsumer accountConsumer)
        {
            List<ShoppingCardDetail> result = 
                        ( from details in repository.ShoppingCardDetails
                          where details.ShoppingCard.Id == accountConsumer.ShoppingCards.Id
                          select details).ToList();
            return result;
        }

        // Lấy toàn bộ sản phẩm
        public List<Product> GetProducts() {
            return repository.Products.ToList();
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

        // delete by Shopping cart id
        public void DeleteCartDetailById(int id) {
            var ShoppingCartDetails = repository.ShoppingCardDetails.FirstOrDefault(prop => prop.ShoppingCardID == id);

            if (ShoppingCartDetails != null) {
                repository.ShoppingCardDetails.Remove(ShoppingCartDetails);
                repository.SaveChanges();
                System.Diagnostics.Debug.WriteLine("XÓA CHI TIẾT THÀNH CÔNG");

            }
        }
    }
}
