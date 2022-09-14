using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal abstract class Account
    {
        public int id { get; set; }
        public string useName { get; set; }
        public string password { get; set; } 
        public string email { get; set; }
        public DateTime createdDate { get; set; }
        public int stateID { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string sex { get; set; }
        public string avata { get; set; }

        public virtual ICollection<AccountHaveRole> AccountRoles { get; set; }
        public virtual AccountState AccountState { get; set; }
    }
}
