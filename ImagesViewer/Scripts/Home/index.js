$(document).ready(function () {
    selectPhotoListener();
    $('#listView').click(showAsList);
    $('#tableView').click(showAsTable);
    //$('#addPhoto').click(addPhoto);
    //$('#deletePhoto').click(deletePhoto);
});

var selectPhotoListener = function() {
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

var addPhoto = function () {

}

var deletePhoto = function () {

}

var renderPhotos = function() {
    
}