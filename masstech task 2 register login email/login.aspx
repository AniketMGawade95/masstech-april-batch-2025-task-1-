<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="masstech_task_2_register_login_email.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>

            <br />
            <br />

            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtpass" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>
