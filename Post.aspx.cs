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
    protected void Page_Load(object sender, EventArgs e)
    {  
        Master.pageType = "post";
        Master.bgImg = "post-bg.jpg";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Master.con;
        int nid = int.Parse(Request.QueryString["id"].ToString());
        cmd.CommandText = @"SELECT * FROM
                                BlogTB INNER JOIN Login
                                ON BlogTB.userid=Login.id WHERE BlogTB.id = @nid;";
        cmd.Parameters.AddWithValue("@nid", nid);
        SqlDataReader reader;
        reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            dict.Add("postTitle", reader["postTitle"].ToString());
            dict.Add("postSubTitle", reader["postSubTitle"].ToString());
            dict.Add("username", reader["username"].ToString());
            dict.Add("createdAt", reader["createdAt"].ToString());
            dict.Add("content", reader["content"].ToString());
        }
        reader.Close();
        this.DataBind();
    }
} 