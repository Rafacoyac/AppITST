$(document).ready(function () {
    LoadClassroom();
    LoadSubject();
    LoadGroup();
    LoadEmployer();
});


/*function LoadGroup() {
    var accion;
    var error;
    var msj;

    $.ajax({
        url: "http://localhost:59538/Api/Lesson/ShowGroup",
        method: "POST",
        dataType: "json",
        data: "{}",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                $("#grupoId").append("<option value=" + data[i].id + ">" + data[i].nombre + "</option>");
            }
            error = "Ninguno";
            msj = "Funcionamiento correcto";
            accion = "Obtencion de un grupo";
            Information(accion, error, msj);
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
*/

function LoadSubject() {

    var accion;
    var error;
    var msj;

        $.ajax({
            url: "http://localhost:59538/Api/Lesson/ShowSubject",
            method: "POST",
            dataType: "json",
            data: "{}",
            success: function (data) {
                for (var i = 0; i < data.length; i++) {
                    $("#materiaId").append("<option value=" + data[i].id + ">" + data[i].nombre + "</option>");
                }

                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "Obtencion de una materia";
                Information(accion, error, msj);
            },
            error: function (jqXHR, status, error) {
                alert('Disculpe, existió un problema');
                error = err + " " + textStatus + " " + jqXHR;
                msj = "Administrador revisa el funcionamiento del portal";
                accion = "Fallo obtencion de una materia";
                Information(accion, error, msj);
            }
        });
}

function LoadEmployer() {
    var accion;
    var error;
    var msj;

    $.ajax({
        url: "http://localhost:59538/Api/Lesson/ShowEmployer",
        method: "POST",
        dataType: "json",
        data: "{}",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                $("#profesorId").append("<option value=" + data[i].id + ">" + data[i].nombre + " " + data[i].apellidop + " " + data[i].apellidom+ "</option>");

                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "Obtencion de un empleado";
                Information(accion, error, msj);
            }
        },
        error: function (jqXHR, status, error) {
            alert('Disculpe, existió un problema');

            error = err + " " + textStatus + " " + jqXHR;
            msj = "Administrador revisa el funcionamiento del portal";
            accion = "Fallo obtencion de empleados";
            Information(accion, error, msj);
        }
    });

}

function LoadClassroom() {
    var accion;
    var error;
    var msj;

    $.ajax({
        url: "http://localhost:59538/Api/Lesson/ShowClassroom",
        method: "POST",
        dataType: "json",
        data: "{}",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                $("#aulaId").append("<option value=" + data[i].id + ">" + data[i].clave + "  " + data[i].nombre + "</option>");
            }

            error = "Ninguno";
            msj = "Funcionamiento correcto";
            accion = "Obtencion de aulas";
            Information(accion, error, msj);
        },
        error: function (jqXHR, status, error) {
            alert('Disculpe, existió un problema');

            error = err + " " + textStatus + " " + jqXHR;
            msj = "Administrador revisa el funcionamiento del portal";
            accion = "Fallo obtencion de aulas";
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
