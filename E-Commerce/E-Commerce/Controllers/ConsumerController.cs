using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce_Repository.Models;
using E_Commerce_Business_Logic.HomepageItems;

namespace E_Commerce.Controllers
{
    public class ConsumerController : Controller
    {
        // GET: Consumer
        public ActionResult Index()
        {
            return View();
        }


        // Người dùng đăng nhập bằng username và password
       [HttpPost]
       [AllowAnonymous]
       [ValidateAntiForgeryToken]
       public void Login(string username, string password) {

            Login login = new Login();

            AccountConsumer account = login.ValidationAccount(username, password);

            if (account != null) {
                Session["AccountLogin"] = account;
            }
        }

        public ActionResult Logout() {
            Session.Clear();

            return View();
        }
    }
}