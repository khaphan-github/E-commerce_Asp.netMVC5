using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class ShoppingCard
    {
        [Key]
        public int ShoppingId { get; set; }
        public int NumberOfItems { get; set; }
        public int IsEmpty { get; set; }
        public DateTime CreatedDate { get; set; }

        // Quan hệ 1 - 1 với AccountConsumer
        public virtual AccountConsumer AccountConsumer { get; set; }

        // QUan hệ nhiều nhiều với sản phẩm
        public virtual ICollection<Product> Products { get; set; }
        
    }
}
