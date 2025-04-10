<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="masstech_task_1_company_mail_sending.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets\StyleSheet1.css" rel="stylesheet" />
</head>
<body>

    <div class="wrapper">

    <form id="form1" runat="server">


        <h1>Interview Registration</h1>


        <div class="input-box mmm">
            <br />
            <asp:Label ID="lblResume" runat="server" Text="Resume"></asp:Label>
            <asp:FileUpload ID="FileUploadResume" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUploadResume" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            
        </div>

        <div class="input-box">
            <asp:Label ID="lblStream" runat="server" Text="Stream"></asp:Label>  
            <asp:DropDownList ID="DropDownListStream" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListStream_SelectedIndexChanged">
                <asp:ListItem>SELECT</asp:ListItem>
                <asp:ListItem>BCA</asp:ListItem>
                <asp:ListItem>MCA</asp:ListItem>
                <asp:ListItem>BSC CS</asp:ListItem>
                <asp:ListItem>MSC CS</asp:ListItem>
                <asp:ListItem>BSC IT</asp:ListItem>
                <asp:ListItem>MSC IT</asp:ListItem>
                <asp:ListItem>BTECH CS</asp:ListItem>
                <asp:ListItem>MTECH CS</asp:ListItem>
                <asp:ListItem>BTECH IT</asp:ListItem>
                <asp:ListItem>MTECH IT</asp:ListItem>
                <asp:ListItem>BE CS</asp:ListItem>
                <asp:ListItem>ME CS</asp:ListItem>
                <asp:ListItem>BE IT</asp:ListItem>
                <asp:ListItem>ME IT</asp:ListItem>
                <asp:ListItem>DIPLOMA CS</asp:ListItem>
                <asp:ListItem>DIPLOMA IT</asp:ListItem>
                <asp:ListItem>OTHERS</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownListStream" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
           
        </div>

        <div class="input-box">
            <asp:Label ID="lblExperience" runat="server" Text="Experience"></asp:Label>
            <asp:DropDownList ID="DropDownListExperience" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListExperience_SelectedIndexChanged">
                <asp:ListItem>SELECT</asp:ListItem>
                <asp:ListItem>FRESHER</asp:ListItem>
                <asp:ListItem>EXPERIENCED</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownListExperience" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
           
        </div>

         <div class="input-box">
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter Valid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
        <div class="input-box">
            <asp:Label ID="lblContactno" runat="server" Text="Contact Number"></asp:Label>
            <asp:TextBox ID="txtContact" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtContact"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContact" ErrorMessage="Enter A Proper Number" ForeColor="Red" ValidationExpression="^[6-9]\d{9}$"></asp:RegularExpressionValidator>
            
        </div>


        <div class="input-box">
            <asp:Label ID="lblCtc" runat="server" Text="CTC"></asp:Label>
            <asp:TextBox ID="txtctc" runat="server" TextMode="Number" class="input"></asp:TextBox>
        </div>
        <div class="input-box">
            <asp:Label ID="lblEctc" runat="server" Text="ECTC"></asp:Label>
            <asp:TextBox ID="txtEctc" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <div class="input-box">
            <asp:Label ID="lblNp" runat="server" Text="Notice Period In Months"></asp:Label>
            <asp:TextBox ID="txtNoticePeriod" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <asp:Button ID="btnUpload" runat="server" Text="UPLOAD" class="btn" OnClick="btnUpload_Click" BackColor="#0099FF" ForeColor="White" Height="25px" Width="100px" />
    </form>

    </div>

</body>
</html>
