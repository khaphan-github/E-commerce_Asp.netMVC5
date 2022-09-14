using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class Position
    {
        public  int PositionId { get; set; }
        public string PositionName { get; set; }
        public float BaseSalary { get; set; }

        public virtual AccountAdmin AccountAdmin { get; set; }
    }
}
