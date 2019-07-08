$(document).ready(function () {
    LoadDatatable();
});

function LoadDatatable() {
    var table = $('#group').DataTable({
        "scrollY": 350,
        "scrollX": true,
        "ajax": {
            "method": "POST",
            "url": "http://localhost:59538/Api/Group/Show",
            dataSrc: ''
        },
        "columns": [
            {
                'aTargets': [0],
                'bSortable': true,
                'mData': "nombre",
                "width": "20%"
            },
            {
                "mRender": function (param, type, full) {
                    return "<center><a class='btn btn-warning' role='button' aria-pressed='true' id='Editar' alt='Editar'><i class='fa fa-pencil-square-o'></i></a>" +
                        "&nbsp;&nbsp;<a class='btn btn-danger' role='button' aria-pressed='true' id='Eliminar'><i class='fa fa-trash-o'></i></a></center>";
                }
            }
        ]
    });

    table.on('click', '#Editar', function () {
        var objecDtos = table.row($(this).parents('tr')).data();
        var id = objecDtos.id;
        localStorage.setItem("id", id);
        var a = localStorage.getItem("id");
        window.location.href = "UpdateGroup?id=" + a;
    });


    table.on('click', '#Eliminar', function () {
        var objecDtos = table.row($(this).parents('tr')).data();
        id = objecDtos.id;
        console.log(id);
        if (confirm('Desea eliminar el registro')) {
            Delete(id);
        }
    });
}



function Delete(id) {
    var accion;
    var error;
    var msj;

    $.ajax({
        type: "POST",
        url: "http://localhost:59538/Api/Group/Delete",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify({
            GroupId: id
        }),
        async: false,
        dataType: "json",
    }).done(function (response) {
        alert("Se elimino el grupo correctamente");
        //LoadDatatable.table.destroy();
        window.location.href = "ShowGroup";
        error = "Ninguno";
        msj = "Funcionamiento correcto";
        accion = "Eliminacion de un grupo";
        Information(accion, error, msj);
        //LoadDatatable();
    }).fail(function (jqXHR, textStatus, err) {
        console.log(err.response + textStatus + jqXHR)
        error = err + " " + textStatus + " " + jqXHR;
        msj = "Administrador revisa el funcionamiento del portal";
        accion = "Fallo eliminacion de un grupo";
        Information(accion, error, msj);
    });
}

function Information(accion, error, msj) {
    var oModel = {
        "Accion": accion,
        "Error": error,
        "Msj": msj
    }
    $.ajax({
        "async": true,
        "crossDomain": true,
        "cache": false,
        "method": "POST",
        "url": "http://localhost:59538/Api/Binnacle/Info",
        "data": JSON.stringify(oModel),
        "contentType": "application/json"
    }).done(function (response) {
        console.log(response);
    }).fail(function (jqXHR, textStatus, err) {
        console.log(textStatus);
    });
}
