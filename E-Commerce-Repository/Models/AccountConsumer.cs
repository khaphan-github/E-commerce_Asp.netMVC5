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
        // Quan hệ nhiều nhiều với địa chỉ
        public AccountConsumer()
        {
            this.Addresses = new HashSet<Address>();
        }
        public virtual ICollection<Address> Addresses { get; set; }

        // Quan hệ 1 nhiều với Banking Card; 
        public virtual ICollection<BankingCard> BankingCards { get; set; }

      

        // Quan hệ 1 - 1 với shopping card; 
        public virtual ShoppingCard ShoppingCard { get; set; }

        // Quan hệ 1 nhiều với feedback
        public virtual ICollection<Feedback> Feedbacks { get; set; }

    }
}
