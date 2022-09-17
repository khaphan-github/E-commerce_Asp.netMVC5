﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class ShippingMethod
    {
        [Key]
        public int ShippingMethodId { get; set; }
        public string ShippingMethodName { get; set; }
        public string Desc { get; set; }

        // Quan hệ nhiều 1 với order
        public virtual ICollection<Order> Orders { get; set; }
        
    }
}