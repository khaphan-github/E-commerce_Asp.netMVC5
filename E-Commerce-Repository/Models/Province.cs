using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class Province
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public string Domain { get; set; }

        public District District { get; set; }
    }
}
