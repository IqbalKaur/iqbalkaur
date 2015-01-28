<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="Post" MasterPageFile="~/MasterPage.master" %>
<%@ MasterType TypeName="MasterPage" %>
<asp:content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   <%# dict["postTitle"] %>    
</asp:content>
<asp:Content ID="content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <h2 class="subheading"> 
        <%# dict["postSubTitle"] %>
    </h2>
    <span class="meta">
        Posted by <a href="#"><%# dict["username"] %></a> on <% Master.help.convertsUtctimeToESTtime(dict["createdAt"]); %>
    </span>  
</asp:Content>

<%--Main Content--%>
<asp:Content ID="content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <article>
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-lg-offset-2 col-md-10 col-md-offset-1">
                   <div class="content"><%# dict["content"] %></div> 
                    <hr />
                    <h2>Comments</h2>
                    <% while (reader.Read()) { %>
                        <div class="comment">
                            <h3 class="comment-content">
                                <%= reader["comment"].ToString() %>
                            </h3>
                            <p class="comment-meta">By <%= reader["name"].ToString() %></p>
                        </div>
                        <hr/>
                    <% } %>
                    <p>Please leave your comment here!</p>
                    <form name="postComment" runat="server" novalidate="novalidate">
                        <div class="row control-group">
                            <div class="form-group col-xs-12 floating-label-form-group controls">          
                                <label>Name:</label>
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Name"/><br />
                            </div>
                        </div>
                        <div class="row control-group">
                            <div class="form-group col-xs-12 floating-label-form-group controls">          
                                <label>Email:</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email"/><br />
                            </div>
                        </div>
                        <div class="row control-group">
                            <div class="form-group col-xs-12 floating-label-form-group controls">          
                                <label>Comment:</label>
                                <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Your Comments"/><br /><br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-xs-12">
                                <asp:Button ID="btnComment" runat="server" Text="Post Comment" class="btn btn-default" OnClick="btnComment_Click"/>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </article>

    <hr/>
</asp:Content>
