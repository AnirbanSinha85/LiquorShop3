<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="Create_New_Purchase_Invoice.aspx.cs" Inherits="Admin_Create_New_Purchase_Invoice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <div align="center" style="height: 100%">
                <table style="width: 100%;" class="tbl_style">
                    <tr>
                        <td colspan="9" class="tbl_Header">
                            Create New Purchase Invoice &nbsp; &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Invoice No
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtInvoiceNo" runat="server" ValidationGroup="V" AutoPostBack="True"
                                OnTextChanged="txtInvoiceNo_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtInvoiceNo"
                                ValidationGroup="V" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Invoice Date
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtInvoiceDate" runat="server" ValidationGroup="v"></asp:TextBox>
                            <asp:CalendarExtender ID="txtInvoiceDate_CalendarExtender" runat="server" TargetControlID="txtInvoiceDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtInvoiceDate"
                                ValidationGroup="V" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Receive Date
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtReceiveDate" runat="server" ValidationGroup="v"></asp:TextBox>
                            <asp:CalendarExtender ID="txtReceiveDate_CalendarExtender" runat="server" TargetControlID="txtReceiveDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtInvoiceDate"
                                ValidationGroup="V" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Select Supplier
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlSupplier" runat="server" AutoPostBack="True" ValidationGroup="V"
                                OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlSupplier"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Supplier Name
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSupplierName" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td align="left">
                            Supplier Phone No
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSupplierPhNo" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Pass No
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPassNo" runat="server"></asp:TextBox>
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
                    </tr>
                    <tr>
                        <td align="left">
                            Product Name
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlProductName" runat="server" ValidationGroup="V">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlProductName"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Quantity (CASE)
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtQtyInBox" runat="server" AutoPostBack="True" OnTextChanged="txtQtyInBox_TextChanged"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                                TargetControlID="txtQtyInBox">
                            </asp:FilteredTextBoxExtender>
                        </td>
                        <td align="left">
                            Quantity (PCS.)
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtQtyInPce" runat="server" AutoPostBack="True" OnTextChanged="txtQtyInPce_TextChanged"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers"
                                TargetControlID="txtQtyInPce">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Unit Of Packing
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPcsInBox" runat="server" Enabled="false"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtPcsInBox_FilteredTextBoxExtender" FilterType="Numbers"
                                runat="server" TargetControlID="txtPcsInBox">
                            </asp:FilteredTextBoxExtender>
                        </td>
                        <td align="left">
                            Rate Per Case
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td style="margin-left: 240px" align="left">
                            <asp:TextBox ID="txtRate" runat="server" CssClass="txt_Style" AutoPostBack="True"
                                OnTextChanged="txtRate_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRate"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterMode="ValidChars"
                                ValidChars="0123456789." TargetControlID="txtRate">
                            </asp:FilteredTextBoxExtender>
                        </td>
                        <td align="left">
                            Amount
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtAmount" runat="server" CssClass="txt_Style"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterMode="ValidChars"
                                ValidChars="0123456789." TargetControlID="txtAmount">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Batch No
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBatchNo" runat="server"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:Button ID="cmdAdd" runat="server" OnClick="cmdAdd_Click" Text="Add" ValidationGroup="V" />
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left" style="margin-left: 240px">
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
                        <td align="center" colspan="9">
                            <div style="overflow: scroll; height: 150px;">
                                <asp:GridView ID="gvPurcase_Invoice" runat="server" CellPadding="3" Width="100%"
                                    DataKeyNames="Purchase_Invoice_ID" GridLines="Horizontal" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" 
                                    BorderWidth="1px" onrowdeleting="gvPurcase_Invoice_RowDeleting">
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                                                    ImageUrl="~/images/delete.jpg" ToolTip="Delete" Height="20px" Width="20px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Category_Name" HeaderText="Category" />
                                        <asp:BoundField DataField="Brand_Name" HeaderText="Brand" />
                                        <asp:BoundField DataField="Size_Name" HeaderText="Size" />
                                        <asp:BoundField DataField="Product_Name" HeaderText="Product" />
                                        <asp:BoundField DataField="Batch_No" HeaderText="Batch No" />
                                        <asp:BoundField DataField="Quantity_In_Pce" HeaderText="Quantity (PCS.)" />
                                        <asp:BoundField DataField="Quantity_In_Box" HeaderText="Quantity (CASE)" />
                                        <asp:BoundField DataField="Rate" HeaderText="Rate">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Standerd_Rebet" HeaderText="Discount Per Case">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Amount" HeaderText="Amount">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" HorizontalAlign="Left" />
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="6" rowspan="8" valign="top">
                            <table width="100%">
                                <tr>
                                    <td style="width: 100%">
                                        <div style="overflow: auto; height: 130px;">
                                        </div>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left">
                            Gross Total
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="right">
                            <asp:Label ID="lblGrossTotal" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Standard Rebate
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="right">
                            <asp:Label ID="lblStandardRebate" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Sales Tax
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtSTaxPercent" runat="server" AutoPostBack="True" OnTextChanged="txtSTaxPercent_TextChanged"
                                Width="30px"></asp:TextBox>
                            &nbsp; % &nbsp;
                            <asp:Label ID="lblSTaxAmount" runat="server" Text="Label"></asp:Label>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterMode="ValidChars"
                                TargetControlID="txtSTaxPercent" ValidChars="0123456789.">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Discount
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtDiscount" runat="server" AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged"
                                CssClass="txt_Style" Width="50px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterMode="ValidChars"
                                ValidChars="0123456789." TargetControlID="txtDiscount">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            IC
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtIC" runat="server" AutoPostBack="True" OnTextChanged="txtIC_TextChanged"
                                CssClass="txt_Style" Width="50px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" FilterMode="ValidChars"
                                ValidChars="0123456789." TargetControlID="txtIC">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            TCS
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtTCS" runat="server" AutoPostBack="True" OnTextChanged="txtTCS_TextChanged"
                                CssClass="txt_Style" Width="50px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" FilterMode="ValidChars"
                                ValidChars="0123456789." TargetControlID="txtTCS">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Grand Total
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="right">
                            <asp:Label ID="lblGrandTotal" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Net Payble Amount
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="right">
                            <asp:Label ID="lblNetPay" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
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
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="right">
                            <asp:Button ID="cmdCreate" runat="server" Text="CREATE" OnClick="cmdCreate_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
