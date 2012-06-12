$(document).ready(function () {

    $("#btnAddBookTitle").click(function () {
        
        var $bookTitle = $("#txtBookTitle").val();

        $.ajax({
            type: "POST",
            url: "Default.aspx/AddBook",
            data: "{ 'bookTitle':'" + $bookTitle + "' }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                var $bookId = msg.d;
                var $option = new Option($bookTitle, $bookId);
                $("#lstBookTitles").append($option);
            },
            error: function () {
                alert('Error calling AddBook');
            }
        });
        return false;
    });
    
});