using System;
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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        // Quan hệ nhiều 1 với order

        public ShippingMethod()
        {
            this.Orders = new HashSet<Order>();

        }
        public virtual ICollection<Order> Orders { get; set; }
        
    }
}
