using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class ProductImage
    {

        [Key]
        public int ImageId { get; set; }
        public string URL { get; set; }

        public int productId { get; set;  }
        public Product product { get; set; }
    }
}
