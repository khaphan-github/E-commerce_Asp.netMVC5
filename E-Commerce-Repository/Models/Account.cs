using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class Account
    {
        internal string useName { get; set; }
        internal string email { get; set; }
        internal int id { get; set; }
        internal string password { get; set; }  
        internal DateTime createdDate { get; set; }
        internal int stateID { get; set; }
        public string phone { get; set; }
        internal string address { get; set; }
        internal DateTime dateOfBirth { get; set; }
        internal string sex { get; set; }
        internal string avata { get; set; }

        internal AccountState accountState { get; set; }

    }
}
