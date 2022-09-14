using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class Review
    {
        public int ReviewId { get; set; }
        public DateTime DateTime { get; set; }

        public Product Product { get; set; }
    }
}
