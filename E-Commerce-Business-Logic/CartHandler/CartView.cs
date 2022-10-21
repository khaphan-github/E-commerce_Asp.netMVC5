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
            if (productView == null) {
                Products.Add(product);
            }
            totalprice = Products.Sum(prop => prop.TotalPrice*prop.numberItems);
        }
    }
}