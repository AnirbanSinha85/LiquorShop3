<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Report_Product_Wise_Sale_Valuation.aspx.cs" Inherits="Report_Product_Wise_Sale_Valuation" %>

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
                <table style="width: 50%;" class="tbl_style">
                    <tr>
                        <td colspan="7" class="tbl_Header">
                            Product Wise Sale Valuation</td>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
