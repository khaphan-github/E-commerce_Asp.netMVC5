using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Business_Logic.HomepageItems
{
    public class Login
    {
        // Basic login

        public AccountConsumer ValidationAccount(string username, string password) {
            AccountConsumer account = new AccountConsumer();

            account.Id = 1;
            account.Username = "admin";
            account.Password = "123";

            if (account.Username == username && account.Password == password) {
                return account;
            }
            return null;
        }

        // Google login https://console.cloud.google.com/apis/credentials?project=unique-shop-362016

    }
}
