using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class DeliverState
    {
        public int DeliverId { get; set; }
        public string DeliverName { get; set; }
        public int OrderNumber { get; set; }
    }
}
