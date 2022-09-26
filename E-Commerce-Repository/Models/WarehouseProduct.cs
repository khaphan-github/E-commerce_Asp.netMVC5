using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class WarehouseProduct
    {
        // Khóa ngoại đến product và warehouse
        public int ID { get; set; }
        public int numerItems { get; set; }

        public string status { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Warehouse> Warehouses { get; set; }


    }
}
