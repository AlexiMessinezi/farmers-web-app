<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FarmerMenu.aspx.cs" Inherits="ProgTask2v2.FarmerMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblWelcomeFarmer" runat="server" Text="lblWelcomeFarmer" Font-Bold="True" Font-Size="Large"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Height="28px" OnClick="Button1_Click" Text="Logout" Font-Bold="True" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Product Name:"></asp:Label>
        <br />
        <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Text="Product Date:"></asp:Label>
        <asp:Calendar ID="cldProductDate" runat="server"></asp:Calendar>
        <asp:Label ID="lblError" runat="server" Text="Please make sure no fields are empty" Visible="False"></asp:Label>
        <p style="margin-left: 40px">
            <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="btnAddProduct_Click" Font-Bold="True" />
        </p>
    </form>
</body>
</html>
