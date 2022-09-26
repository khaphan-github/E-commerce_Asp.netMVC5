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
        public int Id { get; set; }
        public string Name { get; set; }

        // Quan hệ 1 - 1 với địa chỉ
        public virtual ICollection<Address> Addresss { get; set; }
        // Quan hệ 1 nhiều với phường xã
        public virtual Province Province { get; set; }
        public virtual ICollection<Wards> Wards { get; set; }

    }
}
