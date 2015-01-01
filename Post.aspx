<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="Post" MasterPageFile="~/MasterPage.master" %>
<%@ MasterType TypeName="MasterPage" %>
<asp:content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   <%= reader["postTitle"].ToString() %>    
</asp:content>
<asp:Content ID="content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <h2 class="subheading"> 
    <%= reader["postSubTitle"].ToString() %></h2>
    <span class="meta">Posted by <a href="#"><%= reader["postedBy"].ToString() %></a> on <%= reader["date"].ToString() %></span>  
</asp:Content>

<%--Main Content--%>
<asp:Content ID="content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <article>
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-lg-offset-2 col-md-10 col-md-offset-1">
                    <%= reader["content"].ToString() %>
                </div>
            </div>
        </div>
    </article>

    <hr/>
</asp:Content>
