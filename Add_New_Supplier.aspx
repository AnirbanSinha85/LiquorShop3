<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="Add_New_Supplier.aspx.cs" Inherits="Admin_Add_New_Supplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    
    <div align="center">
        <table style="width: 70%;" class="tbl_style">
            <tr>
                <td colspan="6" class="tbl_Header">
                    Add New Supplier
                </td>
            </tr>
            <tr>
                <td align="left">
                    Supplier Name
                </td>
                <td align="left">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtSupplierName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSupplierName"
                        ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                </td>
                <td align="left">
                    Supplier Address
                </td>
                <td align="left">
                    :
                </td>
                <td style="margin-left: 200px" align="left">
                    <asp:TextBox ID="txtSupplierAddress" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSupplierAddress"
                        ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Supplier PhNo</td>
                <td align="left">
                    :</td>
                <td align="left">
                    <asp:TextBox ID="txtSupplierPhNo" runat="server"></asp:TextBox>
                </td>
                <td align="left">
                    Active</td>
                <td align="left">
                    :</td>
                <td style="margin-left: 200px" align="left">
                    <asp:CheckBox ID="chkActive" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                    <asp:Button ID="cmdSave" runat="server" Text="Create" OnClick="cmdSave_Click" ValidationGroup="V" />
                    <asp:Button ID="cmdReset" runat="server" Text="Reset" OnClick="cmdReset_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:GridView ID="gvSupplier" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
            DataKeyNames="Supplier_ID" GridLines="None" AutoGenerateColumns="False" AllowPaging="True">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/images/update.jpg"
                                        ToolTip="Update" Height="20px" Width="20px" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/images/Cancel.jpg"
                                        ToolTip="Cancel" Height="20px" Width="20px" />
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="~/images/Edit.jpg" ToolTip="Edit"
                                        Height="20px" Width="20px"   />
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                                        OnClientClick="javascript:ConfirmationBox()" ImageUrl="~/images/delete.jpg" ToolTip="Delete"
                                        Height="20px" Width="20px" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Supplier_Name" HeaderText="Supplier Name" />
                <asp:BoundField DataField="Supplier_Address" HeaderText="Supplier Address" />
                <asp:BoundField DataField="Supplier_PhNo" HeaderText="Phone No" />
                <asp:BoundField DataField="Delete_Flag" HeaderText="State" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            
        </asp:GridView>
       
    </div>
</asp:Content>
