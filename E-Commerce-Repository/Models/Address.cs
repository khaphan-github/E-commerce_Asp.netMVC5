using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }

        //  tỉnh
        public virtual Province Province { get; set; }
        //  huyện
        public virtual District District { get; set; }
        //  phường
        public virtual Wards Wards { get; set; }

        public Address()
        {
            this.Orders = new HashSet<Order>();
            this.AccountConsumers = new HashSet<AccountConsumer>();
            this.Warehouses = new HashSet<Warehouse>();
        }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<AccountConsumer> AccountConsumers { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }

    }
}
