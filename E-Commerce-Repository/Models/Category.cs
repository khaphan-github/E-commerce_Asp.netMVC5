using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string thumbImage { get; set; }
    }
}
