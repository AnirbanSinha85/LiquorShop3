<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SearchProduct.aspx.cs" Inherits="SearchProduct" %>
     <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <script type="text/javascript">
        $(function () {
            $('.search_textbox').each(function (i) {
                $(this).quicksearch("[id*=gvProduct] tr:not(:has(th))", {
                    'testQuery': function (query, txt, row) {
                        return $(row).children(":eq(" + i + ")").text().toLowerCase().indexOf(query[0].toLowerCase()) != -1;
                    }
                });
            });
        });
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
    <asp:GridView ID="gvProduct" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false"
        Width="100%" DataKeyNames="Product_ID" GridLines="None" AutoGenerateColumns="False"
         OnDataBound="OnDataBound"
        >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Product_ID" HeaderText="P#" />
            <asp:BoundField DataField="Category_Name" HeaderText="Category Name" />
            <asp:BoundField DataField="Brand_Name" HeaderText="Brand Name" />
            <asp:BoundField DataField="Bar_Code" HeaderText="Bar Code" />
            <asp:BoundField DataField="Size_Name" HeaderText="Size Name" />
            <asp:BoundField DataField="Product_Name" HeaderText="Product Name" />
            <asp:BoundField DataField="Standerd_Rebet" HeaderText="Standerd Rebet" />
            <asp:BoundField DataField="Avalable_Quantity" HeaderText="Avalable Quantity" />
            <asp:BoundField DataField="MRP" HeaderText="MRP" />
            <asp:BoundField DataField="Sort_Code" HeaderText="Sort Code" />
            <asp:TemplateField ItemStyle-Width="90px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="~/images/Edit.jpg" ToolTip="Edit"
                            CausesValidation="false" Height="20px" Width="20px" />
                        <asp:ImageButton ID="imgbtnDelete" Text="Edit" runat="server" ImageUrl="~/images/delete.jpg"
                            ToolTip="Delete" Height="20px" Width="20px" />
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
</asp:Content>
