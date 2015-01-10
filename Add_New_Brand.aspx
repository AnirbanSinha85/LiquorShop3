<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="Add_New_Brand.aspx.cs" Inherits="Admin_Add_New_Brand" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
                            Add New Brand
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Brand Name
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBrandName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBrandName"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Description
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td style="margin-left: 200px" align="left">
                            <asp:TextBox ID="txtBrandDesc" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBrandDesc"
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
                <asp:GridView ID="gvBrand" runat="server" CellPadding="4" ForeColor="#333333" Width="100%"
                    DataKeyNames="Brand_ID" GridLines="None" AutoGenerateColumns="False" 
                    AllowPaging="True" onrowdeleting="gvBrand_RowDeleting">
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
                        <asp:BoundField DataField="Brand_Name" HeaderText="Brand Name" />
                        <asp:BoundField DataField="Brand_Description" HeaderText="Brand Description" />
                        <asp:BoundField DataField="Delete_Flag" HeaderText="Status" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                <asp:Label ID="lblresult" runat="server" />
                <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup"
                    PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Style="display: none">
                    <table width="100%" style="border: Solid 3px #3D73B1; width: 100%;" cellpadding="5px"
                        cellspacing="0">
                        <tr class="popUpheader">
                            <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                                align="center">
                                Update Brand
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Brand ID :
                            </td>
                            <td>
                                <asp:Label ID="lblID" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Brand Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Brand Description :
                            </td>
                            <td>
                                <asp:TextBox ID="txtDesc" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Active :
                            </td>
                            <td>
                                <asp:TextBox ID="txtActive" runat="server" Visible="false" />
                                <asp:CheckBox ID="chkEditActive" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnUpdate" CommandName="Update" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
