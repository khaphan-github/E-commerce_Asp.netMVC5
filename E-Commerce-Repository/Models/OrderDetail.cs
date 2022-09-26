using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class OrderDetail
    {
        public int Id { get; set; } 
        public int NumberofItems { get; set; }
        public float Price { get; set; }
        
    }
}
