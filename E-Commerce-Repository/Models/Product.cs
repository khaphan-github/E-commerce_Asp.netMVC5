using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        
        public virtual ICollection<OrderDetail> Orders { get; set; }
        public virtual ICollection<WarehouseProduct> Warehouses { get; set; }
        public virtual ICollection<ShoppingCard> ShoppingCards { get; set; }
        public TypeProduct TypeProduct { get; set; }
        public Supplier Supplier { get; set; }
        public Company Company { get; set; }
       
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual Describe Describe { get; set; }
        public Promotion Promotion { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public Product() {
            this.TypeProduct = new TypeProduct();
            this.ProductImages = new HashSet<ProductImage>();
        }
    }
}
