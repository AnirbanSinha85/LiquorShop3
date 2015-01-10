<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Report_Product_Wise_Detail_Stock.aspx.cs" Inherits="Report_Product_Wise_Detail_Stock" %>
    
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <div align="center">
        <table style="width: 50%;" class="tbl_style">
            <tr>
                <td colspan="4" class="tbl_Header">
                    PRODUCT WISE DETAIL STOCK
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
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left">
                    <asp:Button ID="cmdSearch" runat="server" Text="Search" OnClick="cmdSearch_Click"
                        ValidationGroup="v" />
                    <asp:Button ID="cmdPrint" runat="server" Text="Print" 
                        onclick="cmdPrint_Click" ValidationGroup="v" />
                </td>
                <td align="left">
                    &nbsp;
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
