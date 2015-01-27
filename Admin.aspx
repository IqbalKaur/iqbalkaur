<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" MasterPageFile="~/MasterPage.master" ValidateRequest="false"%>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="manage1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Manage Blog Posts
</asp:Content>

<asp:Content ID="manage2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <hr class="small"/>
    <span class="subheading">
    Here you can manage your blog posts
        </span>
</asp:Content>

<asp:Content ID="manage3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <form id="form1" runat="server">
        <asp:GridView ID="postGrid" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="false" DataKeyNames="id" CellSpacing="5" CellPadding="10">
            <RowStyle BackColor="white" ForeColor="Black"/>
            <HeaderStyle BackColor="#000000" ForeColor="White" Font-Bold="true" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="postTitle" HeaderText=" Post Title" />
                <asp:BoundField DataField="postSubTitle" HeaderText="Sub Title" />
                <asp:BoundField DataField="createdAt" HeaderText="Date" />
                <asp:CommandField ShowDeleteButton="true" />
                <asp:HyperLinkField DataNavigateUrlFields="id" HeaderText="Edit" ItemStyle-Width="80" DataNavigateUrlFormatString="EditPost.aspx?id={0}" Text="Select" ItemStyle-HorizontalAlign="Center"/>
            </Columns>            
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cn %>" SelectCommand="SELECT id, postTitle, postSubTitle, createdAt from Blog" DeleteCommand="delete from Blog where id=@id"></asp:SqlDataSource>
    </form>

</asp:Content>
