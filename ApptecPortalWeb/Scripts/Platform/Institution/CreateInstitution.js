$(document).ready(function () {
    Insertar();
});

function Insertar() {
    var accion;
    var error;
    var msj;

    var nombre = $("#nombreAdmin").val();
    var direccion = $("#direccion").val();
    var telefono = $("#telefono").val();
    var nivel = $("#nivelEdInstitucion").val();
    var director = $("#directorInstitucion").val();

    var oModel = {
        "Name": nombre,
        "Direction": direccion,
        "Phone": telefono,
        "EducationLevelID": nivel,
        "Logo": "",
        "Director": director
    }


    $.ajax({

        "async": true,
        "crossDomain": true,
        "cache": false,
        "method": "POST",
        "url": "http://localhost:59538/Api/Institution/Create",
        "data": JSON.stringify(oModel),
        "contentType": "application/json"

    }).done(function (response) {

        error = "Ninguno";
        msj = "Funcionamiento correcto";
        accion = "Creacion de una institucion";
        Information(accion, error, msj);

        console.log(response);


        swal("Registro exitoso!", "La petición fue creada correctamente!", "success");
        // $("#nombreGrupo").val("");
        //$("#nombreGrupo").focus();
        window.location.href = "/Profile/CreateProfile?qwr=" + nivel;
        return false;


    }).fail(function (jqXHR, textStatus, err) {
        error = err + " " + textStatus + " " + jqXHR;
        msj = "Administrador revisa el funcionamiento del portal";
        accion = "Fallo creacion de una institucion";
        Information(accion, error, msj);
        console.log(textStatus)
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