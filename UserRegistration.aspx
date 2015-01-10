<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="UserRegistration.aspx.cs" Inherits="Admin_UserRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center">
        <table style="width: 80%;" class="tbl_style">
            <tr>
                <td colspan="6" class="tbl_Header">
                    Create New User Account
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
            </tr>
            <tr>
                <td align="left" class="tbl_Sub_Header">
                    Account Information
                </td>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left" class="tbl_Sub_Header">
                    Personal Information
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
                    User Name
                </td>
                <td align="left">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                        ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                </td>
                <td align="left">
                    First Name
                </td>
                <td align="left">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFName"
                        ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Password
                </td>
                <td align="left">
                    :
                </td>
                <td style="margin-left: 200px" align="left">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                        ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                </td>
                <td align="left">
                    Last Name
                </td>
                <td align="left">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Re-Type Password
                </td>
                <td align="left">
                    :
                </td>
                <td style="margin-left: 240px" align="left">
                    <asp:TextBox ID="txtRTPassword" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                        ControlToValidate="txtRTPassword" ErrorMessage="Password Not Match"></asp:CompareValidator>
                </td>
                <td align="left">
                    Gender
                </td>
                <td align="left">
                    :
                </td>
                <td align="left">
                    <asp:RadioButton ID="rbMale" runat="server" GroupName="g" Text="Male" />
                    <asp:RadioButton ID="rbFemale" runat="server" GroupName="g" Text="Female" />
                </td>
            </tr>
            <tr>
                <td align="left">
                    Active
                </td>
                <td align="left">
                    :
                </td>
                <td style="margin-left: 280px" align="left">
                    <asp:CheckBox ID="chkActive" runat="server" />
                </td>
                <td align="left">
                    DOB
                </td>
                <td align="left">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDOB">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
                <td style="margin-left: 280px" align="left">
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
                <td align="left" class="tbl_Sub_Header">
                    Contact Information
                </td>
                <td align="left">
                    &nbsp;
                </td>
                <td style="margin-left: 280px" align="left">
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
                    Address
                </td>
                <td align="left">
                    :
                </td>
                <td style="margin-left: 280px" align="left" rowspan="2" valign="top">
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td align="left">
                    Phone no
                </td>
                <td align="left">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPhNo" runat="server"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="txtPhNo_FilteredTextBoxExtender" FilterType="Numbers"
                        runat="server" TargetControlID="txtPhNo">
                    </asp:FilteredTextBoxExtender>
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
                    Email ID
                </td>
                <td align="left">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="margin-left: 280px">
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
                    Access Level
                </td>
                <td>
                    :
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlAcessLevel" runat="server" ValidationGroup="V">
                        <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                        <asp:ListItem Text="User" Value="2" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlAcessLevel"
                        ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
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
                <td align="center" colspan="6">
                    <asp:Button ID="cmdSave" runat="server" Text="Create" OnClick="cmdSave_Click" ValidationGroup="V" />
                    <asp:Button ID="cmdReset" runat="server" Text="Reset" OnClick="cmdReset_Click" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:GridView ID="gvUser" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false" Visible="false"
            Width="100%" DataKeyNames="User_ID" GridLines="None" AutoGenerateColumns="False"
            AllowPaging="True" OnPageIndexChanging="gvUser_PageIndexChanging" 
            onrowdeleting="gvUser_RowDeleting">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                            ImageUrl="~/images/delete.jpg" ToolTip="Delete"
                            Height="20px" Width="20px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User Name">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("User_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="First Name">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("First_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Last_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ph-No">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Ph_No") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="E-Mail">
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
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
</asp:Content>
