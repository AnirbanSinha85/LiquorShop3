<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Log-In</title>
    <link href="LogInCSS/login-box.css" rel="stylesheet" type="text/css" />
     
</head>
<body>
    <form id="form1" runat="server">
     <div align="center" style="padding: 100px;">
        <div id="login-box">
            <h2>
                Log-In</h2>
            A Wine Shop System.
            <br />
            <br />
            <div id="login-box-name" style="margin-top: 20px;">
                User Name:
            </div>
            <div id="login-box-field" style="margin-top: 20px;">
                <asp:TextBox ID="txtUserName" runat="server" class="form-login"></asp:TextBox>
            </div>
            <div id="login-box-name">
                Password:</div>
            <div id="login-box-field">
                <asp:TextBox ID="txtPassword" runat="server" class="form-login" 
                    TextMode="Password"></asp:TextBox>
            </div>
            <br />
            &nbsp;
            <br />
            <br />
            <asp:ImageButton ID="cmdLogIn" runat="server" ImageUrl="~/LogInImages/login-btn.png"
                Style="margin-left: 90px;" onclick="cmdLogIn_Click"  />
        </div>
    </div>
    </form>
</body>
</html>
