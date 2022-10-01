using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using System.Collections.Generic;
using System.Linq;
using E_Commerce_Business_Logic.Session;
using System.Web.Mvc;
using System.Web;

namespace E_Commerce_Business_Logic.CartHandler {
    public class CartHandlders {

       
        public static CartView getCardViewSession(AccountConsumer account) {
            if (account != null) {
                ProductRepository repository = new ProductRepository();
                
                CartView cartView = new CartView();
                cartView.cardId = (int) account.ShoppingCardsId.Value;

                List<Product> dbProduct = repository.getProductInShoppingCard(account);

                foreach (Product product in dbProduct) {
                    ProductView productView = new ProductView(product);
                    cartView.AddproductToCard(productView);
                }
                return cartView;
            }
            return null;
        }
        // THÊM SẢN PHẨM VÀO GIỎ HÀNG
        public static string addProductToCart(int productId) {
            ProductRepository productRepository = new ProductRepository();

            CartView cartView = HttpContext.Current.Session[SessionConstaint.SHOPPINGCART] as CartView;
           
            Product product = productRepository.getProductById(productId);
            if (product != null) {
                cartView.AddproductToCard(new ProductView(product));
                HttpContext.Current.Session[SessionConstaint.SHOPPINGCART] = cartView;
            }
           
            return "success";
        }

        // XÓA SẢN PHẨM KHỎI GIỎ HÀNG
        public static string RemoveProductFromCart(int productId) {

            CartView cartView = HttpContext.Current.Session[SessionConstaint.SHOPPINGCART] as CartView;

            cartView.RemoveProductFromCard(productId);
            HttpContext.Current.Session[SessionConstaint.SHOPPINGCART] = cartView;

            return "success";
        }
    }
}
