$(document).ready(function () {
    LoadInstitution();
});

function LoadInstitution() {
    console.log("mostrar");
    $.ajax({
        url: "http://localhost:59538/Api/Classroom/ShowInstitution",
        method: "POST",
        dataType: "json",
        data: "{}",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                $("#institucionId").append("<option value=" + data[i].id + ">" + data[i].nombre + "</option>");
            }
        },
        error: function (jqXHR, status, error) {
            alert('Disculpe, existió un problema');
        }
    });
}