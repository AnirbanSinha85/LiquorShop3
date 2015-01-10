<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Report_Brand_Wise_Purchase.aspx.cs" Inherits="Report_Brand_Wise_Purchase" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <table style="width: 70%;" class="tbl_style">
            <tr>
                <td colspan="9" class="tbl_Header">
                    Brand Wise Purchase
                </td>
            </tr>
            <tr>
                <td>
                    Brand
                </td>
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
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:GridView ID="gvPurcase_Invoice" runat="server" CellPadding="3" Width="100%"
            DataKeyNames="Purchase_Invoice_ID" GridLines="Horizontal" AutoGenerateColumns="False"
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="Category_Name" HeaderText="Category" />
                <asp:BoundField DataField="Brand_Name" HeaderText="Brand" />
                <asp:BoundField DataField="Size_Name" HeaderText="Size" />
                <asp:BoundField DataField="Product_Name" HeaderText="Product" />
                <asp:BoundField DataField="Batch_No" HeaderText="Batch No" />
                <asp:BoundField DataField="Quantity_In_Pce" HeaderText="Quantity (PCS.)" />
                <asp:BoundField DataField="Quantity_In_Box" HeaderText="Quantity (CASE)" />
                <asp:BoundField DataField="Rate" HeaderText="Rate">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Standerd_Rebet" HeaderText="Discount Per Case">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Amount" HeaderText="Amount">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" HorizontalAlign="Left" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        </asp:GridView>
    </div>
</asp:Content>
