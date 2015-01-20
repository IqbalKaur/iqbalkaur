using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Master.con;
        cmd.CommandText="INSERT into Login(UserName, Password) VALUES(@username, @password)";
        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txtUserName.Text;
        cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = Master.auth.LoginHash(txtpassword.Text);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        successRegister.Text = "<div class='alert alert-success'>New User Has Been Created!</div>";
    }
}