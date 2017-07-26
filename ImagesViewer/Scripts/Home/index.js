$(document).ready(function () {
    selectPhotoListener();
    //addPhotoListener();
    $('#addFile').on('change',
        function (e) {
            addPhoto(e);
        });
    $('#listView').click(showAsList);
    $('#tableView').click(showAsTable);
    //$('#addPhoto').click(addPhoto);
    //$('#deletePhoto').click(deletePhoto);

});


var addPhoto = function (e) {
    var files = e.target.files;
    if (files.length > 0) {
        if (window.FormData !== undefined) {
            var data = new FormData();
            //var file = $('input[type=file]')[0].files[0];
            //data.append('file', file);
            for (var x = 0; x < files.length; x++) {
                data.append("file" + x, files[x]);
            }
            console.log(data);
            $.ajax({
                type: 'POST',
                url: '/api/Images/AddImages',
                data: data, //JSON.stringify(data),
                //headers: {
                //    Accept: 'application/json',
                //    ContentType: 'application/json'
                //},
                //contentType: 'application/json; charset=utf-8',
                contentType: false,
                processData: false,
                success: function (result) {
                    console.log('yes!');
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

//var addPhotoListener = function () {
//    $('#addFile').on('change', function (e) {
//        alert('ok');
//        var files = e.target.files;
//        var myID = 3; //uncomment this to make sure the ajax URL works
//        if (files.length > 0) {
//            if (window.FormData !== undefined) {
//                var data = new FormData();
//                for (var x = 0; x < files.length; x++) {
//                    data.append("file" + x, files[x]);
//                }

//                $.ajax({
//                    type: "POST",
//                    url: '/ImagesController/AddImages?id=' + myID,
//                    contentType: false,
//                    processData: false,
//                    data: data,
//                    success: function (result) {
//                        console.log(result);
//                    },
//                    error: function (xhr, status, p3, p4) {
//                        var err = "Error " + " " + status + " " + p3 + " " + p4;
//                        if (xhr.responseText && xhr.responseText[0] == "{")
//                            err = JSON.parse(xhr.responseText).Message;
//                        console.log(err);
//                    }
//                });
//            } else {
//                alert("This browser doesn't support HTML5 file uploads!");
//            }
//        }
//    });
//}

var deletePhoto = function () {

}

var renderPhotos = function () {

}