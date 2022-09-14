using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderedDate { get; set; }
        public float TotalPrice { get; set; }

        public AccountConsumer AccountConsumer { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public virtual DeliverState DeliverState { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public ICollection <Product> Products { get; set; }

    }
}
