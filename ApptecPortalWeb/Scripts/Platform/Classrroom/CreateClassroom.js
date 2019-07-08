$(document).ready(function () {
    Insertar();
});

var clave = "";
var nombre = "";
var descripcion = "";
var institucion = "";
var tipoAula = "";

function Insertar() {
    var accion;
    var error;
    var msj;

    $('#SaveClassroom').click(function () {
        clave = document.getElementById("claveAula").value;
        nombre = document.getElementById("nombreAula").value;
        descripcion = document.getElementById("descripcionAula").value;
        institucion = document.getElementById("institucionId").value;
        tipoAula = document.getElementById("aulaId").value;
        if (clave == "" || nombre == "" || descripcion == "" || institucion == "" || tipoAula=="") {
            alert("Por favor llene todos los campos");
        }
        else {
            var oModel = {
                "Clave":$("#claveAula").val(),
                "Nombre": $("#nombreAula").val(),
                "Descripcion": $("#descripcionAula").val(),
                "Institucion": $("#institucionId").attr("selected", true).val(),
                "TipoAula": $("#aulaId").attr("selected", true).val()
            }
            $.ajax({
                "async": true,
                "crossDomain": true,
                "cache": false,
                "method": "POST",
                "url": "http://localhost:59538/Api/Classroom/Create",
                "data": JSON.stringify(oModel),
                "contentType": "application/json"
            }).done(function (response) {
                console.log(response);
                alert("Aula insertada correctamente");
                $("#claveAula").val("");
                $("#nombreAula").val("");
                $("#descripcionAula").val("");
                $("#institucionId").val("Seleccionar");
                $("#aulaId").val("Seleccionar");

                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "Creacion de un aula";
                Information(accion, error, msj);
            }).fail(function (jqXHR, textStatus, err) {
                console.log(textStatus);
                alert("Ocurrio un error al insertar el aula, reintentelo más tarde");
                $("#claveAula").val("");
                $("#nombreAula").val("");
                $("#descripcionAula").val("");
                $("#institucionId").val("Seleccionar");
                $("#aulaId").val("Seleccionar");

                error = err + " " + textStatus + " " + jqXHR;
                msj = "Administrador revisa el funcionamiento del portal";
                accion = "Fallo creacion de un aula";
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







