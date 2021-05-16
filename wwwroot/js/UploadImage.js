$(document).ready(function () {
    InitDragAndDrop();
    DragDropOperation();
})
function InitDragAndDrop() {
    $("$divUploadFile").on("dragenter", function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
    });
    $("$divUploadFile").on("dragover", function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
    });

    $("$divUploadFile").on("drop", function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
    });
}
function DragDropOperation() {
    $("$divUploadFile").on("drop", function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
        var files = evt.originalEvent.dataTransfer.files;
        var filenames = "";

        if (files.length > 0) {
            filenames += "Przesyłanie obrazu <br/>";
            for (var i = 0; i < files.length; i++) {
                filenames += files[i].name + "<br/>";
            }
        }
        $("$divUploadFile").html(filenames);

        var data = new FormData();
        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
        }

        $.ajax({
            type: "POST",
            url: "/Home/UploadFiles",
            contentType: false,
            processData: false,
            data: data,
            success: function (message) {
                $("#divUploadFile").html(message);
            },
            error: function (e) {
                $("#divUploadFile").html
                    ("There was error uploading files!" + e.error);
            },
            beforeSend: function () {
                $("#progress").show();
            },
            complete: function () {
                $("#progress").hide();
            }

        });
    });
}