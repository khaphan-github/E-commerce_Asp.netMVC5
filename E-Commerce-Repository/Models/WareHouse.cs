
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class WareHouse
    {
        [Key]
        public int WareHouseId { get; set; }
        public string WareHouseName { get; set; }
        public string Status { get; set; }

        // QUan hệ nhiều nhiều với product
        public virtual ICollection<Product> Products { get; set; }
    }
}
