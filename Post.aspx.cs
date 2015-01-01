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
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    protected SqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.pageType = "post";   
        if (!Page.IsPostBack)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        int nid = int.Parse(Request.QueryString["id"].ToString());
        cmd.CommandText = "SELECT * FROM BlogTB WHERE id = @nid";
        cmd.Parameters.AddWithValue("@nid", nid);
        this.reader = cmd.ExecuteReader();
        reader.Read();
        this.DataBind();
    }
} 