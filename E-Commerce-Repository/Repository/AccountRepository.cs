using System.Linq;
using E_Commerce_Repository.Models;
using E_Commerce_Repository.Service;
using E_Commerce_Repository.InitializationDB;

using System.Collections.Generic;
using System;

namespace E_Commerce_Repository.Repository {
    public class AccountRepository : AccountService {

        private EcommerIntializationDB repository = new EcommerIntializationDB();
        public void addRoleToAccount(int accountId, int roleId) {
            var Role = repository.AccountRoles.FirstOrDefault(prop => prop.Id == roleId);
            var Account = repository.Accounts.FirstOrDefault(prop => prop.Id == accountId);
            if(Role != null && Account != null) {
                Role.Account.Add(Account);
                repository.SaveChanges();
            }
        }

        public ShoppingCard getShoppingCartById(int id) {
            return repository.ShoppingCards.FirstOrDefault(prop => prop.AccountConsumerID == id);
        }
        public void changeAccountState(int accountId, int StateId) {
            throw new System.NotImplementedException();
        }

        public void CreateAccount(AccountAdmin account) {
            
        }
        
        public void CreateAccount(AccountConsumer account) {
            try {
                repository.Accounts.Add(account);
                repository.SaveChanges();
            } catch (Exception) {

                throw;
            }
        }

        public void CreateAccount(Account account) {
            try {
                repository.Accounts.Add(account);
                repository.SaveChanges();
            } catch (Exception) {
            }
        }

        public void createAddress(Address address) {
            
            try {
                repository.Addresses.Add(address);
                repository.SaveChanges();
            } catch (Exception) {
                
                throw;
            }
        }

        public void createCartForAccount(ShoppingCard shoppingCard) {
            try {
                repository.ShoppingCards.Add(shoppingCard);
                repository.SaveChanges();
            } catch (Exception) {

                throw;
            }
        }

        public void DeleteAccount(int id) {
            throw new System.NotImplementedException();
        }

        public void DeleteAccount(List<int> id) {
            throw new System.NotImplementedException();
        }

        public AccountRole findRoleByName(string roleName) {
            return repository.AccountRoles.FirstOrDefault(prop => prop.Name == roleName);
        }

        public List<Account> getAccount() {
            throw new System.NotImplementedException();
        }

        public List<Account> getAccount(string role) {
            throw new System.NotImplementedException();
        }

        public Account getAccountById(int id) {
            return repository.Accounts.Where(prop => prop.Id == id).FirstOrDefault();
        }

        public List<Account> getAccountByStatus(string status) {
            throw new System.NotImplementedException();
        }

        public bool isExistedAccount(string username) {
            return repository.Accounts.Any(prop => prop.Username.Equals(username));
        }

        public void removeRoleFromAccount(int accountId, int roleId) {
            throw new System.NotImplementedException();
        }

        public void UpdateAccount(AccountAdmin account) {
            throw new System.NotImplementedException();
        }

        public void UpdateAccount(AccountConsumer account) {
            throw new System.NotImplementedException();
        }

        public Account validation(string username, string password) {
            return repository.Accounts.Where(account => account.Username == username && account.Password == password).FirstOrDefault();
        }
    }
}
