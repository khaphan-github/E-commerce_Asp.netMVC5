using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class WareHouseDetail
    {
        public int NumberProduct { get; set; }

        public Product Product { get; set; }
        public Wards Wards { get; set; }

    }
}
