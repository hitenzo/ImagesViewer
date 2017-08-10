$(document).ready(function () {
    loadImages();
    $('#addFile').on('change',
        function (e) {
            addImages(e);
    });
    $('#listView').click(showAsList);
    $('#tableView').click(showAsTable);
    $('#deletePhoto').click(deletePhoto);
});

var loadImages = function () {
    $('.photosContainer').html("");
    $.ajax({
        type: 'GET',
        url: '/api/Images/GetAllImages',
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            drawImages(result);
            selectPhotoListener();
        },
        error: function (xhr, status, p3, p4) {
            var err = "Error " + " " + status + " " + p3 + " " + p4;
            if (xhr.responseText && xhr.responseText[0] == "{")
                err = JSON.parse(xhr.responseText).Message;
            console.log(err);
        }
    });
}

var drawImages = function (result) {
    for (var i = 0; i < result.length; i++) {
        $('.photosContainer').append(
            '<div class="col-lg-3 col-sm-4 col-xs-6">' +
            '<a title="' + result[i].id + '">' +
            '<img class="thumbnail img-responsive imgFormat" src="data:image/jpg;base64,' + result[i].bytes + '" /></a></div>');
    }
}


var addImages = function(e) {
    var files = $('#addFile')[0].files;
        if (files.length > 0 && window.FormData !== undefined) {
            var data = new FormData();
            for (var x = 0; x < files.length; x++) {
                data.append("file" + x, files[x]);
            }

            $.ajax({
                type: 'POST',
                url: '/api/Images/AddImages',
                data: data,
                contentType: false,
                processData: false,
                success: function () {
                    loadImages();
                },
                error: function (xhr, status, p3, p4) {
                    var err = "Error " + " " + status + " " + p3 + " " + p4;
                    if (xhr.responseText && xhr.responseText[0] == "{")
                        err = JSON.parse(xhr.responseText).Message;
                    console.log(err);
                }
            });
        } else {
            alert("This browser doesn't support HTML5 file uploads!");
        }
}


var selectPhotoListener = function () {
    $('.thumbnail').click(function () {
        $('.modal-body').empty();
        var title = $(this).parent('a').attr("title");
        $('.modal-title').html(title);
        $($(this).parents('div').html()).appendTo('.modal-body');
        $('#myModal').modal({ show: true });
    });
}

var showAsList = function () {
    $('.photosContainer div').css('margin-right', '100%');
}

var showAsTable = function () {
    $('.photosContainer div').css('margin-right', '0%');
}

var deletePhoto = function () {
    var title = $('.modal-title').html();
    var data = JSON.stringify(title);
    $.ajax({
        type: 'POST',
        url: '/api/Images/DeleteImage',
        data: data,
        contentType: 'application/json; charset=utf-8',
        success: function () {
            loadImages();
        },
        error: function (xhr, status, p3, p4) {
            var err = "Error " + " " + status + " " + p3 + " " + p4;
            if (xhr.responseText && xhr.responseText[0] == "{")
                err = JSON.parse(xhr.responseText).Message;
            console.log(err);
        }
    });
}
