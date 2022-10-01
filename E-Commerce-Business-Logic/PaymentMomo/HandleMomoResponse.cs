using E_Commerce_Business_Logic.CartHandler;
using E_Commerce_Business_Logic.Session;
using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace E_Commerce_Business_Logic.PaymentMomo {
    public class HandleMomoResponse {
        public void saveOrder() {
            CartView carview = HttpContext.Current.Session[SessionConstaint.SHOPPINGCART] as CartView;
        }
     }
}
