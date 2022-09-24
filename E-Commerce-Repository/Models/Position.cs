using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Repository.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float BaseSalary { get; set; }


        public Position()
        {
            this.AccountAdmins = new HashSet<AccountAdmin>();

        }
        public virtual ICollection<AccountAdmin> AccountAdmins { get; set; }
    }
}
