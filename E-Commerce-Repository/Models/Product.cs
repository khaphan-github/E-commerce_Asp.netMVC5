using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class Product
    {
        internal int id { get; set; }
        internal string name { get; set; }
        internal int price { get; set; }
        internal decimal quantity { get; set; }

        internal TypeProduct productType { get; set; }

    }
}
