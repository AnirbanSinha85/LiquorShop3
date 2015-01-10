<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Report_Supplier_Wise_Purchase.aspx.cs" Inherits="Report_Supplier_Wise_Purchase" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
                    <ProgressTemplate>
                        <div id="dvProgress" runat="server" style="position: absolute; top: 300px; left: 550px;
                            text-align: center;">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ajax-loader.gif" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <table style="width: 90%;" class="tbl_style">
                    <tr>
                        <td class="tbl_Header" colspan="10">
                            Supplier Wise Purchase Report
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Select Supplier
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlSupplier" runat="server" ValidationGroup="V">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSupplier"
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator"
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator"
                                ValidationGroup="V" ControlToValidate="txtToDate">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            <asp:Button ID="cmdSearch" runat="server" OnClick="cmdSearch_Click" Text="Search"
                                ValidationGroup="V" />
                        </td>
                    </tr>
                </table>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
