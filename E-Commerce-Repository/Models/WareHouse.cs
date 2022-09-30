using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class Warehouse {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public virtual Address Addresses { get; set; }
        public virtual ICollection<WarehouseProduct> Products { get; set; }

        internal void Add(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
