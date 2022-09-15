using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class ShoppingCardDetail
    {
        [Key]
        public int Id { get; set; }
        public int numberofProduct { get; set; }

        public virtual ShoppingCard ShoppingCard { get; set; }
        public virtual Product Product { get; set; }
    }
}
