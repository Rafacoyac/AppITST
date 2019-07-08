$(document).ready(function () {
    LoadFillDegree();
    LoadFillSubject();
});
function LoadFillDegree() {
    var accion;
    var error;
    var msj;

        $.ajax({
            url: "http://localhost:59538/Api/DegreeSubject/GetDegree",
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
                }
                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "Obtencion de un grado";
                Information(accion, error, msj);
            },
                error: function (jqXHR, status, error) {
                    alert('Disculpe, existió un problema');

                    error = err + " " + textStatus + " " + jqXHR;
                    msj = "Administrador revisa el funcionamiento del portal";
                    accion = "Fallo obtencion de grados";
                    Information(accion, error, msj);
                }
            });
    }


function LoadFillSubject() {
    var accion;
    var error;
    var msj;

        $.ajax({
            url: "http://localhost:59538/Api/DegreeSubject/GetSubject",
            method: "POST",
            dataType: "json",
            data: "{}",
            success: function (data) {
                if (data == null) {
                    alert('No hay materias que mostrar, agregue una');
                } else {
                    for (var i = 0; i < data.length; i++) {
                        $("#materiaId").append("<option value=" + data[i].id + ">" + data[i].nombre + "</option>");
                    }
                }
                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "Obtencion de materias";
                Information(accion, error, msj);
            },
            error: function (jqXHR, status, error) {
                alert('Disculpe, existió un problema');

                error = err + " " + textStatus + " " + jqXHR;
                msj = "Administrador revisa el funcionamiento del portal";
                accion = "Fallo obtencion de materias";
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
