using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class ShoppingCard
    {
        [ForeignKey("AccountConsumer")]
        public int Id { get; set; }
        public int Number { get; set; }
        public bool isEmpty { get; set; }
        public DateTime CreatedDate { get; set; }
        public float totalPrice { get; set; }
        public  virtual AccountConsumer AccountConsumer { get; set; }
        // QUan hệ nhiều nhiều với sản phẩm
        public virtual ICollection<Product> Products { get; set; }
        
    }
}
