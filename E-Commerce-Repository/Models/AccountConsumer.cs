using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class AccountConsumer : Account
    {
        public AccountConsumer()
        {
            this.Addresses = new HashSet<Address>();
            this.BankingCards = new HashSet<BankingCard>();
            this.Feedbacks = new HashSet<Feedback>();
        }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<BankingCard> BankingCards { get; set; }
        public virtual ShoppingCard ShoppingCard { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
