using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class AccountRole
    {
        public int AccountRoleId { get; set; }
        public string AccountRoleName { get; set; }
        public string Descibe { get; set; }
        public bool IsActive { get; set; }
        
        public virtual ICollection<AccountHaveRole> Accounts { get; set; }

        
    }
}
