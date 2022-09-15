using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Repository.Models
{
    public class AccountState
    {
        // Khóa ngoại với bảng account
        [ForeignKey("Account")]
        public int id { get; set; }
        public string name { get; set; }

        // Quan hệ 1 - 1 với account
        public virtual Account Account { get; set; }

    }
}
