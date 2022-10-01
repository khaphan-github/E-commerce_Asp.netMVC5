
// Onclick GoogleLoginFunction when user click google button login
function GoogleLoginFunction() {
    alert("Chức năng này chưa hoàn thiện")
} 

function ShowShoppingCard() {
    alert("Hãy Thêm vào giỏ hàng 1 sản phẩm")
}
var username = document.getElementById('singin-email');
var password = document.getElementById('singin-password');

var usernameLabel = document.getElementById('labelUsername');
var paswordLabel = document.getElementById('labelPassword');

username.addEventListener('change', funCheckValueUsername);
password.addEventListener('change', funCheckValuePassword);

function showDefaultLabelUsername() {
    usernameLabel.innerText = "Số điện thoại hoặc email * ";
    usernameLabel.style.color = "black";
}
function showDefaultLabelPassword() {
    paswordLabel.innerText = "Mật khẩu *";
    paswordLabel.style.color = "black";
}

function funCheckValueUsername() {
    var flag = false;
    if (username.value == '') {
        usernameLabel.innerText = "Tên đăng nhập không được để trống *";
        usernameLabel.style.color = "red";
    }
    else if (username.value.length < 10 || username.value.length > 254) {
        usernameLabel.innerText = "Tên đăng nhập không được vượt quá 254 ký tự và ít hơn 8 ký tự *";
        usernameLabel.style.color = "red";
    }
    else {
        showDefaultLabelUsername();
        flag = true;
    }

    return flag;
}

function funCheckValuePassword() {
    var flag = false;

    if (password.value == '') {
        paswordLabel.innerText = "Mật khẩu không được để trống *";
        paswordLabel.style.color = "red";
    }
    else if (password.value.length < 8 || password.value.length > 254) {
        paswordLabel.innerText = "Mật khẩu không được vượt quá 254 ký tự và ít hơn 8 ký tự *";
        paswordLabel.style.color = "red";
    }
    else {
        showDefaultLabelPassword();
        flag = true;
    }
    return flag;
}

function showWrongUsernameOrPassword() {
    var responsems = document.getElementById('responseMessage');
    responsems.innerText = "Sai tên đăng nhập hoặc mật khẩu";
}

function Validation() {
    if (funCheckValuePassword() == true && funCheckValueUsername() == true) {
        fetch('https://localhost:44302/Consumer/Login?', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ usernames: username.value, passwords: password.value })
        }).then(response => response.text()).then((response) => {
            console.log(response)
            if (response == 'success') {
                window.location.replace("https://localhost:44302/");
            }
            else {
                showWrongUsernameOrPassword();
            }
        })
    }
}
// LOGOUT FUNCTION

function Logout() {
    fetch('https://localhost:44302/Consumer/Logout');
    window.location.replace("https://localhost:44302/");
}
