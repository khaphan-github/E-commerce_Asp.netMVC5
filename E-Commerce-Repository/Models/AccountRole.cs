using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace E_Commerce_Repository.Models
{
    public class AccountRole
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descibe { get; set; }

        public bool isActive = true;

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
