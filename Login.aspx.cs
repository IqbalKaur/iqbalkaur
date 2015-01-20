using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.bgImg = "login-bg.jpg";
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        bool loginStatus = Master.auth.Login(usertxt.Text, passwordtxt.Text, Response);
        if (loginStatus == true)
        {
            Response.Redirect("Index.aspx");
        }
        else
        {
            errorlbl.Text = "Login Unsuccessful!";
        }
    }
}