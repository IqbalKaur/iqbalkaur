﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Index" MasterPageFile="~/MasterPage.master" %>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="index" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Blog
</asp:Content>
<asp:Content ID="index1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <hr class="small"/>
    <span class="subheading">
        Sharing what I know.
    </span>
</asp:Content>

<%--Main Content--%>
<asp:Content ID="index2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2 col-md-10 col-md-offset-1"> 
                <form name="indexForm" novalidate="novalidate" runat="server">
                    <% while (reader.Read()) { %>
                        <div class="post-preview">
                            <a href="post.aspx?id=<%= reader["id"].ToString() %>">
                                <h2 class="post-title">
                                    <%= reader["postTitle"].ToString() %>
                                </h2>
                                <h3 class="post-subtitle">
                                    <%= reader["postSubTitle"].ToString()%>                            
                                </h3>
                            </a>
                            <p class="post-meta">Posted by <a href="#"><%= reader["username"].ToString() %></a> on <% Master.help.convertsUtctimeToESTtime(reader["createdAt"].ToString()); %><a href="post.aspx?id=<%= reader["id"].ToString() %>">. <%= getCommentsCount(reader["id"].ToString()) %> Comments</a></p>                 
                        </div>
                        <hr/>
                    <% } %>
                </form>
                <!-- Pager -->
                <% if(needsOlderPostLink == true) { %>
                    <ul class="pager">
                        <li class="next">                       
                            <a href="Index.aspx?PageNumber=<%= PageNumber+1 %>">Older Posts &rarr;</a>
                        </li>
                    </ul>
                <% } %>
                <% if(needsPreviousLink == true) { %>
                    <ul class="pager">
                        <li class="previous">                       
                            <a href="Index.aspx?PageNumber=<%= PageNumber-1 %>">Previous Posts &rarr;</a>
                        </li>
                    </ul>
                <% } %>  
            </div>
        </div>
    </div>

    <hr/>
</asp:Content>
