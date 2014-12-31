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
    SqlConnection con = new SqlConnection();
    protected string postTitle = "";
    protected SqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        if (!Page.IsPostBack)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select * from BlogTB";
        this.reader = cmd.ExecuteReader();
       // reader.Read();
        
       // this.postTitle = reader["postTitle"].ToString();
       //// Response.Write(postTitle);
       // var postSubTitle = reader["postSubTitle"];
       // var postedBy = reader["postedBy"];
       // var date = reader["date"];
       this.DataBind();
    }
}