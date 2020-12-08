$(document).ready(function () {

    $.ajax({
        url: '/ToDo/BuildToDoTable',
        success: function (result) {
            $('#tableDiv').html(result);
        }
    });

});