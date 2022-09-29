using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public virtual Address Addresss { get; set; }
        // Quan hệ nhiều 1 với quận huyện
    }
}
