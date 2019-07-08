
function CargarImagen() {


    var files = $("#inputFile").get(0).files;
    var data = new FormData();
    for (i = 0; i < files.length; i++) {
        data.append("file" + i, files[i]);
    }


    $.ajax({
        type: "POST",
        url: "http://localhost:59538/Api/Admin/file",
        contentType: false,
        processData: false,
        data: data,
        success: function (data) {
            $("#ImgCarga").attr("src", "data:text/plain;base64," + data);
            console.log(data);
            //alert(data);

            localStorage.setItem("image", data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);
        }
    });
}