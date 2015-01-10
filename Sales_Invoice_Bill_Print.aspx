<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sales_Invoice_Bill_Print.aspx.cs"
    Inherits="Admin_Sales_Invoice_Bill_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Liquor-Shop</title>
    <%--<style type="text/css">
	    BR.page { PAGE-BREAK-AFTER: always }
	    #img1
        {
            width: 93px;
            height: 51px;
        }
	</style> --%>
    <style type="text/css">
        @page
        {
            height:10px;
            width:20px;
           /* size: 8.5in 11in;  width height */
        }
    </style>
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
        <div align="center" style="font-family: SimSun-ExtB; font-size: small;">
            New Road-Bye Pass Road Crossing
            <br />
            F.L.OFF SHOP
            <br />
            Sen Raleigh Road , Kumarpur More Asansol<br />
            Licence : DEBDUTTTA ROY
            <asp:Literal ID="view_Sales_Invoice_print" runat="server"></asp:Literal><br />
        </div>
        <div align="center">
            <asp:Button runat="server" ID="cmdBack" Text="Back" Style="width: 70px; font-size: x-small"
                OnClick="cmdBack_Click" />
            <input type="button" id="cmdPrint" value="Print" style="width: 70px; font-size: x-small"
                onclick="Print()" /></div>
    </div>
    <%--  <div>
        <table width='100%' cellspacing='3' cellpadding='4' style='border-style: dotted;
            border-width: 1px; border-color: inherit; font-family: SimSun-ExtB; font-size: small;'>
            <tr>
                <td colspan='5' style='border-bottom-style: dotted; border-bottom-width: 1px' align='left'>
                    Bill No : 54
                </td>
            </tr>
            <tr>
                <td style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted;
                    border-right-width: 1px;' align='left'>
                    Particulars
                </td>
                <td style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted;
                    border-right-width: 1px;' align='right'>
                    Qty.
                </td>
                <td style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted;
                    border-right-width: 1px;' align='right'>
                    MRP
                </td>
                <td style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted;
                    border-right-width: 1px' align='right'>
                    Size
                </td>
                <td style='border-bottom-style: dotted; border-bottom-width: 1px;' align='right'>
                    Amount
                </td>
            </tr>
            <tr>
                <td style='border-right-style: dotted; border-right-width: 1px' align='left'>
                    TUBROG STRONG CAN BEER
                </td>
                <td style='border-right-style: dotted; border-right-width: 1px' align='right'>
                    1
                </td>
                <td style='border-right-style: dotted; border-right-width: 1px' align='right'>
                    65.00
                </td>
                <td style='border-right-style: dotted; border-right-width: 1px' align='right'>
                    500 ML
                </td>
                <td align='right'>
                    65.00
                </td>
            </tr>
            <tr>
                <td colspan='3' style='border-top-style: dotted; border-top-width: 1px;'>
                    Date : 09/30/2013
                </td>
                <td style='border-top-style: dotted; border-top-width: 1px;' align='right'>
                    Total :
                </td>
                <td style='border-top-style: dotted; border-top-width: 1px;' align='right'>
                    65.00
                </td>
            </tr>
        </table>
    </div>--%>
    </form>
</body>
</html>
