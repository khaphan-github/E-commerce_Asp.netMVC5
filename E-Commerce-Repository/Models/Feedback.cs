﻿using System;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Repository.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreadtedDate = DateTime.Now;
        public string Comment { get; set; }
        public int Ranking { get; set; }

        public AccountConsumer AccountConsumer { get; set; }
        public Product Product { get; set; }

    }
}
