using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    [Table("Account")]
    public class Account
    {
        // Quan hệ nhiều nhiều với AccountRole
        public Account()
        {
            this.AccountRoles = new HashSet<AccountRole>();
        }

        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(256)]
        public string username { get; set; }

        [Required]
        [MaxLength(256)]
        public string password { get; set; }

        [MaxLength(256)]
        public string email { get; set; }

        public DateTime createdDate = DateTime.Now;

        [MaxLength(10)]
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string sex { get; set; }
        public string avatar { get; set; }

        // Account virtual đến AccountState quan hệ 1 - 1
        public virtual AccountState AccountState { get; set; }

        // Kéo khóa đến bảng AccountRole
        public virtual ICollection<AccountRole> AccountRoles { get; set; }

    }
}
