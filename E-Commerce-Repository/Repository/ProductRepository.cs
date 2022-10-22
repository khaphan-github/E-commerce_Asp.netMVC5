using E_Commerce_Repository.InitializationDB;
using E_Commerce_Repository.Models;
using E_Commerce_Repository.Service;
using PagedList;
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

            var productInShoppingCartDetail = repository.ShoppingCardDetails.FirstOrDefault(prop => prop.ProductID == productId);

            bool isExistProduct = productInShoppingCartDetail != null; 
            // nếu giỏ đã có sản phẩm thì thêm 1
            // nếu giỏ chưa có mới tạo
            if (isExistProduct) {
                productInShoppingCartDetail.Number += 1;
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
                repository.SaveChanges();
            }

            // Cập nhật tổng tiền
            var CartDetail = repository.ShoppingCardDetails.Where(prop => prop.ShoppingCardID == cardId).ToList();
            float totalPriceUpdateShopingCart = 0;

            // Chổ này chưa cập nhật tiền
            foreach (var item in CartDetail) {
                totalPriceUpdateShopingCart += item.Number * item.price;
            }

            cart.totalPrice = totalPriceUpdateShopingCart;
            System.Diagnostics.Debug.WriteLine("Add product to cart success");
            repository.SaveChanges();
        }

        // Xóa sản phẩm khỏi giỏ hàng
        public void RemoveProductFromCard(int productId, int cardId) {
            // 1 sản phẩm trong chi tiết sản phẩm
            var Detail = repository.ShoppingCardDetails
                                               .FirstOrDefault(prop => prop.ShoppingCardID == cardId && prop.ProductID == productId);

            var product = repository.Products.FirstOrDefault(prop => prop.Id == productId);

            var cart = repository.ShoppingCards.FirstOrDefault(prop => prop.Id == cardId);

            // chổ này xóa 1 lần hết sản phẩm đó luôn;
            if (Detail != null) {
                if(cart.totalPrice > 0) {
                    cart.totalPrice -= product.Price * Detail.Number;
                }
                repository.ShoppingCardDetails.Remove(Detail);
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
            return (from product in repository.Products
                    where product.Id == id
                    select product).FirstOrDefault();
        }
        /*  Lấy danh sách sản phẩm của giõ hàng khách hàng
         *  Trả về sản phẩm (Product) và số lượng (int) */
        public List<ShoppingCardDetail> getProductInShoppingCard(int shoppingCartId)
        {
            List<ShoppingCardDetail> result = 
                        ( from details in repository.ShoppingCardDetails
                          where details.ShoppingCard.Id == shoppingCartId
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
            try {
                var ShoppingCartDetails = repository.ShoppingCardDetails.Where(prop => prop.ShoppingCardID == id);
                if (ShoppingCartDetails != null) {
                    foreach (var item in ShoppingCartDetails) {
                        repository.ShoppingCardDetails.Remove(item);
                      
                    }
                }
                repository.SaveChanges();
                System.Diagnostics.Debug.WriteLine("XÓA CHI TIẾT THÀNH CÔNG");

            } catch (Exception) {

                throw;
            } 
        }

        public ShoppingCard getAccountShoppingCart(AccountConsumer accountConsumer) {
            ShoppingCard shoppingCard = repository.ShoppingCards.FirstOrDefault(prop => prop.AccountConsumerID == accountConsumer.Id);
            return shoppingCard;
        }

        public bool updateProductQuantityById(int id, int quantity, string type) {
            var productNeedToUpdate = repository.Products.FirstOrDefault(prop => prop.Id == id);
            try {
                if (productNeedToUpdate != null) {
                    switch (type) {
                        case "Add":
                            productNeedToUpdate.Quantity += quantity;
                            break;
                        case "Sub":
                            if (productNeedToUpdate.Quantity < quantity) {
                                return false;
                            }
                            productNeedToUpdate.Quantity -= quantity;
                            break;
                    }
                }

                repository.SaveChanges();
            } catch (Exception) {

                throw;
            }
            
            return true;
        }

        public void resetShoppingCart(int shoppingCardId) {
            try {
                var shoppingCartStoreInDB = repository.ShoppingCards.FirstOrDefault(prop => prop.Id == shoppingCardId);
                if (shoppingCartStoreInDB != null) {
                    shoppingCartStoreInDB.totalPrice = 0;
                    repository.SaveChanges();
                }
            } catch (Exception) {

                throw;
            }
            
        }

        public IEnumerable<Product> listProductInPage(int? page, int pageSize) {
            try {
              
                if (page == null) {
                    return repository.Products.OrderBy(p => p.Id).ToPagedList(1, pageSize);
                }
                int pg = page.Value;
                return repository.Products.OrderBy(p => p.Id).ToPagedList(pg, pageSize);
            } catch (Exception) {

                throw;
            }
        }

        public int numberOfProductStoreIndb() {
            return repository.Products.Count();
        }
    }
}
