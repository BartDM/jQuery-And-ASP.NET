$(document).ready(function () {
    $("#btnAddBookTitle").click(function () {
        var $bookTitle = $("#txtBookTitle").val();
        $.ajax({
            type: "GET",
            url: "/API/Book/AddBook/",
            data: {bookTitle:$bookTitle},
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                var $book = msg;
                var $option = new Option($book.BookTitle, $book.BookId);
                $("#lstBookTitles").append($option);
            },
            error: function () {
                alert('Error calling AddBook');
            }
        });
        return false;
    });
});