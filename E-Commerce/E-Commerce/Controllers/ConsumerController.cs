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
using E_Commerce_Business_Logic.RequestFilter;

namespace E_Commerce.Controllers {

    public class ConsumerController : Controller {
        public ProductRepository productRepository = new ProductRepository();

        // Người dùng đăng nhập bằng username và password 
        public string Login(string usernames, string passwords) {

            Login BussinessLogin = new Login();

            AccountConsumer account = BussinessLogin.ValidationAccount(usernames, passwords) as AccountConsumer;

            if (account != null) {
                Session.Add(SessionConstaint.USERSESION, account);
                return "success";
            }
            
            return "fail";
        }

        public string Logout() {
            Session.Clear();
            return "Logout Successfully";
        }

        // Đăng ký tài khoản
        public ActionResult Register() {
            return View();           
        }

        // THANH TOÁN QUAMOMO

        [AuthorizationFilter("User")]
        public ActionResult PaymentMomo(string amout, int paymentMethod, int shippingMethod) {
            if (amout != null) {
                // https://test-payment.momo.vn/download/ 

                string responeFromMomo = PaymentRequest.sendPaymentRequest(amout, "Thanh toán mua hàng Unique Shop");

                try {
                    JObject jmessage = JObject.Parse(responeFromMomo);

                    System.Diagnostics.Debug.WriteLine(jmessage.ToString());

                    bool successPayment = jmessage.GetValue("payUrl").ToString() != null;
                    if (successPayment) {
                        // Lưu đơn hàng
                        HandleMomoResponse.saveOrder();

                    }
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

        [AuthorizationFilter("User")]
        public ActionResult Payment() {
            return View();
        }


        [AuthorizationFilter("User")]
        public ActionResult AccountDetail() {
            return View();
        }

        [AuthorizationFilter("User")]
        public ActionResult ConfirmPaymentMomo(PaymentResponse response) {
            // Handle response
            if (response.errorCode.Equals("0")) {
                System.Diagnostics.Debug.WriteLine("THÊM ORDER THANH CÔNG");
                return RedirectToAction("ShowSuccessPayment", "Consumer", new { status  = "success"});
            }
            return RedirectToAction("ShowSuccessPayment", "Consumer", new { status = "fail" });
        }

        [AuthorizationFilter("User")]
        public ActionResult ShowSuccessPayment(string status) {
            // Thanh toán thành công
            if (status == "success") {
                ViewBag.imageURL = "/assets/images/logo/thanhtoanthanhcong.png";
            }
            else {
                ViewBag.paymentMessage = "Thanh toán Momo thất bại, vui lòng thực hiện lại!";
                return RedirectToAction("Index","Card");
            }
            // Thanh toán thất bại
            return View();
        }
        // Quản lý đơn hàng
        [AuthorizationFilter("User")]
        public ActionResult ConsumerOrder() {
            return View();
        }
    }
}