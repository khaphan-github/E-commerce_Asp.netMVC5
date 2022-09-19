using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class TypeProduct
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
       

        // Quan hệ 1 nhiều với Category
        public Category Category { get; set; } 

        // QUan hệ 1 nhiều với sản phẩm
        public virtual ICollection<Product> Products { get; set; }
    }
}
