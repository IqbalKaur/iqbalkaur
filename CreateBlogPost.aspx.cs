using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CreateBlogPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.pageTitle = "New Blog Post";
        Master.bgImg = "blogpost-bg.jpg";
        //reference site http://www.tinymce.com/wiki.php
        Master.formatContent = @"
        <script type='text/javascript' src='/js/tinymce/tinymce.min.js'></script>
        <script type='text/javascript' src='/js/tinymce/jquery.tinymce.min.js'></script>
        <script src='/js/tinymceEditor.js'></script>";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {     
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Master.con;
        cmd.CommandText = "INSERT into Blog(postTitle, postSubTitle, userId, createdAt, content) VALUES(@postTitle, @postSubTitle, @userId, @createdAt, @content)";
        cmd.Parameters.Add("@postTitle", SqlDbType.NVarChar).Value = txtpostTitle.Text;
        cmd.Parameters.Add("@postSubTitle", SqlDbType.NVarChar).Value = txtpostSubTitle.Text;
        cmd.Parameters.Add("@userId", SqlDbType.Int).Value = Master.auth.userId;
        cmd.Parameters.Add("@createdAt", SqlDbType.VarChar).Value = DateTime.Now.ToString();
        cmd.Parameters.Add("@content", SqlDbType.NVarChar).Value = txtcontent.Text;
        cmd.ExecuteNonQuery(); 
        cmd.Dispose();
        Clear_Rec();
        successPost.Text = "<div class='alert alert-success'>You post has been submitted!</div>"; 
    }

    private void Clear_Rec()
    {
        txtpostTitle.Text = "";
        txtpostSubTitle.Text = "";
        txtcontent.Text = "";
    }
}
