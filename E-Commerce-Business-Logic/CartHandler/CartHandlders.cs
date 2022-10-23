using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using System.Collections.Generic;
using System.Linq;
using E_Commerce_Business_Logic.Session;
using System.Web.Mvc;
using System.Web;

namespace E_Commerce_Business_Logic.CartHandler {
    public class CartHandlders {
       
        public static CartView getCardView(AccountConsumer account) {
            if (account != null) {
                ProductRepository repository = new ProductRepository();
                
                CartView cartView = new CartView();
                cartView.cardId = account.Id;

                List<ShoppingCardDetail> dbProduct = repository.getProductInShoppingCard(account.Id);

                foreach (ShoppingCardDetail detail in dbProduct) {
                    
                    ProductView productView = new ProductView(detail);

                    cartView.AddproductToCard(productView);
                }
                return cartView;
            }
            return null;
        }

        /* THÊM SẢN PHẨM VÀO GIỎ HÀNG:
         * 1. Lấy session giỏ hàng hiện tại -> Lấy thông tín sản phẩm muốn thêm vào giỏ hàng
         * 2. Thêm sản phẩm vào giỏ hàng hiển thị trên web -> lưu sản phẩm vào giỏ hàng trong db
         * 3. return message;
         *
         */
        public static string addProductToCart(int productId) {

            string message = "fail"; 

            ProductRepository productRepository = new ProductRepository();

            Product product = productRepository.getProductById(productId);

            var curentUser = HttpContext.Current.Session[SessionConstaint.USERSESION] as AccountConsumer;

            int cartID = curentUser.ShoppingCards.Id;

            if (product != null) {
                productRepository.AddProductToCard(productId, cartID);
                message = "success";
            }

            return message;
        }

        /* XÓA SẢN PHẨM KHỎI GIỎ HÀNG:
        * 1. Lấy session giỏ hàng hiện tại -> Lấy thông tín sản phẩm muốn thêm vào giỏ hàng
        * 2. Thêm sản phẩm vào giỏ hàng hiển thị trên web -> lưu sản phẩm vào giỏ hàng trong db
        * 3. return message;
        */
        public static string RemoveProductFromCart(int productId) {

            ProductRepository productRepository = new ProductRepository();

            var currentUser = HttpContext.Current.Session[SessionConstaint.USERSESION] as AccountConsumer;

            int cartID = currentUser.ShoppingCards.Id;

            productRepository.RemoveProductFromCard(productId, cartID);

            return "success";
        }
    }
}
