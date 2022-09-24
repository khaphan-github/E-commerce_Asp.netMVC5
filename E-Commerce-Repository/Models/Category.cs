using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public Category()
        {
            this.Products = new HashSet<TypeProduct>();
        }
        // QUan hệ 1 nhiều với loại sản phẩm
        public virtual ICollection<TypeProduct> Products { get; set; }
    }
}
