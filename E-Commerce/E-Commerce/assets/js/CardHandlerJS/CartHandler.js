function AddProductToCard(productId) {

    fetch('https://localhost:44302/Card/addProductToCard?', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ productId: productId })
    }).then(response => response.text()).then((response) => {
        console.log(response)
        if (response == 'success') {
            let text = "Thêm sản phẩm thành công, Xem giỏ hàng?";
            if (confirm(text) == true) {
                window.location.replace("/Card")
            } else {
                
            }
            
        }
        else {
            alert("Vui lòng đăng nhập để thêm vào giỏ hàng");
        }
    });
}

function RemoveProductFromCard(productId) {

    fetch('https://localhost:44302/Card/removeProductFromCard?', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ productId: productId })
    }).then(response => response.text()).then((response) => {
        console.log(response)
        if (response == 'success') {
           
        }
        else {
           
        }
    });
}