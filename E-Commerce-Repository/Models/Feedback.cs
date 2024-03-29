﻿using System;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public DateTime CreadtedDate = DateTime.Now;
        public string Comment { get; set; }
        public int Ranking { get; set; }
        public int? AccountConsumerID { get; set; }
        public virtual AccountConsumer AccountConsumer { get; set; }
        public int? ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
