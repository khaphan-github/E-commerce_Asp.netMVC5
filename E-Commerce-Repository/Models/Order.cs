using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }
        public DateTime orderedDate { get; set; }
        public float totalPrice { get; set; }

        // QUan hệ 1 1 với phương thức vận chuyển
        public int shippingMethodId { get; set; }
        public virtual ShippingMethod ShippingMethod { get; set; }

        // QUan hệ 1 1 với phương thức thanh toán
        public int PaymentMethodID { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        // Quan hệ 1 1 với địa chỉ giao hàng địa 

        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
        // Quan hệ 1 1 với trạng thái giao hàng

        public int DeliverStateID { get; set; }
        public virtual DeliverState DeliverState { get; set; }
        // QUan hệ 1 1 với consumer account 
        public virtual AccountConsumer AccountConsumer { get; set; }

        // Quan hệ 1 nhiều với Product
        public virtual ICollection<Product> Products { get; set; }

    }
}
