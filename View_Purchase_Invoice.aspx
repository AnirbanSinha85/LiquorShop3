<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="View_Purchase_Invoice.aspx.cs" Inherits="Admin_View_Purchase_Invoice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center">
        <table style="width: 50%;" class="tbl_style">
            <tr>
                <td colspan="7" class="tbl_Header">
                    View Purchase Invoice
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
                    <asp:Button ID="cmdSearch" runat="server" Text="Search" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="gvPurcase_Invoice_View" runat="server" CellPadding="3" Width="100%"
            DataKeyNames="Purchase_Invoice_NO" GridLines="Horizontal" AutoGenerateColumns="False"
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
            <AlternatingRowStyle BackColor="#F7F7F7" />
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
                                        Height="20px" Width="20px" OnClick="imgbtnEdit_Click" />
                                </td>
                                
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Purchase_Invoice_NO" HeaderText="Purchase Invoice NO" />
                <asp:BoundField DataField="Purchase_Invoice_Date" HeaderText="Date" />
                <asp:BoundField DataField="GROSS_TOTAL" HeaderText="Grand Total" />
                <asp:BoundField DataField="Paid_Amount" HeaderText="Paid Amount" />
                <asp:BoundField DataField="Due_Amount" HeaderText="Due Amount" />
                <asp:BoundField DataField="User_Name" HeaderText="Last Modify By" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" HorizontalAlign="Left" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
             
        </asp:GridView>

        <asp:Label ID="lblresult" runat="server" />
        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup"
            PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        
        <asp:Panel ID="pnlpopup" runat="server" BackColor="White">
            <table width="100%" style="border: Solid 3px #3D73B1; width: 100%;" cellpadding="5px"
                cellspacing="0">
                <tr class="popUpheader">
                    <td colspan="6" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                        align="center">
                        Update Purchase Invoice
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
                    &nbsp;</td>
                <td align="left">
                    Brand
                </td>
                <td align="left">
                    :
                </td>
                <td align="left" style="margin-left: 40px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left">
                    Size
                </td>
                <td align="left">
                    :
                </td>
                <td style="margin-left: 200px" align="left">
                    &nbsp;</td>
                <td align="left">
                    Product Name
                </td>
                <td align="left">
                    :
                </td>
                <td align="left" style="margin-left: 40px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left">
                    Avalable Quantity
                </td>
                <td align="left">
                    :
                </td>
                <td style="margin-left: 240px" align="left">
                    &nbsp;</td>
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
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnUpdate" CommandName="Update" runat="server" Text="Update" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
