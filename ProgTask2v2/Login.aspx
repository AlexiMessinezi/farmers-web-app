<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProgTask2v2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Login Page"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Text="Username:"></asp:Label>
            <br />
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        </div>
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" Text="Password:"></asp:Label>
        <br />
        <asp:TextBox ID="txtPassword" TextMode ="Password" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
        <p>
            <asp:Button ID="BtnLogin" runat="server" Text="Login" Width="125px" OnClick="BtnLogin_Click" Font-Bold="True" />
        </p>
    </form>
</body>
</html>
