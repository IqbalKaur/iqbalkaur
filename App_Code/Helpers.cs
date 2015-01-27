using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Helpers
{
	public Helpers()
	{
		
	}

    public void convertsUtctimeToESTtime(string createdAt)
    {
        DateTime timeUtc = Convert.ToDateTime(createdAt);
        TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        DateTime estTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, estZone);
        HttpContext.Current.Response.Write(estTime);
    }
}