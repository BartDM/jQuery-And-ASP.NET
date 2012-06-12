<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePanel.aspx.cs" Inherits="Webform.UpdatePanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <asp:Label runat="server" ID="lblFirstName" Text="Bart"></asp:Label><br />
                <asp:Label runat="server" ID="lblLastName" Text="De Meyer"></asp:Label><br />
                <asp:Label ID="Label1" runat="server" Text="Ticket"></asp:Label><br />
                <asp:TextBox ID="txtTicket" runat="server">
                </asp:TextBox><br />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /><br />
                <asp:ListBox runat="server" ID="lstTickets" DataTextField="TicketName" DataValueField="TickedId">
                   
                </asp:ListBox>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
