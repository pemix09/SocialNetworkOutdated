$(document).ready(function () {

    $("#progress").hide();

    $("#fileBasket").on("dragenter", function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
    });

    $("#fileBasket").on("dragover", function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
    });

    $("#fileBasket").on("drop", function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
        var files = evt.originalEvent.dataTransfer.files;
        var fileNames = "";
        if (files.length > 0) {
            fileNames += "Uploading <br/>"
            for (var i = 0; i < files.length; i++) {
                fileNames += files[i].name + "<br />";
            }
        }
        $("#fileBasket").html(fileNames)

        var data = new FormData();
        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
        }
        $.ajax({
            type: "POST",
            url: "/controllers/UploadFiles",
            contentType: false,
            processData: false,
            data: data,
            success: function (message) {
                $("#fileBasket").html(message);
            },
            error: function (e) {
                $("#fileBasket").html
                    ("There was error uploading files!"+e);
            },
            beforeSend: function () {
                $("#progress").show();
            },
            complete: function () {
                $("#progress").hide();
            }
        });
    });
});