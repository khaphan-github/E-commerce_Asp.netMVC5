using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Street { get; set; }

        // QUan hệ 1 -1 với Tỉnh
        public virtual Wards Wards { get; set; }
        // QUan hệ 1 -1 với Quận Huyện
        public virtual District District { get; set; }
       
        // QUan hệ 1 -1 với Phường Xã
        public virtual Province Province { get; set; }


        // Quan hệ 1 nhiều với order
        public virtual ICollection<Order> Orders { get; set; }
    }
}
