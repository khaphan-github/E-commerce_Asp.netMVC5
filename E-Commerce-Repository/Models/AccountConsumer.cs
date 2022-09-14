using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class AccountConsumer:Account
    {
        
        public ICollection <Order> Order { get; set; }
        public virtual  ICollection < Address> Address { get; set; }
        public virtual  BankingCard BankingCard { get; set; }
        public virtual ShoppingCard ShoppingCard { get; set; }
        public ICollection <Comment> Comment { get; set; }

    }
}
