<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" MasterPageFile="~/MasterPage.master"%>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="register1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    New User!
</asp:Content>
<asp:Content ID="register2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <hr class="small"/>
    <span class="subheading"></span>
</asp:Content>
<asp:Content ID="resgister3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2 col-md-10 col-md-offset-1">  
                <form name="register" novalidate="novalidate" runat="server">
                    <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">          
                            <label>User Name:</label>
                            <asp:RequiredFieldValidator ID="validateUserName" ControlToValidate="txtUserName" Text="You must enter user name." runat="server"/>
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="User Name" CausesValidation="true"/><br />
                        </div>
                    </div>
                    <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">
                            <label>Password:</label>
                            <asp:RequiredFieldValidator ID="validatePassword" ControlToValidate="txtpassword" Text="You must enter password." runat="server"/>
                            <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" placeholder="Password" CausesValidation="true" TextMode="Password"/><br />
                        </div>
                    </div>
                    <div class="row control-group">
                        <div class="form-group col-xs-12 floating-label-form-group controls">
                            <label>Confirm Password:</label>
                            <asp:RequiredFieldValidator ID="validateConfirmPassword" ControlToValidate="txtPassword1" Text="You must confirm your password." runat="server"/>
                            <asp:CompareValidator ID="validatePassword1" runat="server" ErrorMessage="Password Mismatch!" ControlToCompare="txtpassword" ControlToValidate="txtPassword1"></asp:CompareValidator>
                            <asp:TextBox ID="txtPassword1" runat="server" CssClass="form-control" placeholder="New Password" CausesValidation="true" TextMode="Password"/><br /><br />
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-12">
                            <asp:Button ID="btnRegister" runat="server" Text="Register" class="btn btn-default" OnClick="btnRegister_Click"/>
                        </div>
                    </div>
                    <asp:Literal ID="successRegister" runat="server" />
                </form>
            </div>
        </div>
    </div>
</asp:Content>
