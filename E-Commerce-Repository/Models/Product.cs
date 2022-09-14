using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }

        public TypeProduct productType { get; set; }
        public virtual ICollection <Order> Orders { get; set; }
        public virtual ICollection<ShoppingCard> ShoppingCards { get; set; }
        public Supplier Supplier { get; set; }
        public Company Company { get; set; }
        public virtual ICollection <WareHouse> WareHouses { get; set; }
        public ICollection <ProductImage> ProductImages { get; set; }
        public virtual Describe Describe { get; set; }
        public virtual ICollection<Promotion> Promotion { get; set; }
        public ICollection <Review> Reviews { get; set; }

    }
}
