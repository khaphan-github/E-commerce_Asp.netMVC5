using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class ShoppingCard
    {
        public int ShoppingId { get; set; }
        public int NumberOfItems { get; set; }
        public int IsEmpty { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual AccountConsumer AccountConsumer { get; set; }
        public virtual ICollection < Product> Product { get; set; }
    }
}
