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
                <p>You must be Login to create a new blog post</p><br /><br />

                <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">
                <label>UserName</label>
                <asp:TextBox ID="usertxt" runat="server" CssClass="form-control" placeholder="UserName"></asp:TextBox>
                            <br />
                </div>
                    </div>

                <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">
                <label>Password</label>
                <asp:TextBox ID="passwordtxt" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"/><br />
                </div>
                    </div>
                <asp:Button ID="btnlogin" runat="server" Text="Login" class="btn btn-default" OnClick="btnlogin_Click"/><br />
                <asp:Label ID="errorlbl" runat="server" ForeColor="Red" />
                </div>
            </div>
        </div>
</asp:Content>