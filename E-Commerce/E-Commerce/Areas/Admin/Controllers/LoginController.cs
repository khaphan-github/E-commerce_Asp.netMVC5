using E_Commerce_Business_Logic.Logic;
using E_Commerce_Business_Logic.Session;
using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Areas.Admin.Controllers
{
    public class LoginController : BaseController {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string username, string password) {
            System.Diagnostics.Debug.WriteLine(username);
            System.Diagnostics.Debug.WriteLine(password);


            Login login = new Login();

            Account account = login.ValidationAccount(username, password);

            if (account != null) {
                System.Diagnostics.Debug.WriteLine("KHÔNG ĐĂNG NHẬP THÀNH CÔNG");
                Session[SessionConstaint.USERSESION] = account;
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Login");
        }
    }
}