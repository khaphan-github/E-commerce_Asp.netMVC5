using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Repository.Models
{
    public class Position
    {
        [ForeignKey("AccountAdmin")]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string name { get; set; }
        public float baseSalary { get; set; }

        // Quan hệ 1 - 1 với bảng AccountAdmin
        public virtual AccountAdmin AccountAdmin { get; set; }
    }
}
