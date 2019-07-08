$(document).ready(function () {
    Insertar();
});

var clave = "";
var nombre = "";
var creditos = "";
var carrera = "";
var especialidad = "";

function Insertar() {
    var accion;
    var error;
    var msj;

    $('#saveSubject').click(function () {
        clave = document.getElementById("claveMateria").value;
        nombre = document.getElementById("nombreMateria").value;
        creditos = document.getElementById("creditosMateria").value;
        carrera = document.getElementById("carreraId").value;
        especialidad = document.getElementById("especialidadId").value;
        if (clave == "" || nombre == "" || creditos == "" || carrera== "" || especialidad=="") {
            alert("Por favor llene todos los campos");
        }
        else {
            var oModel = {
                "Clave": $("#claveMateria").val(),
                "Nombre": $("#nombreMateria").val(),
                "Creditos": $("#creditosMateria").val(),
                "CarreraId": $("#carreraId").attr("selected", true).val(),
                "EspecialidadId": $("#especialidadId").attr("selected", true).val()
            }
            $.ajax({
                "async": true,
                "crossDomain": true,
                "cache": false,
                "method": "POST",
                "url": "http://localhost:59538/Api/Subject/Create",
                "data": JSON.stringify(oModel),
                "contentType": "application/json"
            }).done(function (response) {
                console.log(response);
                alert("Materia insertada correctamente");
                $("#claveMateria").val("");
                $("#nombreMateria").val("");
                $("#creditosMateria").val("");
                $("#carreraId").val("Seleccionar");
                $("#especialidadId").val("Seleccionar");

                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "Creacion de una materia";
                Information(accion, error, msj);
            }).fail(function (jqXHR, textStatus, err) {
                console.log(textStatus);
                alert("Ocurrio un error al insertar la materia, reintentelo más tarde");
                $("#claveMateria").val("");
                $("#nombreMateria").val("");
                $("#creditosMateria").val("");
                $("#carreraId").val("Seleccionar");
                $("#especialidadId").val("Seleccionar");

                error = err + " " + textStatus + " " + jqXHR;
                msj = "Administrador revisa el funcionamiento del portal";
                accion = "Fallo creacion de una materia";
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



