using E_Commerce_Business_Logic.Session;
using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Business_Logic.Payment {
    public class PaymentHandler {
        public static bool validatetionPaymentRequest(string amount, int paymentMethod, string shippingMethod) {

            float rightAmount;
            bool isRightAmount = float.TryParse(amount, out rightAmount);
            if (!isRightAmount) {
                return false;
            }

            OrderRepository orderRepository = new OrderRepository();
            var shippingMethodStoreInDb = orderRepository.getShippingMethodByDesc(shippingMethod);
            var paymentMethodStoreInDb = orderRepository.getPaymentMethodById(paymentMethod);

            if (shippingMethodStoreInDb == null || paymentMethodStoreInDb == null) {
                return false;
            }

            ProductRepository productRepository = new ProductRepository();
            AccountConsumer currentAccount = HttpContext.Current.Session[SessionConstaint.USERSESION] as AccountConsumer;
            if (currentAccount != null) {
                var currentAccountShoppingCard = productRepository.getAccountShoppingCart(currentAccount);
                if (currentAccountShoppingCard == null) {
                    return false;
                }
                else if(currentAccountShoppingCard.totalPrice != rightAmount + shippingMethodStoreInDb.Price) {
                    return false;
                }
            } 

            return true;
        }

        public static bool SaveOrder(string amount, int paymentMethod, string shippingMethod) {
            OrderRepository orderRepository = new OrderRepository();
            ProductRepository productRepository = new ProductRepository();
            var createdDate = DateTime.Now;

            var currentUser = HttpContext.Current.Session[SessionConstaint.USERSESION] as AccountConsumer;
            
            List<ShoppingCardDetail> Details = productRepository.getProductInShoppingCard(currentUser);

            var totalPrice = float.Parse(amount);
            var shippingmethod = orderRepository.getShippingMethodByDesc(shippingMethod);

            Order order = new Order() {
                Date = createdDate,
                AccountConsumerID = currentUser.Id,
                PaymentMethodId = paymentMethod,
                TotalPrice = totalPrice,
                AddressID = currentUser.Addresses.First().Id,
                ShippingMethodID = shippingmethod.Id,
                DeliverStateID = 4,
            };
            orderRepository.CreateOrder(order);

            var orderNew = orderRepository.getOrderByDateAndConsumerID(createdDate, currentUser.Id);

            foreach (ShoppingCardDetail shoppingCardDetail in Details) {

                OrderDetail orderDetail = new OrderDetail() {
                    OrderID = orderNew.Id,
                    ProductID = shoppingCardDetail.ProductID,
                    NumberofItems = shoppingCardDetail.Number,
                    Price = shoppingCardDetail.price,
                };

                bool isUpdatedProduct =
                productRepository.updateProductQuantityById(shoppingCardDetail.ProductID.Value, shoppingCardDetail.Number, "Sub");
                if (!isUpdatedProduct) {
                    throw new Exception();
                }
                orderRepository.SaveOrderDetail(orderDetail);
            }

            // return giá trong shopping cart;
            productRepository.resetShoppingCart(currentUser.ShoppingCards.Id);

            productRepository.DeleteCartDetailById(currentUser.ShoppingCards.Id);
            return true;
        }

    }
}
