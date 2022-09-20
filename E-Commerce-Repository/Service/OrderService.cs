using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Service {
    interface OrderService {

        // CHỨC NĂNG QUẢN LÝ ORDER
        // Lấy sản phẩm theo ID
        Order getOrderById(int Id);

        List<Order> getOrders();
        List<Order> getOrders(DateTime dateTime);

        // Lấy đơn hàng từ ngày này với ngày kia
        List<Order> getOrders(DateTime under, DateTime  above);

        // Lấy đơn hàng theo trạng thái giao hàng
        List<Order> getOrders(string deliveryStatus);

        void CreateOrder(Order order);

        void UpdateOrder(Order order);

        void DeteteOrderById(int Id);




    }
}
