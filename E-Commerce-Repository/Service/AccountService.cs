using E_Commerce_Repository.Models;
using System.Collections.Generic;

namespace E_Commerce_Repository.Service {
    interface AccountService {
        
        // CHỨC NĂNG QUẢN LÝ TÀI KHOẢN
      
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

    }
}
