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
        public int Id { get; set; }
        public string Street { get; set; }
        public int? ProvinceID { get; set; }
        public virtual Province Province { get; set; }
        public int? DistrictID { get; set; }
        public virtual District District { get; set; }
        public int? WardsID { get; set; }
        public virtual Wards Wards { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<AccountConsumer> AccountConsumers { get; set; }
    }
}
