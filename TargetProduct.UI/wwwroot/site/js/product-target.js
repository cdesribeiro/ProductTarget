$(function () {
    $('#table').bootstrapTable({
        url: 'http://localhost:5188/api/Product/GetProductsGridList'
    });

    $('#modalForm').on('shown.bs.modal', function () {
        $('#product-description').focus();
    })
});

function SalvarProduto() {
    debugger;
    var description = $('#product-description').val();
    var shortDescription = $('#product-short-description').val();
    var quantity = $('#product-quantity').val();;
    var value = $('#product-value').val();
    var active = $('#product-active').is(":checked")
    var objProdSave = {
        Description: description,
        ShortDescription: shortDescription,
        Quantity: quantity,
        Value: value,
        Active: active
    }

    $.ajax({
        type: "POST",
        url: 'http://localhost:5188/api/Product/',
        data: JSON.stringify(objProdSave),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            debugger;
        }
    });

}
