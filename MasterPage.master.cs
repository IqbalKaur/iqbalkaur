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

    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    public Auth auth;
    public string pageType = "site";           // Variable to differentiate formatting.
    public string bgImg = "home-bg.jpg";
    protected string loginPage = "Login.aspx";
    protected string loginStatus = "Login";

    
    public MasterPage()
    {
        con.Open();
        auth = new Auth(con);
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        bool loginInfo = auth.CheckLoginInfo(Request);
        if (loginInfo == true)
        {
            loginPage = "Logout.aspx";
            loginStatus = "Logout";
        }
    }
}
