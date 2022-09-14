using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class TypeProduct
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        
        public ICollection<Product> Products { get; set; }
        public Category Category { get; set; }

        
    }
}
