using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    // Phường xã
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
    

        // Quan hệ 1 - 1 với Địa chỉ
        public virtual Address Address { get; set; }

        // Quan hệ nhiều 1 với quận huyện
        public int DistrictID { get; set; }
        public District District { get; set; }

    }
}
