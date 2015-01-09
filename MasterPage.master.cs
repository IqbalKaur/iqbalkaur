using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    public string pageType = "site";           // Variable to differentiate formatting.
    public string bgImg = "home-bg.jpg";
    protected string loginPage = "Login.aspx";
    protected string loginStatus = "Login";
    protected string username = "Iqbal Kaur";
    protected void Page_Load(object sender, EventArgs e)
    {     
        if (Request.Cookies["ik_secret"] != null)
        {
            string secretCookie = Request.Cookies["ik_secret"].Value;
            string id = Request.Cookies["ik_id"].Value;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Login where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Auth auth = new Auth();
                if (secretCookie == auth.LoginHash(reader["UserName"].ToString() + reader["Password"].ToString()))
                {
                    loginPage = "Logout.aspx";
                    loginStatus = "Logout";
                    username = reader["UserName"].ToString();
                }
            }
            cmd.Dispose();
        }
    }
}
