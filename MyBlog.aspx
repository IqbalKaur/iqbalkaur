<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyBlog.aspx.cs" Inherits="MyBlog" MasterPageFile="~/MasterPage.master"%>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="headertxt" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Welcome Admin
</asp:Content>
<asp:Content ID="headerxt2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Add a new blog post from here!
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2 col-md-10 col-md-offset-1">            
    <asp:Label id="postlbl" runat="server" Text="Post Title:"/><asp:TextBox ID="txtpostTitle" runat="server"/><br />
    <asp:Label id="sublbl" runat="server" Text="Post SubTitle:"/><asp:TextBox ID="txtpostSubTitle" runat="server" ></asp:TextBox><br />
    <asp:Label id="postedbylbl" runat="server" Text="Posted By:"/><asp:TextBox ID="txtpostedBy" runat="server"></asp:TextBox><br />
    <asp:Label id="datelbl" runat="server" Text="Date:"/><asp:TextBox ID="txtCalender" runat="server" TextMode="DateTime"></asp:TextBox><br />
    <asp:Label id="contentlbl" runat="server" Text="Content:"/><asp:TextBox ID="txtcontent" runat="server" TextMode="MultiLine"></asp:TextBox><br /><br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
            </div>
        </div>
     </div>
</asp:Content>
    