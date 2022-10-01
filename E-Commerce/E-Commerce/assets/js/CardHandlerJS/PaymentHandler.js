function getPaymentMethod() {
    var paymentmomo = document.getElementById("paymentmomo").checked;

    if (paymentmomo) {
        var amout = document.getElementById('totalPrice').innerText;
        amout = amout.replaceAll(",", "");
        if (amout > 50000000) {
            alert("Chỉ có thể thanh toán Momo đơn hàng nhỏ hơn 50 triệu");
        }
        else {
            var urlPayment = "/Consumer/PaymentMomo?amout=" + amout;
            alert(urlPayment);
            window.location.replace(urlPayment);
        }
    }

    else {
        window.location.replace("/Consumer/Payment/");
    }
}


function UpdateCartClick() {

}



