using E_Commerce_Business_Logic.CartHandler;
using E_Commerce_Business_Logic.Session;
using E_Commerce_Repository.Models;

using E_Commerce_Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace E_Commerce_Business_Logic.PaymentMomo {
    public class HandleMomoResponse {
        public static string saveOrder() {

            OrderRepository orderRepository = new OrderRepository();
            ProductRepository productRepository = new ProductRepository();
            
            var currentUser = HttpContext.Current.Session[SessionConstaint.USERSESION] as AccountConsumer;
         
            List<ShoppingCardDetail> Details = productRepository.getProductInShoppingCard(currentUser);

            var createdDate = DateTime.Now;
            var totalPrice = Details.Sum(prop => prop.price);
            // THÊM ORDER 
            Order order = new Order() {
                Date = createdDate,
                AccountConsumerID = currentUser.Id, 
                PaymentMethodId = 1,
                TotalPrice = totalPrice,
                Address = currentUser.Addresses.FirstOrDefault(),
                
            };

            orderRepository.CreateOrder(order);

            var orderNew = orderRepository.getOrderByDateAndConsumerID(createdDate, currentUser.Id);

            foreach(ShoppingCardDetail shoppingCardDetail in Details) {

                OrderDetail orderDetail = new OrderDetail() {
                    OrderID = orderNew.Id,
                    ProductID = shoppingCardDetail.ProductID,
                    NumberofItems = shoppingCardDetail.Number,
                    Price = shoppingCardDetail.price,
                };

                orderRepository.SaveOrderDetail(orderDetail);
            }

            productRepository.DeleteCartDetailById(currentUser.Id);

            return "success";
        }
     }
}
