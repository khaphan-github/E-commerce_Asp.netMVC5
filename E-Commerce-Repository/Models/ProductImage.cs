using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Repository.Models
{
    public class ProductImage
    {

        [Key]
        public int Id { get; set; }
        public string URL { get; set; }

        [ForeignKey("Product")]
        public int? Product_ID { get; set; }
        public virtual Product Product { get; set; }
    }
}