<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_Brand_Wise_Sales_Valuation_Print.aspx.cs"
    Inherits="Report_Brand_Wise_Sales_Valuation_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Brand Wise Sales Valuation.aspx</title>
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
        BR.page
        {
            page-break-after: always;
        }
        #img1
        {
            width: 93px;
            height: 51px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <br />
    <br />
    <div align="center" style="top:400px;">
        <asp:Literal ID="view_Brand_Wise_Bill_print" runat="server"></asp:Literal><br />
    </div>
    <div align="center">
        <asp:Button runat="server" ID="cmdBack" Text="Back" Style="width: 70px; font-size: x-small"
            OnClick="cmdBack_Click" />
        <input type="button" id="cmdPrint" value="Print" style="width: 70px; font-size: x-small"
            onclick="Print()" /></div>
    <table>
        <tr>
            <td style="width: 10%">
            <div style=" width:100%; background-color:#ACD3FB; color: #FFFFFF; font-weight: bold;" ></div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
