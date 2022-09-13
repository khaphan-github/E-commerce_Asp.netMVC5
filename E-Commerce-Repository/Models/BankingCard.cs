using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class BankingCard
    {
        public int bankingCardId { get; set; }
        public string bankingCardName { get; set; }
        public string accountName { get; set; }
        public string accountNumber { get; set; }

    }
}
