using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class AccountRole
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Name { get; set; }
<<<<<<< Updated upstream

        [MaxLength(50)]
        public string Descibe { get; set; }
        public bool isActive { get; set; }
        public virtual ICollection<Account> Account { get; set; }
=======
        
        public int Level { get; set; }
        public string Descibe { get; set; }
        public bool isActive { get; set; }
>>>>>>> Stashed changes
    }
}
