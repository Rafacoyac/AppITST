$(document).ready(function () {
    LoadFillGroup();
    LoadFillDegree();
});
function LoadFillGroup() {
    var accion;
    var error;
    var msj;

    $.ajax({
        url: "http://localhost:59538/Api/Student/ShowGroup",
        method: "POST",
        dataType: "json",
        data: "{}",
        success: function (data) {
            if (data == null) {
                alert('No hay grupos que mostrar, agregue uno');
            } else {
                for (var i = 0; i < data.length; i++) {
                    $("#grupoId").append("<option value=" + data[i].id + ">" + data[i].nombre + "</option>");
                }
                
                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "Obtencion de un grupo";
                Information(accion, error, msj);
            }
        },
        error: function (jqXHR, status, error) {
            alert('Disculpe, existió un problema');

            error = err + " " + textStatus + " " + jqXHR;
            msj = "Administrador revisa el funcionamiento del portal";
            accion = "Fallo obtencion de un grupo";
            Information(accion, error, msj);
        }
    });
}

function LoadFillDegree() {
    var accion;
    var error;
    var msj;

    $.ajax({
        url: "http://localhost:59538/Api/Student/ShowDegree",
        method: "POST",
        dataType: "json",
        data: "{}",
        success: function (data) {
            if (data == null) {
                alert('No hay grados que mostrar, agregue uno');
            } else {
                for (var i = 0; i < data.length; i++) {
                    $("#gradoId").append("<option value=" + data[i].id + ">" + data[i].nombre + "</option>");
                }

                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "Obtencion de un grado";
                Information(accion, error, msj);
            }
        },
        error: function (jqXHR, status, error) {
            alert('Disculpe, existió un problema');

            error = err + " " + textStatus + " " + jqXHR;
            msj = "Administrador revisa el funcionamiento del portal";
            accion = "Fallo obtencion de un grado";
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
