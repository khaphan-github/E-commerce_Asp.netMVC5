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
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<BankingCard> BankingCards { get; set; }
        public virtual ShoppingCard ShoppingCards { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
