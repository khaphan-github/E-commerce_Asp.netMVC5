using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models {
    public class CartView {
        public int cardId { get; set; }
        public List<ProductView> Products { get; set; }
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
        }

        public void RemoveProductFromCard(int productId) {
            ProductView productView = Products.Where(prop => prop.productId == productId).FirstOrDefault();
            
            if (productView != null && productView.numberItems > 1) {
                productView.numberItems -= 1;
            }
            else {
                Products.Remove(productView);
            }
        }
    }
}