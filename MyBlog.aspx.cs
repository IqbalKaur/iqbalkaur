using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class MyBlog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.bgImg = "myblog-bg.jpg";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Master.con;
        cmd.CommandText = "INSERT into BlogTB(postTitle, postSubTitle, userId, createdAt, content) VALUES(@postTitle, @postSubTitle, @userId, @createdAt, @content)";
        cmd.Parameters.Add("@postTitle", SqlDbType.NVarChar).Value = txtpostTitle.Text;
        cmd.Parameters.Add("@postSubTitle", SqlDbType.NVarChar).Value = txtpostSubTitle.Text;
        cmd.Parameters.Add("@userId", SqlDbType.VarChar).Value = Master.auth.userId;
        cmd.Parameters.Add("@createdAt", SqlDbType.VarChar).Value = DateTime.Now.ToString();
        cmd.Parameters.Add("@content", SqlDbType.NVarChar).Value = txtcontent.Text;
        cmd.ExecuteNonQuery(); 
        cmd.Dispose();
        Clear_Rec();
    }

    private void Clear_Rec()
    {
        txtpostTitle.Text = "";
        txtpostSubTitle.Text = "";
        txtcontent.Text = "";
    }
}