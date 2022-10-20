using E_Commerce_Business_Logic.RequestFilter;
using E_Commerce_Repository.InitializationDB;
using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Areas.Admin.Controllers
{
    [AuthorizationFilter(allowedRoles: Role.SystemAdmin)]
    public class MemberController : Controller {
        // GET: Admin/Member/Index
        EcommerIntializationDB db = new EcommerIntializationDB();
        public ActionResult Index(string roleName)
        {
            // Lọc theo quyền user
            if (roleName == null)
                roleName = "User";
            var AccountRole = db.AccountRoles.FirstOrDefault(x => x.Name.Equals(roleName));
            ViewBag.AccountList = AccountRole.Account.ToList();
            // Lọc theo quyền Admin
            // Lọc theo quyền systemadmin
            return View(ViewBag.AccountList);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var acc = db.Accounts.FirstOrDefault(x => x.Id == id);
                acc.AccountRoles.Clear();
                db.Accounts.Remove(acc);
                db.SaveChanges();
                return RedirectToAction("Index", "Member");
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}