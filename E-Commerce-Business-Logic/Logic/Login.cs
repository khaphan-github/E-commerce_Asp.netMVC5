using E_Commerce_Business_Logic.Session;
using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using MD5Hash;
using System;
using System.Web;

namespace E_Commerce_Business_Logic.Logic {
    public class Login {
        public Account ValidationAccount(string username, string password) {
            try {
                AccountRepository accountRepository = new AccountRepository();
                string passwordHash = MD5Hash.Hash.Content(password);
                return accountRepository.validation(username, passwordHash);

            } catch (System.Exception) {

            }
            return null;
        }

        public bool CreateAccount(string fullname, string username, string password, string Address) {
            AccountConsumer account = new AccountConsumer() {
                Username = username,
                DisplayName = fullname
            };

            AccountRepository accountRepository = new AccountRepository();

            if (accountRepository.isExistedAccount(account.Username)) {
                return false;
            }
          
            account.Password = MD5Hash.Hash.Content(password);
         
            account.CreatedDate = DateTime.Now;
            account.AccountStateId = 2;

            Address address = new Address { Street = Address };
            accountRepository.createAddress(address);
            accountRepository.CreateAccount(account);
            AccountConsumer newAc = ValidationAccount(account.Username, password) as AccountConsumer;

            ShoppingCard shoppingCard = new ShoppingCard() {
                Id = newAc.Id,
                AccountConsumerID = newAc.Id,
                Number = 0,
                totalPrice = 0,
                isEmpty = true,
                CreatedDate = DateTime.Now
            };

            accountRepository.createCartForAccount(shoppingCard);


            AccountRole accountRole = accountRepository.findRoleByName("User");

            accountRepository.addRoleToAccount(newAc.Id, accountRole.Id);

            HttpContext.Current.Session[SessionConstaint.USERSESION] = newAc;
            return true;

        }
    }
}
