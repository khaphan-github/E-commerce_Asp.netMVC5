using System;
using System.Web.Mvc;
using E_Commerce_Repository.Models;
using E_Commerce_Business_Logic.Logic;
using E_Commerce_Business_Logic.Session;
using E_Commerce_Repository.Repository;
using E_Commerce_Business_Logic.PaymentMomo;
using E_Commerce_Business_Logic.CashPayment;
using Newtonsoft.Json.Linq;
using E_Commerce_Business_Logic.RequestFilter;
using E_Commerce_Business_Logic.Payment;

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
        // Thanh toán tiền mặt
        [AuthorizationFilter("User")]
        public ActionResult Payment(string amout, int paymentMethod, string shippingMethod) {
            // Thực hiện thanh toán băng tiền mặt
            HandleCashPayment.SaveOrderByCashPayment(amout, paymentMethod, shippingMethod);
            return RedirectToAction("CashPayment", "Consumer");
        }

        [AuthorizationFilter("User")]
        public ActionResult CashPayment() {
            return View();
        }
        [AuthorizationFilter("User")]
        public ActionResult AccountDetail() {
            return View();
        }

        // Quản lý đơn hàng
        [AuthorizationFilter("User")]
        public ActionResult ConsumerOrder() {
            return View();
        }

        // THANH TOÁN QUAMOMO
        [AuthorizationFilter("User")]
        public ActionResult PaymentMomo(string amout, int paymentMethod, string shippingMethod) {
            string errorMessage = "";
            if (amout != null) {

                bool isValidated = PaymentHandler.validatetionPaymentRequest(amout, paymentMethod, shippingMethod);

                if (isValidated) {
                    string responeFromMomo = PaymentRequest.sendPaymentRequest(amout, "Thanh toán mua hàng Unique Shop", shippingMethod);

                    try {
                        JObject jmessage = JObject.Parse(responeFromMomo);

                        System.Diagnostics.Debug.WriteLine(jmessage.ToString());
                        string momoPaymentUrl = jmessage.GetValue("payUrl").ToString();

                        if (momoPaymentUrl != null) {
                            return Redirect(momoPaymentUrl);
                        }
                    } catch (Exception e) {
                        System.Diagnostics.Debug.WriteLine(e.Message);
                    }
                }
            }
            else {
                errorMessage = "Thanh toán thất bại vui lòng thanh toán lại";
            }
            // Hiển thị trang thông báo thanh toán thât ba
            return RedirectToAction("Index", "Card", new { ErrorMessage = errorMessage });
        }

        [AuthorizationFilter("User")]
        public ActionResult ConfirmPaymentMomo(PaymentResponse response) {

            if (response.errorCode.Equals("0")) {

                HandleMomoResponse.saveOrderByMomoPayment(response.amount, response.orderId);

                System.Diagnostics.Debug.WriteLine("THÊM ORDER THANH CÔNG");

                return RedirectToAction("ShowSuccessPayment", "Consumer", new { status = "success" });
            }
            return RedirectToAction("ShowSuccessPayment", "Consumer", new { status = "fail" });
        }

        [AuthorizationFilter("User")]
        public ActionResult ShowSuccessPayment(string status) {
            if (status == "success") {
                ViewBag.imageURL = "/assets/images/logo/thanhtoanthanhcong.png";
            }
            else {
                ViewBag.paymentMessage = "Thanh toán Momo thất bại, vui lòng thực hiện lại!";
                return RedirectToAction("Index", "Card");
            }
            return View();
        }
    }
}