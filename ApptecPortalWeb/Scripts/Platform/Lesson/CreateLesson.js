$(document).ready(function () {
    Insertar();
});

var dia = "";
var profesor = "";
var horain = "";
var horafin = "";
var aula = "";
var materia = "";
//var grupo = "";

function habilitar(value) {

    if (value == "0") {
        var d = "Lunes";
        Day(d);
    } else if (value == "1") {
        var d = "Martes";
        Day(d);
    } else if (value == "2") {
        var d = "Miercoles";
        Day(d);
    } else if (value == "3") {
        var d = "Jueves";
        Day(d);
    } else if (value == "4") {
        var d = "Viernes";
        Day(d);
    } else if (value == "5") {
        var d = "Sabado";
        Day(d);
    }

}

function Insertar() {
    var accion;
    var error;
    var msj;

    $('#saveLesson').click(function () {
        dia = document.getElementById("diaClases").value;
        profesor = document.getElementById("profesorId").value;
        horain = document.getElementById("horaInClases").value;
        horafin = document.getElementById("horaFinClases").value;
        aula = document.getElementById("aulaId").value;
        materia = document.getElementById("materiaId").value;
//        grupo = document.getElementById("grupoId").value;
        

        if (dia == "" || horain == "" || horafin == "" || aula == "" || materia == "" || profesor=="") {
            alert("Por favor llene todos los campos grado");
        }
        else {
            var oModel = {
                "Dia": $("#diaClases").val(),
                "EmpleadosId": $("#profesorId").attr("selected", true).val(),
                "HoraIn": $("#horaInClases").val(),
                "HoraFin": $("#horaFinClases").val(),
                "AulaId": $("#aulaId").attr("selected", true).val(),
                "MateriaId": $("#materiaId").attr("selected", true).val()
               // "GrupoId": $("#grupoId").attr("selected", true).val()
            }
            
            $.ajax({
                "async": true,
                "crossDomain": true,
                "cache": false,
                "method": "POST",
                "url": "http://localhost:59538/Api/Lesson/Create",
                "data": JSON.stringify(oModel),
                "contentType": "application/json"
            }).done(function (response) {
                console.log(response);
                alert("Horario insertado correctamente");
                $("#diaClases").val("");
                $("#profesorId").val("Seleccionar");
                $("#horaInClases").val("");
                $("#horaFinClases").val("");
                $("#aulaId").val("Seleccionar");
                $("#materiaId").val("Seleccionar");
               // $("#grupoId").val("Seleccionar");

                error = "Ninguno";
                msj = "Funcionamiento correcto";
                accion = "Creacion de un horario";
                Information(accion, error, msj);
            }).fail(function (jqXHR, textStatus, err) {
                console.log(textStatus);
                alert("Ocurrio un error al insertar el horario, reintentalo");
                $("#diaClases").val("");
                $("#profesorId").val("Seleccionar");
                $("#horaInClases").val("");
                $("#horaFinClases").val("");
                $("#aulaId").val("Seleccionar");
                $("#materiaId").val("Seleccionar");
               // $("#grupoId").val("Seleccionar");

                error = err + " " + textStatus + " " + jqXHR;
                msj = "Administrador revisa el funcionamiento del portal";
                accion = "Fallo creacion de un horario de clases";
                Information(accion, error, msj);
            });
        }
    });
}

function Day(dia) {
    var d = dia;
    $('#lesson').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ registros por página.",
            "zeroRecords": "Lo sentimos. No se encontraron registros.",
            "info": "Mostrando página _PAGE_ de _PAGES_",
            "infoEmpty": "No hay registros aún.",
            "infoFiltered": "(filtrados de un total de _MAX_ registros)",
            "search": "Búsqueda",
            "LoadingRecords": "Cargando ...",
            "Processing": "Procesando...",
            "SearchPlaceholder": "Comience a teclear...",
            "paginate": {
                "previous": "Anterior",
                "next": "Siguiente",
            }
        },
        "scrollY": 300,
        "scrollX": true,
         destroy: true,
        "ajax": {
            "method": "POST",
            "url": "http://localhost:59538/Api/Lesson/Day",
           data: {
                "Dia": d
            },
            dataSrc: ''
        },
        "columns": [
            {
                'aTargets': [0],
                'bSortable': true,
                'mData': "materiaNombre",
                "width": "20%"
            },
            {
                'aTargets': [1],
                'bSortable': true,
                'mData': "gradoNombre",
                "width": "20%"
            },
            {
                'aTargets': [2],
                'bSortable': true,
                'mData': "aulaNombre",
                "width": "20%"
            },
            {
                'aTargets': [3],
                'bSortable': true,
                'mData': "empleadosNombre",
                "width": "20%"
            },
            {
                'aTargets': [4],
                'bSortable': true,
                'mData': "empleadoApp",
                "width": "20%"
            },
            {
                'aTargets': [5],
                'bSortable': true,
                'mData': "empleadoApm",
                "width": "20%"
            },
            {
                'aTargets': [6],
                'bSortable': true,
                'mData': "horaIn",
                "width": "20%"
            },
            {
                'aTargets': [7],
                'bSortable': true,
                'mData': "horaFin",
                "width": "20%"
            }
        ]
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






