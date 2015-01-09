
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
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.bgImg = "login-bg.jpg";
        if (Page.IsPostBack)
        {
            con.Open();
        }
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM Login WHERE UserName=@username and Password=@password";
        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = usertxt.Text;
        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = passwordtxt.Text;
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            Auth auth = new Auth();
            Response.Cookies["ik_secret"].Value = auth.LoginHash(usertxt.Text + passwordtxt.Text);
            Response.Cookies["ik_secret"].Expires = DateTime.Now.AddHours(1);
            while (reader.Read())
            {
                Response.Cookies["ik_id"].Value = reader["id"].ToString();
                Response.Cookies["ik_id"].Expires = DateTime.Now.AddHours(1);
            }
            Response.Redirect("MyBlog.aspx");
        }
        else
        {
            errorlbl.Text = "Login Unsuccessfull!";
        }
        cmd.Dispose();
    }
}