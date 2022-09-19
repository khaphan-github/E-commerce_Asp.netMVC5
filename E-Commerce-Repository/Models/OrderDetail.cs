using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class OrderDetail
    {
        [Key]
        public int NumberofItems { get; set; }
        public float Price { get; set; }


        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

        
    }
}
