using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public virtual ICollection<Address> Addresss { get; set; }
        // Quan hệ nhiều 1 với quận huyện
        public virtual ICollection<District> Districts { get; set; }
    }
}
