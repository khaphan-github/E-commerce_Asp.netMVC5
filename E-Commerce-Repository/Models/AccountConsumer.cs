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
            this.Feedbacks = new HashSet<Feedback>();
        }

        public virtual ICollection<Feedback> Feedbacks { get; set; }        
        public virtual ICollection<Address> Addresses { get; set; }

        [ForeignKey("BankingCard")]
        public int BankingCard_ID { get; set; }
        public virtual BankingCard BankingCard { get; set; }

        [ForeignKey("ShoppingCard")]
        public int ShoppingCar_ID { get; set; }
        public virtual ShoppingCard ShoppingCard { get; set; }

    }
}
