using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int numberofItems { get; set; }
        public float price { get; set; }

        // Khóa ngoại với sản phẩm
        
        // Quan hệ 1 nhiều với order
        public virtual Order Order { get; set; }
        // QUan hệ 1 nhiều với product
        public virtual Product Product { get; set; }

        
    }
}
