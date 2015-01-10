<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Report_Category_Wise_Detail_Stock.aspx.cs" Inherits="Report_Category_Wise_Detail_Stock" %>
    
<%@ Register Namespace="CustomControls" TagPrefix="ctrl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type ="text/javascript">
     $(document).ready(function () {
         $("#<%=gvProductStock.ClientID%> tr").hover(function () {
             $(this).css("background-color", "Lightgrey");
         },
                function () {
                    $(this).css("background-color", "#ffffff");
                });
     }); s
    </script>
    <div align="center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <table style="width: 70%;" class="tbl_style">
            <tr>
                <td colspan="9" class="tbl_Header">
                    Brand Wise Stock</td>
            </tr>
            <tr>
                <td>
                    Brand</td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddlBrand" runat="server" ValidationGroup="V">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlBrand"
                        ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                </td>
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
                        ValidationGroup="V" ControlToValidate="txtFromDate">*</asp:RequiredFieldValidator>
                </td>
                <td align="left" style="margin-left: 40px">
                    <asp:Button ID="cmdSearch" runat="server" Text="Search" OnClick="cmdSearch_Click"
                        ValidationGroup="V" />
                </td>
                <td align="left">
                    <asp:Button ID="cmdPrint" runat="server" Text="Print"  ValidationGroup="V" 
                        onclick="cmdPrint_Click" />
                </td>
            </tr>
        </table>
    </div>
    <br />

    <div style=" width:100%">
       <ctrl:ExGridView ID="gvProductStock" runat="server" AutoGenerateColumns="False" CellPadding="4" GridHeight="400px" AllowPaging="true"
            EnableModelValidation="True" DataKeyNames="Product_ID" ForeColor="#333333" GridLines="None" PageSize="300"
            Width="100%"  >
            
            <Columns>
                <asp:BoundField DataField="Product_Name" HeaderText="PRODUCT NAME" HeaderStyle-Width="30%" ItemStyle-Width="30%"/>
                <asp:BoundField DataField="Size_In_ML" HeaderText="PACK" HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="O_Balance" HeaderText="OPENING" HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="Today_Total_Purchase" HeaderText="PURCHASE" HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="Total_Openning_Purchase" HeaderText="TOTAL" HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="Today_Total_Sales_Qty" HeaderText="SALE" HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="ToDay_Total_Claim_Qty" HeaderText="B.S.L" HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="Total_BSL_Sales" HeaderText="TOTAL" HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="STOCK" HeaderText="BALANCE" HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"/>
            </Columns>
            
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
             
        </ctrl:ExGridView>
    </div>
</asp:Content>
