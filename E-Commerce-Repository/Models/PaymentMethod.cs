using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentId { get; set; }
        public string PaymentName { get; set; }
        public string Desc { get; set; }

        // Quan hệ 1 nhiều với order
        public virtual ICollection<Order> Orders { get; set; }
    }
}
