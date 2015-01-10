<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="View_Sales_Invoice.aspx.cs" Inherits="Admin_View_Sales_Invoice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <div align="center">
        <table style="width: 50%;" class="tbl_style">
            <tr>
                <td colspan="7" class="tbl_Header">
                    View Sales Invoice
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
                </td>
                <td align="left" style="margin-left: 40px">
                    <asp:Button ID="cmdSearch" runat="server" Text="Search" OnClick="cmdSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div align="center">
        <asp:GridView ID="gvSales_Invoice_View" runat="server" CellPadding="4" Width="50%" EmptyDataText="No Data Found" ShowHeader="true"
            DataKeyNames="Bill_No" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC"
            BorderStyle="None" BorderWidth="1px" AllowPaging="True" 
            OnPageIndexChanging="gvSales_Invoice_View_PageIndexChanging" 
            onrowdeleting="gvSales_Invoice_View_RowDeleting">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                         OnClientClick="javascript:return confirm('Are you sure?');"
                            ImageUrl="~/images/delete.jpg" ToolTip="Delete" Height="20px" Width="20px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bill No">
                    <ItemTemplate>
                        <a href='<%#"Sales_Invoice_Bill_Print.aspx?Bno="+DataBinder.Eval(Container.DataItem,"Bill_No") %>'>
                            <%#Eval("Bill_No")%>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Total_Amount" HeaderText="Total_Amount">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Bill_Date" HeaderText="Bill Date" DataFormatString="{0:d}" />
                <asp:BoundField DataField="User_Name" HeaderText="Created By" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" HorizontalAlign="Left" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        </asp:GridView>
    </div>
</asp:Content>
