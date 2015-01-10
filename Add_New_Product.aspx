<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="Add_New_Product.aspx.cs" Inherits="Admin_Add_New_Product" %>

<%@ Register Namespace="CustomControls" TagPrefix="ctrl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <div align="center">
                <table style="width: 80%;" class="tbl_style">
                    <tr>
                        <td colspan="9" class="tbl_Header">
                            Add New Product
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Bar Code
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBarCode" runat="server"></asp:TextBox>
                        </td>
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
                    </tr>
                    <tr>
                        <td align="left">
                            Product Name
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtProductName"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Size
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td style="margin-left: 200px" align="left">
                            <asp:DropDownList ID="ddlSize" runat="server" ValidationGroup="V">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSize"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Avalable Quantity
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td style="margin-left: 240px" align="left">
                            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtQuantity_FilteredTextBoxExtender" FilterType="Numbers"
                                runat="server" TargetControlID="txtQuantity">
                            </asp:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtQuantity"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Standerd Rebet
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStanderdRebet" runat="server"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtStanderdRebet_FilteredTextBoxExtender" FilterType="Numbers"
                                runat="server" TargetControlID="txtStanderdRebet">
                            </asp:FilteredTextBoxExtender>
                        </td>
                        <td align="left">
                            MRP
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtMRP" runat="server"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtMRP_FilteredTextBoxExtender" runat="server" FilterMode="ValidChars"
                                TargetControlID="txtMRP" ValidChars="0123456789.">
                            </asp:FilteredTextBoxExtender>
                        </td>
                        <td align="left">
                            Sort Code
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSortCode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="9">
                            <asp:Button ID="cmdSave" runat="server" Text="Create" OnClick="cmdSave_Click" ValidationGroup="V" />
                            <asp:Button ID="cmdReset" runat="server" Text="Reset" OnClick="cmdReset_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div>
                <table width="100%">
                    <tr>
                        <td>
                            Product Name
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtProductNameSearch" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="cmdSearch" runat="server" Text="Search" OnClick="cmdSearch_Click" />
                        </td>
                         <td>
                            Sort Code
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearchSortCode" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="cmdSortCodeSearch" runat="server" OnClick="cmdSortCodeSearch_Click"
                                Text="Sort Code Search" />
                        </td>
                    </tr>
                  
                </table>
            </div>
            <br />
            <div>
                <ctrl:ExGridView ID="gvProduct" runat="server" CellPadding="4" ForeColor="#333333"
                    GridHeight="280px" Width="100%" DataKeyNames="Product_ID" GridLines="None" AutoGenerateColumns="False"
                    AllowPaging="True" OnPageIndexChanging="gvProduct_PageIndexChanging" OnRowDeleting="gvProduct_RowDeleting"
                    PageSize="300" EnableModelValidation="True">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="~/images/Edit.jpg" ToolTip="Edit"
                                                Height="20px" Width="20px" OnClick="imgbtnEdit_Click" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" runat="server" ToolTip="Delete"
                                                OnClientClick="return confirm('Are you sure you want to delete this product?');"
                                                ImageUrl="~/images/delete.jpg"   Height="20px" Width="20px" />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="5%" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Product_ID" HeaderText="P#" HeaderStyle-Width="3%" HeaderStyle-HorizontalAlign="Left"
                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="3%"></asp:BoundField>
                        <asp:BoundField DataField="Category_Name" HeaderText="Category Name" HeaderStyle-Width="10%"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="10%">
                        </asp:BoundField>
                        <asp:BoundField DataField="Brand_Name" HeaderText="Brand Name" HeaderStyle-Width="10%"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="10%">
                        </asp:BoundField>
                        <asp:BoundField DataField="Bar_Code" HeaderText="Bar Code" HeaderStyle-Width="10%"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="10%">
                        </asp:BoundField>
                        <asp:BoundField DataField="Size_Name" HeaderText="Size Name" HeaderStyle-Width="7%"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="7%">
                        </asp:BoundField>
                        <asp:BoundField DataField="Product_Name" HeaderText="Product Name" HeaderStyle-Width="25%"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="25%">
                        </asp:BoundField>
                        <asp:BoundField DataField="Standerd_Rebet" HeaderText="Standerd Rebet" HeaderStyle-Width="10%"
                            HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%">
                        </asp:BoundField>
                        <asp:BoundField DataField="Avalable_Quantity" HeaderText="Avalable" HeaderStyle-Width="5%"
                            HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="5%">
                        </asp:BoundField>
                        <asp:BoundField DataField="MRP" HeaderText="MRP" HeaderStyle-Width="7%" HeaderStyle-HorizontalAlign="Right"
                            ItemStyle-HorizontalAlign="Right" ItemStyle-Width="7%"></asp:BoundField>
                        <asp:BoundField DataField="Sort_Code" HeaderText="Sort Code" HeaderStyle-Width="7%"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="7%">
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </ctrl:ExGridView>
                <asp:Label ID="lblresult" runat="server" />
                <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup"
                    PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlpopup" runat="server" BackColor="White">
                    <%--Style="display: none"--%>
                    <table width="100%" style="border: Solid 3px #3D73B1; width: 100%;" cellpadding="5px"
                        class="tbl_style" cellspacing="0">
                        <tr class="popUpheader">
                            <td colspan="9" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                                align="center">
                                Update Brand
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblID" runat="server" Text="Label" Visible="False"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
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
                                <asp:DropDownList ID="ddlEditCategory" runat="server" ValidationGroup="V">
                                </asp:DropDownList>
                                <%-- <asp:Label ID="lblEditCategory" runat="server" Text="Label"></asp:Label>--%>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCategory"
                                    ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                                Brand
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <%--                                <asp:Label ID="lblEditBrand" runat="server" Text="Label"></asp:Label>--%>
                                <asp:DropDownList ID="ddlEditBrand" runat="server" ValidationGroup="V">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlBrand"
                                    ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                                MRP
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEditMRP" runat="server"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789."
                                    FilterMode="ValidChars" TargetControlID="txtMRP">
                                </asp:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Size
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td style="margin-left: 200px" align="left">
                                <%-- <asp:Label ID="lblEditSize" runat="server" Text="Label"></asp:Label>--%>
                                <asp:DropDownList ID="ddlEditSize" runat="server" ValidationGroup="V">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlSize"
                                    ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                                Product Name
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEditProductName" runat="server" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtProductName"
                                    ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                                Standerd Rebet
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEditStanderdRebet" runat="server"></asp:TextBox>
                                <%-- <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" FilterType="Numbers"
                                runat="server" TargetControlID="txtEditStanderdRebet">
                            </asp:FilteredTextBoxExtender>--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Avalable Quantity
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td style="margin-left: 240px" align="left">
                                <asp:TextBox ID="txtEditQuantity" runat="server"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" FilterType="Numbers" runat="server"
                                    TargetControlID="txtQuantity">
                                </asp:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtQuantity"
                                    ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                                Bar Code
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEditBarCode" runat="server"></asp:TextBox>
                            </td>
                            <td align="left">
                                Sort Code
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEditSortCode" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9" align="center">
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
