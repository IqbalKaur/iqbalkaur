<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateBlogPost.aspx.cs" Inherits="CreateBlogPost" MasterPageFile="~/MasterPage.master" ValidateRequest="false"%>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="headertxt" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Welcome Admin
</asp:Content>
<asp:Content ID="headerxt2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <hr class="small"/>
    <span class="subheading">
    Add a new blog post from here!
        </span>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2 col-md-10 col-md-offset-1">  
                <form name="submitPost" novalidate="novalidate" runat="server">
                    <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">          
                            <label>Post Title:</label>
                            <asp:RequiredFieldValidator ID="validatePost" ControlToValidate="txtpostTitle" Text="You must enter post Title." runat="server"/>
                            <asp:TextBox ID="txtpostTitle" runat="server" CssClass="form-control" placeholder="Post Title" CausesValidation="true"/><br />
                        </div>
                    </div>
                    <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">
                            <label>Post SubTitle:</label>
                            <asp:RequiredFieldValidator ID="validateSubTitle" ControlToValidate="txtpostSubTitle" Text="You must enter a sub post Title." runat="server"/>
                            <asp:TextBox ID="txtpostSubTitle" runat="server" CssClass="form-control" placeholder="Post SubTitle" CausesValidation="true"/><br />
                        </div>
                    </div>
                    <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">
                            <label>Content:</label>
                            <asp:RequiredFieldValidator ID="validateContent" ControlToValidate="txtContent" Text="You cannot submit a post without content." runat="server"/>
                            <asp:TextBox ID="txtcontent" runat="server" TextMode="MultiLine" CssClass="mcetiny" placeholder="Content" CausesValidation="true"/><br /><br />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-12">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" class="btn btn-default"/>
                        </div>
                    </div>
                    <asp:Literal ID="successPost" runat="server" />
                </form>
            </div>
        </div>
     </div> 
</asp:Content>
 