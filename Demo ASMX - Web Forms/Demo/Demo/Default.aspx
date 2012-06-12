<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Demo._Default" ClientIDMode="Static"  %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/Default.aspx.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        Enter your book title for your wish list
    </p>
    <asp:TextBox runat="server" ID="txtBookTitle" Width="200"></asp:TextBox>
    <asp:Button runat="server" ID="btnAddBookTitle" Text="Add book title" /><br/>
    <asp:ListBox runat="server" ID="lstBookTitles"></asp:ListBox>

</asp:Content>
