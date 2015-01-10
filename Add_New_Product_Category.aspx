<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="Add_New_Product_Category.aspx.cs" Inherits="Admin_Add_New_Product_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
            <div align="center">
                <table style="width: 70%;" class="tbl_style">
                    <tr>
                        <td colspan="9" class="tbl_Header">
                            Add New Product Category
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Category Name
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCategoryName"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Description
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td style="margin-left: 200px" align="left">
                            <asp:TextBox ID="txtCategoryDesc" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCategoryDesc"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Active
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td style="margin-left: 280px" align="left">
                            <asp:CheckBox ID="chkActive" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="9">
                            <asp:Button ID="cmdSave" runat="server" Text="Create" OnClick="cmdSave_Click" ValidationGroup="V" />
                            <asp:Button ID="cmdReset" runat="server" Text="Reset" OnClick="cmdReset_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="9">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div>
                <asp:GridView ID="gvProduct_Category" runat="server" CellPadding="4" ForeColor="#333333"
                    Width="100%" DataKeyNames="Category_ID" GridLines="None" AutoGenerateColumns="False"
                    AllowPaging="True" EnableModelValidation="True" OnRowDeleting="gvProduct_Category_RowDeleting">
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
                        <asp:TemplateField HeaderText="Category Name">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Category_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category Description">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Category_Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Delete_Flag") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
