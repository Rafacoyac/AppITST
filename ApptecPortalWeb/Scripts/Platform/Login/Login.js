$(document).ready(function () {
    $('#user').focus();s
});

var u = "";
var p = "";
var g = "password";
var accion;
var error;
var msj;

function logear() {

    u = document.getElementById("user").value;
    p = document.getElementById("pass").value;

    if (u == "" || p == "") {

        swal("Ingresa todos los datos.", "Asegurate de llenar todos los campos", "error");
        $('#user').val('');
        $('#pass').val('');
        $('#user').focus();

    } else {


        $.ajax({
            url: 'http://localhost:59538/oauth/token',
            type: 'POST',
            data: jQuery.param({ username: u, password: p, grant_type: g }),
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            success: function (data) {

                alert(data.access_token);
                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "Creacion de un usuario";
                Information(accion, error, msj);
                window.location.href = '/Home/Inicio';

                //console.log(data.access_token);
                // alert("Bienvenido "+data.access_token);


            },
            error: function (jqXHR, textStatus) {
                console.log(jqXHR);
                console.log(textStatus);
                swal("Datos incorrectos", "Puedes volver a intertarlo", "error");
                $('#user').val('');
                $('#pass').val('');
                $('#user').focus();
                error = err + " " + textStatus + " " + jqXHR;
                msj = "Administrador revisa el funcionamiento del portal";
                accion = "Fallo creacion de un usuario";
                Information(accion, error, msj);
            }
        });

    }
    
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