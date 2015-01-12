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
    protected SqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        Master.bgImg = "home-bg.jpg";
        if (!Page.IsPostBack)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"SELECT * 
                            FROM BlogTB 
                            INNER JOIN Login 
                                ON BlogTB.userid=Login.id";
        this.reader = cmd.ExecuteReader();
        this.DataBind();
    }
}