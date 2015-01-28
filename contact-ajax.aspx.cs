using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class js_contact_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Master.con;
        cmd.CommandText = @"INSERT INTO ContactMe (name, email, phone, message)
                            VALUES (@name, @email, @phone, @message)";
        cmd.Parameters.AddWithValue("@name", Request.Form["name"]);
        cmd.Parameters.AddWithValue("@email", Request.Form["email"]);
        cmd.Parameters.AddWithValue("@phone", Request.Form["phone"]);
        cmd.Parameters.AddWithValue("@message", Request.Form["message"]);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        //Master.con.Close();

    }
}