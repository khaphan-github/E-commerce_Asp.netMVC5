using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class AccountAdmin : Account
    {
        public float Salary { get; set; }

        public virtual Position Position { get; set; }
    }
}
