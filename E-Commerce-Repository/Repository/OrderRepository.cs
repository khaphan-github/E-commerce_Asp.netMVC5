using E_Commerce_Repository.InitializationDB;
using E_Commerce_Repository.Models;
using E_Commerce_Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Repository
{
    public class OrderRepository : OrderService
    {
        public EcommerIntializationDB repository = new EcommerIntializationDB();
        //Add order 
        public void CreateOrder(Order order)
        {
            repository.Orders.Add(order);
            repository.SaveChanges();
        }
        //Delete order theo id
        public void DeteteOrderById(int Id)
        {
            var or = repository.Orders.Find(Id);
            repository.Orders.Remove(or);
            repository.SaveChanges();

        }

        public Order getOrderByDateAndConsumerID(DateTime date, int Consumerid) {
            return repository.Orders.FirstOrDefault(prop => prop.Date == date && prop.AccountConsumerID == Consumerid);
        }

        //Lấy order theo id
        public Order getOrderById(int Id)
        {
            return (from order in repository.Orders
                    where order.Id == Id
                    select order).FirstOrDefault();
        }
        //Lấy toàn bộ danh sách order
        public List<Order> getOrders()
        {
            return (from order in repository.Orders
                    select order).ToList();
        }
        //Lấy danh sách order theo ngày
        public List<Order> getOrders(DateTime dateTime)
        {
            return (from order in repository.Orders
                    where order.Date == dateTime
                    select order).ToList();
        }
        //Lấy danh sách order từ ngày under đến above
        public List<Order> getOrders(DateTime under, DateTime above)
        {
            return (from order in repository.Orders
                    where order.Date > under && order.Date <above
                    select order).ToList();
        }
        //Lấy danh sách order theo status
        public List<Order> getOrders(string deliveryStatus)
        {
            return (from order in repository.Orders
                    from deliverstate in repository.DeliverStates
                    where deliverstate.Name == deliveryStatus && deliverstate.Orders == order.DeliverState
                    select order).ToList();
        }

        public List<Order> getOrders(AccountConsumer accountConsumer) {
            return repository.Orders.Where(prop => prop.AccountConsumerID == accountConsumer.Id).OrderBy(p => p.Date).ToList();
        }

        public PaymentMethod getPaymentMethodById(int id) {
            return repository.PaymentMethods.FirstOrDefault(prop => prop.Id == id);
        }

        public ShippingMethod getShippingMethodByDesc(string desc) {
            return repository.ShippingMethods.FirstOrDefault(prop => prop.Desc.Equals(desc));
        }

        public ShippingMethod getShippingMethodById(int id) {
            return repository.ShippingMethods.FirstOrDefault(prop => prop.Id == id);
        }

        public List<ShippingMethod> GetShippingMethods() {
            return repository.ShippingMethods.ToList();

        }

        public void SaveOrderDetail(OrderDetail orderDetail) {
            repository.OrderDetails.Add(orderDetail);
            repository.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            repository.Orders.Attach(order);
            repository.Entry(order).State = System.Data.Entity.EntityState.Modified;
            repository.SaveChanges();
        }

        //lấy 5 sản phẩm bán nhiều nhất
        
    }
}
