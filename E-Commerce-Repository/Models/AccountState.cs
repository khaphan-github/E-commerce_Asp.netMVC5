using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class AccountState
    {
        public  int AccountStateId { get; set; }
        public string AccountName { get; set; }
        public virtual Account Account { get; set; }


    }
}
