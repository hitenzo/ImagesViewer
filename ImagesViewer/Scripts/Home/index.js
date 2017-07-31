$(document).ready(function () {
    selectPhotoListener();
    //addPhotoListener();

    //$('#addFile').on('change', addPhoto(e));
    $('#addFile').on('change',
        function (e) {
            recognizeImage(e);
        });
    $('#listView').click(showAsList);
    $('#tableView').click(showAsTable);
    //$('#addPhoto').click(addPhoto);
    //$('#deletePhoto').click(deletePhoto);

});


var recognizeImage = function (e) {
    var files = $('#addFile')[0].files;
    if (files.length > 0 && window.FormData !== undefined) {
        var data = new FormData();
        //var data;
        for (var x = 0; x < files.length; x++) {
            data.append("file" + x, files[x]);
            //data = new FormData();
            //data.append("file" + x, files[x]);
            //$.ajax({
            //    type: 'POST',
            //    url: '/api/Recognition/RegonizeImage',
            //    data: data,
            //    contentType: false,
            //    processData: false,
            //    success: function (result) {
            //        addImage(result);
            //        console.log('tags: ' + result + ' type: ' + jQuery.type(result));
            //    },
            //    error: function (xhr, status, p3, p4) {
            //        var err = "Error " + " " + status + " " + p3 + " " + p4;
            //        if (xhr.responseText && xhr.responseText[0] == "{")
            //            err = JSON.parse(xhr.responseText).Message;
            //        console.log(err);
            //    }
            //});
        }

        $.ajax({
            type: 'POST',
            url: '/api/Recognition/RegonizeImage',
            data: data,
            contentType: false,
            processData: false,
            success: function (result) {
                addImage(result);
                console.log('tags: ' + result + ' type: ' + jQuery.type(result));
                console.log('tags1: ' + result[0] + ' type: ' + jQuery.type(result[0]));
                console.log('tags2: ' + result[1] + ' type: ' + jQuery.type(result[1]));
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

var addImage = function (tags) {
    $.ajax({
        type: 'POST',
        url: '/api/Images/AddImages',
        data: JSON.stringify(tags),
        contentType: "application/json; charset=utf-8",
        success: function (result) {

        },
        error: function (xhr, status, p3, p4) {
            var err = "Error " + " " + status + " " + p3 + " " + p4;
            if (xhr.responseText && xhr.responseText[0] == "{")
                err = JSON.parse(xhr.responseText).Message;
            console.log(err);
        }
    });
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

var getAllPhotos = function () {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:53148/api/Images/GetAllImages',
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            // render all images
        },
        error: function (xhr, status, error) {
            console.log(error.message);
        }
    });
}

var addPhotoListener = function () {

}

var deletePhoto = function () {

}

var renderPhotos = function () {

}