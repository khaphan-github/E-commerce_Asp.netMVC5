using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class Account
    {

        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(130)]
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Avatar { get; set; }   
        public virtual AccountState AccountState { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
    }
}
