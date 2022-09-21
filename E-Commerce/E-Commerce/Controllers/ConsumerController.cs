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

       [HttpPost]
       [AllowAnonymous]
       [ValidateAntiForgeryToken]
       public ActionResult Login(string username, string password) {
            Login login = new Login();

            AccountConsumer account = new AccountConsumer();
            
            account = login.ValidationAccount(username, password);

            if (account != null) {
                Session["AccountLogin"] = account;
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout() {
            Session.Clear();

            return View();
        }
    }
}