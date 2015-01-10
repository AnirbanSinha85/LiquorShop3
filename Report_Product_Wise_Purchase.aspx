<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Report_Product_Wise_Purchase.aspx.cs" Inherits="Report_Product_Wise_Purchase" %>

<%@ Register Namespace="CustomControls" TagPrefix="ctrl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div align="center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <table style="width: 80%;" class="tbl_style">
            <tr>
                <td colspan="10" class="tbl_Header">
                    Product&nbsp; Wise Purchase
                </td>
            </tr>
            <tr>
                <td>
                    Product
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddlProduct" runat="server" ValidationGroup="V">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlProduct"
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
                <td align="left">
                    To Date
                </td>
                <td align="left">
                    :
                </td>
                <td align="left" style="margin-left: 40px">
                    <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate">
                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator"
                        ValidationGroup="V" ControlToValidate="txtToDate">*</asp:RequiredFieldValidator>
                </td>
                <td align="left" style="margin-left: 40px">
                    <asp:Button ID="cmdSearch" runat="server" Text="Search" OnClick="cmdSearch_Click"
                        ValidationGroup="V" />
                </td>
                <td>
                    <asp:Button ID="cmdPrint" runat="server" Text="Print" 
                        onclick="cmdPrint_Click" /></td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <ctrl:ExGridView ID="gvPurcase_Invoice" runat="server" CellPadding="3" Width="100%" GridHeight="450px" AllowPaging="true" PageSize="300"
            DataKeyNames="Purchase_Invoice_ID" GridLines="Horizontal" AutoGenerateColumns="False"
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <%--<asp:BoundField DataField="Category_Name" HeaderText="Category" />
                <asp:BoundField DataField="Brand_Name" HeaderText="Brand" />
                <asp:BoundField DataField="Size_Name" HeaderText="Size" />
                <asp:BoundField DataField="Product_Name" HeaderText="Product" />
                <asp:BoundField DataField="Batch_No" HeaderText="Batch No" />
                <asp:BoundField DataField="Quantity_In_Pce" HeaderText="Quantity (PCS.)" />
                <asp:BoundField DataField="Quantity_In_Box" HeaderText="Quantity (CASE)" />
                <asp:BoundField DataField="Purchase_Invoice_Date" HeaderText="Purchase Date" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="Rate" HeaderText="Rate">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Standerd_Rebet" HeaderText="Discount Per Case">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Amount" HeaderText="Amount">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>--%>
                <asp:BoundField DataField="Purchase_Invoice_Date" HeaderText="Purchase Date" DataFormatString="{0:dd-MM-yyyy}" HeaderStyle-Width="9%" ItemStyle-Width="9%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                <asp:BoundField DataField="Product_Name" HeaderText="Product" HeaderStyle-Width="20%" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                <asp:BoundField DataField="Batch_No" HeaderText="Batch No" HeaderStyle-Width="7%" ItemStyle-Width="7%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                <asp:BoundField DataField="Pass_No" HeaderText="Pass No" HeaderStyle-Width="7%" ItemStyle-Width="7%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                <asp:BoundField DataField="Supplier_Name" HeaderText="Supplier Name" HeaderStyle-Width="20%" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                <asp:BoundField DataField="Quantity_In_Pce" HeaderText="PCS."  HeaderStyle-Width="8%" ItemStyle-Width="8%" HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="right"/>
                <asp:BoundField DataField="Quantity_In_Box" HeaderText="CASE"  HeaderStyle-Width="8%" ItemStyle-Width="8%" HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="right"/>
                <asp:BoundField DataField="Amount" HeaderText="Amount" HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="right">
                </asp:BoundField>
            </Columns>
           <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />   
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" HorizontalAlign="Left" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        </ctrl:ExGridView>
    </div>
</asp:Content>

