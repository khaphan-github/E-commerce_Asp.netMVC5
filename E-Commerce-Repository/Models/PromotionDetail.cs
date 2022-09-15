using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class PromotionDetail
    {
        public float Price { get; set; }

        public Product Product { get; set; }
        public Promotion Promotion { get; set; }

    }
}
