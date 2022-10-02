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
            throw new System.NotImplementedException();
        }

        public void changeAccountState(int accountId, int StateId) {
            throw new System.NotImplementedException();
        }

        public void CreateAccount(AccountAdmin account) {
            throw new System.NotImplementedException();
        }

        public void CreateAccount(AccountConsumer account) {
            throw new System.NotImplementedException();
        }

        public void DeleteAccount(int id) {
            throw new System.NotImplementedException();
        }

        public void DeleteAccount(List<int> id) {
            throw new System.NotImplementedException();
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
