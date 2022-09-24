using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Repository.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreadtedDate { get; set; }
        public string Comment { get; set; }
        public int Ranking { get; set; }

   //     public int? AccountConsumer_ID { get; set; }
   //     public virtual AccountConsumer AccountConsumer { get; set; }

        [ForeignKey("Product")]
        public int? Product_ID { get; set; }
        public  Product Product { get; set; }

    }
}
