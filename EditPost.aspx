<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditPost.aspx.cs" Inherits="EditPost" MasterPageFile="~/MasterPage.master" validateRequest="false"%>
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
                            <label>Id:</label>
                            <asp:RequiredFieldValidator ID="validateID" ControlToValidate="txtUserId" Text="You must enter a User ID." runat="server"/>
                            <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control" placeholder="User ID" CausesValidation="true"/><br />
                        </div>
                    </div>
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
                            <label>Created At:</label>
                            <asp:RequiredFieldValidator ID="validateCreatedAt" ControlToValidate="txtcreatedAt" Text="You must enter a created At." runat="server"/>
                            <asp:TextBox ID="txtcreatedAt" runat="server" CssClass="form-control" placeholder="Created At" CausesValidation="true"/><br />
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
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" class="btn btn-default" OnClientClick="tinyMCE.triggerSave(true,false)"/>
                        </div>
                    </div>
                    <asp:Literal ID="successPost" runat="server" />
                </form>
            </div>
        </div>
     </div> 
</asp:Content>
 

