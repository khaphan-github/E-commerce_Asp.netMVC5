using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class Describe
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Pin { get; set; }   
        public int? ProductID { get; set; }
        public virtual Product Product { get; set; }
        //public virtual ICollection<Product> Products { get; set; }/*------------------------*/
    }
}
