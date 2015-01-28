<%@ Page Language="C#" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="about" MasterPageFile="~/MasterPage.master"%>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="aboutMe" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    About Me
</asp:Content>

<asp:Content ID="aboutMe1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <hr class="small"/>
    <span class="subheading">
    This is what I am, What I do.</span>
</asp:Content>

<%--Main Content--%>
<asp:Content ID="aboutMe2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
<div class="container">
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2 col-md-10 col-md-offset-1">
                <p>Hi! Honestly speaking I don't like about me pages. But it doesn't mean I hate reading others. I enjoyed reading others. But I hate writing about myself because 
                    I always get confused from where to start or what to start.</p>

                <p>Okay! Let me start quickly! My name is Iqbal Kaur. I belong to Punjabi family. I live in Boston. 
                    I got married in 2014. Oh! Just married a few months ago. My husband is a Web Developer.</p>   
                               
                <p>Have a look at my Professional Life...</p>
                <p>I majored in M.C.A. (Masters of Computer Application) at Panjab University (Chandigarh, India). This is my highest qualification. 
                   My second highest qualification is B.C.A. (Bachelors of Computer Application). I was always good in studies. Always awarded 1st in college for achieving top academic 
                   distinction in university examinations.</p>

                <p>Software and Computer skills:</p>
                <ul>
                    <li>Languages known: ASP.NET using C#, C, C++, Java, JavaScript, CSS and HTML.</li>
                    <li>Designing and Development in web–based applications.</li>
                    <li>Tools: SQL Server, Microsoft Visual Studio, Git, SourceTree, SQL Server Management Studio.</li>
                    <li>I studied Computer System Architecture, Data structures, Linux, Unix,
                    Internet programming, java, Object Oriented Programming using C, Analysis and Designing of OOPS, RDBMS, System Software and Operating System during my Masters Degree.</li>
                </ul>

                <p>I love making websites. I'm passionate about it. Always eager to learn something new.</p>

                <p>What else should I write?</p>
                <p>I am a fun loving girl. The most strange thing about me is that I love to visit different places, explore new things but I hate traveling. In my free time, I do
                    cooking with new experiments, watch movies, play with children and surf the internet. Whenever I feel stuck in programming, my husband is always here to help me out.
                    The things I learnt from him, I have never learnt before in my life.</p>
                <p>That's all!</p>               
            </div>
        </div>
    </div>

    &nbsp;<hr/>
</asp:Content>