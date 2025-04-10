<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="masstech_task_2_register_login_email.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="User Id"></asp:Label> 
            &nbsp; 
            <asp:TextBox ID="txtuserid" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtuserid"></asp:RequiredFieldValidator>
            
            <br />
            <br />
            
            <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label> 
            &nbsp;<asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtemail"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail" ErrorMessage="Enter Valid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            
            <br />
            <br />
            
            <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label> 
            &nbsp;<asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPass"></asp:RequiredFieldValidator>

            <br />
            <br />
            <asp:Button ID="btnsignup" runat="server" OnClick="btnsignup_Click" Text="Sign Up" />

        </div>
    </form>
</body>
</html>
