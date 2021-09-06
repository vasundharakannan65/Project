// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Write your JavaScript code.

function FindPrice() {
    Qty = Number(document.getElementById('quantity').value);
    Price = Number(document.getElementById('price').value);
    Cost = Qty * Price;

    document.getElementById('cost').value = Cost;
}

function FindTotal() {
    
}