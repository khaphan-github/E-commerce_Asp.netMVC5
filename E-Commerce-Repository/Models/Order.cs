﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float TotalPrice { get; set; }

        public virtual ShippingMethod ShippingMethod { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual Address Address { get; set; }
        public virtual DeliverState DeliverState { get; set; }
        public virtual AccountConsumer AccountConsumer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }

    }
}
