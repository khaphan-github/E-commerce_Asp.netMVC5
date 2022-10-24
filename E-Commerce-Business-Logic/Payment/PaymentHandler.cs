using E_Commerce_Business_Logic.Session;
using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Business_Logic.Payment {
    public class PaymentHandler {
        public static bool validatetionPaymentRequest(string amount, int paymentMethodID, string shippingMethodDesc) {
            try {
                float rightAmount;
                bool isRightAmount = float.TryParse(amount, out rightAmount);
                if (!isRightAmount) {
                    return false;
                }
                if(rightAmount <= 0) {
                    return false;
                }

                OrderRepository orderRepository = new OrderRepository();

                var shippingMethodStoreInDb = orderRepository.getShippingMethodByDesc(shippingMethodDesc);
                var paymentMethodStoreInDb = orderRepository.getPaymentMethodById(paymentMethodID);

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
                    else if (rightAmount != currentAccountShoppingCard.totalPrice + shippingMethodStoreInDb.Price) {
                        return false;
                    }
                }

                return true;
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
           
        }

        public static bool SaveOrder(string amount, int paymentMethod, string shippingMethod) {
            try {
                OrderRepository orderRepository = new OrderRepository();
                ProductRepository productRepository = new ProductRepository();

                var currentUser = HttpContext.Current.Session[SessionConstaint.USERSESION] as AccountConsumer;

                List<ShoppingCardDetail> Details = productRepository.getProductInShoppingCard(currentUser.Id);

                var totalPrice = float.Parse(amount);
                var createdDate = DateTime.Now;
                var shippingmethod = orderRepository.getShippingMethodByDesc(shippingMethod);
                const int WaitingForAccept = 4;

                Order order = new Order() {
                    Date = createdDate,
                    AccountConsumerID = currentUser.Id,
                    PaymentMethodId = paymentMethod,
                    TotalPrice = totalPrice,
                    AddressID = currentUser.Addresses.First().Id,
                    ShippingMethodID = shippingmethod.Id,
                    DeliverStateID = WaitingForAccept,
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
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
            
        }

    }
}
