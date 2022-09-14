using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ActiveType { get; set; }

        public ICollection <Product> Product { get; set; }
    }
}
