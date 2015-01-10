<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="Add_New_Size.aspx.cs" Inherits="Admin_Add_New_Size" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                <table style="width: 80%;" class="tbl_style">
                    <tr>
                        <td colspan="12" class="tbl_Header">
                            Add New Size
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Size
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSize" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSize"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Description
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td style="margin-left: 200px" align="left">
                            <asp:TextBox ID="txtSizeDesc" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSizeDesc"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Pcs In Box
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPcsInBox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPcsInBox"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                                   <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers"
                                TargetControlID="txtPcsInBox">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td align="left">
                            Active
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="chkActive" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Size In ML
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSizeInML" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSizeInML"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                                TargetControlID="txtSizeInML">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td style="margin-left: 200px" align="left">
                            &nbsp;
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
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="12">
                            <asp:Button ID="cmdSave" runat="server" Text="Create" OnClick="cmdSave_Click" ValidationGroup="V" />
                            <asp:Button ID="cmdReset" runat="server" Text="Reset" OnClick="cmdReset_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="12">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div>
                <asp:GridView ID="gvSize" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false"
                    Width="100%" DataKeyNames="Size_ID" GridLines="None" AutoGenerateColumns="False"
                    AllowPaging="True" onrowdeleting="gvSize_RowDeleting">
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
                        <asp:TemplateField HeaderText="Size">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Size_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Size Description">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Size_Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Delete_Flag") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pcs In Box">
                            <ItemTemplate>
                                <asp:Label ID="Label42" runat="server" Text='<%# Bind("Pcs_In_Box") %>'></asp:Label>
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
