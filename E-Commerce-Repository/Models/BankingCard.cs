using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class BankingCard
    {
        [Key]
        public int bankingCardId { get; set; }
        public string bankingCardName { get; set; }
        public string accountName { get; set; }
        public string accountNumber { get; set; }

        // Kết nối 2 đầu với Consumer từ bankingcard
        public int AccountConsumerID { get; set; }
        public AccountConsumer accountConsumer { get; set; }
    }
}
