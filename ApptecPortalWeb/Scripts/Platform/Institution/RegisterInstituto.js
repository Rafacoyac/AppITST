
function Registrar() {

    //var level = localStorage.getItem("nivel");





    var nombre = $("#nombreAdmin").val();
    var direccion = $("#direccion").val();
    var telefono = $("#telefono").val();
    var nivel = $("#nivelEdInstitucion").val();
    var director = $("#directorInstitucion").val();




    if (nombre == "") {

        swal("Ingresa todos los campos.");
        $('#nombreAdmin').focus();


    } else if (direccion == "") {

        swal("Ingresa todos los campos.");
        $('#nombreAdmin').focus();

    } else if (telefono == "") {
        swal("Ingresa todos los campos.");
        $('#telefono').focus();

    } else if (nivel == "Seleccionar") {
        swal("Selecciona un nivel educativo.");


    } else if (director == "") {
        swal("Ingresa todos los campos.");
        $('#directorInstitucion').focus();

    } else {


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


            console.log(response);


            swal("Registro exitoso!", "La petición fue creada correctamente!", "success");
            // $("#nombreGrupo").val("");
            //$("#nombreGrupo").focus();
            window.location.href = "/Profile/CreateProfile?qwr=" + nivel;
            return false;


        }).fail(function (jqXHR, textStatus, err) {

            console.log(textStatus)



        });


    }






}
