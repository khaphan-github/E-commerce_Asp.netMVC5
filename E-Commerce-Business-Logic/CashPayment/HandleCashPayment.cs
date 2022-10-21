using E_Commerce_Business_Logic.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Business_Logic.CashPayment {
    public class HandleCashPayment {
        public static void SaveOrderByCashPayment(string amout, int paymentMethod, string shippingMethod) {
            bool isValidated = PaymentHandler.validatetionPaymentRequest(amout, paymentMethod, shippingMethod);
            if(isValidated) {
                PaymentHandler.SaveOrder(amout, paymentMethod, shippingMethod);
            }
        }
    }
}
