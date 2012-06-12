$(document).ready(function () {
    $("#btnSave").click(function () {
        var ticketName = $("#txtTicket").val();
        $.ajax({
            type: "POST",
            url: "/Ticket/AddTicket/",
            data: "{'ticketName':'" + ticketName + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                var ticket = msg;
                var option = new Option(ticket.TicketName, ticket.TickedId);
                $("#lstTickets").append(option);
                $("#txtTicket").val('');
            },
            error: function () {
                alert("Error adding ticket");
            }
        });
        return false;
    });
})