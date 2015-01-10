<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangedPassword.aspx.cs" Inherits="ChangedPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
 <div align="center">
                <table style="width: 70%;" class="tbl_style">
                    <tr>
                        <td colspan="6" class="tbl_Header">
                            Change Your Password
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <strong>Enter Old Password
                        </strong>
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassword"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                           Enter New Password
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td style="margin-left: 200px" align="left">
                            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Button ID="cmdUpdate" runat="server" Text="Update"  ValidationGroup="V" 
                                onclick="cmdUpdate_Click" />
                             
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="6">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
</asp:Content>

