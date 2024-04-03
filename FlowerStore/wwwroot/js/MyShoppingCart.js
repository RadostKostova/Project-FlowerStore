document.addEventListener('DOMContentLoaded', function () {
    const decrementBtn = document.getElementById('decrement');
    const incrementBtn = document.getElementById('increment');
    const quantityInput = document.getElementById('productQuantity');
    const productIdInput = document.getElementById('prodId');

    let refreshClicked = false;    // track if the refresh button was clicked

    function updateCart(productId, newQuantity) {   
        if (refreshClicked) {
            fetch('/ShoppingCart/UpdateCart', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ productId: productId, newQuantity: newQuantity })
            }).then(response => {
                if (response.ok) {
                    console.log("Shopping Cart updated");
                    window.location.reload();      // Reload the page after successful update
                }
            }).catch(error => console.error('Error updating cart:', error));
        }
    }

    decrementBtn.addEventListener('click', function () {
        let currentValue = parseInt(quantityInput.value);
        if (currentValue > 1) {
            quantityInput.value = currentValue - 1;
        }
    });

    incrementBtn.addEventListener('click', function () {
        let currentValue = parseInt(quantityInput.value);
        if (currentValue < 20) {
            quantityInput.value = currentValue + 1;
        }
    });

    const refreshButton = document.getElementById('refreshButton');
    refreshButton.addEventListener('click', function () {
        refreshClicked = true;           // Set to true when the refresh button is clicked

        updateCart(parseInt(productIdInput.value), parseInt(quantityInput.value));
    });
});
