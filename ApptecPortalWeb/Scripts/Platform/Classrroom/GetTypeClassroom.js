$(document).ready(function () {
    LoadTypeClassroom();
    LoadInstitution();
});



function LoadTypeClassroom() {
    var accion;
    var error;
    var msj;

    $.ajax({
        url: "http://localhost:59538/Api/Classroom/ShowClassroomType",
        method: "POST",
        dataType: "json",
        data: "{}",
        success: function (data) {
             for (var i = 0; i < data.length; i++) {
                 $("#aulaId").append("<option value=" + data[i].id + ">" + data[i].nombre + "</option>");
            }

            error = "Ninguno";
            msj = "Funcionamiento correcto";
            accion = "Obtencion de un aula";
            Information(accion, error, msj);
        },
        error: function (jqXHR, status, error) {
            alert('Disculpe, existió un problema');

            error = err + " " + textStatus + " " + jqXHR;
            msj = "Administrador revisa el funcionamiento del portal";
            accion = "Fallo obtencion de un aula";
            Information(accion, error, msj);
        }
    });
}

function LoadInstitution() {
    var accion;
    var error;
    var msj;

    $.ajax({
        url: "http://localhost:59538/Api/Classroom/ShowInstitution",
        method: "POST",
        dataType: "json",
        data: "{}",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                $("#institucionId").append("<option value=" + data[i].id + ">" + data[i].nombre + "</option>");
            }

            error = "Ninguno";
            msj = "Funcionamiento correcto";
            accion = "Obtencion de una istitucion";
            Information(accion, error, msj);
        },
        error: function (jqXHR, status, error) {
            alert('Disculpe, existió un problema');

            error = err + " " + textStatus + " " + jqXHR;
            msj = "Administrador revisa el funcionamiento del portal";
            accion = "Fallo obtencion de la institucion";
            Information(accion, error, msj);
        }
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


