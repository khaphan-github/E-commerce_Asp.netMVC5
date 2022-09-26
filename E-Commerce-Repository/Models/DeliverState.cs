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
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderNumber { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
