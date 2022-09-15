using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class DeliverState
    {
        [Key]
        public int DeliverId { get; set; }
        public string DeliverName { get; set; }
        public int OrderNumber { get; set; }

        // QUan hệ 1 nhiều với order
        public virtual ICollection<Order> Orders { get; set; }
    }
}
