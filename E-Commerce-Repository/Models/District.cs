using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    // Quận huyện
    public class District
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        // Quan hệ 1 - 1 với địa chỉ
        public virtual Address Address { get; set; }

        // Quan hệ nhiều - 1 với tỉnh thành phố
        public int WardID { get; set; }
        public Wards Wards { get; set;  }   

        // Quan hệ 1 nhiều với phường xã
        public virtual ICollection<Province> Provinces { get; set; }
     }
}
