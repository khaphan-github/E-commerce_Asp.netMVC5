using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace E_Commerce_Repository.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public int Email { get; set; }

        // Nhà cung cấp quan hệ 1 nhiều với sản phẩm
        public virtual ICollection<Product> Products { get; set; }
    }
}
