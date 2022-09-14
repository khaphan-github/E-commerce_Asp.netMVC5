using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class Promotion
    {
        public int PromotionId { get; set; }
        public string PromotionName { get; set; }
        public DateTime DateTime { get; set; }

        public virtual ICollection <Product > Products { get; set; }    

    }
}
