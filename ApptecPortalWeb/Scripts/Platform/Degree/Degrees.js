$(document).ready(function () {
    Insertar();
});
    
    var nombre="";
function Insertar() {
    var accion;
    var error;
    var msj;
        $('#SaveDegree').click(function () {
            nombre = document.getElementById("nombreGrado").value;
            if (nombre == "") {
                alert("Por favor ingrese un grado");
            }
            else{
                var oModel = {
                    "Nombre": $("#nombreGrado").val()
                }
                $.ajax({
                    "async": true,
                    "crossDomain": true,
                    "cache": false,
                    "method": "POST",
                    "url": "http://localhost:59538/Api/Degree/Create",
                    "data": JSON.stringify(oModel),
                    "contentType": "application/json"
                }).done(function (response) {
                    console.log(response);
                    alert("Grado insertado correctamente");
                    $("#nombreGrado").val("");
                    error = "Ninguno";
                    msj = "Funcionamiento correcto";
                    accion = "Registro de un nuevo grado";
                    Information(accion, error, msj);
                }).fail(function (jqXHR, textStatus, err) {
                    console.log(textStatus);
                    error = err + " " + textStatus + " " + jqXHR;
                    msj = "Administrador revisa el funcionamiento del portal";
                    alert("Ocurrio un error al insertar el grado, reintentelo más tarde");
                    Information(accion, error, msj);
                    $("#nombreGrado").val("");
                    accion = "Fallo Registro de un nuevo grado";
                });
            }

           
    });
   
 }

function Information(accion, error, msj) {
            var oModel = {
                "Accion": accion,
                "Error": error,
                "Msj":msj
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
   




