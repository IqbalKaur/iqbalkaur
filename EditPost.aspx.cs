using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class EditPost : System.Web.UI.Page
{
    public int nid;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.pageTitle = "New Blog Post";
        Master.bgImg = "blogpost-bg.jpg";
        //reference site http://www.tinymce.com/wiki.php
        Master.formatContent = @"
            <script type='text/javascript' src='/js/tinymce/tinymce.min.js'></script>
            <script type='text/javascript' src='/js/tinymce/jquery.tinymce.min.js'></script>
            <script src='/js/tinymceEditor.js'></script>";
        if (Request.QueryString["id"] != null)
        {
            nid = Convert.ToInt32(Request.QueryString["id"]);
        }

        /**
         * Executes the following block of code only when 
         * the page is not posted back. If IsPostBack is true 
         * or no PostBack methed declared here, then update command on btnUpdate_Click event won't work. No information will be updated.
         * Because the Page_Load method resets the changed values with the old values again.
         */ 
        if (IsPostBack == false)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Master.con;
            cmd.CommandText = @"SELECT * 
                                FROM Blog 
                                WHERE id = @nid";
            cmd.Parameters.AddWithValue("@nid", nid);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtpostTitle.Text = reader["postTitle"].ToString();
                txtpostSubTitle.Text = reader["postSubTitle"].ToString();
                txtUserId.Text = reader["userId"].ToString();
                txtcreatedAt.Text = reader["createdAt"].ToString();
                txtcontent.Text = reader["content"].ToString();
            }
        }      
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            nid = Convert.ToInt32(Request.QueryString["id"]);
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Master.con;
        cmd.CommandText = @"UPDATE Blog 
                            SET postTitle=@postTitle, postSubTitle=@postSubTitle, userId=@userId, createdAt=@createdAt, content=@content 
                            WHERE id=@nid";
        cmd.Parameters.Add("@nid", SqlDbType.Int).Value = nid;
        cmd.Parameters.Add("@postTitle", SqlDbType.NVarChar).Value = txtpostTitle.Text;
        cmd.Parameters.Add("@postSubTitle", SqlDbType.NVarChar).Value = txtpostSubTitle.Text;
        cmd.Parameters.Add("@userId", SqlDbType.Int).Value = txtUserId.Text;
        cmd.Parameters.Add("@createdAt", SqlDbType.DateTime).Value = txtcreatedAt.Text;
        cmd.Parameters.Add("@content", SqlDbType.NVarChar).Value = txtcontent.Text;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        Clear_Rec();
        successPost.Text = "<div class='alert alert-success'>You post has been updated!</div>";
    }

    private void Clear_Rec()
    {
        txtUserId.Text = "";
        txtpostTitle.Text = "";
        txtpostSubTitle.Text = "";
        txtcreatedAt.Text = "";
        txtcontent.Text = "";
    }

}