using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class WarehouseProduct
    {
        public int ID { get; set; }
        public int Number { get; set; }

        public  Product Product { get; set; }
        public  Warehouse Warehouse { get; set; }
    }
}

