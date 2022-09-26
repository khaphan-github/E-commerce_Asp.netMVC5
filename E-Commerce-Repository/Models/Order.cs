using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float TotalPrice { get; set; }

    }
}
