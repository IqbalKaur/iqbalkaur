<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyBlog.aspx.cs" Inherits="MyBlog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Post Title: <asp:TextBox ID="txtpostTitle" runat="server"></asp:TextBox><br />
        Post SubTitle: <asp:TextBox ID="txtpostSubTitle" runat="server"></asp:TextBox><br />
        Posted By: <asp:TextBox ID="txtpostedBy" runat="server"></asp:TextBox><br />
        Date: <asp:TextBox ID="txtCalender" runat="server" TextMode="DateTime"></asp:TextBox><br />
        Content:<asp:TextBox ID="txtcontent" runat="server" TextMode="MultiLine"></asp:TextBox><br /><br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
    </div>
    </form>
</body>
</html>
