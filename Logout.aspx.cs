using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["ik_secret"] != null)
        {
            Response.Cookies["ik_secret"].Expires = DateTime.Now.AddHours(-1);
            Response.Cookies["ik_id"].Expires = DateTime.Now.AddHours(-1);
            Response.Redirect("Index.aspx");
        }
    }
}