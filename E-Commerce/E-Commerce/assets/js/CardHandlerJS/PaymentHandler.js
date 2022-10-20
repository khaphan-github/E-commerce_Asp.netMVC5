function getPaymentMethod() {
    var paymentmomo = document.getElementById("paymentmomo").checked;
   
    var amout = document.getElementById('totalPrice').innerText;
    amout = amout.replaceAll(",", "");

    var paymentMethodPagram = "&paymentMethod=";
    var shippingMethodParam = "&shippingMethod=" + getShippingmethod();
    if (paymentmomo) {
        if (amout > 50000000) {
            alert("Chỉ có thể thanh toán Momo đơn hàng nhỏ hơn 50 triệu");
        }
        else if (amout == 0) {
            alert("Chưa có sản phẩm để thanh toán");
        }
        else {
            paymentMethodPagram += "1";
            var urlPayment = "/Consumer/PaymentMomo?amout=" + amout + paymentMethodPagram + shippingMethodParam;
          
            window.location.replace(urlPayment); 
        }
    }
    else {
        paymentMethodPagram += "2";
        var urlPayment = "/Consumer/Payment?amout=" + amout + paymentMethodPagram + shippingMethodParam;
        window.location.replace(urlPayment);
    }
}
function formatCash(str) {
    return str.split('').reverse().reduce((prev, next, index) => {
        return ((index % 3) ? next : (next + ',')) + prev
    })
}
var TotalPrice = document.getElementById('totalPrice');

var tempPrice = 0;
function CheckOrder(shippingRadio) {
    var amout = parseInt(document.getElementById('totalPrice').innerText.replaceAll(',',''));
    // Xóa bỏ giấu phẩy,
    amout += (parseInt(shippingRadio.value) - tempPrice);

    tempPrice = parseInt(shippingRadio.value);

    TotalPrice.innerText = formatCash(amout.toString());

    return parseInt(shippingRadio.value);
}

function getShippingmethod() {
    var result = "FREE";
    var amount = document.querySelector('input[name="shipping"]:checked').value;
    if (amount == 28000) {
        result = "SAVE";
    }
    else if (amount == 43000) {
        result = "FAST";
    }
    return result;
}