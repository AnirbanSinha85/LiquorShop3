<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="Create_New_Sales_Invoice.aspx.cs" Inherits="Admin_Create_New_Sales_Invoice" %>

<%@ Register Namespace="CustomControls" TagPrefix="ctrl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script type="text/javascript" language="javascript">
        $(document).ready(function () {

            $('#<%=gvSalesInvoice.ClientID %>').Scrollable();
        }
)
    </script>--%>
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
                    <ProgressTemplate>
                        <%-- <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ajax-loader.gif" /> Please Wait........--%>
                        <div id="dvProgress" runat="server" style="position: absolute; top: 300px; left: 550px;
                            text-align: center;">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ajax-loader.gif" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <table style="width: 70%;" class="tbl_style">
                    <tr>
                        <td colspan="9" class="tbl_Header">
                            Create New Sales Invoice
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Bill No
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:Label ID="lblBillNo" runat="server" Text="Label"></asp:Label>
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
                            Date
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSalesDate" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="txtInvoiceDate_CalendarExtender" runat="server" TargetControlID="txtSalesDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSalesDate"
                                ValidationGroup="V" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Batch No
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBatch" runat="server"></asp:TextBox>
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
                            Quantity
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtQty"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Bar Code
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBarCode" runat="server" AutoPostBack="True" OnTextChanged="txtBarCode_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBarCode"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
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
                            <asp:Button ID="cmdNewBill" runat="server" OnClick="cmdNewBill_Click" Text="New Bill" />
                            <asp:Button ID="cmdPrint" runat="server" OnClick="cmdPrint_Click" Text="Print" />
                        </td>
                    </tr>
                </table>
                <br />
                 <div>
                   <ctrl:ExGridView ID="gvSalesInvoice" runat="server" AutoGenerateColumns="False" 
                         CellPadding="4"  GridHeight="400px"
                        EnableModelValidation="True" DataKeyNames="Sales_Invoice_ID" ForeColor="#333333"
                        GridLines="None" Width="100%" OnRowDataBound="gvSalesInvoice_RowDataBound" ShowFooter="True"
                        OnRowDeleting="gvSalesInvoice_RowDeleting"  >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                                        ImageUrl="~/images/delete.jpg" ToolTip="Delete" Height="20px" Width="20px" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                <ItemStyle HorizontalAlign="Left" Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item Number">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                <ItemStyle Width="10%" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Sales_Qty" HeaderText="Sales Qty" >
                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MRP" HeaderText="MRP"  >
                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Size">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Size_Name") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Size_Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalML" runat="server" />
                                </FooterTemplate>
                                <HeaderStyle HorizontalAlign="Right" Width="10%" />
                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                                <FooterStyle HorizontalAlign="Right" />
                                
                            </asp:TemplateField>
                            <asp:BoundField DataField="Product_Name" HeaderText="Particulars" >
                            <HeaderStyle HorizontalAlign="Left" Width="30%" />
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Amount") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    Total Amount (Rs.) :
                                    <asp:Label ID="lblTotal" runat="server" />
                                </FooterTemplate>
                                
                                <HeaderStyle HorizontalAlign="Right" Width="20%" />
                                <ItemStyle HorizontalAlign="Right" Width="20%" />
                                <FooterStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                   </ctrl:ExGridView>
                </div>
                 
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div align="center">
    </div>
</asp:Content>
