using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class ProductImage
    {

        [Key]
        public int Id { get; set; }
        public string URL { get; set; }

        public Product Product { get; set; }
    }
}
