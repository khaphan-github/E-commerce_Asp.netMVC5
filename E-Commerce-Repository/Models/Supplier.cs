using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace E_Commerce_Repository.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
