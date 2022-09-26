using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class ShoppingCardDetail
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public float price { get; set; }
    }
}
