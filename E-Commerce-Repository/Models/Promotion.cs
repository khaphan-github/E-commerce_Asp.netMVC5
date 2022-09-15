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
        public string name { get; set; }
        public string desc { get; set; }

        public float percentPromotion { get; set; }
        public DateTime createdDate = DateTime.Now;

        // Quan hệ nhiều - 1 với product
        public virtual ICollection<Product> Products { get; set; }

        // quan hệ 1 nhiều với account
        public int AdminAccountId { get; set; }
        public AccountAdmin accountAdmin { get; set; }

    }
}
