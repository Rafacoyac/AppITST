$(document).ready(function () {
    LoadDatatable();
});

function LoadDatatable() {
    var table = $('#speciality').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ registros por página.",
            "zeroRecords": "Lo sentimos. No se encontraron registros.",
            "info": "Mostrando página _PAGE_ de _PAGES_",
            "infoEmpty": "No hay registros aún.",
            "infoFiltered": "(filtrados de un total de _MAX_ registros)",
            "search": "Búsqueda",
            "LoadingRecords": "Cargando ...",
            "Processing": "Procesando...",
            "SearchPlaceholder": "Comience a teclear...",
            "paginate": {
                "previous": "Anterior",
                "next": "Siguiente",
            }
        },
        "scrollY": 300,
        "scrollX": true,
        "ajax": {
            "method": "POST",
            "url": "http://localhost:59538/Api/Speciality/Show",
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
                'aTargets': [1],
                'bSortable': true,
                'mData': "institucionNombre",
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
        window.location.href = "UpdateSpeciality?id=" + a;
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
        url: "http://localhost:59538/Api/Speciality/Delete",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify({
            SpecialityId: id
        }),
        async: false,
        dataType: "json",
    }).done(function (response) {
        alert("Se elimino la especialidad correctamente");
        //LoadDatatable.table.destroy();
        window.location.href = "ShowSpeciality";
        //LoadDatatable();
        error = "Ninguno";
        msj = "Funcionamiento correcto";
        accion = "Eliminacio de una especialidad";
        Information(accion, error, msj);
    }).fail(function (jqXHR, textStatus, err) {
        console.log(err.response + textStatus + jqXHR);
        error = err + " " + textStatus + " " + jqXHR;
        msj = "Administrador revisa el funcionamiento del portal";
        accion = "Fallo eliminacion de una especialidad";
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


