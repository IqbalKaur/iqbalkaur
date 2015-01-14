using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Post : System.Web.UI.Page
{
    
    protected Dictionary<string, string> dict = new Dictionary<string, string>();
    public SqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Master.pageTitle = "- Post";
        
        Master.pageType = "post";
        Master.bgImg = "post-bg.jpg";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Master.con;
        int nid = int.Parse(Request.QueryString["id"].ToString());
        cmd.CommandText = @"SELECT * FROM
                                Blog INNER JOIN Login
                                ON Blog.userid=Login.id WHERE Blog.id = @nid";
        cmd.Parameters.AddWithValue("@nid", nid);
        reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            dict.Add("postTitle", reader["postTitle"].ToString());
            dict.Add("postSubTitle", reader["postSubTitle"].ToString());
            dict.Add("username", reader["username"].ToString());
            dict.Add("createdAt", reader["createdAt"].ToString());
            dict.Add("content", reader["content"].ToString());
            Master.pageTitle = reader["postTitle"].ToString();
        }
        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = Master.con;
        cmd1.CommandText = "select * from Comments where postId = @nid";
        cmd1.Parameters.AddWithValue("@nid", nid);
        this.reader = cmd1.ExecuteReader();
        
        //reader.Close();
        this.DataBind();
    }
    protected void btnComment_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Master.con;
        cmd.CommandText = "INSERT INTO Comments(name, email, comment, postId) VALUES(@name, @email, @comment, @postid)";
        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = txtName.Text;
        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = txtEmail.Text;
        cmd.Parameters.Add("@comment", SqlDbType.NVarChar).Value = txtComment.Text;
        cmd.Parameters.Add("@postid", SqlDbType.Int).Value = Request.QueryString["id"];
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
} 