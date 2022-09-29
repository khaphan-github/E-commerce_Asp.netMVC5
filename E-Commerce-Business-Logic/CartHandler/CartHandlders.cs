using E_Commerce.Models;
using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Business_Logic.CartHandler {
    public class CartHandlders {

        public static CartView getCardViewSession(AccountConsumer account) {
            if (account != null) {
                ProductRepository repository = new ProductRepository();

                CartView cartView = new CartView();
                cartView.cardId = (int)account.ShoppingCardsId.Value;

                List<Product> dbProduct = repository.getProductInShoppingCard(account);

                foreach (Product product in dbProduct) {
                    ProductView productView = new ProductView() {
                        productId = product.Id,
                        productName = product.Name,
                        Price = product.Price,
                        typeProduct = product.TypeProduct.Name,
                        Company = product.Company.Name,
                        productImages = product.ProductImages.ToList(),
                        numberItems = 1
                    };
                    cartView.AddproductToCard(productView);
                }
                return cartView;
            }

            return null;
        }
    }
}
