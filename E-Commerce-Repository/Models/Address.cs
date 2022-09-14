using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        
        public virtual ICollection <AccountConsumer> AccountConsumers { get; set; }
        public virtual Wards Wards { get; set; }
        public virtual District District { get; set; }
        public virtual Province Province { get; set; }
    }
}
