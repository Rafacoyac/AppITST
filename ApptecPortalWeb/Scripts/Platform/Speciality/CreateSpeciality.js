$(document).ready(function () {
    Insertar();
});

var especialidad = "";
var institucion = "";

function Insertar() {
    var accion;
    var error;
    var msj;

    $('#saveSpeciality').click(function () {
        especialidad = document.getElementById("nombreEspecialidad").value;
        institucion = document.getElementById("institucionId").value;
        if (especialidad == "" || institucion == "") {
            alert("Por favor llene todos los campos");
        }
        else {
            var oModel = {
                "Nombre": $("#nombreEspecialidad").val(),
                "InstitucionId": $("#institucionId").attr("selected", true).val()
            }
            $.ajax({
                "async": true,
                "crossDomain": true,
                "cache": false,
                "method": "POST",
                "url": "http://localhost:59538/Api/Speciality/Create",
                "data": JSON.stringify(oModel),
                "contentType": "application/json"
            }).done(function (response) {
                console.log(response);
                alert("Especialidad insertada correctamente");
                $("#nombreEspecialidad").val("");
                $("#institucionId").val("Seleccionar");

                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "Creacion de una especialidad";
                Information(accion, error, msj);
            }).fail(function (jqXHR, textStatus, err) {
                console.log(textStatus);
                alert("Ocurrio un error al insertar la nombreEspecialidad, reintentelo más tarde");
                $("#nombreEspecialidad").val("");
                $("#institucionId").val("Seleccionar");

                error = err + " " + textStatus + " " + jqXHR;
                msj = "Administrador revisa el funcionamiento del portal";
                accion = "Fallo creacion de una especialidad";
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



