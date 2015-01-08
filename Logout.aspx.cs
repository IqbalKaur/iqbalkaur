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
        if (Request.Cookies["I_USER"] != null)
        {
            Response.Cookies["I_USER"].Expires = DateTime.Now.AddHours(-1);
            Response.Cookies["I_ID"].Expires = DateTime.Now.AddHours(-1);
            Response.Redirect("Index.aspx");
        }
    }
}