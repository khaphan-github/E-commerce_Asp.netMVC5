using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class TypeProduct
    {
        [Key]
        public int id { get; set; }
        public string typeName { get; set; }
       

        // Quan hệ 1 nhiều với Category
        public int CategogyId { get; set; }
        public Category category { get; set; } 

        // QUan hệ 1 nhiều với sản phẩm
        public virtual ICollection<Product> Products { get; set; }
    }
}
