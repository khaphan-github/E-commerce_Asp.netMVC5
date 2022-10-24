using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Service
{
    interface ProductService
    {
        // CHỨC NĂNG QUẢN LÝ SẢN PHẨM

        // Lấy sản phẩm theo Id
        Product getProductById(int id);
        // Lấy toàn bộ sản phẩmư
        List<Product> GetProducts();

        // Lây sản phẩm có tên hoặc danh mục hoặc mô tả gần giống với searchString
        List<Product> SearchProducts(string searchString);

        // Lọc sản phẩm có giá từ under đến above
        List<Product> FilterProduct(float under, float above);

        // lọc sản phẩm theo ngôi sao
        List<Product> FilterProduct(int rank);

        /*
         *  Lấy danh sách sản phẩm của giõ hàng khách hàng
         *  Trả về sản phẩm (Product) và số lượng (int)
         */
        ShoppingCard getAccountShoppingCart(AccountConsumer accountConsumer);
        List<ShoppingCardDetail> getProductInShoppingCard(int shoppingCartId);

        void resetShoppingCart(int shoppingCardId);

        // Thêm mới sản phẩm
        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        // Xóa sản phẩm theo Id;
        void DeleteProduct(int Id);

        // Xóa hàng hoạt sản phẩm theo id;
        void DeteteProduct(List<int> productId);

        // Thêm sản phẩm vào giỏ hàng
        void AddProductToCard(int productId, int cardId);

        // Xóa sản phẩm khỏi giỏ hàng
        void RemoveProductFromCard(int productId, int cardId);

        void DeleteCartDetailById(int id);

        bool updateProductQuantityById(int id, int quantity, string type);

        IEnumerable<Product> listProductInPage(int? page, int pageSize);

        int numberOfProductStoreIndb();
        IEnumerable<Product> getTopProducts(int top);
        IEnumerable<Product> getBestSellerProducts(int top);
    }
}
