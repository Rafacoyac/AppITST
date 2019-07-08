$(document).ready(function () {
    mostrar();

});

function mostrar() {



    $.ajax({
        url: "http://localhost:59538/Api/Admin/ShowInstitutions",
        method: "POST",
        dataType: "json",
        data: "{}",
        success: function (data) {
            console.log(data);


            for (var i = 0; i < data.length; i++) {
                $("#institucioId").append("<option value=" + data[i].adminsID + ">" + data[i].name + "</option>");

            }


        },
        error: function (jqXHR, status, error) {
            alert('Disculpe, existió un problema');
        }
    });


}


