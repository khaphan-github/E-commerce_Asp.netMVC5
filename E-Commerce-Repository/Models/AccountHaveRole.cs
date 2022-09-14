using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class AccountHaveRole
    {
        public Account Account { get; set; }
        public AccountRole AccountRole { get; set; }
    }
}
