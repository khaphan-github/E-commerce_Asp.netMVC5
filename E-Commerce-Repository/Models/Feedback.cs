using System;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public DateTime creadtedDate = DateTime.Now;
        public string comment { get; set; }
        public int ranking { get; set; }

        // Quan hệ 1 1 với Consumer
        public int AccountConsumerId { get; set; }
        public AccountConsumer AccountConsumer { get; set; }
        // khách hành chỉ viết được 1 feedback trên 1 sản phẩm
        // Sản phẩm có nhiều feedback

        // QUan hệ 1 nhiều với sản phẩm
        public int productId { get; set; }
        public Product product { get; set; }

    }
}
