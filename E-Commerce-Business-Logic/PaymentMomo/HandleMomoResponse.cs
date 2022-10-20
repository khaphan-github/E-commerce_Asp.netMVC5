using E_Commerce_Business_Logic.CartHandler;
using E_Commerce_Business_Logic.Payment;
using E_Commerce_Business_Logic.Session;
using E_Commerce_Repository.Models;

using E_Commerce_Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace E_Commerce_Business_Logic.PaymentMomo {
    public class HandleMomoResponse {

        /* LƯU ĐƠN HÀNG KHI THANH TOÁN THÀNH CÔNG
         * 1. Lấy tất cả sản phẩm trong giỏ hàng
         * 2. Tạo mới Order -> thêm order vào db
         * 3. Lấy Order từ DB -> Chuyễn nhưng sản phẩm trong giỏ hàng qua Order
         * 4. Xóa chi tiết giỏ hàng
         * 5. Lưu tất cả nhưng thay đỗi
         * 
         * Gửi mail về người dùng khi đặt hàng thành côngi
         */
       
        public static string saveOrderByMomoPayment(string amount, string orderID) {

            int paymentMethodID = 1;

            ShippingMethod shipingMethod = PaymentRequest.getShippingMethodAfterPayment(orderID);

            PaymentHandler.SaveOrder(amount, paymentMethodID, shipingMethod.Desc);

            return "success";
        }
     }
}