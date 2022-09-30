using System;
using System.Linq;
using System.Web.Mvc;
using E_Commerce_Repository.Models;
using E_Commerce_Business_Logic.Logic;
using E_Commerce_Business_Logic.Session;
using E_Commerce_Repository.Repository;
using E_Commerce_Business_Logic.PaymentMomo;
using E_Commerce_Business_Logic.CartHandler;

using Newtonsoft.Json.Linq;
using E_Commerce.Models;

namespace E_Commerce.Controllers {
    public class ConsumerController : Controller {
        public ProductRepository productRepository = new ProductRepository();
        // GET: Consumer
        public ActionResult Index() {
            return View();
        }

        // Người dùng đăng nhập bằng username và password 

        public string Login(string usernames, string passwords) {

            Login BussinessLogin = new Login();

            AccountConsumer account = BussinessLogin.ValidationAccount(usernames, passwords) as AccountConsumer;

            if (account != null) {
                CartView cart = CartHandlders.getCardViewSession(account);
                System.Diagnostics.Debug.WriteLine(cart.Products.ElementAt(0).productName);

                Session.Add(SessionConstaint.USERSESION, account);
                Session.Add(SessionConstaint.SHOPPINGCART, cart);

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
        public ActionResult PaymentMomo(string amout) {
            if (amout != null) {
                // https://test-payment.momo.vn/download/ 
                
                string responeFromMomo = PaymentRequest.sendPaymentRequest(amout, "Thanh toán mua hàng Unique Shop");

                try {
                    JObject jmessage = JObject.Parse(responeFromMomo);

                    System.Diagnostics.Debug.WriteLine(jmessage.ToString());
                    bool successPayment = jmessage.GetValue("payUrl").ToString() != null;
                    return Redirect(jmessage.GetValue("payUrl").ToString());
                    // Update thanh toán cập nhật hóa đơn                  
                } catch (Exception e) {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
               
            }
            // Hiển thị trang thông báo thành công
            return Redirect("/Card/Index");
        }

        // Thanh toán tiền mặt
        public ActionResult Payment() {
            return View();
        }

        public ActionResult AccountDetail() {
            return View();
        }

        public ActionResult ConfirmPaymentMomo(PaymentResponse response) {
            // Handle response
            if (response.errorCode.Equals("0")) {
                // thanh toans thanfh coong
                // Thêm sản phẩm vào order
                // Xóa sản phẩm khỏi card

            }
            else {
                // Thanh toan that bai
            }
            return View();
        }

    }
}