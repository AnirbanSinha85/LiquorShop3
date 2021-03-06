﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_Product_Wise_Detail_Stock_Print.aspx.cs"
    Inherits="Report_Product_Wise_Detail_Stock_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Wise Detail</title>
    <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
      <script language="javascript" type="text/javascript">
        function Print() {
            document.getElementById("cmdPrint").style.display = "none";
            document.getElementById("cmdBack").style.display = "none";
            

            window.print();
            document.getElementById("cmdPrint").style.display = "";
            document.getElementById("cmdBack").style.display = "";

        }
    
    </script>
    <style type="text/css">
        @media print
        {
            theads
            {
                display: table-header-group;
                width:100%;
            }
            tfoot
            {
                display: table-footer-group;
            }
        }
        @media screen
        {
            thead
            {
                display: block;
                width:100%;
            }
            tfoot
            {
                display: block;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <asp:Literal ID="view_Product_Wise_Stock_print" runat="server"></asp:Literal><br />
    </div>
    <div align="center">
        <asp:Button runat="server" ID="cmdBack" Text="Back" Style="width: 70px; font-size: x-small"
            OnClick="cmdBack_Click" />
        <input type="button" id="cmdPrint" value="Print" style="width: 70px; font-size: x-small"
            onclick="Print()" /></div>
     
    </form>
</body>
</html>
