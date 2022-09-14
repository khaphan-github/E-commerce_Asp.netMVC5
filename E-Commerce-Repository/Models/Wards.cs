using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class Wards
    {
        public int WardsId { get; set; }
        public string WardName { get; set; }

        public Address Address { get; set; }
        public ICollection <District> Districts { get; set; }

    }
}
