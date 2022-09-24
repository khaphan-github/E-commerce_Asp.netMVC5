using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Repository.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Product()
        {
            this.ProductImages = new HashSet<ProductImage>();
            this.Warehouses = new HashSet<WarehouseProduct>();
            //   this.ShoppingCards = new HashSet<ShoppingCard>();
            // this.Orders = new HashSet<OrderDetail>();
   //         Feedbacks = new HashSet<Feedback>();
        }
       

        [ForeignKey ("TypeProduct")]
        public int? TypeProduct_ID { get; set; }
        public virtual TypeProduct TypeProduct { get; set; }

        [ForeignKey("Supplier")]
        public int? Supplier_ID { get; set; }
        public virtual Supplier Supplier { get; set; }

        [ForeignKey("Company")]
        public int? Company_ID { get; set; }
        public virtual Company Company { get; set; }

        [ForeignKey("Promotion")]
        public int? Promotion_ID { get; set; }
        public virtual Promotion Promotion { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }
       
        public virtual Describe Describe { get; set; }
    //    public virtual ICollection<Feedback> Feedbacks { get; set; }
        //   public virtual ICollection<OrderDetail> Orders { get; set; }
        public virtual ICollection<WarehouseProduct> Warehouses { get; set; }
        //   public virtual ICollection<ShoppingCard> ShoppingCards { get; set; }
    }
}
