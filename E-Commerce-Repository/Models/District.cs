using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class District
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }

        public Wards Wards { get; set; }
        public ICollection<Province> Provinces { get; set; }
    }
}
