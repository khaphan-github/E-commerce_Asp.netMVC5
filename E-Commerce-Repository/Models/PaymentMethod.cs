using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class PaymentMethod
    {
   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
