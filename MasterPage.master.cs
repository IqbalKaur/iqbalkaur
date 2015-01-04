using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public string pageType = "site";           // Variable to differentiate formatting.
    public string bgImg = "home-bg.jpg";
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
}
