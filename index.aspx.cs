using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Index : System.Web.UI.Page
{
    protected SqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.bgImg = "home-bg.jpg";
        SqlCommand cmd = new SqlCommand("blogIndex", Master.con);
        cmd.CommandType = CommandType.StoredProcedure;
        this.reader = cmd.ExecuteReader();
    }

    // counting number of comments of postid
    // return total number of comments
    protected string getCommentsCount(string id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Master.con;
        int nid = int.Parse(id);
        cmd.CommandText = @"
            SELECT count(postid) AS commentsCount 
            FROM Comments 
            WHERE postid = @nid";
        cmd.Parameters.AddWithValue("@nid", nid);
        string result = Convert.ToString(cmd.ExecuteScalar());

        return result;
    }
}