using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class PaymentMethod
    {
        public int PaymentId { get; set; }
        public string PaymentName { get; set; }
        public string Desc { get; set; }

        public ICollection  <Order> Order { get; set; }

    }
}
