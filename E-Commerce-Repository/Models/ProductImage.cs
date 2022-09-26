using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public virtual Product Product { get; set; }
    }
}