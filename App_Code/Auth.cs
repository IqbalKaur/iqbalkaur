using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public class Auth
{
    public string username;
    public string userId;
    SqlConnection con;
    public Auth(SqlConnection con)
    {
        this.con = con;
    }

    // Method to hash password.
    public string LoginHash(string str)
    {
        SHA1CryptoServiceProvider crypto = new SHA1CryptoServiceProvider();
        byte[] bytePassword = Encoding.Unicode.GetBytes(str);
        byte[] hashPassword = crypto.ComputeHash(bytePassword);
        string strHashPassword = "";
        foreach (byte thisByte in hashPassword)
        {
            strHashPassword += Convert.ToString(thisByte);
        }
        return strHashPassword;
    }

    // If cookies are not null then expires cookies.
    public void Logout(HttpRequest Request, HttpResponse Response)
    {
        if (Request.Cookies["ik_secret"] != null)
        {
            Response.Cookies["ik_secret"].Expires = DateTime.Now.AddHours(-1);
            Response.Cookies["ik_id"].Expires = DateTime.Now.AddHours(-1);
            Response.Redirect("Index.aspx");
        }
    }

    
    /**
     * Creates login, if user exists in Login table then creates cookie for that user.
     * Returns true if Login successful.
     * Else false.
     */
    public bool Login(string usertxt, string passwordtxt, HttpResponse Response)
    {
        passwordtxt = this.LoginHash(passwordtxt);

        // Query
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = this.con;
        cmd.CommandText = "SELECT * FROM Login WHERE UserName=@username and Password=@password";
        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = usertxt;
        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = passwordtxt;

        // Set cookie if has rows
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            Response.Cookies["ik_secret"].Value = this.LoginHash(usertxt + passwordtxt);
            Response.Cookies["ik_secret"].Expires = DateTime.Now.AddHours(1);
            while (reader.Read())
            {
                Response.Cookies["ik_id"].Value = reader["id"].ToString();
                Response.Cookies["ik_id"].Expires = DateTime.Now.AddHours(1);
            }
            cmd.Dispose();
            return true;
        } 
        else
        {
            cmd.Dispose();
            return false;
        }
    }

    //
    public bool CheckLoginInfo(HttpRequest Request)
    {
        if (Request.Cookies["ik_secret"] != null)
        {
            string secretCookie = Request.Cookies["ik_secret"].Value;
            string id = Request.Cookies["ik_id"].Value;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.con;
            cmd.CommandText = "Select * from Login where id = @id"; 
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (secretCookie == this.LoginHash(reader["UserName"].ToString() + reader["Password"].ToString()))
                {
                    this.username = reader["UserName"].ToString();
                    this.userId = reader["id"].ToString();
                    reader.Close();
                    return true;
                }
            }
        }
        return false;
    }
}

