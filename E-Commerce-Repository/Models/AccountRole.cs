using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    [Table("AccountRole")]
    public class AccountRole
    {
        // Quan hệ nhiều nhiều với Account
        public AccountRole()
        {
            this.Accounts = new HashSet<Account>();
        }

        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(30)]
        public string name { get; set; }
        [MaxLength(50)]
        public string descibe { get; set; }

        public bool isActive = true;

        // Khéo khóa đến bảng Account
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
