<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Webform.aspx.cs" Inherits="Webform.Webform" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/Webform.aspx.js" type="text/javascript"></script>
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="lblFirstName" Text="Bart"></asp:Label><br />
        <asp:Label runat="server" ID="lblLastName" Text="De Meyer"></asp:Label><br />
        <asp:Label ID="Label1" runat="server" Text="Ticket"></asp:Label><br />
        <asp:TextBox ID="txtTicket" runat="server">
        </asp:TextBox><br />
        <asp:Button ID="btnSave" runat="server" Text="Save" /><br />
        <asp:ListBox runat="server" ID="lstTickets" DataTextField="TicketName" DataValueField="TickedId">
        </asp:ListBox>
    </div>
    </form>
</body>
</html>
