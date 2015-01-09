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
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.bgImg = "myblog-bg.jpg";
        txtDate.Text = DateTime.Now.ToShortDateString();
        if (Page.IsPostBack)
        {
            con.Open();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT into BlogTB(postTitle, postSubTitle, postedBy, date, content) VALUES(@postTitle, @postSubTitle, @postedBy, @date, @content)";
        cmd.Parameters.Add("@postTitle", SqlDbType.NVarChar).Value = txtpostTitle.Text;
        cmd.Parameters.Add("@postSubTitle", SqlDbType.NVarChar).Value = txtpostSubTitle.Text;
        cmd.Parameters.Add("@postedBy", SqlDbType.VarChar).Value = txtpostedBy.Text;
        cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = txtDate.Text; 
        cmd.Parameters.Add("@content", SqlDbType.NVarChar).Value = txtcontent.Text;
        cmd.ExecuteNonQuery(); 
        cmd.Dispose();
        Clear_Rec();
    }

    private void Clear_Rec()
    {
        txtpostTitle.Text = "";
        txtpostSubTitle.Text = "";
        txtpostedBy.Text = "";
        txtDate.Text = "";
        txtcontent.Text = "";
    }
}