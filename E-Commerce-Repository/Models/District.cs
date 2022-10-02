using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
       
        // Quan hệ 1 nhiều với phường xã
        public virtual Address Address { get; set; }
      
    }
}
