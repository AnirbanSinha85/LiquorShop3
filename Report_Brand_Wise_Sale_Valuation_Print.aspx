﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_Brand_Wise_Sale_Valuation_Print.aspx.cs"
    Inherits="Report_Brand_Wise_Sale_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function Print() {
            document.getElementById("cmdPrint").style.display = "none";
            document.getElementById("cmdBack").style.display = "none";


            window.print();
            document.getElementById("cmdPrint").style.display = "";
            document.getElementById("cmdBack").style.display = "";

        }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div align="center">
            <asp:Literal ID="view_Brand_Wise_Sale_print" runat="server"></asp:Literal><br />
        </div>
        <div align="center">
            <asp:Button runat="server" ID="cmdBack" Text="Back" Style="width: 70px; font-size: x-small"
                OnClick="cmdBack_Click" />
            <input type="button" id="cmdPrint" value="Print" style="width: 70px; font-size: x-small"
                onclick="Print()" /></div>
    </div>
    
    </form>
</body>
</html>
