$(function () {

    var productId = 0;
    $('#table').bootstrapTable({
        url: 'http://localhost:5188/api/Product/GetProductsGridList',
        columns: [{}, {}, {}, {}, {}, {}, {},
        {
            field: 'edit',
            title: 'Editar',
            align: 'center',
            valign: 'middle',
            clickToSelect: false,
            formatter: function (value, row, index) {
                return '<button onclick="EditarProduto(' + row.id + ')" class="btn btn-primary" rowId="' + row.id + '" >Editar</button> ';
            }
        },
        {
            field: 'delete',
            title: 'Excluir',
            align: 'center',
            valign: 'middle',
            clickToSelect: false,
            formatter: function (value, row, index) {
                return '<button onclick="ExcluirProduto(' + row.id + ')" class="btn btn-danger" rowId="' + row.id + '" >Excluir</button> ';
            }
        },

        ]
    });

    $('#modalForm').on('shown.bs.modal', function () {
        $('#product-description').focus();
    })
});

function EditarProduto(id) {
    $.get("http://localhost:5188/api/Product/GetProductEdit?id=" + id, function (data) {
        console.log(data);

        $('#modalForm').modal('show');

        FillForm(data);

    });

}
function ExcluirProduto(id) {
    return $.ajax({
        url: "http://localhost:5188/api/Product/?id=" + id,
        type: 'DELETE',
        success: function (res) {
            $('#table').bootstrapTable('refresh');
            showSuccesMessage('Produto Excluído com sucesso');
        },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        error: function (request, status, error) {
            errorFormatter(request.responseText);
        }
    });
}

function SalvarProduto() {
    let description = $('#product-description').val();
    let shortDescription = $('#product-short-description').val();
    let quantity = $('#product-quantity').val();
    let value = $('#product-value').val();
    let active = $('#product-active').is(":checked")
    let objProdSave = {
        Id: productId,
        Description: description,
        ShortDescription: shortDescription,
        //Quantity: quantity,
        //Value: value,
        Active: active
    }

    let jsonObjProdSave = JSON.stringify(objProdSave);

    $.ajax({
        type: "POST",
        url: 'http://localhost:5188/api/Product/',
        data: jsonObjProdSave,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            $('#table').bootstrapTable('refresh');
            $('#modalForm').modal('hide');
            FormClear();
            showSuccesMessage('Produto salvo com sucesso');
        },
        error: function (request, status, error) {
            errorFormatter(request.responseText);
        }
    });

}

function LimparIdProduto() {
    productId = 0;
}

function FormClear() {
    $('#product-description').val('');
    $('#product-quantity').val('');
    $('#product-value').val('');
    $('#product-short-description').val('');
    $("#product-active").prop('checked', false);
}

function FillForm(data) {
    console.log(data);

    productId = data.id;

    $('#product-description').val(data.description);
    $('#product-quantity').val(data.quantity);
    $('#product-value').val(data.value);
    $('#product-short-description').val(data.shortDescription);
    $("#product-active").prop('checked', data.active);
}

function errorFormatter(error) {
    try {
        let objError = JSON.parse(error);
        if (objError != undefined && objError.errors != undefined) {
            let errorsKeys = Object.keys(objError.errors);
            let errorArray = [];

            errorsKeys.forEach(function (element, index, array) {
                var elementArray = objError.errors[element];
                errorArray = errorArray.concat(elementArray);
            });

            console.log(objError);
            console.log(errorsKeys);
            let ArrErrors = errorArray.join('<br>');
            showErrorMessage(ArrErrors)
        }
    } catch (err) {
        console.log(err);
        showErrorMessage(error)
    }
}

function showSuccesMessage(message) {
    iziToast.success({
        title: 'Sucesso',
        message: message,
        position: 'topRight'
    });
}

function showErrorMessage(message) {
    iziToast.error({
        title: 'Erro',
        message: message,
        position: 'topRight'
    });
}