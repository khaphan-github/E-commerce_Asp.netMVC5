using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce_Repository.Models;
using E_Commerce_Business_Logic.HomepageItems;
using E_Commerce_Business_Logic.Session;

namespace E_Commerce.Controllers
{
    public class ConsumerController : Controller
    {
        // GET: Consumer
        public ActionResult Index() {
            return View();
        }

        // Người dùng đăng nhập bằng username và password
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public void Login(string username, string password) {

            Login login = new Login();

            AccountConsumer account = login.ValidationAccount(username, password);

            System.Diagnostics.Debug.WriteLine(username);

            if (account != null) {
                Session.Add(SessionConstaint.USERSESION, account);
            }
            // hàm luuw data vô db

        }
        public void Logout() {
            Session.Clear();
        }
    }
}