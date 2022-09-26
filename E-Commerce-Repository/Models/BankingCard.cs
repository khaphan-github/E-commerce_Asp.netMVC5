using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class BankingCard
    {
        public int Id { get; set; }
        public string BankingCardName { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public AccountConsumer AccountConsumer { get; set; }

    }
}
