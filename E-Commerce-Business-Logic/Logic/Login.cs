using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using MD5Hash;
namespace E_Commerce_Business_Logic.Logic {
    public class Login {
        public Account ValidationAccount(string username, string password) {
            AccountRepository accountRepository = new AccountRepository();
            string passwordHash = MD5Hash.Hash.Content(password);
            return accountRepository.validation(username, passwordHash);
        }
    }
}
