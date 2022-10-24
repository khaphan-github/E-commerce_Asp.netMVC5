using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Service {
    interface AccountService {

        // CHỨC NĂNG QUẢN LÝ TÀI KHOẢN
        ShoppingCard getShoppingCartById(int id);
        Account getAccountById(int id);

        // Lấy toàn bộ account cả account admin và account user
        List<Account> getAccount();

        // Lấy tài khoản theo quyền
        List<Account> getAccount(string role);

        // Lấy tài khoản theo trạng thái của tài khoản
        List<Account> getAccountByStatus(string status);

        // Tạo mới account Admin
        void CreateAccount(AccountAdmin account);

        // Tạo mới account Consumer
        void CreateAccount(AccountConsumer account);

        void CreateAccount(Account account);

        void UpdateAccount(AccountAdmin account);
        void UpdateAccount(AccountConsumer account);

        // Xóa Acocunt
        void DeleteAccount(int id);

        void DeleteAccount(List<int> id);

        // Xác thực tài khoản pass word mã hóa MD5
        Account validation(string username, string password);
        void changeAccountState(int accountId, int StateId);

        // Thêm quyền cho account
        void addRoleToAccount(int accountId, int roleId);

        // Thu hồi quyền từ account
        void removeRoleFromAccount(int accountId, int roleId);

        // Quản lý trạng thái tài khoản

        bool isExistedAccount(string username);

        AccountRole findRoleByName(string roleName);


        void createCartForAccount(ShoppingCard shoppingCard);

        void createAddress(Address address);
    }
}
