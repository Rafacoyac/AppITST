var accion;
var error;
var msj;

$.ajax({

    "async": true,
    "crossDomain": true,
    "cache": false,
    "method": "POST",
    "url": "http://localhost:59538/Api/Admin/Show",
    "data": "",
    "contentType": "application/json"


}).done(function (data) {


    console.log(data);

    for (var i = 0, len = data.length; i < len; i++) {

        $("#nombreAlumno").val(data[i].name);
        $("#apellidopAlumno").val(data[i].lastNameP);
        $("#apellidomAlumno").val(data[i].lastNameM);
        $("#usuarioAdmin").val(data[i].users);
        $("#contrasenaAdmin").val(data[i].pass);
        $("#institucionAdmin").val(data[i].institutionID);

        $("#ImgCarga").attr("src", "data:text/plain;base64," + data[i].photo);
    }

    error = "Ninguno";
    msj = "Funcionamiento correcto";
    accion = "Obtencion datos del perfil";
    Information(accion, error, msj);

}).fail(function (jqXHR, textStatus, err) {

    console.log(textStatus);
    console.log(jqXHR);
    console.log(err);

    error = err + " " + textStatus + " " + jqXHR;
    msj = "Administrador revisa el funcionamiento del portal";
    accion = "Fallo obtencion de datos del perfil";
    Information(accion, error, msj);
});



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
