$(document).ready(function () {
    selectPhotoListener();
    $('#listView').click(showAsList);
    $('#tableView').click(showAsTable);
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
    $('.photoContainer div').css('margin-right', '100%');
}

var showAsTable = function () {
    $('.photoContainer div').css('margin-right', '0%');
}