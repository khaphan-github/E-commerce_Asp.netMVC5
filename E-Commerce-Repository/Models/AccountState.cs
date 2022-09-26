using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Repository.Models
{
    public class AccountState
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(100)]
        public string Name { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
