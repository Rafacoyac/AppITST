$(document).ready(function () {
    Insertar();
});

var nombre = "";
var apellidop = "";
var apellidom = "";
var rfc = "";
var rol = "";
var institucion = "";

function Insertar() {
    var accion;
    var error;
    var msj;

    $('#employer').click(function () {
        nombre = document.getElementById("nombreEmpleado").value;
        apellidop = document.getElementById("apellidopEmpleado").value;
        apellidom = document.getElementById("apellidomEmpleado").value;
        rfc = document.getElementById("rfcEmpleado").value;
        rol = document.getElementById("tipoTrabajadorId").value;
        institucion = document.getElementById("institucionId").value;
        if (nombre == "" || apellidop == "" || apellidom == "" || rfc == "" || rol == "" || institucion=="") {
            alert("Por favor llene todos los campos");
        }
        else {
            var oModel = {
                "Nombre": $("#nombreEmpleado").val(),
                "Apellidop": $("#apellidopEmpleado").val(),
                "Apellidom": $("#apellidomEmpleado").val(),
                "Rfc": $("#rfcEmpleado").val(),
                "RolesId": $("#tipoTrabajadorId").attr("selected", true).val(),
                "InstitucionId": $("#institucionId").attr("selected", true).val()
            }
            $.ajax({
                "async": true,
                "crossDomain": true,
                "cache": false,
                "method": "POST",
                "url": "http://localhost:59538/Api/Employer/Create",
                "data": JSON.stringify(oModel),
                "contentType": "application/json"
            }).done(function (response) {
                console.log(response);
                alert("Profesor guardado correctamente");
                $("#nombreEmpleado").val("");
                $("#apellidopEmpleado").val("");
                $("#apellidomEmpleado").val("");
                $("#rfcEmpleado").val("");
                $("#tipoTrabajadorId").val("Seleccionar");
                $("#institucionId").val("Seleccionar");

                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "creacion de un empleado";
                Information(accion, error, msj);
            }).fail(function (jqXHR, textStatus, err) {
                console.log(textStatus);
                alert("Ocurrio un error al guardar el profesor, reintentelo más tarde");
                $("#nombreEmpleado").val("");
                $("#apellidopEmpleado").val("");
                $("#apellidomEmpleado").val("");
                $("#rfcEmpleado").val("");
                $("#tipoTrabajadorId").val("Seleccionar");
                $("#institucionId").val("Seleccionar");

                error = err + " " + textStatus + " " + jqXHR;
                msj = "Administrador revisa el funcionamiento del portal";
                accion = "Fallo creacion de un empleado";
                Information(accion, error, msj);
            });
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




