using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public  class Wards
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


        public Wards()
        {
            this.Addresss = new HashSet<Address>();

        }
        // QUan hệ 1 - 1 với Address
        public virtual ICollection<Address> Addresss { get; set; }
        public virtual District District { get; set; }
    }
}
