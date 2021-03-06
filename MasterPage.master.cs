﻿using System;
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
    public Helpers help;
    public string pageTitle;
    public string formatContent;                // For TinyMCE .js file.
    public string pageType = "site";           // Variable to differentiate formatting.
    public string bgImg = "home-bg.jpg";
    public bool isLoggedIn = false;
  
    public MasterPage()
    {
            con.Open();
            auth = new Auth(con);
            help = new Helpers();
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        isLoggedIn = auth.CheckLoginInfo(Request);
    }
     
}
