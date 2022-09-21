using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public float PercentPromotion { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public AccountAdmin AccountAdmin { get; set; }

    }
}
