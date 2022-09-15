using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class AccountAdmin : Account
    {
        public float salary { get; set; }

        // Quan hệ  1 - 1 với bảng Position
        public virtual Position Position { get; set; }

        // Quan hệ 1 nhiều với promotion
        public virtual ICollection<Promotion> Promotions { get; set; }
    }
}
