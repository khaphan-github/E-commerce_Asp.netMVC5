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

        public void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeteteOrderById(int Id)
        {
            throw new NotImplementedException();
        }

        public Order getOrderById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Order> getOrders()
        {
            throw new NotImplementedException();
        }

        public List<Order> getOrders(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<Order> getOrders(DateTime under, DateTime above)
        {
            throw new NotImplementedException();
        }

        public List<Order> getOrders(string deliveryStatus)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
