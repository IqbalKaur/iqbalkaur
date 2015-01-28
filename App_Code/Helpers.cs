using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Helpers
{
	public Helpers()
	{
		
	}
    /**
     * Converts UTC time to Eastern Time
     * Takes UTC time as parameter from Blog table.
     * And converts UTC time to EST Time by using ConvertTimeFromUtc method.
     */ 
    public void convertsUtctimeToESTtime(string createdAt)
    {
        DateTime timeUtc = Convert.ToDateTime(createdAt);
        TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        DateTime estTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, estZone);
        HttpContext.Current.Response.Write(estTime);
    }
}