using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class BankingCard
    {
        public int BankingCardId { get; set; }
        public string BankingCardName { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }

        public virtual AccountConsumer AccountConsumer { get; set; }

    }
}
