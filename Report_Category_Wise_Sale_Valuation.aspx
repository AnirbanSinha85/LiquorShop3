<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Report_Category_Wise_Sale_Valuation.aspx.cs" Inherits="Report_Category_Wise_Quantity_Sale" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <table style="width: 70%;" class="tbl_style">
            <tr>
                <td colspan="9" class="tbl_Header">
                    Category Wise Sale
                    Valuation</td>
            </tr>
            <tr>
                <td>
                    Category
                </td>
                <td>
                    :
                </td>
                <td>
                     <asp:DropDownList ID="ddlCategory" runat="server" ValidationGroup="V">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCategory"
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"  ValidationGroup="V"
                        ControlToValidate="txtFromDate">*</asp:RequiredFieldValidator>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator"   ValidationGroup="V"
                        ControlToValidate="txtToDate">*</asp:RequiredFieldValidator>
                </td>
                <td align="left" style="margin-left: 40px">
                    <asp:Button ID="cmdSearch" runat="server" Text="Search" OnClick="cmdSearch_Click"  ValidationGroup="V" />
                </td>
            </tr>
        </table>
    </div>
    <br />
</asp:Content>

