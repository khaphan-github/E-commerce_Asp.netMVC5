using E_Commerce_Repository.InitializationDB;
using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Areas.Admin.Controllers
{
    public class ViewProfileController : BaseController {
        // GET: Admin/ViewProfile
        private EcommerIntializationDB db = new EcommerIntializationDB();
        
        public ActionResult Index(int id)
        {
            // Lấy tài khoản theo id
            AccountRepository accountrepository = new AccountRepository();
            var accountModel = accountrepository.getAccountById(id);

            //Lưu data
            
            //db.Accounts.Add();

            return View(accountModel);
        }

        // update account
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateAccount(Account account, HttpPostedFileBase fileupload)
        {
            // SỬ LÝ ẢNH 
            if (fileupload == null)
            {
                var accountStoreInDB = db.Accounts.FirstOrDefault(p => p.Id == account.Id);
                accountStoreInDB.DisplayName = account.DisplayName;
                accountStoreInDB.DateOfBirth = account.DateOfBirth;
                accountStoreInDB.Sex = account.Sex;
                accountStoreInDB.Phone = account.Phone;
                accountStoreInDB.Email = account.Email;
                db.SaveChanges();
                return RedirectToAction("Index", "ViewProfile", new { id = account.Id });
            }
            else
            {
                var accountStoreInDB = db.Accounts.FirstOrDefault(p => p.Id == account.Id); 
                string img = "";
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileupload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Image/"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        fileupload.SaveAs(path);
                    }
                    img =  "/Areas/Admin/Image/" + fileName ;
                    /*if (accountStoreInDB != null)
                    {*/
                        accountStoreInDB.DisplayName = account.DisplayName;
                        accountStoreInDB.DateOfBirth = account.DateOfBirth;
                        accountStoreInDB.Sex = account.Sex;
                        accountStoreInDB.Phone = account.Phone;
                        accountStoreInDB.Email = account.Email;
                        accountStoreInDB.Avatar = img;
                        db.SaveChanges();
                    
                }
                return RedirectToAction("Index", "ViewProfile", new { id = account.Id });
            }
            
            
        }
    }
}