<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Add_New_Claim.aspx.cs" Inherits="Add_New_Claim" %>

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
                        <td colspan="12" class="tbl_Header">
                            Claim
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
                            <asp:DropDownList ID="ddlCategory" runat="server" ValidationGroup="V">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCategory"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Brand
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlBrand" runat="server" ValidationGroup="V">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlBrand"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Size
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlSize" runat="server" ValidationGroup="V" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlSize_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSize"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Product Name
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlProductName" runat="server" ValidationGroup="V" 
                                Width="300px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlProductName"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Date
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtClaimDate" runat="server" ValidationGroup="v"></asp:TextBox>
                            <asp:CalendarExtender ID="txtInvoiceDate_CalendarExtender" runat="server" TargetControlID="txtClaimDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtClaimDate"
                                ValidationGroup="V" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Quantity
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtQuantity"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterMode="ValidChars"
                                ValidChars="0123456789" TargetControlID="txtQuantity">
                            </asp:FilteredTextBoxExtender>
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Button ID="cmdAdd" runat="server" Text="Add" ValidationGroup="V" OnClick="cmdAdd_Click" />
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="gvClaim" runat="server" CellPadding="4" ForeColor="#333333" Width="90%"
                    DataKeyNames="Claim_ID" GridLines="None" AutoGenerateColumns="False" 
                    AllowPaging="True" onpageindexchanging="gvClaim_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                                    ImageUrl="~/images/delete.jpg" ToolTip="Delete" Height="20px" Width="20px" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Category_Name" HeaderText="Category Name" />
                        <asp:BoundField DataField="Brand_Name" HeaderText="Brand Name" />
                        <asp:BoundField DataField="Size_Name" HeaderText="Size Name" />
                        <asp:BoundField DataField="Product_Name" HeaderText="Product Name" />
                        <asp:TemplateField HeaderText="Claim Date">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Claim_Date","{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Clain_Qty" HeaderText="Clain Qty" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
