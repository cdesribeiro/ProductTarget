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
        },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
    });

}

function SalvarProduto() {
    var description = $('#product-description').val();
    var shortDescription = $('#product-short-description').val();
    var quantity = $('#product-quantity').val();
    var value = $('#product-value').val();
    var active = $('#product-active').is(":checked")
    var objProdSave = {
        Id: productId,
        Description: description,
        ShortDescription: shortDescription,
        //Quantity: quantity,
        //Value: value,
        Active: active
    }

    $.ajax({
        type: "POST",
        url: 'http://localhost:5188/api/Product/',
        data: JSON.stringify(objProdSave),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            $('#table').bootstrapTable('refresh');
            $('#modalForm').modal('hide');
            FormClear();
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
