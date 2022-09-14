using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<TypeProduct> TypeProduct { get; set; }
    }
}
