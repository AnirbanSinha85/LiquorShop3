<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_Claim_Print.aspx.cs"
    Inherits="Report_Claim_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Claim Report</title>
      <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
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
        <div align="center" style="font-family: SimSun-ExtB; font-size: medium;">
            New Road-Bye Pass Road Crossing
            <br />
            F.L.OFF SHOP
            <br />
            Sen Raleigh Road , Kumarpur More Asansol<br />
            Licence : DEBDUTTTA ROY
            <asp:Literal ID="view_Claim_print" runat="server"></asp:Literal><br />
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
