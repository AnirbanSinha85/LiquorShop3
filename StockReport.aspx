<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="StockReport.aspx.cs" Inherits="Admin_StockReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div align="center">
        <table style="width: 50%;" class="tbl_style">
            <tr>
                <td colspan="7" class="tbl_Header">
                    Stock Report
                </td>
            </tr>
            <tr>
                <td align="left">
                    Product Category
                </td>
                <td align="left">
                    :
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlCategory" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="left">
                    Brand
                </td>
                <td align="left">
                    :
                </td>
                <td align="left" style="margin-left: 40px">
                    <asp:DropDownList ID="ddlBrand" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="left" style="margin-left: 40px">
                    <asp:Button ID="cmdSearch" runat="server" Text="Search" OnClick="cmdSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div align="center">
        <div style="font-size: 14px; color: Navy">
            Total Items:
            <asp:Label ID="totalcount" runat="server"></asp:Label>
        </div>
        <asp:Repeater ID="rptStockReport" runat="server">
            <HeaderTemplate>
                <table border="0" width="95%" cellpadding="2" cellspacing="1" style="border: 1px solid maroon;">
                    <tr bgcolor="#5D7B9D" style="color: #FFFFFF">
                        <th align="left">
                            Category
                        </th>
                        <th align="left">
                            Brand Name
                        </th>
                        <th align="left">
                            Product Name
                        </th>
                        <th align="left">
                            Size
                        </th>
                        <th align="left">
                            Avalable Quantity
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td width="20%">
                        <%# DataBinder.Eval(Container, "DataItem.Category_Name")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container, "DataItem.Brand_Name")%>
                    </td>
                    <td width="20%">
                        <%# DataBinder.Eval(Container, "DataItem.Product_Name")%>
                    </td>
                    <td width="20%">
                        <%# DataBinder.Eval(Container, "DataItem.Size_Name")%>
                    </td>
                    <td width="20%">
                        <%# DataBinder.Eval(Container, "DataItem.Avalable_Quantity")%>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr bgcolor="#e8e8e8">
                    <td width="20%">
                        <%# DataBinder.Eval(Container, "DataItem.Category_Name")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container, "DataItem.Brand_Name")%>
                    </td>
                    <td width="20%">
                        <%# DataBinder.Eval(Container, "DataItem.Product_Name")%>
                    </td>
                    <td width="20%">
                        <%# DataBinder.Eval(Container, "DataItem.Size_Name")%>
                    </td>
                    <td width="20%">
                        <%# DataBinder.Eval(Container, "DataItem.Avalable_Quantity")%>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
