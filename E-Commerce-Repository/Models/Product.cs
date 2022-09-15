using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public decimal quantity { get; set; }

        internal TypeProduct productType { get; set; }

        // Quan hệ 1 nhiều với Order
        public virtual ICollection<Order> Orders { get; set; }

        // Quan hệ nhiều nhiều với Shopping card
        public virtual ICollection<ShoppingCard> ShoppingCards { get; set; }

        // Quan hệ 1 nhiều với typeproduct
        public int TypeProductId { get; set; }
        public TypeProduct TypeProduct { get; set; }

        // Quan hệ 1 nhiều với nhà cung cấp
        public int SupplierID { get; set; }
        public Supplier supplier { get; set; }

        // Quan hệ 1 nhiều với công ty
        public int CompanyID { get; set; }
        public Company company { get; set; }

        // Quan hệ nhiều nhiều với warehouse
        public virtual ICollection<WareHouse> WareHouses { get; set; }

        // QUan hệ 1 nhiều với product image
        public ICollection<ProductImage> productImages { get; set; }

        // Quan hệ 1 - 1 với mô tả
        public virtual Describe Describe { get; set; }

        // Quan hệ 1 nhiều với khuyến mãi
        public int promotionid { get; set; }
        public Promotion promotion { get; set; }

        // QUan hệ 1 nhiều với feed back
        public virtual ICollection<Feedback> Feedbacks { get; set; }

    }
}
