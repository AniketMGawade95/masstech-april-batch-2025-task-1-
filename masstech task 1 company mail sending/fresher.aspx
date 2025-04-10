<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fresher.aspx.cs" Inherits="masstech_task_1_company_mail_sending.fresher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="assets\StyleSheet1.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <div class="wrapper">

    <form id="form1" runat="server">
         <h1>Day And Time Registration</h1>
        <div>
            <div class="input-box">
                <asp:Label ID="lblDay" runat="server" Text="Day"></asp:Label>
                <asp:DropDownList ID="DropDownListDays" runat="server" AutoPostBack="True">
                    <asp:ListItem>SELECT</asp:ListItem>
                    <asp:ListItem>MONDAY</asp:ListItem>
                    <asp:ListItem>TUESDAY</asp:ListItem>
                    <asp:ListItem>WEDNESDAY</asp:ListItem>
                    <asp:ListItem>THURSDAY</asp:ListItem>
                    <asp:ListItem>FRIDAY</asp:ListItem>
                </asp:DropDownList>

            </div>
            
            <div class="input-box">
                <asp:Label ID="lblTime" runat="server" Text="Time"></asp:Label>
                <asp:DropDownList ID="DropDownListTiming" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTiming_SelectedIndexChanged">
                    <asp:ListItem>SELECT</asp:ListItem>
                    <asp:ListItem>9-10AM</asp:ListItem>
                    <asp:ListItem>10-11AM</asp:ListItem>
                    <asp:ListItem>11-12AM</asp:ListItem>
                    <asp:ListItem>12-1PM</asp:ListItem>
                    <asp:ListItem>1-2PM</asp:ListItem>
                    <asp:ListItem>2-3PM</asp:ListItem>
                    <asp:ListItem>3-4PM</asp:ListItem>
                    <asp:ListItem>4-5PM</asp:ListItem>
                </asp:DropDownList>

                <br />

            </div>

            <asp:Button ID="btnBook" runat="server" Text="BOOK" OnClick="btnBook_Click" BackColor="#0099FF" ForeColor="White" Height="25px" Width="100px"  />

        </div>
    </form>
    </div>

</body>
</html>
