using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<WarehouseProduct> Warehouses { get; set; }
        public virtual ICollection<ShoppingCardDetail> ShoppingCardDetails { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }

        public int? TypeProductID { get; set; }
        public virtual TypeProduct TypeProduct { get; set; }
        public int? SupplierID { get; set; }
        public virtual Supplier Supplier { get; set; }
        public int? CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public int? DescribeID { get; set; }
        public virtual Describe Describe { get; set; }
        //public virtual ICollection<Describe> Describes { get; set; }/*---------------------*/
        public int? PromotionID { get; set; }
        public virtual Promotion Promotion { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}