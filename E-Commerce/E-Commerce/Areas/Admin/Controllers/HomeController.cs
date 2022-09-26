using E_Commerce_Business_Logic.Logic;
using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            // Hiển thị được tài dăng nhập vô 

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password) {

            Login login = new Login();

            Account account = new AccountConsumer();

            account = login.ValidationAccount(username, password);

            if (account != null) {

                Session["AccountLogin"] = account;

                return RedirectToAction("Index", "Home");

            }

            return RedirectToAction("Index", "Home");
        }
    }
}