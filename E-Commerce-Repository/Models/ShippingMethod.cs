using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class ShippingMethod
    {
        public int ShippingMethodId { get; set; }
        public string ShippingMethodName { get; set; }
        public string Desc { get; set; }
    }
}
