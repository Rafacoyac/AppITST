$(document).ready(function () {
    Insertar();
});

var clave = "";
var nombre = "";
var institucion = "";

function Insertar() {
    var accion;
    var error;
    var msj;


    $('#SaveCareer').click(function () {
        clave = document.getElementById("claveCarrera").value;
        nombre = document.getElementById("nombreCarrera").value;
        institucion = document.getElementById("institucionId").value;
        if (clave == "" || nombre == "" || institucion == "") {
            alert("Por favor llene todos los campos");
        }
        else {
            var oModel = {
                "Clave": $("#claveCarrera").val(),
                "Nombre": $("#nombreCarrera").val(),
                "InstitucionId": $("#institucionId").attr("selected", true).val()
            }
            $.ajax({
                "async": true,
                "crossDomain": true,
                "cache": false,
                "method": "POST",
                "url": "http://localhost:59538/Api/Career/Create",
                "data": JSON.stringify(oModel),
                "contentType": "application/json"
            }).done(function (response) {
                console.log(response);
                alert("Carrera insertada correctamente");
                $("#claveCarrera").val("");
                $("#nombreCarrera").val("");
                $("#institucionId").val("Seleccionar");

                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "Creacion de una carrera";
                Information(accion, error, msj);
            }).fail(function (jqXHR, textStatus, err) {
                console.log(textStatus);
                alert("Ocurrio un error al insertar la carrera, reintentelo más tarde");
                $("#claveCarrera").val("");
                $("#nombreCarrera").val("");
                $("#institucionId").val("Seleccionar");

                error = err + " " + textStatus + " " + jqXHR;
                msj = "Administrador revisa el funcionamiento del portal";
                accion = "Fallo creacion de una carrera";
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





