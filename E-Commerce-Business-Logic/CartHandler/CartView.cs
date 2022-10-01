using System.Collections.Generic;
using System.Linq;

namespace E_Commerce_Business_Logic.CartHandler {
    public class CartView {
        public int cardId { get; set; }
        public List<ProductView> Products { get; set; }

        public float totalprice { get; set; }
        public CartView() {
            Products = new List<ProductView>();
        }
        public void AddproductToCard(ProductView product) {
            ProductView productView = Products.Where(prop => prop.productId == product.productId).FirstOrDefault();
            
            if (productView != null) {
                productView.numberItems += product.numberItems;
            }
            else {
                Products.Add(product);
            }
            totalprice += product.Price;
        }

        public void RemoveProductFromCard(int productId) {
            ProductView productView = Products.Where(prop => prop.productId == productId).FirstOrDefault();
            
            if (productView != null && productView.numberItems > 1) {
                productView.numberItems -= 1;
                totalprice -= productView.Price;
            }
            else {
                totalprice -= productView.Price;
                Products.Remove(productView);
            }
            
        }
    }
}