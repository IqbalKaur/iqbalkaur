using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

public class Auth
{
    public Auth()
    {

    }

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
}
