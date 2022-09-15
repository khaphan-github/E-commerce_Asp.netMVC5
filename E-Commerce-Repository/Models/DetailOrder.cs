using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class DetailOrder
    {
        public int NumberOfProduct { get; set; }
        public float Price { get; set; }

        public  Order Order { get; set; }
        public  Product Product { get; set; }
    }
}
