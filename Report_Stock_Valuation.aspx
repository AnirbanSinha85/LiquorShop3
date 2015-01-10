<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Report_Stock_Valuation.aspx.cs" Inherits="Report_Stock_Valuation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    
     
   
    <div align="center">
        <table style="width: 50%; " class="tbl_style">
            <tr>
                <td colspan="4" class="tbl_Header">
                    PRODUCT WISE DETAIL STOCK VALUATION
                </td>
            </tr>
            <tr>
                <td align="left">
                    From Date
                </td>
                <td align="left">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate">
                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
                        ControlToValidate="txtFromDate" ValidationGroup="v">*</asp:RequiredFieldValidator>
                </td>
                <td align="left">
                    <asp:Button ID="cmdSearch" runat="server" Text="Search" OnClick="cmdSearch_Click"
                        ValidationGroup="v" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <div align="center">
            <asp:Literal ID="view_Stock_Valuation" runat="server"></asp:Literal><br />
        </div>
    </div>
      
     
    <script src="JS/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery-scrolltofixed.js"></script>
    <script type="text/javascript">
        $('#test').scrollToFixed({
             
        });
    </script>

    <div align="center">
        <asp:GridView ID="gvStockValuation" runat="server" CellPadding="4" ForeColor="#333333"
            Visible="false" Width="100%" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
            EnableModelValidation="True" OnPageIndexChanging="gvStockValuation_PageIndexChanging"
            PageSize="20">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Product_Name" HeaderText="Product Name" />
                <asp:BoundField DataField="Size_Name" HeaderText="Size Name" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" />
                <asp:BoundField DataField="MRP" HeaderText="MRP">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Stock_Valuation" HeaderText="Stock Valuation">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
    </div>
</asp:Content>
