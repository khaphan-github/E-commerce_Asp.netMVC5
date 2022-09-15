using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class Describe
    {
        [ForeignKey("Product")]
        public int DescribeId { get; set; }
        public string Description { get; set; }

        public virtual Product Product { get; set; }

    }
}
