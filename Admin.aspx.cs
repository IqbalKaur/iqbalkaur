using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin : System.Web.UI.Page
{
    public int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.bgImg = "admin-bg.jpg";
        if (Request.QueryString["id"] != null)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
        }       
    }
}