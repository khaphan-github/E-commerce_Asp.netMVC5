using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce_Repository.Models;
using E_Commerce_Business_Logic.Logic;
using E_Commerce_Business_Logic.Session;
using E_Commerce_Repository.Repository;
using E_Commerce_Business_Logic.PaymentMomo;
using Newtonsoft.Json.Linq;

namespace E_Commerce.Controllers
{
    public class ConsumerController : Controller
    {
        public ProductRepository productRepository = new ProductRepository();
        // GET: Consumer
        public ActionResult Index() {
            return View();
        }

        // Người dùng đăng nhập bằng username và password
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public string Login(string username, string password) {

            Login BussinessLogin = new Login();

            AccountConsumer account = BussinessLogin.ValidationAccount(username, password) as AccountConsumer;

            if (account != null) {

                System.Diagnostics.Debug.WriteLine(account.Username);

                Session.Add(SessionConstaint.USERSESION, account);

                return "success";
            }
            System.Diagnostics.Debug.WriteLine("ACCOUNT NOT ESIST IN DB");
            return "fail";

        }
        public string Logout() {
            Session.Clear();
            return "Logout Successfully";
        }

   

        // THANH TOÁN QUAMOMO
        public ActionResult PaymentMomo() {
            // https://test-payment.momo.vn/download/.
            string responeFromMomo =
                PaymentRequest.sendPaymentRequest("20000","testpayment");
            
            JObject jmessage = JObject.Parse(responeFromMomo);
            bool successPayment = jmessage.GetValue("payUrl").ToString() != null;
            // Update thanh toán cập nhật hóa đơn

            try { 
                return Redirect(jmessage.GetValue("payUrl").ToString());
            } catch (Exception e) {
                
            }
            return Redirect("/Card/Index");
        }

        // Thanh toán tiền mặt
        public ActionResult Payment() {
            return View();
        }

    }
}