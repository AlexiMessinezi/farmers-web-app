<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeMenu.aspx.cs" Inherits="ProgTask2v2.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="lblWelcome">
            <asp:Label ID="lblWelcomeEmployee" runat="server" Text="lblWelcomeEmployee" Font-Bold="True" Font-Size="Large"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEmployeeLogout" runat="server" Height="28px" OnClick="Button1_Click" Text="Logout" Font-Bold="True" Font-Size="Large" />
            <br />
            <br />
            <asp:Label ID="lblUsername" runat="server" Text="Farmer Username: " Font-Bold="True" Font-Size="Large"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <br />
        <asp:TextBox ID="txtFarmerUsername" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblUsername0" runat="server" Text="Farmer Password:" Font-Bold="True" Font-Size="Large"></asp:Label>
            <br />
        <asp:TextBox ID="txtFarmerPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblError" runat="server" Text="Please make sure no fields are empty" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
            <br />
        </div>
        <asp:Button ID="btnAddFarmer" runat="server" Text="Add Farmer" OnClick="btnAddFarmer_Click" Font-Bold="True" Font-Size="Large" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Filter Farmer: "></asp:Label>
        <br />
        <asp:TextBox ID="txtFilterFarmer" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Text="Filter Product:"></asp:Label>
        <br />
        <asp:TextBox ID="txtFilterProduct" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnApply" runat="server" Font-Bold="True" Font-Size="Large" OnClick="btnApply_Click" Text="Apply" Width="62px" />
        <asp:Button ID="btnClear" runat="server" Font-Bold="True" Font-Size="Large" OnClick="btnClear_Click" Text="Clear" />
        <br />
        <br />
        <asp:GridView ID="grdView" runat="server" Height="435px" Width="100%">
        </asp:GridView>
    </form>
</body>
</html>
