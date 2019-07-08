
var nombre, apep, apem, user, contra, instituto;

var inst;


function Registrar() {

    nombre = document.getElementById("nombreAdmin").value;
    apep = document.getElementById("apellidopAdmin").value;
    apem = document.getElementById("apellidomAdmin").value;
    user = document.getElementById("usuarioAdmin").value;
    contra = document.getElementById("contrasenaAdmin").value;
    //instituto = document.getElementById("instituto").value;
    inst = $('#institucioId').val();




    if (contra.length >= 6) {

        AdminApi();
        // AdminPortal();

    } else {

        $('#contrasenaAdmin').focus();

        swal("Ingresa mínimo 6 carácteres para la contraseña.");

    }





}

function InstirutionRegisterUser() {

    inst = $('#institucioId').val();
    user = document.getElementById("usuarioAdmin").value;


    var oModel = {

        "InstitutionID": inst,
        "UserCreation": user
    }


    $.ajax({

        "async": true,
        "crossDomain": true,
        "cache": false,
        "method": "POST",
        "url": "http://localhost:59538/Api/Institution/UpdateRegisterUser",
        "data": JSON.stringify(oModel),
        "contentType": "application/json"



    }).done(function (response) {



        console.log(response);

        AdminPortal();




    }).fail(function (jqXHR, textStatus, err) {



        console.log(textStatus)


    });


}




function AdminPortal() {


    var oModel = {


        "Name": nombre,
        "LastNameP": apep,
        "LastNameM": apem,
        "Users": user,
        "Pass": contra,
        "InstitutionID": inst,
        "Photo": ""


    }



    $.ajax({

        "async": true,
        "crossDomain": true,
        "cache": false,
        "method": "POST",
        "url": "http://localhost:59538/Api/Admin/Create",
        "data": JSON.stringify(oModel),
        "contentType": "application/json"




    }).done(function (response) {



        console.log(response);



        swal("Registro exitoso!", "La petición fue creada correctamente!", "success");
        // $("#nombreGrupo").val("");
        //$("#nombreGrupo").focus();

        window.location.href = "/Login/Login";
        //return false;



    }).fail(function (jqXHR, textStatus, err) {



        console.log(textStatus)


    });


}




function AdminApi() {



    var oModel = {


        "Email": nombre + apep + apem,
        "UserName": user,
        "Password": contra,
        "ConfirmPassword": contra,
        "FirstName": nombre,
        "LastName": apep + " " + apem



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
        InstirutionRegisterUser();


        // swal("Registro exitoso!", "La petición fue creada correctamente!", "success");
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
