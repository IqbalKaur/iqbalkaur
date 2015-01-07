<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="~/MasterPage.master" %>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="header" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="header1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2 col-md-10 col-md-offset-1">
                <asp:Label ID="label1" runat="server" Text="You must be Login to create a new blog post" /><br /><br />
                <asp:Label ID="userlbl" runat="server" Text="UserName" />
                <asp:TextBox ID="usertxt" runat="server" ></asp:TextBox><br />
                <asp:Label ID="passwdlbl" runat="server" Text="Password"/>
                <asp:TextBox ID="passwordtxt" runat="server" TextMode="Password" ></asp:TextBox><br />
                <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click"/><br />
                <asp:Label ID="errorlbl" runat="server" ForeColor="Red" />
                </div>
            </div>
        </div>
</asp:Content>