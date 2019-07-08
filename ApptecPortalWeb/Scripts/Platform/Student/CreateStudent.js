$(document).ready(function () {
    Insertar();
});

var matricula = "";
var nombre = "";
var apellidop = "";
var apellidom = "";
var telefono = "";
var institucion = "";
var grupo = "";
var grado = "";

function Insertar() {
    var accion;
    var error;
    var msj;

    $('#saveStudent').click(function () {
        matricula = document.getElementById("matriculaAlumno").value;
        nombre = document.getElementById("nombreAlumno").value;
        apellidop = document.getElementById("apellidopAlumno").value;
        apellidom = document.getElementById("apellidomAlumno").value;
        telefono = document.getElementById("telefonoAlumno").value;
        institucion = document.getElementById("institucionId").value;
        grupo = document.getElementById("grupoId").value;
        grado = document.getElementById("gradoId").value;

        if (matricula == "" || nombre == "" || apellidop == "" || apellidom == "" || telefono == "" || institucion == "" || grupo == "" || grado == "") {
            alert("Por favor llene todos los campos");
        }
        else {
            var oModel = {
                "Matricula": $("#matriculaAlumno").val(),
                "Nombre": $("#nombreAlumno").val(),
                "Apellidop": $("#apellidopAlumno").val(),
                "Apellidom": $("#apellidomAlumno").val(),
                "Telefono": $("#telefonoAlumno").val(),
                "InstitucionId": $("#institucionId").attr("selected", true).val(),
                "GrupoId": $("#grupoId").attr("selected", true).val(),
                "Grado": $("#gradoId").attr("selected", true).val()
            }
            $.ajax({
                "async": true,
                "crossDomain": true,
                "cache": false,
                "method": "POST",
                "url": "http://localhost:59538/Api/Student/Create",
                "data": JSON.stringify(oModel),
                "contentType": "application/json"
            }).done(function (response) {
                console.log(response);
                //alert("Estudiante insertado correctamente");



                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "Creacion de un alumno";
                Information(accion, error, msj);

                AdminApi();

            }).fail(function (jqXHR, textStatus, err) {
                console.log(textStatus);
                alert("Ocurrio un error al insertar el estudiante, reintentelo más tarde");
                $("#matriculaAlumno").val("");
                $("#nombreAlumno").val("");
                $("#apellidopAlumno").val("");
                $("#apellidomAlumno").val("");
                $("#telefonoAlumno").val("");
                $("#institucionId").val("Seleccionar");
                $("#grupoId").val("Seleccionar");
                $("#grado").val("Seleccionar");

                error = err + " " + textStatus + " " + jqXHR;
                msj = "Administrador revisa el funcionamiento del portal";
                accion = "Fallo creacion de un alumno";
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


function AdminApi() {

    matricula = document.getElementById("matriculaAlumno").value;
    nombre = document.getElementById("nombreAlumno").value;
    apellidop = document.getElementById("apellidopAlumno").value;
    apellidom = document.getElementById("apellidomAlumno").value;



    var oModel = {


        "Email": nombre + apellidop,
        "UserName": matricula,
        "Password": matricula,
        "ConfirmPassword": matricula,
        "FirstName": nombre,
        "LastName": apellidop


    }


    $.ajax({

        "async": true,
        "crossDomain": true,
        "cache": false,
        "method": "POST",
        "url": "http://localhost:59538/api/accounts/create",
        "data": JSON.stringify(oModel),
        "contentType": "application/json"



    }).done(function (response) {



        console.log(response);


        swal("Registro exitoso!", "La petición fue creada correctamente!", "success");

        $("#matriculaAlumno").val("");
        $("#nombreAlumno").val("");
        $("#apellidopAlumno").val("");
        $("#apellidomAlumno").val("");
        $("#telefonoAlumno").val("");
        $("#institucionId").val("Seleccionar");
        $("#grupoId").val("Seleccionar");
        $("#grado").val("Seleccionar");
        // $("#nombreGrupo").val("");
        //$("#nombreGrupo").focus();
        //window.location.href = "/Login/Login";
        //return false;



    }).fail(function (jqXHR, textStatus, err) {


        console.log("textstatus: " + textStatus);
        console.log("jqxhr: " + jqXHR);
        console.log("err: " + err);

        if (err == "Bad Request") {

            swal("Ups!", "Debes ingresar otro usuario, por favor!", "info");
            $('#usuarioAdmin').val("");
            $('#usuarioAdmin').focus();




        } else {
            swal("Ups!", "Estamos trabajando en ello, vuelva a intentarlo más tarde por favor!", "error");

        }


    });


}





