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
                <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">          
    <label>Post Title:</label>
                <asp:TextBox ID="txtpostTitle" runat="server" CssClass="form-control" placeholder="Post Title"/><br />
                            </div>
                    </div>
                <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">
    <label>Post SubTitle:</label>
                <asp:TextBox ID="txtpostSubTitle" runat="server" CssClass="form-control" placeholder="Post SubTitle"/><br />
                            </div>
                    </div>
                <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">
    <label>Posted By:</label>
                <asp:TextBox ID="txtpostedBy" runat="server" CssClass="form-control" placeholder="Posted By"/><br />
                            </div>
                    </div>
                <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">
    <label>Date:</label>
                <asp:TextBox ID="txtCalender" runat="server" TextMode="DateTime" CssClass="form-control" placeholder="Date"/><br />
                            </div>
                    </div>
                <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">
    <label>Content:</label>
                <asp:TextBox ID="txtcontent" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Content"/><br /><br />
                            </div>
                    </div>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" class="btn btn-default"/>
            </div>
        </div>
     </div>
</asp:Content>
    